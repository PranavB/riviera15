using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace riviera__15
{

    public sealed partial class eventsection : Page
    {
        List<Event> eventlist = new List<Event>();
        string type;
        public eventsection()
        {

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            type = (e.Parameter as string);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // header.Text = type;
            // headerpanel.Background = AppData.blah[type];
            eventlist = AppData.events;
            list.DataContext = null;
            list.DataContext = eventlist;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(event_details), (sender as FrameworkElement).DataContext as Event);
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            (sender as ListBox).SelectedItem = null;
        }
    }
}
