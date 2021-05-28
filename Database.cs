using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace Works
{
    public static class Database
    {
        private static SqlConnection sqlConnection =
            new SqlConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False; Data Source=|DataDirectory|\dbo.mdb; ");

        public static DataTable SendQuery(string query)
        {
            DataTable resultat = new DataTable();
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);

                SqlDataAdapter chitat1 = new SqlDataAdapter(command);

                chitat1.Fill(resultat);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить действие: {ex.Message}");
            }
            sqlConnection.Close();

            return resultat;
        }

        public static List<Service> GetServices()
        {
            List<Service> list = new List<Service>();
            DataTable table = SendQuery($"Select * from dbo.Service");
            foreach (DataRow row in table.Rows)
            {
                list.Append(new Service
                {
                    Id = (int)row.ItemArray[0],
                    Title = row.ItemArray[1].ToString(),
                    Cost = (int)row.ItemArray[2],
                    Time = (int)row.ItemArray[3],
                    Sale = (float)row.ItemArray[5],
                    Image = Image.FromFile(row.ItemArray[6].ToString()),
                });
            }
            return list;
        }

        //public static void AddObject(object element, DataType type)
        //    => SendQuery($"Insert into dbo.{DataTypes[type]} values {element}");

        //public static void DeleteObject(int id, DataType type)
        //    => SendQuery($"Delete from dbo.{DataTypes[type]} where id = {id}");
    }
}
