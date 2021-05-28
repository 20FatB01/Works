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
                Service service = new Service
                {
                    Id = (int)row.ItemArray[0],
                    Title = row.ItemArray[1].ToString(),
                    Cost = float.Parse(row.ItemArray[2].ToString()),
                    Time = (int)row.ItemArray[3],
                    Sale = float.Parse(row.ItemArray[5].ToString()),
                    Description = row.ItemArray[4].ToString(),
                    ImagePath = row.ItemArray[6].ToString().Trim()
                };
                list.Add(service);
            }
            return list;
        }

        public static List<User> GetUsers()
        {
            List<User> list = new List<User>();
            DataTable table = SendQuery($"Select * from Client");
            foreach (DataRow row in table.Rows)
            {
                User user = new User
                {
                    Id = (int)row.ItemArray[0],
                    FirstName = row.ItemArray[1].ToString(),
                    LastName = row.ItemArray[2].ToString(),
                    Patronymic = row.ItemArray[3].ToString(),
                    Birthday = DateTime.Parse(row.ItemArray[4].ToString()),
                    RegistrationDate = DateTime.Parse(row.ItemArray[5].ToString()),
                    Email = row.ItemArray[6].ToString(),
                    Phone = row.ItemArray[7].ToString(),
                    GenderCode = row.ItemArray[8].ToString(),
                    PhotoPath = row.ItemArray[9].ToString(),
                };
                list.Add(user);
            }
            return list;
        }

        public static void AddService(Service element)
            => SendQuery($"Insert into Service values {element}");

        public static void AddJoining(User client, Service service, DateTime start, string comment)
            => SendQuery($"Insert into ClientService values ({client.Id}, {service.Id}, '{start.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{comment}')");

        public static void UpdateService(Service element)
            => SendQuery($"Update Service set Title = '{element.Title}', Description = '{element.Description}', DurationInSeconds = {element.Time}, Discount = {$"{element.Sale}".Replace(',','.')}, MainImagePath = '{element.ImagePath}' where id = {element.Id}");
    }
}
