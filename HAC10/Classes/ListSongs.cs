using HAC10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAC10.Classes
{
    public class ListSongs
    {
        public int CurrentPage { get; set; }
        public ObservableCollection<SongTbl> Songs { get; set; }

        public bool Loading { get; set; }

        public ListSongs()
        {
            this.CurrentPage = 0;
            this.Songs = new ObservableCollection<SongTbl>();
            this.Loading = false;
        }

        public void AppendSongs(List<SongTbl> newSongs)
        {
            foreach(var s in newSongs)
            {
                this.Songs.Add(s);
            }
        }
    }
}
