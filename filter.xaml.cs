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
    /// Логика взаимодействия для filter.xaml
    /// </summary>
    public partial class filter : Window
    {
        private List<Service> Services;
        private bool isFirstLoad = true;
        public filter(List<Service> services, int selected_index = 0, string text1 = "", string text2 = "")
        {
            Services = services;
            InitializeComponent();
            DGServises.ItemsSource = Services;
            DGServises.IsReadOnly = true;
            sale.SelectedIndex = selected_index;
            name.Text = text1;
            desk.Text = text2;
            isFirstLoad = false;
            count.Content = $"Показано {Services.Count} из {Database.GetServices().Count} услуг";
        }
        int i = -1;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isFirstLoad)
            {
                UploadPage();
            }
        }

        private void UploadPage()
        {
            Services = Database.GetServices();
            switch (sale.SelectedIndex)
            {
                case 1:
                    Services = Services.Where(x => x.Sale * 100 >= 0 && x.Sale * 100 < 5).ToList();
                    break;
                case 2:
                    Services = Services.Where(x => x.Sale * 100 >= 5 && x.Sale * 100 < 15).ToList();
                    break;
                case 3:
                    Services = Services.Where(x => x.Sale * 100 >= 15 && x.Sale * 100 < 30).ToList();
                    break;
                case 4:
                    Services = Services.Where(x => x.Sale * 100 >= 30 && x.Sale * 100 < 70).ToList();
                    break;
                case 5:
                    Services = Services.Where(x => x.Sale * 100 >= 70 && x.Sale * 100 < 100).ToList();
                    break;
            }

            if (name.Text != "")
                Services = Services.Where(x => x.Title == name.Text).ToList();

            if (desk.Text != "")
                Services = Services.Where(x => x.Description == desk.Text).ToList();

            ShowPageWithServices();
        }

        private void ShowPageWithServices()
        {
            new filter(Services, sale.SelectedIndex, name.Text, desk.Text).Show();
            Close();
        }

        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < Services.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Service S = Services[i];
                Uri U = new Uri(AppDomain.CurrentDomain.BaseDirectory + S.ImagePath, UriKind.Relative);
                ME.Source = U;
                ME.LoadedBehavior = MediaState.Play;
                //   i++;
            }
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < Services.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = Services[i];
                TB.Text = $"{S.Title}\nПродолжительность: {S.Time} секунд";
            }

        }

        private void BRed_Initialized(object sender, EventArgs e)
        {
            Button BtnRed = (Button)sender;
            if (BtnRed != null)
            {
                BtnRed.Uid = Convert.ToString(i);
            }
        }

        private void JoinButton_Initialized(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                button.Uid = Convert.ToString(i);
            }
        }

        private void StackPanel_Initialized(object sender, EventArgs e)
        {
            if (i < Services.Count)
            {
                StackPanel SP = (StackPanel)sender;
                Service S = Services[i];
                if (S.Sale != 0)
                {
                    SP.Background = new SolidColorBrush(Color.FromRgb(231, 250, 191));
                }
            }
        }

        private void TextBlock_Initialized_1(object sender, EventArgs e)
        {
            if (i < Services.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = Services[i];
                TB.Text = $"Стоимость: {S.Cost}";
            }
        }

        private void TextBlock_Initialized_2(object sender, EventArgs e)
        {
            if (i < Services.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = Services[i];
                if (S.Sale != 0)
                {
                    TB.Text = $"Скидка: {S.Sale*100}%";
                }
                else
                {
                    TB.Text = "";
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!isFirstLoad) { UploadPage(); }
        }
    }
}
