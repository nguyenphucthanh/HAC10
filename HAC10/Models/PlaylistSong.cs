using System.ComponentModel;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace HAC10.Models
{
    [Table("Playlist_Song_Tbl")]
    public class Playlist_Song_Tbl : INotifyPropertyChanged
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

        public int song_id { get; set; }

        [Ignore]
        public int SongId
        {
            get { return song_id; }
            set { song_id = value; OnPropertyChanged("SongId"); }
        }

        public Playlist_Song_Tbl()
        {
        }
    }
}
