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
using HAC10.Classes;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HAC10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageSong : Page
    {
        public ListSongs ListRecentUpdatedSongs;
        public ListSongs ListPopularSongs;
        public PageSongViewing Viewing;
        public int Take = 20;
        public double PreviousScrollView = 0;

        public PageSong()
        {
            InitializeComponent();
        }

        public void LoadRecentSongs()
        {
            ListRecentUpdatedSongs.Loading = true;
            progressRing.IsActive = true;
            Viewing = PageSongViewing.RECENT;
            using (var db = App.Connection)
            {
                var songs =
                    db.Table<SongTbl>()
                    .OrderByDescending(x => x.song_date)
                    .Take(Take)
                    .Skip(ListRecentUpdatedSongs.CurrentPage)
                    .ToList();

                ListRecentUpdatedSongs.AppendSongs(songs);
                ListRecentUpdatedSongs.CurrentPage++;
                ListRecentUpdatedSongs.Loading = false;

                lstRecentSongs.ItemsSource = ListRecentUpdatedSongs.Songs;
                progressRing.IsActive = false;
            }
        }

        public void LoadPopularSongs()
        {
            ListRecentUpdatedSongs.Loading = true;
            progressRing.IsActive = true;
            Viewing = PageSongViewing.POPULAR;
            using (var db = App.Connection)
            {
                var songs =
                    db.Table<SongTbl>()
                    .OrderByDescending(x => x.song_lastview)
                    .Take(Take)
                    .Skip(ListPopularSongs.CurrentPage)
                    .ToList();

                ListPopularSongs.AppendSongs(songs);
                ListPopularSongs.CurrentPage++;
                ListPopularSongs.Loading = false;

                lstPopularSongs.ItemsSource = ListPopularSongs.Songs;
                progressRing.IsActive = false;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            lstRecentSongs.Visibility = Visibility.Visible;
            lstPopularSongs.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            lstRecentSongs.Visibility = Visibility.Collapsed;
            lstPopularSongs.Visibility = Visibility.Visible;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return depObj as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = GetScrollViewer(child);
                if (result != null) return result;
            }
            return null;
        }

        private void ListViewRecentSongs_Loaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GetScrollViewer(sender as ListView);
            scrollViewer.ViewChanging += ScrollViewer_ViewChanging;
            scrollViewer.ViewChanged += ScrollViewer_ViewChanged;
        }

        private void ScrollViewerPopular_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            PreviousScrollView = scroll.VerticalOffset;
        }

        private void ScrollViewerPopular_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            var percent = scroll.VerticalOffset / scroll.ScrollableHeight;
            if (percent > 0.7 && scroll.VerticalOffset > PreviousScrollView)
            {
                LoadPopularSongs();
            }
        }

        private void lstPopularSongs_Loaded(object sender, RoutedEventArgs e)
        {
            var scrollViewerPopular = GetScrollViewer(sender as ListView);
            scrollViewerPopular.ViewChanging += ScrollViewerPopular_ViewChanging;
            scrollViewerPopular.ViewChanged += ScrollViewerPopular_ViewChanged;
        }

        private void ScrollViewer_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            PreviousScrollView = scroll.VerticalOffset;
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            var percent = scroll.VerticalOffset / scroll.ScrollableHeight;
            if(percent > 0.7 && scroll.VerticalOffset > PreviousScrollView)
            {
                LoadRecentSongs();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListPopularSongs = new ListSongs();
            ListRecentUpdatedSongs = new ListSongs();

            Viewing = PageSongViewing.RECENT;

            LoadRecentSongs();
            LoadPopularSongs();

            ckbRecent.IsChecked = true;
        }
    }

    public enum PageSongViewing
    {
        RECENT,
        POPULAR
    }
}
