using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rage_sava
{
    /// <summary>
    /// Логика взаимодействия для OknoGenre.xaml
    /// </summary>
    public partial class OknoGenre : Page
    {
        public OknoGenre()
        {
            InitializeComponent();
            DataContext = new VMGenre();
        }
    }
}
