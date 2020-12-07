using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DatabaseModel.Command;
using Domain.Interfaces;
using Domain.Model;
using Faker;

namespace DatabaseModel
{
    public class OlympiadViewModel : INotifyPropertyChanged
    {
        private IOperatingSystemClass systemClass;
        public OlympicsDbContext db { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _logoImagePath = @"C:\Users\ibrah\source\repos\Olympics\Olympics\Images\olympics.png";
        public string LogoImagePath
        {
            get { return _logoImagePath; }
            set { _logoImagePath = value; PropertyChangedHandler(); }
        }

        #region AddCountryView Variables
        public ObservableCollection<Country> Countries { get; set; }

        private int _countryCount;
        public int CountryCount
        {
            get { return _countryCount; }
            set { _countryCount = value; PropertyChangedHandler(); }
        }

        private Country _selectedCountry;

        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set { _selectedCountry = value; PropertyChangedHandler(); }
        }
        private string _newCountryName;
        public string NewCountryName
        {
            get { return _newCountryName; }
            set { _newCountryName = value; PropertyChangedHandler(); }
        }
        private string _newCountryImage;
        public string NewCountryImage
        {
            get { return _newCountryImage; }
            set { _newCountryImage = value; PropertyChangedHandler(); }
        }
        #endregion

        #region AddSportsman Variables

        public ObservableCollection<Sportsman> Sportsmen { get; set; }

        private int _sportsmenCount;
        public int SportsmenCount
        {
            get { return _sportsmenCount; }
            set { _sportsmenCount = value; PropertyChangedHandler(); }
        }

        private Sportsman _selectedSportsman;
        public Sportsman SelectedSportsman
        {
            get { return _selectedSportsman; }
            set { _selectedSportsman = value; PropertyChangedHandler(); }
        }

        private string _newSportsmanName;
        public string NewSportsmanName
        {
            get { return _newSportsmanName; }
            set { _newSportsmanName = value; PropertyChangedHandler(); }
        }
        private string _newSportsmanSurname;
        public string NewSportsmanSurname
        {
            get { return _newSportsmanSurname; }
            set { _newSportsmanSurname = value; PropertyChangedHandler(); }
        }

        private DateTime _newSportsmanBirthday; 
        public DateTime NewSportsmanBirthday
        {
            get { return _newSportsmanBirthday; }
            set { _newSportsmanBirthday = value; PropertyChangedHandler(); }
        }

        private Country _newSportsmanCountry;
        public Country NewSportsmanCountry
        {
            get { return _newSportsmanCountry; }
            set { _newSportsmanCountry = value; PropertyChangedHandler(); }
        }
        private Sport _newSportsmanSport;
        public Sport NewSportsmanSport
        {
            get { return _newSportsmanSport; }
            set { _newSportsmanSport = value; PropertyChangedHandler(); }
        }

        #endregion

        #region AddSportView Variables

        public ObservableCollection<Sport> Sports { get; set; }

        private int _sportCount;
        public int SportCount
        {
            get { return _sportCount; }
            set { _sportCount = value; PropertyChangedHandler(); }
        }

        private Sport _selectedSport;
        public Sport SelectedSport
        {
            get { return _selectedSport; }
            set { _selectedSport = value; PropertyChangedHandler(); }
        }

        private string _newSportName;
        public string NewSportName
        {
            get { return _newSportName; }
            set { _newSportName = value; PropertyChangedHandler(); }
        }

        private bool _isSummerSport = true;
        public bool IsSummerSport
        {
            get { return _isSummerSport; }
            set { _isSummerSport = value; PropertyChangedHandler(); }
        }

        private string _newSportDescription;
        public string NewSportDescription
        {
            get { return _newSportDescription; }
            set { _newSportDescription = value; PropertyChangedHandler(); }
        }
        private string _newSportImage;
        public string NewSportImage
        {
            get { return _newSportImage; }
            set { _newSportImage = value; PropertyChangedHandler(); }
        }

        #endregion

        #region AddOlympiadView Variables

        public ObservableCollection<Olympiad> Olympiads { get; set; }

        private int _olympiadCount;
        public int OlympiadCount
        {
            get { return _olympiadCount; }
            set { _olympiadCount = value; PropertyChangedHandler(); }
        }

        private Olympiad _selectedOlympiad;
        public Olympiad SelectedOlympiad
        {
            get { return _selectedOlympiad; }
            set { _selectedOlympiad = value; PropertyChangedHandler(); }
        }

        private string _newOlympiadYear;
        public string NewOlympiadYear
        {
            get { return _newOlympiadYear; }
            set { _newOlympiadYear = value; PropertyChangedHandler(); }
        }

        private bool _isSummerOlympiad;
        public bool IsSummerOlympiad
        {
            get { return _isSummerOlympiad; }
            set { _isSummerOlympiad = value; PropertyChangedHandler(); }
        }

        private Country _newOlympiadCountry;
        public Country NewOlympiadCountry
        {
            get { return _newOlympiadCountry; }
            set { _newOlympiadCountry = value; PropertyChangedHandler(); }
        }

