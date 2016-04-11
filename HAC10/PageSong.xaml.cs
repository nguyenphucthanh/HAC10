using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HAC10.Models;
using SQLite.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HAC10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageSong : Page
    {
        public List<SongTbl> ListRecentUpdatedSongs;

        public PageSong()
        {
            this.InitializeComponent();
            LoadRescentSongs();
        }

        public void LoadRescentSongs()
        {
            using (var db = App.Connection)
            {
                ListRecentUpdatedSongs =
                    db.Table<SongTbl>().OrderByDescending(x => x.song_date).Take(20).Skip(0).ToList();
                this.ListViewRecentSongs.ItemsSource = ListRecentUpdatedSongs;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            LoadRescentSongs();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
