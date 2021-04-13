using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace rage_sava
{
    public class MainVM : INotifyPropertyChanged
    {
        internal Page CurrentPage { get; set; }
        Db db;

        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public ChavanCommand OpenBooks { get; set; }
        public ChavanCommand OpenAuthors { get; set; }
        public ChavanCommand OpenGenres { get; set; }
        public ChavanCommand OpenPublishers { get; set; }

        public MainVM()
        {
            OpenBooks = new ChavanCommand(() => { CurrentPage = new OknoBook(); SignalChanged("CurrentPage"); });
            OpenAuthors = new ChavanCommand(() => { CurrentPage = new OknoAuthor(); SignalChanged("CurrentPage"); });
            OpenGenres = new ChavanCommand(() => { CurrentPage = new OknoGenre(); SignalChanged("CurrentPage"); });
            OpenPublishers = new ChavanCommand(() => { CurrentPage = new OknoPublisher(); SignalChanged("CurrentPage"); });
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
