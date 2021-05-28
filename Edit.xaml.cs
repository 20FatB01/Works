using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private Service service;
        private int serviceId = -1;
        public Edit(Service _service)
        {
            InitializeComponent();
            service = _service;
            if (service != null)
            {
                mainLabel.Content = "Сервис";
                id.Text = service.Id.ToString();
                title.Text = service.Title;
                cost.Text = service.Cost.ToString();
                time.Text = service.Time.ToString();
                imagePath.Text = service.ImagePath.Split('\\')[1];
                sale.Text = (service.Sale * 100).ToString();
                desk.Text = service.Description;
                serviceId = service.Id;
            }
            else
            {
                mainLabel.Content = "Новый сервис";
                id.Visibility = Visibility.Hidden;
                id_label.Visibility = Visibility.Hidden;
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (title.Text == "")
                {
                    throw new Exception("Название не может быть пустым.");
                }

                if (!float.TryParse(cost.Text, out float trueCost))
                {
                    throw new Exception("Введите действительную стоимость занятия.");
                }
                else if (trueCost == 0)
                {
                    throw new Exception("Бесплатные занятия не предусмотрены.");
                }
                else if (trueCost < 0)
                {
                    throw new Exception("Цена занятия не может быть меньше нуля.");
                }

                if (!int.TryParse(time.Text, out int trueTime))
                {
                    throw new Exception("Введите действительное время занятия.");
                }
                else if (trueTime == 0)
                {
                    throw new Exception("Время занятия не может быть нулевым.");
                }
                else if (trueTime < 0)
                {
                    throw new Exception("Время занятия не может быть отрицательным.");
                }
                else if (trueTime/360 > 4)
                {
                    throw new Exception("Время занятия не может быть более 4 часов.");
                }

                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Услуги школы\" + imagePath.Text))
                {
                    throw new Exception("Картинка не существует.");
                }

                if (!float.TryParse(sale.Text, out float trueSale))
                {
                    throw new Exception("Введите действительную скидку.");
                }
                else if (trueSale < 0)
                {
                    throw new Exception("Скидка не может быть меньше нуля.");
                }

                List<Service> services = Database.GetServices();
                foreach (Service temp in services)
                {
                    if (temp.Title == title.Text && temp.Id != serviceId)
                    {
                        throw new Exception("Услуга с таким названием уже существует!");
                    }
                }

                if (service == null)
                {
                    Service last = Database.GetServices().Last();
                    Database.AddService(new Service
                    {
                        Id = last.Id + 1,
                        Title = title.Text,
                        Cost = trueCost,
                        Time = trueTime,
                        Description = desk.Text,
                        ImagePath = @"Услуги школы\" + imagePath.Text,
                        Sale = trueSale/100
                    });
                }
                else
                {
                    service.Title = title.Text;
                    service.Cost = trueCost;
                    service.Time = trueTime;
                    service.Description = desk.Text;
                    service.ImagePath = @"Услуги школы\" + imagePath.Text;
                    service.Sale = trueSale/100;
                    Database.UpdateService(service);
                }
                ReturnToMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReturnToMenu()
        {
            new MainWindow().Show();
            Close();
        }
    }
}
