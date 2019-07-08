using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PhoneApp1.PrivateService;
using PhoneApp1.PublicService;
using PhoneApp1.Tools;
using PhoneApp1.ViewModel;

namespace PhoneApp1.ViewModel
{
    #region OLD Bastien's code
    //public partial class ViewModelMainPage : INotifyPropertyChanged
    //{
    //    //private Services _service;
        
    //    //// -> FLUX (F)
    //    //private List<RssChannel> _FFlux;
    //    //public ICommand ChargerFluxCommand { get; private set; }
    //    //public List<RssChannel> FFlux
    //    //{
    //    //    get { return _FFlux; }
    //    //    set
    //    //    {
    //    //        if (_FFlux == value)
    //    //            return;
    //    //        _FFlux = value;
    //    //        NotifyPropertyChanged("FFlux");
    //    //    }
    //    //}
    //    //// <- FLUX

    //    //// -> CATEGORIES (C)
    //    //private List<Category> _CCategories;
    //    //private string _CName;
    //    //public ICommand ChargerCategoriesCommand { get; private set; }

    //    //public List<Category> CCategories
    //    //{
    //    //    get { return _CCategories; }
    //    //    set
    //    //    {
    //    //        if (_CCategories == value)
    //    //            return;
    //    //        _CCategories = value;
    //    //        NotifyPropertyChanged("CCategories");
    //    //    }
    //    //}
    //    //public string CName
    //    //{
    //    //    get { return _CName; }
    //    //    set
    //    //    {
    //    //        if (_CName == value)
    //    //            return;
    //    //        _CName = value;
    //    //        NotifyPropertyChanged("CName");
    //    //    }
    //    //}
    //    //// <- CATEGORIES

    //    //// -> ARTICLES (S)
    //    //private string _STitre;
    //    //private List<ModelArticle> _SArticles;
    //    //private string _SUrlLink;
    //    //private string _SDescription;
    //    //public ICommand ChargerArticlesCommand { get; private set; }

    //    //public string STitre
    //    //{
    //    //    get { return _STitre; }
    //    //    set
    //    //    {
    //    //        if (_STitre == value)
    //    //            return;
    //    //        _STitre = value;
    //    //        NotifyPropertyChanged("STitre");
    //    //    }
    //    //}
    //    //public string SUrlLink
    //    //{
    //    //    get { return _SUrlLink; }
    //    //    set
    //    //    {
    //    //        if (_SUrlLink == value)
    //    //            return;
    //    //        _SUrlLink = value;
    //    //        NotifyPropertyChanged("SUrlLink");
    //    //    }
    //    //}
    //    //public string SDescription
    //    //{
    //    //    get { return _SDescription; }
    //    //    set
    //    //    {
    //    //        if (_SDescription == value)
    //    //            return;
    //    //        _SDescription = value;
    //    //        NotifyPropertyChanged("SDescription");
    //    //    }
    //    //}
    //    //public List<ModelArticle> SArticles
    //    //{
    //    //    get { return _SArticles; }
    //    //    set
    //    //    {
    //    //        if (_SArticles == value)
    //    //            return;
    //    //        _SArticles = value;
    //    //        NotifyPropertyChanged("SArticles");
    //    //    }
    //    //}
    //    //// <- ARTICLES

    //    //// -> ARTICLE (A)
    //    //private string _ATitre;
    //    //private string _AUrlLink;
    //    //private string _ADescription;
    //    //private string _AAuthor;
    //    //private string _ACategory;
    //    //private string _AComments;
    //    //private string _AEnclosure;
    //    //private string _AGuid;
    //    //private string _APubDate;
    //    //private string _ASource;
    //    //public ICommand ChargerArticleCommand { get; private set; }

