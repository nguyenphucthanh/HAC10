using System.ComponentModel;
using SQLite.Net.Attributes;
namespace HAC10.Models
{
    [Table("ArtistTbl")]
    public class ArtistTbl : INotifyPropertyChanged
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

        #region fields
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int _id { get; set; }

        [Ignore]
        public int Id
        {
            get {return _id;}
            set { this._id = value; OnPropertyChanged("Id"); }
        }

        [Column("artist_id")]
        public int artist_id { get; set; }

        [Ignore]
        public int ArtistId
        {
            get { return artist_id; }
            set { artist_id = value; OnPropertyChanged("ArtistId"); }
        }

        [Column("artist_name")]
        public string artist_name { get; set; }

        [Ignore]
        public string Name
        {
            get { return artist_name; }
            set { artist_name = value; OnPropertyChanged("Name"); }
        }

        [Column("artist_ascii")]
        public string artist_ascii { get; set; }

        [Ignore]
        public string NameASCII
        {
            get { return artist_ascii; }
            set { artist_ascii = value; OnPropertyChanged("NameASCII"); }
        }
        #endregion

        public ArtistTbl()
        {
        }
    }
}
