using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace rage_sava
{
    public class VMPublisher : INotifyPropertyChanged
    {
        Db db;
        public ObservableCollection<Publisher> Publishers { get; set; }
        private Publisher selectedPublisher;
        public ChavanCommand AddPublisher { get; set; }
        public ChavanCommand SavePublisher { get; set; }
        public Publisher SelectedPublisher
        {
            get => selectedPublisher;
            set { selectedPublisher = value; SignalChanged(); }
        }
        public VMPublisher()
        {
            db = Db.GetDb();
            LoadPublishers();
            AddPublisher = new ChavanCommand(() =>
            {
                var publisher = new Publisher { Name = "Имя", Address = "Фамилия" };
                db.Publishers.Add(publisher);
                SelectedPublisher = publisher;
                LoadPublishers();
            });
            SavePublisher = new ChavanCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadPublishers();
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
        private void LoadPublishers()
        {
            Publishers = new ObservableCollection<Publisher>(db.Publishers);
            SignalChanged("Publishers");
        }
    }
}
