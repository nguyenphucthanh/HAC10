using HAC10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HAC10
{
    public partial class ResourceDict : ResourceDictionary
    {
        public ResourceDict()
        {
            this.InitializeComponent();
        }

        private void btnFav_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var button = (sender as Button);
            var song = (SongTbl)button.DataContext;
            using(var db = App.Connection)
            {
                song.IsFavorite = song.IsFavorite > 0 ? 0 : 1;
                db.Update(song);
            }
        }
    }
}
