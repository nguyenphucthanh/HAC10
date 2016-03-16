using System.ComponentModel;
using SQLite.Net.Attributes;

namespace HAC10.Models
{
    [Table("ChordTbl")]
    public class ChordTbl : INotifyPropertyChanged
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

        public int chord_id { get; set; }

        [Ignore]
        public int ChordId
        {
            get { return chord_id; }
            set { chord_id = value; OnPropertyChanged("ChordId"); }
        }

        public string chord_name { get; set; }

        [Ignore]
        public string Name
        {
            get { return chord_name; }
            set { chord_name = value; OnPropertyChanged("Name"); }
        }

        public string chord_relations { get; set; }

        [Ignore]
        public string Relations
        {
            get { return chord_relations; }
            set { chord_relations = value; OnPropertyChanged("Name"); }
        }

        public ChordTbl()
        {
        }
    }
}
