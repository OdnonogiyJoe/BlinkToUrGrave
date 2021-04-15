using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace rage_sava
{
    public class VMGenre: INotifyPropertyChanged
    {
        Db db;
        public ObservableCollection<Genre> Genres { get; set; }
        private Genre selectedGenre;
        public ChavanCommand AddGenre { get; set; }
        public ChavanCommand SaveGenre { get; set; }
        public Genre SelectedGenre
        {
            get => selectedGenre;
            set { selectedGenre = value; SignalChanged(); }
        }
        public VMGenre()
        {
            db = Db.GetDb();
            LoadGenres();
            AddGenre = new ChavanCommand(() =>
            {
                var genre = new Genre { Name = "Название" };
                db.Genres.Add(genre);
                SelectedGenre = genre;
                LoadGenres();
            });
            SaveGenre = new ChavanCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadGenres();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private void LoadGenres()
        {
            Genres = new ObservableCollection<Genre>(db.Genres);
            SignalChanged("Genres");
        }
    }
}
