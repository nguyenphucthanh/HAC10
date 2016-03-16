using System.ComponentModel;
using SQLite.Net.Attributes;

namespace HAC10.Models
{
    [Table("Song_Chord_Tbl")]
    public class Song_Chord_Tbl : INotifyPropertyChanged
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

        public int chord_id { get; set; }

        [Ignore]
        public int ChordId
        {
            get { return chord_id; }
            set { chord_id = value; OnPropertyChanged("ChordId"); }
        }

        public Song_Chord_Tbl()
        {
        }

        public Song_Chord_Tbl(int _song_id, int _chord_id)
        {
            this.song_id = _song_id;
            this.chord_id = _chord_id;
        }

        
    }
}
