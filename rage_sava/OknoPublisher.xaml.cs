﻿using System;
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
    /// Логика взаимодействия для OknoPublisher.xaml
    /// </summary>
    public partial class OknoPublisher : Page
    {
        public OknoPublisher()
        {
            InitializeComponent();
            DataContext = new VMPublisher();
        }
    }
}
