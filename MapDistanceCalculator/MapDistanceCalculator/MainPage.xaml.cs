using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MapDistanceCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;

            var position = await locator.GetGeopositionAsync();
            await MyMap.TrySetViewAsync(position.Coordinate.Point, 18D);

            mySlider.Value = MyMap.ZoomLevel;

        }

        //Getting the Current Position
        private void getPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Lat1 = MyMap.Center.Position.Latitude;
            Lon1 = MyMap.Center.Position.Longitude;

        }
        public static double Lat1;
        public static double Lon1;
        public static double Lat2;
        public static double Lon2;
        public static char unit;

        //Adding a slider
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (MyMap != null)
                MyMap.ZoomLevel = e.NewValue;
        }


        //Setting the setPositionButton
        private void setPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Lat2 = MyMap.Center.Position.Latitude;
            Lon2 = MyMap.Center.Position.Longitude;
            double finalDist = calculateDistance(Lat1, Lon1, Lat2, Lon2, 'k');
            finalDistance.Text = finalDist.ToString("0,00 Km");

        }

        //Calculating the distance between two positions
        private double calculateDistance(double Lat1, double Lon1, double Lat2,
           double Lon2, char unit)
        {
            double theta = Lon1 - Lon2;
            double dist = Math.Sin(deg2rad(Lat1)) * Math.Sin(deg2rad(Lat2)) + Math.Cos(deg2rad(Lat1)) * Math.Cos(deg2rad(Lat2)) * Math.Cos(deg2rad(theta));
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return dist;
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

    }
}
