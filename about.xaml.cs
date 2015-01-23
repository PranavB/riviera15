using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace riviera__15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class about : Page
    {
        public about()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vitmap.Center =
                  new Geopoint(new BasicGeoposition()
                  {
                      Latitude = 12.969598,
                      Longitude = 79.155904
                  });
            vitmap.MapServiceToken = "GezSF-9OSTvSnvS-WyC4Aw";
            vitmap.ZoomLevel = 17;
            vitmap.LandmarksVisible = true;
            vitmap.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.AerialWithRoads;
            vitmap.ColorScheme = Windows.UI.Xaml.Controls.Maps.MapColorScheme.Light;
            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Image =
                RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Pictures/mapPin.png"));
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 12.969598,
                Longitude = 79.155904
            });
            MapIcon1.NormalizedAnchorPoint = new Point(0.5, 0.5);
            
            MapIcon1.Title = "VIT University, Vellore";
            vitmap.MapElements.Add(MapIcon1);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
