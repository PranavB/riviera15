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
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace riviera__15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class map : Page
    {
        public Dictionary<string, latAndLong> atlas;
        public latAndLong res;
        string destName;

        public map()
        {
            this.InitializeComponent();
            atlas = new Dictionary<string, latAndLong>();
            res = new latAndLong();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            res.addLocations(atlas);
            if (atlas.TryGetValue(e.Parameter.ToString(), out res))
            {
                locationMap.Center =
                      new Geopoint(new BasicGeoposition()
                      {
                          Latitude = res.latitude,
                          Longitude = res.longitude
                      });
                locationMap.ZoomLevel = 18;
                locationMap.MapServiceToken = "edaf9ad9-5d59-4fa0-bb8d-8a469aa69b04";
                locationMap.LandmarksVisible = true;
                locationMap.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.AerialWithRoads;
                locationMap.ColorScheme = Windows.UI.Xaml.Controls.Maps.MapColorScheme.Light;
                MapIcon MapIcon1 = new MapIcon();
                MapIcon1.Image =
                    RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Pictures/mapPin.png"));
                MapIcon1.Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = res.latitude,
                    Longitude = res.longitude
                });
                MapIcon1.NormalizedAnchorPoint = new Point(0.5, 0.5);
                destName = e.Parameter.ToString();
                MapIcon1.Title = destName;
                locationMap.MapElements.Add(MapIcon1);
            }
        }

        async private void directionsBtn_Click(object sender, RoutedEventArgs e)
        {
            progRing.IsActive = true;

            string walking = "ms-walk-to:?destination.latitude=" + res.latitude +
                "&destination.longitude=" + res.longitude + "&destination.name=" + destName;

            Geolocator geo = new Geolocator();
            Geoposition pos = await geo.GetGeopositionAsync();

            string inbuilt = "bingmaps:?rtp=pos." +
                pos.Coordinate.Point.Position.Latitude.ToString() + "_" + pos.Coordinate.Point.Position.Longitude.ToString()
                + "~pos." + res.latitude + "_" + res.longitude;

            Uri uri = new Uri(inbuilt);

            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            if (success)
            {
                progRing.IsActive = false;
            }
        }
    }
}
