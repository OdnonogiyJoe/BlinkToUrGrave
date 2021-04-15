using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace rage_sava
{
    public class VMAuthor: INotifyPropertyChanged
    {
        Db db;
        public ObservableCollection<Author> Authors { get; set; }
        private Author selectedAuthor;
        public ChavanCommand AddAuthor { get; set; }
        public ChavanCommand SaveAuthor { get; set; }
        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set { selectedAuthor = value; SignalChanged(); }
        }
        public VMAuthor()
        {
            db = Db.GetDb();
            LoadAuthors();
            AddAuthor = new ChavanCommand(() =>
            {
                var author = new Author {  FirstName ="Имя", SecondName="Псевдоним", LastName="Фамилия", Birthday=DateTime.Now };
                db.Authors.Add(author);
                SelectedAuthor = author;
                LoadAuthors();
            });
            SaveAuthor = new ChavanCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadAuthors();
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
        private void LoadAuthors()
        {
            Authors = new ObservableCollection<Author>(db.Authors);
            SignalChanged("Authors");
        }
    }
}
