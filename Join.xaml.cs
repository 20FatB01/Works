using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Works
{
    /// <summary>
    /// Логика взаимодействия для Join.xaml
    /// </summary>
    public partial class Join : Window
    {
        private Service service;
        public Join(Service _service)
        {
            service = _service;
            InitializeComponent();
            name.Text = service.Title;
            time.Text = (service.Time / 60).ToString() + " мин.";
            List<User> users = Database.GetUsers();
            user_list.ItemsSource = users;
            user_list.SelectedItem = user_list.Items[0];
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (char ch in timeLesson.Text)
                {
                    if ((ch < '0' || ch > '9') && ch != ':')
                    {
                        throw new Exception("Время начала оказания услуги может содержать только цифры и двоеточие");
                    }
                }

                if (!DateTime.TryParse(timeLesson.Text, out DateTime time))
                {
                    throw new Exception("Недействительное время начала оказания услуги");
                }

                if (!DateTime.TryParse(date.Text, out DateTime correctDate))
                {
                    throw new Exception("Недействительная дата начала оказания услуги");
                }

                DateTime final = correctDate.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(time.Second);

                Database.AddJoining((User)user_list.SelectedItem, service, final, "");

                MessageBox.Show($"Запись успешно добавлена. Время окончания: {time.AddSeconds(service.Time)}");

                new MainWindow().Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
