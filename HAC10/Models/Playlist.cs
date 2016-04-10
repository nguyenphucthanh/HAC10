using System.Collections.Generic;
using System.ComponentModel;
using SQLite.Net.Attributes;

namespace HAC10.Models
{
    [Table("Playlist_Tbl")]
    public class Playlist_Tbl : INotifyPropertyChanged
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

        [PrimaryKey, AutoIncrement]
        public int _id { get; set; }

        [Ignore]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public int playlist_id { get; set; }

        [Ignore]
        public int PlaylistId
        {
            get { return playlist_id; }
            set { playlist_id = value; OnPropertyChanged("PlaylistId"); }
        }

        public string playlist_name { get; set; }

        [Ignore]
        public string Name
        {
            get { return playlist_name; }
            set { playlist_name = value; OnPropertyChanged("Name"); }
        }

        public string playlist_description { get; set; }

        [Ignore]
        public string Description
        {
            get { return playlist_description; }
            set { playlist_description = value; OnPropertyChanged("Description"); }
        }

        public string playlist_date { get; set; }

        [Ignore]
        public string Date
        {
            get { return playlist_date; }
            set { playlist_date = value; OnPropertyChanged("Date"); }
        }

        public int playlist_public { get; set; }

        [Ignore]
        public int Public
        {
            get { return playlist_public; }
            set { playlist_public = value; OnPropertyChanged("Public"); }
        }

        [Ignore]
        public int SongCount { get; set; }

        [Ignore]
        public List<SongTbl> Songs { get; set; }

        public Playlist_Tbl()
        {
        }
    }
}
