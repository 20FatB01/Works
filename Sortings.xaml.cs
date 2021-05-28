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
    /// Логика взаимодействия для Sortings.xaml
    /// </summary>
    public partial class Sortings : Window
    {
        private List<Service> Services;
        public Sortings(List<Service> services)
        {
            InitializeComponent();
            Services = services;
            DGServises.ItemsSource = Services;
            DGServises.IsReadOnly = true;
        }
        int i = -1;
        private void sortings_Click(object sender, RoutedEventArgs e)
        {
            new Sortings(Services.OrderByDescending(x => x.Cost * (1 - x.Sale)).ToList()).Show(); 
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Sortings(Services.OrderBy(x => x.Cost * (1 - x.Sale)).ToList()).Show();
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
                if (S.Sale != 0)
                {
                    TB.TextDecorations.Add(new TextDecoration(TextDecorationLocation.Strikethrough, new Pen(BorderBrush = Brushes.Red, 1), 1, TextDecorationUnit.FontRecommended, TextDecorationUnit.FontRecommended));
                }
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
                    TB.Text = $"Новая стоимость: {S.Cost * (1 - S.Sale)}";
                }
                else
                {
                    TB.Text = "";
                }
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
