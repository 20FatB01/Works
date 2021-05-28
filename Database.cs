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
            new SqlConnection(@"Data Source=ngknn.ru;Initial Catalog=Cirkel;User ID=32В;Password=444444");

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
            DataTable table = SendQuery($"Select * from Service");
            foreach (DataRow row in table.Rows)
            {
                int id = (int)row.ItemArray[0];
                string title = row.ItemArray[1].ToString();
                float cost = float.Parse(row.ItemArray[2].ToString());
                int time = (int)row.ItemArray[3];
                float sale = float.Parse(row.ItemArray[5].ToString());
                string path = row.ItemArray[6].ToString().Trim();
                Service service = new Service
                {
                    Id = id,
                    Title = title,
                    Cost = cost,
                    Time = time,
                    Sale = sale,
                    ImagePath = path
                };
                list.Add(service);
            }
            return list;
        }

        //public static void AddObject(object element, DataType type)
        //    => SendQuery($"Insert into dbo.{DataTypes[type]} values {element}");

        //public static void DeleteObject(int id, DataType type)
        //    => SendQuery($"Delete from dbo.{DataTypes[type]} where id = {id}");
    }
}