    //    //public string ATitre
    //    //{
    //    //    get { return _ATitre; }
    //    //    set
    //    //    {
    //    //        if (_ATitre == value)
    //    //            return;
    //    //        _ATitre = value;
    //    //        NotifyPropertyChanged("ATitre");
    //    //    }
    //    //}
    //    //public string AUrlLink
    //    //{
    //    //    get { return _AUrlLink; }
    //    //    set
    //    //    {
    //    //        if (_AUrlLink == value)
    //    //            return;
    //    //        _AUrlLink = value;
    //    //        NotifyPropertyChanged("AUrlLink");
    //    //    }
    //    //}
    //    //public string ADescription
    //    //{
    //    //    get { return _ADescription; }
    //    //    set
    //    //    {
    //    //        if (_ADescription == value)
    //    //            return;
    //    //        _ADescription = value;
    //    //        NotifyPropertyChanged("ADescription");
    //    //    }
    //    //}
    //    //public string AAuthor
    //    //{
    //    //    get { return _AAuthor; }
    //    //    set
    //    //    {
    //    //        if (_AAuthor == value)
    //    //            return;
    //    //        _AAuthor = value;
    //    //        NotifyPropertyChanged("AAuthor");
    //    //    }
    //    //}
    //    //public string ACategorie
    //    //{
    //    //    get { return _ACategory; }
    //    //    set
    //    //    {
    //    //        if (_ACategory == value)
    //    //            return;
    //    //        _ACategory = value;
    //    //        NotifyPropertyChanged("ACategorie");
    //    //    }
    //    //}
    //    //public string AComments
    //    //{
    //    //    get { return _AComments; }
    //    //    set
    //    //    {
    //    //        if (_AComments == value)
    //    //            return;
    //    //        _AComments = value;
    //    //        NotifyPropertyChanged("AComments");
    //    //    }
    //    //}
    //    //public string AEnclosure
    //    //{
    //    //    get { return _AEnclosure; }
    //    //    set
    //    //    {
    //    //        if (_AEnclosure == value)
    //    //            return;
    //    //        _AEnclosure = value;
    //    //        NotifyPropertyChanged("AEnclosure");
    //    //    }
    //    //}
    //    //public string AGuid
    //    //{
    //    //    get { return _AGuid; }
    //    //    set
    //    //    {
    //    //        if (_AGuid == value)
    //    //            return;
    //    //        _AGuid = value;
    //    //        NotifyPropertyChanged("AGuid");
    //    //    }
    //    //}
    //    //public string APubDate
    //    //{
    //    //    get { return _APubDate; }
    //    //    set
    //    //    {
    //    //        if (_APubDate == value)
    //    //            return;
    //    //        _APubDate = value;
    //    //        NotifyPropertyChanged("APubDate");
    //    //    }
    //    //}
    //    //public string ASource
    //    //{
    //    //    get { return _ASource; }
    //    //    set
    //    //    {
    //    //        if (_ASource == value)
    //    //            return;
    //    //        _ASource = value;
    //    //        NotifyPropertyChanged("ASource");
    //    //    }
    //    //}
    //    //// <- ARTICLE

    //    //public ViewModelMainPage()   
    //    //{
    //    //    _service = new Services();
    //    //    ChargerArticleCommand = new RelayCommand(ChargeArticle);
    //    //    ChargerArticlesCommand = new RelayCommand(ChargeArticles);
    //    //    ChargerCategoriesCommand = new RelayCommand(ChargeCategories);
    //    //    ChargerFluxCommand = new RelayCommand(ChargeFlux);
    //    //}

    //    //public void ChargeFlux()
    //    //{
    //    //    ModelFlux flux = _service.LoadFlux();
    //    //    FFlux = flux._lFlux;
    //    //}

    //    //public void ChargeCategories()
    //    //{
    //    //    ModelCategorie categories = _service.LoadCategories();
    //    //    CCategories = categories._lCategories;
    //    //    CName = categories._name;
    //    //}

    //    //public void ChargeArticle()
    //    //{
    //    //    ModelArticle article = _service.LoadArticle();
    //    //    ATitre = article._titre;
    //    //    AUrlLink = article._urlLink;
    //    //    ADescription = article._description;
    //    //    AAuthor = article._author;
    //    //    ACategorie = article._category;
    //    //    AComments = article._comments;
    //    //    AEnclosure = article._enclosure;
    //    //    AGuid = article._guid;
    //    //    APubDate = article._pubDate;
    //    //    ASource = article._source;
    //    //}

    //    //public void ChargeArticles()
    //    //{
    //    //    ModelArticles articles = _service.LoadArticles();
    //    //    STitre = articles._titre;
    //    //    SUrlLink = articles._urlLink;
    //    //    SDescription = articles._description;
    //    //    SArticles = articles._articles;
    //    //}
    //}
    #endregion

