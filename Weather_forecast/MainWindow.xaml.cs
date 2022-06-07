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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;
using Microsoft.Win32;

namespace Weather_forecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void showWeatherNow_Click(object sender, RoutedEventArgs e)
        {
            string city;

            city = citySelector.Text;

            string uri = string.Format("http://api.weatherapi.com/v1/current.xml?key=48506950c6fb43ef8f7132151220606&q={0}&aqi=no", city);

            XDocument doc = XDocument.Load(uri);

            string iconUri = (string)doc.Descendants("imageOne").FirstOrDefault();

            /*WebClient client = new WebClient();

            byte[] image = client.DownloadData("http:" + iconUri);

            MemoryStream stream = new MemoryStream(image);
            */


            string xCTemp = (string)doc.Descendants("temp_c").FirstOrDefault();
            string xFTemp = (string)doc.Descendants("temp_f").FirstOrDefault();

            string xWindDir = (string)doc.Descendants("wind_dir").FirstOrDefault();
            string xWindSpeedKPH = (string)doc.Descendants("wind_kph").FirstOrDefault();

            string xHumidity = (string)doc.Descendants("humidity").FirstOrDefault();

            string xRegion = (string)doc.Descendants("region").FirstOrDefault();
            string xCountry = (string)doc.Descendants("country").FirstOrDefault();

            string xPressure = (string)doc.Descendants("pressure_mb").FirstOrDefault();
            string xCloud = (string)doc.Descendants("cloud").FirstOrDefault();

            string xVisibilityKM = (string)doc.Descendants("vis_km").FirstOrDefault();
            string xUV = (string)doc.Descendants("uv").FirstOrDefault();

            string xLastUpdate = (string)doc.Descendants("last_updated").FirstOrDefault();

            celciusTemp.Text = xCTemp;
            farenheitTemp.Text = xFTemp;
            windDir.Text = xWindDir;
            kphSpeed.Text = xWindSpeedKPH;
            humidity.Text = xHumidity;
            region.Text = xRegion;
            country.Text = xCountry;
            pressure.Text = xPressure;
            cloudCover.Text = xCloud;
            visibilityKm.Text = xVisibilityKM;
            uv.Text = xUV;
            lastUpdate.Text = xLastUpdate;
        }

        private void showWeatherBrodcast_Click(object sender, RoutedEventArgs e)
        {
            /*ForecastForMOreDays objFFMD = new ForecastForMOreDays();
            objFFMD.Show();
            */

            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();

            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;

                MessageBox.Show(filepath);
            }
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file(*.txt)|*.txt |C# file (*.cs)|*.cs";
            if(dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, $"Temperatura w Celsiuszach: {celciusTemp.Text}C, Temperatura w Farenheitach: {farenheitTemp.Text}F, Prędkość wiatru KpH: {kphSpeed.Text}kph, Wilgotność: {humidity.Text}%, Kraj: {country.Text}, Ciśnienie: {pressure.Text}HPa, Zachmurzenie: {cloudCover.Text}%, Widoczność: {visibilityKm.Text}km, UV: {uv.Text} na 11, Ostatnia aktualizacja pogody: {lastUpdate.Text}");
            }
        }
    }
}
