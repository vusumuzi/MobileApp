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

           // mySlider.Value = MyMap.ZoomLevel;

        }
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

        private void setPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Lat2 = MyMap.Center.Position.Latitude;
            Lon2 = MyMap.Center.Position.Longitude;
            //double finalDist = calculateDistance(Lat1, Lon1, Lat2, Lon2, 'k');
            //finalDistance.Text = finalDist.ToString("0,00 Km");

        }
    }
}
