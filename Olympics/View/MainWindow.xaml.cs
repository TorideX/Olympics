using System;
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
using MaterialDesignThemes.Wpf;
using DatabaseModel;
using Domain.Model;
using System.Collections.ObjectModel;
using Olympics.View;
using Olympics.Model;

namespace Olympics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new OlympiadViewModel(new WindowsClass());
        }

        private void windowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void menuBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void windowMinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void windowMaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else if(this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
        }

        private void MenuButtonClicked(object sender, RoutedEventArgs e)
        {
            displayGrid.Children.Clear();
            var s = sender as Button;
            if (s == addCountryMenuBtn)
                displayGrid.Children.Add(new AddCountryView());
            else if (s == addSportMenuBtn)
                displayGrid.Children.Add(new AddSportView());
            else if (s == addSportmanMenuBtn)
                displayGrid.Children.Add(new AddSportsmanView());
            else if (s == addOlympiadMenuBtn)
                displayGrid.Children.Add(new AddOlympiadView());
            else if (s == addEventMenuBtn)
                displayGrid.Children.Add(new AddEventView());
            else if (s == addParticipantMenuBtn)
                displayGrid.Children.Add(new AddParticipantView());
            else if (s == fillParticipantMenuBtn)
                displayGrid.Children.Add(new FillParticipantView());
            else if (s == giveMedalMenuBtn)
                displayGrid.Children.Add(new GiveMedalView());
            else if (s == mostHostingCountryMenuBtn)
                displayGrid.Children.Add(new MostHostingCountryView());
            else if (s == countryStatisticsMenuBtn)
                displayGrid.Children.Add(new CountryStatisticsView());
            else if (s == mostWinnerForSportMenuBtn)
                displayGrid.Children.Add(new MostWinnerForSportView());
            else if (s == countryWithMostMedalsMenuBtn)
                displayGrid.Children.Add(new CountryWithMostMedalsView());
            else if (s == allMedalsMenuBtn)
                displayGrid.Children.Add(new AllMedalsView());
            else if (s == winnersBySportsMenuBtn)
                displayGrid.Children.Add(new WinnersBySportsView());
        }
    }
}
