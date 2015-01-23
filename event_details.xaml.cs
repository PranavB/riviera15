using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using System.Globalization;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using riviera__15;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace riviera__15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class event_details : Page
    {
        Event ev;
        public event_details()
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
            ev = e.Parameter as Event;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ev;
            if (dateTxtBx.Text == String.Empty)
            {
                dateTxtBx.Visibility = Visibility.Collapsed;
                datelabel.Visibility = Visibility.Collapsed;
            }
            if (prizeMoneyTxtBx.Text == String.Empty)
            {
                prizeMoneyTxtBx.Visibility = Visibility.Collapsed;
                prizeMoneyLabel.Visibility = Visibility.Collapsed;
            }
            if (timeTxtBx.Text == String.Empty)
            {
                timeTxtBx.Visibility = Visibility.Collapsed;
                Timelabel.Visibility = Visibility.Collapsed;
            }
            if (locationTxtBx.Text == String.Empty)
            {
                locationTxtBx.Visibility = Visibility.Collapsed;
                loclabel.Visibility = Visibility.Collapsed; ;
            }

            if (regFeeTxtBx.Text == String.Empty)
            {
                regFeeTxtBx.Text = "Free";
            }
            // banner.Background = AppData.blah[ev.type];
            if(locationTxtBx.Text==String.Empty)
            {
                locateBtn.Visibility = Visibility.Collapsed;
            }
        }


        private async void AppBarButton_Tapped(object sender, RoutedEventArgs e)
        {
            var success = await Windows.System.Launcher.LaunchUriAsync(new Uri("https://academics.vit.ac.in/online_application/riviera_app/apply.asp"));
        }

        private void hideFlyoutBtn_Click(object sender, RoutedEventArgs e)
        {
            remindBtn.Flyout.Hide();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isAppointmentValid = true;
            string dateAndTime;
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();

            // StartTime
            dateAndTime = dateTxtBx.Tag + " " + timeTxtBx.Text;
            var date = Convert.ToDateTime(dateAndTime);
            var time = Convert.ToDateTime(dateAndTime);
            var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            var startTime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0, timeZoneOffset);
            appointment.StartTime = startTime;

            // Subject
            appointment.Subject = eventTitleTxtBx.Text;
            if (appointment.Subject.Length > 255)
            {
                isAppointmentValid = false;
            }

            // Location
            appointment.Location = locationTxtBx.Text;

            // Details
            appointment.Details = descTxtBx.Text;
            if (appointment.Details.Length > 1073741823)
            {
                isAppointmentValid = false;
            }

            // Duration    
            double dur;
            if (Double.TryParse(timeTxtBx.Tag.ToString(), out dur))
            {
                appointment.Duration = TimeSpan.FromHours(dur);
            }

            // All Day
            appointment.AllDay = false;

            // Reminder
            appointment.Reminder = TimeSpan.FromHours(1);

            // Sensitivity
            appointment.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Private;

            String appointmentId =
                await Windows.ApplicationModel.Appointments.AppointmentManager.ShowEditNewAppointmentAsync(appointment);

            if (appointmentId != String.Empty && isAppointmentValid)
            {
                remindBtn.Flyout.Hide();
            }
        }

        private void locateBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(map), locationTxtBx.Tag);
        }
    }
}
