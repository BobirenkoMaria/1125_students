﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp15.ViewModels;

namespace WpfApp15.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditJournalPage.xaml
    /// </summary>
    public partial class EditJournalPage : Page
    {
        public EditJournalPage(EditJournalVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
