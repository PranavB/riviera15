using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace riviera__15
{
    class prowshow
    {
        public BitmapImage banner { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }

    class EventSection
    {
        string banner { get; set; }
        SolidColorBrush theme { get; set; }
        List<string> eventlist { get; set; }

    }

    class Event
    {
        public string event_title { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string reg_fee { get; set; }
        public string date { get; set; }
        public string formattedDate { get; set; }
        public string startTime { get; set; }
        public string location { get; set; }
        public string duration { get; set; }
        public string place { get; set; }
        public string prize { get; set; }
    }

    public class latAndLong
    {
        public double latitude, longitude;

        public latAndLong() { }

        public latAndLong(double la, double lo)
        {
            latitude = la;
            longitude = lo;
        }

        public void addLocations(Dictionary<string, latAndLong> themap)
        {
            themap.Add("CDMM", new latAndLong(12.969278, 79.155064));
            themap.Add("Foodys", new latAndLong(12.969083, 79.158234));
            themap.Add("Woodstock", new latAndLong(12.969964, 79.157497));
            themap.Add("TT", new latAndLong(12.971067, 79.159417));
            themap.Add("Greeno", new latAndLong(12.969616, 79.158240));
            themap.Add("SMV", new latAndLong(12.969645, 79.157687));
            themap.Add("SJT", new latAndLong(12.971432, 79.163556));
            themap.Add("TTBball", new latAndLong(12.970431, 79.158395));
            themap.Add("ControlBball", new latAndLong(12.970016, 79.156137));
            themap.Add("AnnaBball", new latAndLong(12.970481, 79.155898));
            themap.Add("MB", new latAndLong(12.969598, 79.155904));
            themap.Add("Anna", new latAndLong(12.969987, 79.155643));
            themap.Add("KCGround", new latAndLong(12.968536, 79.156799));
            themap.Add("OutdoorStadium", new latAndLong(12.975991, 79.160748));
        }
    }

    class AppData
    {
        public static List<Event> events;
        public static Dictionary<string, SolidColorBrush> blah = new Dictionary<string, SolidColorBrush>();
        static AppData()
        {

            blah.Add("informal", new SolidColorBrush(Color.FromArgb(255, 180, 0, 0)));
            blah.Add("formal", new SolidColorBrush(Color.FromArgb(255, 44, 62, 80)));
            blah.Add("sports", new SolidColorBrush(Color.FromArgb(255, 39, 174, 96)));
        }
    }


}