    public partial class ViewModelMainPage : INotifyPropertyChanged
    {
        #region Properties

        //ServiceContractClient _serveur;
        PublicServiceContractClient _pubServeur;

        private int _selectedTabIndexUser;
        public int SelectedTabIndex
        {
            get { return _selectedTabIndexUser; }
            set
            {
                _selectedTabIndexUser = value;
                NotifyPropertyChanged("SelectedTabIndex");
            }
        }

        private string _debugText;
        public string DebugText
        {
            get { return _debugText; }
            set
            {
                _debugText = value;
                NotifyPropertyChanged("DebugText");
            }
        }

        private bool _isTabControlEnabled;
        public bool IsTabControlEnabled
        {
            get { return _isTabControlEnabled; }
            set
            {
                _isTabControlEnabled = value;
                NotifyPropertyChanged("IsTabControlEnabled");
            }
        }

        private bool _isSettingsFloutOppenned;
        public bool IsSettingsFloutOppenned
        {
            get { return _isSettingsFloutOppenned;; }
            set
            {
                _isSettingsFloutOppenned = value;
                NotifyPropertyChanged("IsSettingsFloutOppenned");
            }
        }

        private bool _isProgressRingActive;
        public bool IsProgressRingActive
        {
            get { return _isProgressRingActive; ; }
            set
            {
                _isProgressRingActive = value;
                NotifyPropertyChanged("IsProgressRingActive");
            }
        }

        public ICommand ViewSettingsCmd { get; set; }
        public ICommand ViewSettingsCmdValidate { get; set; }
        public ICommand OpenInBrowserCmd { get; set; }

        #endregion


        #region Constructor


        public void testCompleted(object sender, PrivateService.getCategoriesCompletedEventArgs e)
        {
            var Catlist = e.Result.ToString();
            MessageBox.Show(Catlist.GetType().ToString());
        }

        public ViewModelMainPage()
        {
            //_serveur = new ServiceContractClient();
            //_serveur.ClientCredentials.UserName.UserName = "jerem";
            //_serveur.ClientCredentials.UserName.Password = "pass";
            //_serveur.authenticateAsync("jerem", "pass");

            //_serveur.getCategoriesCompleted += new EventHandler<getCategoriesCompletedEventArgs>(testCompleted);


            AccountLoginText = "OUech";


            ConnectionErrorText = "";

            IsLoggedIn = false;
            IsTabControlEnabled = true;
            LogMessage = "LOG IN";

            // TODO : A supprimer
            DebugText = "";

            // Fonction appelant les initialisation des COMMANDs
            LogUser();
            LoadEntities();
            ManageUser();
            ManageCategories();
            ManageChannels();
            ManageItems();
        }



        #endregion


        #region Methods

