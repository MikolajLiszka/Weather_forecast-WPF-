using System;
using System.Collections.Generic;
using System.Data;
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

namespace Weather_forecast
{
    /// <summary>
    /// Logika interakcji dla klasy ForecastForMOreDays.xaml
    /// </summary>
    public partial class ForecastForMOreDays : Window
    {
        public ForecastForMOreDays()
        {
            InitializeComponent();
        }

        private void getWeather(string city)
        {

        }

        private void weatherFor7Days_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("country", typeof(string));
        }
    }
}