        private string _newOlympiadCity;
        public string NewOlympiadCity
        {
            get { return _newOlympiadCity; }
            set { _newOlympiadCity = value; PropertyChangedHandler(); }
        }

        private string _newOlympiadImage;
        public string NewOlympiadImage
        {
            get { return _newOlympiadImage; }
            set { _newOlympiadImage = value; PropertyChangedHandler(); }
        }


        #endregion

        #region AddParticipantView Variables

        public ObservableCollection<Participant> Participants { get; set; }

        private int _participantCount;
        public int ParticipantCount
        {
            get { return _participantCount; }
            set { _participantCount = value; PropertyChangedHandler(); }
        }

        private Participant _selectedParticipant;
        public Participant SelectedParticipant
        {
            get { return _selectedParticipant; }
            set { _selectedParticipant = value; PropertyChangedHandler(); }
        }

        private Country _newParticipantCountry;
        public Country NewParticipantCountry
        {
            get { return _newParticipantCountry; }
            set { _newParticipantCountry = value; PropertyChangedHandler(); }
        }

        private Event _newParticipantEvent;
        public Event NewParticipantEvent
        {
            get { return _newParticipantEvent; }
            set { _newParticipantEvent = value; PropertyChangedHandler(); }
        }


        #endregion

        #region AddEventView Variables

        public ObservableCollection<Event> Events { get; set; }

        private int _eventCount;
        public int EventCount
        {
            get { return _eventCount; }
            set { _eventCount = value; PropertyChangedHandler(); }
        }