        private void LoadEntities()
        {   

            // ******** chargement d'une catégorie *********
            LoadCategoryCmd = new CommandWithParameter(new Action<Object>((o) =>
            {
                var test = o as int?;
                if (SelectedCategory != null)
                {
                    CurrentCategory = SelectedCategory;
                    SelectedTabIndex = (int)ToolsBox.TabIndex.TAB_CHANNEL;

                    ChannelTitleText = CurrentCategory.Name;
                    ChannelsList = null;
                    // ChannelsList = _serveur.getRssChannelsInCategoryWithCategoryName(CurrentCategory.Name);
                }
            }));

            // ******** chargement d'un channel *********
            LoadChannelCmd = new Command(new Action(async () =>
            {
                if (SelectedChannel != null)
                {
                    CurrentChannel = SelectedChannel;
                    SelectedTabIndex = (int)ToolsBox.TabIndex.TAB_ITEMS;
                    try
                    {
                        ItemsTitleText = CurrentChannel.Title;
                        ItemsList = null;
                        IsProgressRingActive = true;
                        // ItemsList = await _serveur.getRssItemsWithChannelIdAsync(CurrentChannel.IdEntity);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null)
                            DebugText = e.InnerException.Message;
                        else
                            DebugText = e.Message;
                    }
                    IsProgressRingActive = false;
                }
            }));


            // ******** chargement d'un item *********
            LoadItemCmd = new Command(new Action(() =>
            {
                if (SelectedItem != null)
                {
                    CurrentItem = SelectedItem;
                    SelectedTabIndex = (int)ToolsBox.TabIndex.TAB_VIEWER;
                    // CurrentItem.SetLu()
                    try
                    {
                        CurrentItem.IsRead = true;
                        IsProgressRingActive = true;
                        //_serveur.setItemAsRead(CurrentItem.IdEntity);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null)
                            DebugText = e.InnerException.Message;
                        else
                            DebugText = e.Message;
                    }
                    IsProgressRingActive = false;
                }
            }));


            // ******** chargement de toutes les catégories *********
            LoadAllCategoriesCmd = new Command(new Action(async () =>
            {
                try
                {
                    SelectedTabIndex = (int)ToolsBox.TabIndex.TAB_CHANNEL;
                    IsProgressRingActive = true;

                    CurrentCategory = null;
                    ChannelsList = null;
                    //ChannelsList = await _serveur.getRssChannelsAsync();

                    ChannelTitleText = "All Channels";
                }
                catch (Exception e)
                {
                    IsProgressRingActive = false;
                    if (e.InnerException != null)
                        DebugText = "[Exception]" + e.InnerException.Message;
                    else
                        DebugText = "[Exception]" + e.Message;
                }
                IsProgressRingActive = false;
            }));


            // ******** chargement de tous les items de tous les channels d'une catégorie  *********
            LoadAllChannelsCmd = new Command(new Action(async () =>
            {
                if (CurrentCategory == null)
                    LoadAllItemsCmd.Execute(null);
                try
                {
                    SelectedTabIndex = (int)ToolsBox.TabIndex.TAB_ITEMS;
                    ItemsTitleText = "All items In " + CurrentCategory.Name;
                    IsProgressRingActive = true;
                    ItemsList = null;
                    await LoadAllItemsOfChannels();
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                        DebugText = "[Exception]" + e.InnerException.Message;
                    else
                        DebugText = "[Exception]" + e.Message;
                }
                IsProgressRingActive = false;
            }));


            // ******** chargement de tous les items *********
            LoadAllItemsCmd = new Command(new Action(async () =>
            {
                SelectedTabIndex = (int)ToolsBox.TabIndex.TAB_ITEMS;
                
                try
                {
                    ItemsTitleText = "All items";
                    IsProgressRingActive = true;
                    ItemsList = null;
                    await LoadAllItemsOfCategories();
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                        DebugText = "[Exception]" + e.InnerException.Message;
                    else
                        DebugText = "[Exception]" + e.Message;
                }
                IsProgressRingActive = false;
            }));
        }


        async public Task LoadAllItemsOfChannels()
        {
            var list = new List<RssItem>();
            foreach (var channel in ChannelsList)
            {
                //var listOfItems = await _serveur.getRssItemsWithChannelIdAsync(channel.IdEntity);
                //if (listOfItems == null)
                //    continue;
                //list.AddRange(listOfItems);
            }
            ItemsList = null;
            ItemsList = list;
            //ItemsList = _serveur.GetRssItemsWithCategoryId(CurrentCategory.IdEntity);
        }

        async public Task LoadAllItemsOfCategories()
        {
            var list = new List<RssItem>();
            foreach (var category in CategoryList)
            {
                //var listOfChannels = await _serveur.getRssChannelsInCategoryWithIdCategoryAsync(category.IdEntity);
                //if (listOfChannels == null)
                //    continue;
                //foreach (var channel in listOfChannels)
                //{
                //    var listOfItems = await _serveur.getRssItemsWithChannelIdAsync(channel.IdEntity);
                //    if (listOfItems == null)
                //        continue;
                //    list.AddRange(listOfItems);
                //}
            }
            ItemsList = null;
            ItemsList = list;
        }


        public void ReinitiateData()
        {
            CategoryList = null;
            ChannelsList = null;
            ItemsList = null;
            CurrentCategory = null;
            CurrentChannel = null;
            CurrentItem = null;
            CurrentUserName = null;
            DebugText = "";
            FlyoutMessage = "";
        }


        #endregion

    }
}
