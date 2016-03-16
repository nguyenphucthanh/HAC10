using System.ComponentModel;
using SQLite.Net.Attributes;

namespace HAC10.Models
{
    [Table("Song_Singer_Tbl")]
    public class Song_Singer_Tbl : INotifyPropertyChanged
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

        public int song_id { get; set; }

        [Ignore]
        public int SongId
        {
            get { return song_id; }
            set { song_id = value; OnPropertyChanged("SongId"); }
        }

        public int artist_id { get; set; }

        [Ignore]
        public int ArtistId
        {
            get { return artist_id; }
            set { artist_id = value; OnPropertyChanged("ArtistId"); }
        }

        public Song_Singer_Tbl()
        {
        }

        public Song_Singer_Tbl(int _song_id, int _artist_id)
        {
            this.song_id = _song_id;
            this.artist_id = _artist_id;
        }

        
    }
}
