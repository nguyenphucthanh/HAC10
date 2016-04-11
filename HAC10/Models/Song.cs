using System.ComponentModel;
using SQLite.Net.Attributes;

namespace HAC10.Models
{
    [Table("SongTbl")]
    public class SongTbl : INotifyPropertyChanged
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

        #region table fields
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int _id { get; set; }

        [Ignore]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        [Column("song_id")]
        public int song_id { get; set; }

        [Ignore]
        public int SongId
        {
            get { return song_id; }
            set
            {
                song_id = value;
                OnPropertyChanged("SongId");
            }
        }

        [Column("song_title")]
        public string song_title { get; set; }

        [Ignore]
        public string Title
        {
            get { return song_title; }
            set
            {
                song_title = value;
                OnPropertyChanged("Title");
            }
        }

        [Column("song_link")]
        public string song_link { get; set; }

        [Ignore]
        public string Link
        {
            get { return song_link; }
            set { song_link = value; OnPropertyChanged("Link"); }
        }

        [Column("song_content")]
        public string song_content { get; set; }

        [Ignore]
        public string Content
        {
            get { return song_content; }
            set { song_content = value; OnPropertyChanged("Content"); }
        }

        [Column("song_first_lyric")]
        public string song_first_lyric { get; set; }

        [Ignore]
        public string FirstLyric
        {
            get { return song_first_lyric.Replace(System.Environment.NewLine, " ").Replace("\n", " "); }
            set { song_first_lyric = value; OnPropertyChanged("FirstLyric"); }
        }

        [Column("song_date")]
        public string song_date { get; set; }

        [Ignore]
        public string Date
        {
            get { return song_date; }
            set { song_date = value; OnPropertyChanged("Date"); }
        }

        [Column("song_title_ascii")]
        public string song_title_ascii { get; set; }

        [Ignore]
        public string TitleASCII
        {
            get { return song_title_ascii; }
            set { song_title_ascii = value; OnPropertyChanged("TitleASCII"); }
        }

        [Column("song_lastview")]
        public int song_lastview { get; set; }

        /// <summary>
        /// this field contain datetime data in tick format
        /// </summary>
        [Ignore]
        public int LastView
        {
            get { return song_lastview; }
            set { song_lastview = value; OnPropertyChanged("LastView"); }
        }

        [Column("song_isfavorite")]
        public int song_isfavorite { get; set; }

        [Ignore]
        public int IsFavorite
        {
            get { return song_isfavorite; }
            set
            {
                song_isfavorite = value;
                OnPropertyChanged("IsFavorite");
                OnPropertyChanged("IsFavoriteIconText");
            }
        }

        [Ignore]
        public string IsFavoriteIconText
        {
            get
            {
                return IsFavorite > 0 ? "\uE735" : "\uE734";
            }
        }

        [Column("song_rhythm")]
        public string song_rhythm { get; set; }

        [Ignore]
        public string Rhythm
        {
            get { return song_rhythm; }
            set { song_rhythm = value; OnPropertyChanged("Rhythm"); }
        }

        [Ignore]
        public string RhythmString
        {
            get
            {
                switch (this.Rhythm)
                {
                    case "ballad":
                    case "slow":
                    case "disco":
                    case "blues":
                    case "valse":
                    case "fox":
                    case "bollero":
                    case "rhumba":
                    case "pop":
                    case "chachacha":
                    case "rock":
                    case "boston":
                    case "tango":
                    case "nova":
                        return this.Rhythm.ToUpper();
                    case "slowrock":
                        return "slow rock".ToUpper();
                    default:
                        return this.Rhythm.ToUpper();
                }
            }
        }
        #endregion

        

        public SongTbl()
        {
        }

        
    }
}
