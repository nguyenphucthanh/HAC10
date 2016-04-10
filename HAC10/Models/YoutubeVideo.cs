using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAC10.Models
{
    public class YoutubeVideo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }
        private string _desc;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; OnPropertyChanged("Desc"); }
        }
        private Uri _thumbnail;

        public Uri Thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; OnPropertyChanged("Thumbnail"); }
        }

        public YoutubeVideo()
        {
        }
    }
}
