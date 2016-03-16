using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAC10.API
{
    public class Version
    {
        public int id { get; set; }
        public string date { get; set; }
        public int song_number { get; set; }
        public DateTime _date
        {
            get { return DateTime.Parse(date); }
            set { date = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }
        public Version()
        {
        }
    }

    public class Chord
    {
        public int chord_id { get; set; }
        public string name { get; set; }
        public string relations { get; set; }
        public Chord()
        {
        }
    }

    public class Artist
    {
        public int artist_id { get; set; }
        public string artist_name { get; set; }
        public string artist_ascii { get; set; }
        public Artist()
        {
        }
    }

    public class Song
    {
        public int song_id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string content { get; set; }
        public string firstlyric { get; set; }
        public string date { get; set; }
        public string rhythm { get; set; }
        public Chord[] chords { get; set; }
        public Artist[] authors { get; set; }
        public Artist[] singers { get; set; }
        public DateTime _date
        {
            get { return DateTime.Parse(date); }
            set { date = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }
        public Song()
        {
        }
    }

    public class Playlist
    {
        public int playlist_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public int @public { get; set; }
        public int[] song_ids { get; set; }
        public Playlist()
        {
        }
    }

    public class Profile
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string avatar_image_data { get; set; }
        public int activated { get; set; }
        public int banned { get; set; }
        public string ban_reason { get; set; }
        public Profile()
        {
        }
    }

    public class Rhythm
    {
        public string rhythm_code { get; set; }
        public string rhythm_name { get; set; }
        /// <summary>
        /// vote count
        /// </summary>
        public int vc { get; set; }

        public Rhythm()
        {

        }
    }
}