        private Event _selectedEvent;
        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; PropertyChangedHandler(); }
        }

        private Sport _newEventSport;
        public Sport NewEventSport
        {
            get { return _newEventSport; }
            set { _newEventSport = value; PropertyChangedHandler(); }
        }

        private Olympiad _newEventOlympiad;
        public Olympiad NewEventOlympiad
        {
            get { return _newEventOlympiad; }
            set { _newEventOlympiad = value; PropertyChangedHandler(); }
        }

        #endregion
        
        #region FillParticipantView Variables

        private void FillParticipantOlympiadChanged()
        {
            FillParticipantSportsmen.Clear();
            FillParticipantParticipants.Clear();
            FillParticipantEvents.Clear();
            if (FillParticipantOlympiad != null)
                foreach (var item in db.Olympiads.ToList().First(o => o.Id == FillParticipantOlympiad.Id).Events)
                {
                    FillParticipantEvents.Add(item);
                }
        }
        private void FillParticipantEventChanged()
        {
            FillParticipantSportsmen.Clear();
            FillParticipantParticipants.Clear();
            if (FillParticipantOlympiad != null && FillParticipantEvent != null)
                foreach (var item in db.Olympiads.ToList().First(o => o.Id == FillParticipantOlympiad.Id).Events.First(e => e.Id == FillParticipantEvent.Id).Participants)
                {
                    FillParticipantParticipants.Add(item);
                }
        }
        private void FillParticipantParticipantChanged()
        {
            FillParticipantSportsmen.Clear();
            MedalSportsmen.Clear();

            if (FillParticipantOlympiad != null && FillParticipantEvent != null && FillParticipantParticipant != null)
            {
                foreach (var item in db.Sportsmen.ToList().Where(s => s.Country == FillParticipantParticipant.Country && s.Sport == FillParticipantEvent.Sport))
                {
                    FillParticipantSportsmen.Add(item);
                }
                FillSportsmanCount = FillParticipantSportsmen.Count;
                

                foreach (var item in db.Participants.ToList().First(p => p.Id == FillParticipantParticipant.Id).Medals)
                {
                    MedalSportsmen.Add(item);
                }
                MedalSportsmenCount = MedalSportsmen.Count;
            }
                
        }

        public ObservableCollection<Event> FillParticipantEvents { get; set; } = new ObservableCollection<Event>();
        public ObservableCollection<Participant> FillParticipantParticipants { get; set; } = new ObservableCollection<Participant>();
        public ObservableCollection<Sportsman> FillParticipantSportsmen { get; set; } = new ObservableCollection<Sportsman>();

        private int _fillSportsmanCount;
        public int FillSportsmanCount
        {
            get { return _fillSportsmanCount; }
            set { _fillSportsmanCount = value; PropertyChangedHandler(); }
        }
               

        private Sportsman _selectedFillSportsman;
        public Sportsman SelectedFillSportsman
        {
            get { return _selectedFillSportsman; }
            set { _selectedFillSportsman = value; PropertyChangedHandler(); }
        }


        private Olympiad _fillParticipantOlympiad;
        public Olympiad FillParticipantOlympiad
        {
            get { return _fillParticipantOlympiad; }
            set 
            { 
                _fillParticipantOlympiad = value;
                PropertyChangedHandler();
                FillParticipantOlympiadChanged();
            }
        }

        private Event _fillParticipantEvent;

        public Event FillParticipantEvent
        {
            get { return _fillParticipantEvent; }
            set 
            {
                _fillParticipantEvent = value;
                PropertyChangedHandler();
                FillParticipantEventChanged();
            }
        }

        private Participant _fillParticipantParticipant;

        public Participant FillParticipantParticipant
        {
            get { return _fillParticipantParticipant; }
            set 
            {
                _fillParticipantParticipant = value;
                PropertyChangedHandler();
                FillParticipantParticipantChanged();
            }
        }

        private Sportsman _fillParticipantSportsman;

        public Sportsman FillParticipantSportsman
        {
            get { return _fillParticipantSportsman; }
            set { _fillParticipantSportsman = value; PropertyChangedHandler(); }
        }

        #endregion
        
        #region GiveMedalView Variables

        public ObservableCollection<MedalSportsman> MedalSportsmen { get; set; } = new ObservableCollection<MedalSportsman>();

        private MedalSportsman _selectedMedalSporstman;

        public MedalSportsman SelectedMedalSporstman
        {
            get { return _selectedMedalSporstman; }
            set { _selectedMedalSporstman = value; PropertyChangedHandler(); }
        }

        private int _medalSportsmenCount;

        public int MedalSportsmenCount
        {
            get { return _medalSportsmenCount; }
            set { _medalSportsmenCount = value; PropertyChangedHandler(); }
        }

        public ObservableCollection<MedalType> MedalTypes { get; set; } = new ObservableCollection<MedalType>();

        private MedalType _giveMedalSportsmanMedalType;
        public MedalType GiveMedalSportsmanMedalType
        {
            get { return _giveMedalSportsmanMedalType; }
            set { _giveMedalSportsmanMedalType = value; PropertyChangedHandler(); }
        }


        #endregion

        #region Tasks

        #region MostHostingCount
        private Country _mostHostingCountry;
        public Country MostHostingCountry
        {
            get { return _mostHostingCountry; }
            set { _mostHostingCountry = value; PropertyChangedHandler(); }
        }
        #endregion

        #region CountryStatistics
        public ObservableCollection<Season> Seasons { get; set; } = new ObservableCollection<Season>();
        private Season _countryStatisticsOlympiadType;
        public Season CountryStatisticsOlympiadType
        {
            get { return _countryStatisticsOlympiadType; }
            set { _countryStatisticsOlympiadType = value; PropertyChangedHandler(); }
        }

        private Country _countryStatisticsCountry;
        public Country CountryStatisticsCountry
        {
            get { return _countryStatisticsCountry; }
            set { _countryStatisticsCountry = value; PropertyChangedHandler(); }
        }

        private int _countryStatisticsGolds;
        public int CountryStatisticsGolds
        {
            get { return _countryStatisticsGolds; }
            set { _countryStatisticsGolds = value; PropertyChangedHandler(); }
        }

        private int _countryStatisticsSilvers;
        public int CountryStatisticsSilvers
        {
            get { return _countryStatisticsSilvers; }
            set { _countryStatisticsSilvers = value; PropertyChangedHandler(); }
        }

        private int _countryStatisticsBronzes;
        public int CountryStatisticsBronzes
        {
            get { return _countryStatisticsBronzes; }
            set { _countryStatisticsBronzes = value; PropertyChangedHandler(); }
        }
        #endregion

        #region MostMedals
        private Sport _mostMedalsSport;
        public Sport MostMedalsSport
        {
            get { return _mostMedalsSport; }
            set { _mostMedalsSport = value; PropertyChangedHandler(); }
        }

        private Sportsman _mostMedalSportsman;
        public Sportsman MostMedalSportsman
        {
            get { return _mostMedalSportsman; }
            set { _mostMedalSportsman = value; PropertyChangedHandler(); }
        }

        private int _mostMedalsCount;
        public int MostMedalsCount
        {
            get { return _mostMedalsCount; }
            set { _mostMedalsCount = value; PropertyChangedHandler(); }
        }
        #endregion
        
        #region CountryWithMostMedals

        private Season _countryWithMostMedalsSeason;
        public Season CountryWithMostMedalsSeason
        {
            get { return _countryWithMostMedalsSeason; }
            set { _countryWithMostMedalsSeason = value; PropertyChangedHandler(); }
        }

        private Country _countryWithMostMedalsCountry;
        public Country CountryWithMostMedalsCountry
        {
            get { return _countryWithMostMedalsCountry; }
            set { _countryWithMostMedalsCountry = value; PropertyChangedHandler(); }
        }

        private int _countryWithMostMedalsMedalCount;
        public int CountryWithMostMedalsMedalCount
        {
            get { return _countryWithMostMedalsMedalCount; }
            set { _countryWithMostMedalsMedalCount = value; PropertyChangedHandler(); }
        }

        #endregion

        #region AllMedalsByCountry

        public ObservableCollection<MedalSportsman> MedalSportsmenByCountry { get; set; } = new ObservableCollection<MedalSportsman>();

        private int _medalSportsmenByCountryCount;
        public int MedalSportsmenByCountryCount
        {
            get { return _medalSportsmenByCountryCount; }
            set { _medalSportsmenByCountryCount = value; PropertyChangedHandler(); }
        }

        private MedalSportsman _selectedMedalSportsmanByCountry;
        public MedalSportsman SelectedMedalSportsmanByCountry
        {
            get { return _selectedMedalSportsmanByCountry; }
            set { _selectedMedalSportsmanByCountry = value; PropertyChangedHandler(); }
        }

        private Season _medalSportsmanByCountryOlympiadType;
        public Season MedalSportsmanByCountryOlympiadType
        {
            get { return _medalSportsmanByCountryOlympiadType; }
            set { _medalSportsmanByCountryOlympiadType = value; PropertyChangedHandler(); }
        }

        private Country _medalSportsmanByCountryCountry;
        public Country MedalSportsmanByCountryCountry
        {
            get { return _medalSportsmanByCountryCountry; }
            set { _medalSportsmanByCountryCountry = value; PropertyChangedHandler(); }
        }


        #endregion

        public ObservableCollection<MedalSportsman> MedalSportsmenBySport { get; set; } = new ObservableCollection<MedalSportsman>();

        private int _medalSportsmenBySportCount;
        public int MedalSportsmenBySportCount
        {
            get { return _medalSportsmenBySportCount; }
            set { _medalSportsmenBySportCount = value; PropertyChangedHandler(); }
        }

        private MedalSportsman _selectedMedalSportsmanBySport;
        public MedalSportsman SelectedMedalSportsmanBySport
        {
            get { return _selectedMedalSportsmanBySport; }
            set { _selectedMedalSportsmanBySport = value; PropertyChangedHandler(); }
        }
        
        private Season _medalSportsmanBySportSeason;
        public Season MedalSportsmanBySportSeason
        {
            get { return _medalSportsmanBySportSeason; }
            set { _medalSportsmanBySportSeason = value; PropertyChangedHandler(); }
        }

        private Sport _medalSportsmanBySportSport;
        public Sport MedalSportsmanBySportSport
        {
            get { return _medalSportsmanBySportSport; }
            set { _medalSportsmanBySportSport = value; PropertyChangedHandler(); }
        }


        #endregion


        #region Commands
        public RelayCommand NewCountrySelectedCommand { get; set; }
        public RelayCommand AddCountryCommand { get; set; }
        public RelayCommand BrowseCountryImage { get; set; }

        public RelayCommand NewSportSelectedCommand { get; set; }
        public RelayCommand AddSportCommand { get; set; }
        public RelayCommand BrowseSportImage { get; set; }

        public RelayCommand NewSportsmanSelectedCommand { get; set; }
        public RelayCommand AddSportsmanCommand { get; set; }

        public RelayCommand AddOlympiadCommand { get; set; }
        public RelayCommand NewOlympiadSelectedCommand { get; set; }
        public RelayCommand BrowseOlympiadImage { get; set; }

        public RelayCommand NewEventSelectedCommand { get; set; }
        public RelayCommand AddEventCommand { get; set; }
        
        public RelayCommand NewParticipantSelectedCommand { get; set; }
        public RelayCommand AddParticipantCommand { get; set; }

        public RelayCommand AddSportsmanToParticipantCommand { get; set; }

        public RelayCommand MostHostingCountryCommand { get; set; }
        public RelayCommand NewFillSportsmanSelectedCommand { get; set; }

        public RelayCommand AddMedalToSportsmanCommand { get; set; }
        public RelayCommand NewMedalTypeSelectedCommand { get; set; }

        public RelayCommand ShowCountryStatistics { get; set; }
        public RelayCommand ShowMostMedalsForSport { get; set; }
        public RelayCommand ShowCountryWithMostMedals { get; set; }
        public RelayCommand ShowAllMedalsByCountry { get; set; }
        public RelayCommand NewMedalSportsmanByCountrySelectedCommand { get; set; }

        public RelayCommand ShowAllMedalsBySport { get; set; }
        public RelayCommand NewMedalSportsmanBySportSelectedCommand { get; set; }

        #endregion

        public OlympiadViewModel(IOperatingSystemClass _systemClass)
        {
            systemClass = _systemClass;
            RegisterCommands();
            db = new OlympicsDbContext();

            Countries = new ObservableCollection<Country>();
            Sports = new ObservableCollection<Sport>();
            Sportsmen = new ObservableCollection<Sportsman>();
            Olympiads = new ObservableCollection<Olympiad>();
            Events = new ObservableCollection<Event>();
            Participants = new ObservableCollection<Participant>();

            FillCountries();
            FillSports();
            FillSportsmen();
            FillOlympiads();
            FillEvents();
            FillParticipants();
            FillMedalTypes();
            FillSeasons();
        }
        private void RegisterCommands()
        {
            NewCountrySelectedCommand = new RelayCommand(NewCountrySelectedExecute);
            AddCountryCommand = new RelayCommand(AddCountryCommandExecute, AddCountryCommandCanExecute);
            BrowseCountryImage = new RelayCommand(BrowseCountryImageExecute);

            NewSportSelectedCommand = new RelayCommand(NewSportSelectedCommandExecute);
            AddSportCommand = new RelayCommand(AddSportCommandExecute, AddSportCommandCanExecute);
            BrowseSportImage = new RelayCommand(BrowseSportImageExecute);

            NewSportsmanSelectedCommand = new RelayCommand(NewSportsmanSelectedCommandExecute);
            AddSportsmanCommand = new RelayCommand(AddSportsmanCommandExecute, AddSportsmanCommandCanExecute);

            NewOlympiadSelectedCommand = new RelayCommand(NewOlympiadSelectedCommandExecute);
            AddOlympiadCommand = new RelayCommand(AddOlympiadCommandExecute, AddOlympiadCommandCanExecute);
            BrowseOlympiadImage = new RelayCommand(BrowseOlympiadImageExecute);

            NewEventSelectedCommand = new RelayCommand(NewEventSelectedCommandExecute);
            AddEventCommand = new RelayCommand(AddEventCommandExecute, AddEventCommandCanExecute);

            NewParticipantSelectedCommand = new RelayCommand(NewParticipantSelectedCommandExecute);
            AddParticipantCommand = new RelayCommand(AddParticipantCommandExecute, AddParticipantCommandCanExecute);

            NewFillSportsmanSelectedCommand = new RelayCommand(NewFillSportsmanSelectedCommandExecute);
            AddSportsmanToParticipantCommand = new RelayCommand(AddSportsmanToParticipantCommandExecute, 
                                                                AddSportsmanToParticipantCommandCanExecute);

            NewMedalTypeSelectedCommand = new RelayCommand(NewMedalTypeSelectedCommandExecute);
            AddMedalToSportsmanCommand = new RelayCommand(AddMedalToSportsmanCommandExecute, AddMedalToSportsmanCommandCanExecute);

            MostHostingCountryCommand = new RelayCommand(MostHostingCountryCommandExecute);
            ShowCountryStatistics = new RelayCommand(ShowCountryStatisticsExecute, ShowCountryStatisticsCanExecute);
            ShowMostMedalsForSport = new RelayCommand(ShowMostMedalsForSportExecute, ShowMostMedalsForSportCanExecute);
            ShowCountryWithMostMedals = new RelayCommand(ShowCountryWithMostMedalsExecute, ShowCountryWithMostMedalsCanExecute);
            ShowAllMedalsByCountry = new RelayCommand(ShowAllMedalsByCountryExecute, ShowAllMedalsByCountryCanExecute);
            NewMedalSportsmanByCountrySelectedCommand = new RelayCommand(NewMedalSportsmanByCountrySelectedCommandExecute);

            ShowAllMedalsBySport = new RelayCommand(ShowAllMedalsBySportExecute, ShowAllMedalsBySportCanExecute);
            NewMedalSportsmanBySportSelectedCommand = new RelayCommand(NewMedalSportsmanByCountrySelectedSportExecute);
        }

        private void NewMedalSportsmanByCountrySelectedSportExecute(object obj)
        {
            SelectedMedalSportsmanBySport = obj as MedalSportsman;
        }

        private void ShowAllMedalsBySportExecute(object obj)
        {
            MedalSportsmenBySport.Clear();
            foreach (var item in db.Participants.ToList().Where(p => p.Event.Sport == MedalSportsmanBySportSport && p.Event.Olympiad.Season == MedalSportsmanBySportSeason).Select(s => s.Medals))
            {
                foreach (var itm in item)
                {
                    MedalSportsmenBySport.Add(itm);
                }
            }
            MedalSportsmenBySportCount = MedalSportsmenBySport.Count;
        }

        private bool ShowAllMedalsBySportCanExecute(object arg)
        {
            if (MedalSportsmanBySportSeason == default || MedalSportsmanBySportSport == null) return false;

            return true;
        }

        private void NewMedalSportsmanByCountrySelectedCommandExecute(object obj)
        {
            SelectedMedalSportsmanByCountry = obj as MedalSportsman;
        }

        private void ShowAllMedalsByCountryExecute(object obj)
        {
            MedalSportsmenByCountry.Clear();
            foreach(var item in db.Participants.ToList().Where(p=>p.Country == MedalSportsmanByCountryCountry && p.Event.Olympiad.Season == MedalSportsmanByCountryOlympiadType).Select(s=>s.Medals))
            {
                foreach (var itm in item)
                {
                    MedalSportsmenByCountry.Add(itm);
                }
            }
            MedalSportsmenByCountryCount = MedalSportsmenByCountry.Count;
        }

        private bool ShowAllMedalsByCountryCanExecute(object arg)
        {
            if (MedalSportsmanByCountryOlympiadType == default || MedalSportsmanByCountryCountry == null) return false;

            return true;
        }

        private void ShowCountryWithMostMedalsExecute(object obj)
        {
            Country country = null;
            int medalCount = 0;

            foreach (var item in db.Countries.ToList())
            {
                foreach (var itm in db.Participants.ToList().Where(p => p.Country == item && p.Event.Olympiad.Season == CountryWithMostMedalsSeason).ToList())
                {
                    int temp = itm.Medals.Where(m => m.MedalType == MedalType.Gold).ToList().Count;
                    if (temp > medalCount)
                    {
                        medalCount = temp;
                        country = item;
                    }
                }
            }
            CountryWithMostMedalsCountry = country;
            CountryWithMostMedalsMedalCount = medalCount;
        }

        private bool ShowCountryWithMostMedalsCanExecute(object arg)
        {
            if (CountryWithMostMedalsSeason == default) return false;

            return true;
        }

        private void ShowMostMedalsForSportExecute(object obj)
        {
            Sportsman sportsman = null;
            int medalscount = 0;

            foreach (var sprtmn in Sportsmen)
            {
                foreach (var item in db.Participants.ToList().Where(p => p.Event.Sport == MostMedalsSport).Select(p => p.Medals))
                {
                    var tempCount = item.Where(m => m.Sportsman == sprtmn).ToList().Count();

                    if(tempCount > medalscount)
                    {
                        medalscount = tempCount;
                        sportsman = sprtmn;
                    }
                }
            }
            MostMedalSportsman = sportsman;
            MostMedalsCount = medalscount;
        }

        private bool ShowMostMedalsForSportCanExecute(object arg)
        {
            if (MostMedalsSport == null) return false;

            return true;
        }

        private void ShowCountryStatisticsExecute(object obj)
        {
            int goldCount = 0;
            int silverCount = 0;
            int bronzeCount = 0;

            foreach (var item in db.Participants.ToList().Where(p => p.Country == CountryStatisticsCountry && p.Event.Olympiad.Season == CountryStatisticsOlympiadType).Select(p => p.Medals).ToList()) 
            {
                foreach (var itm in item)
                {
                    if (itm.MedalType == MedalType.Bronze)
                        bronzeCount++;
                    else if (itm.MedalType == MedalType.Silver)
                        silverCount++;
                    else if (itm.MedalType == MedalType.Gold)
                        goldCount++;
                }
            }

            CountryStatisticsBronzes = bronzeCount;
            CountryStatisticsSilvers = silverCount;
            CountryStatisticsGolds = goldCount;
        }

        private bool ShowCountryStatisticsCanExecute(object arg)
        {
            if (CountryStatisticsOlympiadType == default && CountryStatisticsCountry == null) return false;

            return true;
        }

        private void AddMedalToSportsmanCommandExecute(object obj)
        {
            var medalSportsman = new MedalSportsman(FillParticipantSportsman, GiveMedalSportsmanMedalType);
            db.Participants.First(p => p.Id == FillParticipantParticipant.Id).Medals.Add(medalSportsman);
            db.SaveChanges();

            MedalSportsmen.Add(medalSportsman);
            MedalSportsmenCount++;

            systemClass.ShowMessageBox("Info", $"Medal has been added to {FillParticipantSportsman}");

            FillParticipantSportsman = null;
            GiveMedalSportsmanMedalType = default;
        }

        private bool AddMedalToSportsmanCommandCanExecute(object arg)
        {
            if (FillParticipantOlympiad == null || FillParticipantEvent == null ||
                FillParticipantParticipant == null || FillParticipantSportsman == null)
                return false;
            if (GiveMedalSportsmanMedalType == default) return false;
            if (FillParticipantParticipant.Medals.Any(m => m.Sportsman == FillParticipantSportsman)) return false;

            return true;
        }

        private void NewMedalTypeSelectedCommandExecute(object obj)
        {
            SelectedMedalSporstman = obj as MedalSportsman;
        }

        private void NewFillSportsmanSelectedCommandExecute(object obj)
        {
            SelectedFillSportsman = obj as Sportsman;
        }

        private void MostHostingCountryCommandExecute(object obj)
        {
            int max = 0;
            Country country = null;

            foreach (var item in db.Olympiads.ToList().Select(o => o.Host).Distinct())
            {
                var temp = db.Olympiads.ToList().Count(o => o.Host == item);
                if (temp > max)
                {
                    max = temp;
                    country = item;
                }
            }
            MostHostingCountry = country;
        }

        private void AddSportsmanToParticipantCommandExecute(object obj)
        {
            var result = db.Participants.First(p => p.Id == FillParticipantParticipant.Id).RegisterSportsman(FillParticipantSportsman);

            if(result == true)
            {
                db.SaveChanges();

                systemClass.ShowMessageBox("Info", $"Sportsman has been added to {FillParticipantParticipant}");

                FillParticipantSportsman = null;
                FillParticipantParticipant = null;
                FillParticipantEvent = null;
                FillParticipantOlympiad = null;
            }
            else
            {
                systemClass.ShowMessageBox("Info", $"Sportsman exist in {FillParticipantParticipant}");
            }
        }

        private bool AddSportsmanToParticipantCommandCanExecute(object arg)
        {
            if (FillParticipantOlympiad == null || FillParticipantEvent == null ||
                FillParticipantParticipant == null || FillParticipantSportsman == null)
                return false;

            return true;
        }

        private void NewParticipantSelectedCommandExecute(object obj)
        {
            SelectedParticipant = obj as Participant;
        }

        private void AddParticipantCommandExecute(object obj)
        {
            var participant = new Participant(NewParticipantCountry) { Event = NewParticipantEvent };

            //db.Participants.Add(participant);
            db.Events.First(e => e.Id == NewParticipantEvent.Id).RegisterParticipant(participant);
            db.SaveChanges();

            FillParticipants();

            NewParticipantEvent = null;
            NewParticipantCountry = null;

            systemClass.ShowMessageBox("Info", "Participant has been added!");
        }

        private bool AddParticipantCommandCanExecute(object arg)
        {
            if (NewParticipantCountry == null || NewParticipantEvent == null) return false;
            if (NewParticipantEvent.Participants.Any(p => p.Country == NewParticipantCountry)) return false;

            return true;
        }

        private void NewEventSelectedCommandExecute(object obj)
        {
            SelectedEvent = obj as Event;
        }

        private void AddEventCommandExecute(object obj)
        {
            var evnt = new Event(NewEventSport) { Olympiad = NewEventOlympiad };

            db.Olympiads.First(o=>o.Id == NewEventOlympiad.Id).Events.Add(evnt);
            db.SaveChanges();

            FillEvents();

            NewEventOlympiad = null;
            NewEventSport = null;

            systemClass.ShowMessageBox("Info", "Event has been added!");
        }

        private bool AddEventCommandCanExecute(object arg)
        {
            if (NewEventSport == null || NewEventOlympiad == null) return false;
            if (NewEventOlympiad.Season != NewEventSport.Season) return false;
            if (NewEventOlympiad.Events.Any(e => e.Sport == NewEventSport)) return false;

            return true;
        }

        private void NewOlympiadSelectedCommandExecute(object obj)
        {
            SelectedOlympiad = obj as Olympiad;
        }

        private void AddOlympiadCommandExecute(object obj)
        {
            string imagePath = string.IsNullOrEmpty(NewOlympiadImage) ? @"C:\Users\ibrah\source\repos\Olympics\Olympics\Images\Olympiads\Default.png"
                : NewOlympiadImage;

            var olymp = new Olympiad(
                int.Parse(NewOlympiadYear),
                IsSummerOlympiad ? Season.Summer : Season.Winter,
                NewOlympiadCountry, NewOlympiadCity, imagePath);

            db.Olympiads.Add(olymp);
            db.SaveChanges();

            FillOlympiads();

            NewOlympiadYear = string.Empty;
            NewOlympiadCity = string.Empty;
            NewOlympiadImage = string.Empty;
            NewOlympiadCountry = null;
            IsSummerOlympiad = true;

            systemClass.ShowMessageBox("Info", "Olympiad has been added!");
        }

        private bool AddOlympiadCommandCanExecute(object arg)
        {
            if (string.IsNullOrEmpty(NewOlympiadYear) || string.IsNullOrEmpty(NewOlympiadCity) || NewOlympiadCountry == null)
                return false;

            try
            {
                var year = int.Parse(NewOlympiadYear);
                if (!Olympiad.IsValidYear(year) || db.Olympiads.ToList().Any(o => o.Year == year))
                    return false;
            }
            catch (Exception) { return false; }

            return true;
        }

        private void BrowseOlympiadImageExecute(object obj)
        {
            NewOlympiadImage = systemClass.GetImagePath("Olympiad");
        }

        private void AddSportsmanCommandExecute(object obj)
        {
            var sportsman = new Sportsman(
                NewSportsmanName,
                NewSportsmanSurname,
                NewSportsmanBirthday,
                NewSportsmanCountry,
                NewSportsmanSport);

            if (!db.Sportsmen.ToList().Contains(sportsman))
            {
                db.Sportsmen.Add(sportsman);
                db.SaveChanges();

                FillSportsmen();

                NewSportsmanName = string.Empty;
                NewSportsmanSurname = string.Empty;
                NewSportsmanBirthday = new DateTime(2000, 1, 1);
                NewSportsmanCountry = null;
                NewSportsmanSport = null;

                systemClass.ShowMessageBox("Info", "Olympiad has been added!");
            }
            else
            {
                systemClass.ShowMessageBox("Error", "Olympiad exist");
            }
        }

        private bool AddSportsmanCommandCanExecute(object arg)
        {
            if (string.IsNullOrEmpty(NewSportsmanName) || string.IsNullOrEmpty(NewSportsmanSurname)||
                string.IsNullOrEmpty(NewSportsmanName) || string.IsNullOrEmpty(NewSportsmanName) ||
                (DateTime.Now.Year - NewSportsmanBirthday.Year > 50) || (DateTime.Now.Year - NewSportsmanBirthday.Year < 18) ||
                (NewSportsmanCountry == null || NewSportsmanSport == null))
                return false;
            return true;
        }

        private void NewSportsmanSelectedCommandExecute(object obj)
        {
            SelectedSportsman = obj as Sportsman;
        }

        private void BrowseSportImageExecute(object obj)
        {
            NewSportImage = systemClass.GetImagePath("Sport");
        }

        private void AddSportCommandExecute(object obj)
        {
            string imagePath = string.IsNullOrEmpty(NewSportImage) ? @"C:\Users\ibrah\source\repos\Olympics\Olympics\Images\Sports\Default.jpg"
                : NewSportImage;

            var sport = new Sport(NewSportName, IsSummerSport ? Season.Summer : Season.Winter, NewSportDescription, imagePath);
            db.Sports.Add(sport);
            db.SaveChanges();

            FillSports();

            NewSportName = string.Empty;
            NewSportDescription = string.Empty;
            NewSportImage = string.Empty;
            IsSummerSport = true;

            systemClass.ShowMessageBox("Info", "Sport has been added!");
        }
        private bool AddSportCommandCanExecute(object arg)
        {
            if (string.IsNullOrEmpty(NewSportName) || db.Sports.ToList().Any(s => s.Name.ToLower() == NewSportName.ToLower().Replace(" ","")))
                return false;
            return true;
        }

        private void NewSportSelectedCommandExecute(object obj)
        {
            SelectedSport = obj as Sport;
        }

        private void FillCountries()
        {
            Countries.Clear();
            foreach (var item in db.Countries.ToList())
            {
                Countries.Add(item);
            }
            CountryCount = Countries.Count;
        }
        private void FillSports()
        {
            Sports.Clear();
            foreach (var item in db.Sports.ToList())
            {
                Sports.Add(item);
            }
            SportCount = Sports.Count;
        }
        private void FillSportsmen()
        {
            Sportsmen.Clear();
            foreach (var item in db.Sportsmen.ToList())
            {
                Sportsmen.Add(item);
            }
            SportsmenCount = Sportsmen.Count;
        }
        private void FillOlympiads()
        {
            Olympiads.Clear();
            foreach (var item in db.Olympiads.ToList())
            {
                Olympiads.Add(item);
            }
            OlympiadCount = Olympiads.Count;
        }
        private void FillEvents()
        {
            Events.Clear();
            foreach (var item in db.Events.ToList())
            {
                Events.Add(item);
            }
            EventCount = Events.Count;
        }
        private void FillSeasons()
        {
            Seasons.Clear();
            Seasons.Add(Season.Summer);
            Seasons.Add(Season.Winter);
        }
        private void FillMedalTypes()
        {
            MedalTypes.Clear();
            MedalTypes.Add(MedalType.Bronze);
            MedalTypes.Add(MedalType.Silver);
            MedalTypes.Add(MedalType.Gold);
        }
        private void FillParticipants()
        {
            Participants.Clear();
            foreach (var item in db.Participants.ToList())
            {
                Participants.Add(item);
            }
            ParticipantCount = Participants.Count;
        }

        private void BrowseCountryImageExecute(object obj)
        {
            NewCountryImage = systemClass.GetImagePath("Country");
        }

        private void AddCountryCommandExecute(object obj)
        {
            string imagePath = string.IsNullOrEmpty(NewCountryImage) ? @"C:\Users\ibrah\source\repos\Olympics\Olympics\Images\Countries\Default.png"
                : NewCountryImage;

            var newCountry = new Country(NewCountryName, imagePath);

            db.Countries.Add(newCountry);
            db.SaveChanges();

            FillCountries();

            NewCountryName = string.Empty;
            NewCountryImage = string.Empty;

            systemClass.ShowMessageBox("Info", "Country has been added!");
        }
        private bool AddCountryCommandCanExecute(object arg)
        {
            if (string.IsNullOrEmpty(NewCountryName) || db.Countries.ToList().Any(t => t.Name.ToLower() == NewCountryName.ToLower().Replace(" ", "")))
                return false;
            return true;
        }

        private void NewCountrySelectedExecute(object obj)
        {
            SelectedCountry = obj as Country;
            if (SelectedCountry == null) return;
            SelectedCountry.ImagePath = string.IsNullOrEmpty(SelectedCountry.ImagePath) ? @"C:\Users\ibrah\source\repos\Olympics\Olympics\Images\Countries\Default.png"
                : SelectedCountry.ImagePath;
        }


        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public bool AddSportToDatabase(Sport sport)
        {
            if (!db.Sports.ToList().Contains(sport))
            {
                var a = db.Sports.Add(sport);
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddSportsmanToDatabase(Sportsman sportsman)
        {
            if(!db.Sportsmen.ToList().Contains(sportsman))
            {
                db.Sportsmen.Add(sportsman);  // why always add new Country and Sport
                SaveChanges();
                return true;
            }
            return false;
        }
    }
}
