using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhoneApp1.Model;
using PhoneApp1.ViewModel;

namespace PhoneApp1.ViewModel
{
    public class ViewModelArticle : ViewModelBase
    {
        private string _titre;
        private string _urlLink;
        private string _description;
        private string _author;
        private string _category;
        private string _comments;
        private string _enclosure;
        private string _guid;
        private string _pubDate;
        private string _source;
        public ICommand ChargerArticleCommand { get; private set; }

        public string Titre
        {
            get { return _titre; }
            set
            {
                if (_titre == value)
                    return;
                _titre = value;
                NotifyPropertyChanged("Titre");
            }
        }
        public string UrlLink
        {
            get { return _urlLink; }
            set
            {
                if (_urlLink == value)
                    return;
                _urlLink = value;
                NotifyPropertyChanged("UrlLink");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                    return;
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author == value)
                    return;
                _author = value;
                NotifyPropertyChanged("Author");
            }
        }
        public string Categorie
        {
            get { return _category; }
            set
            {
                if (_category == value)
                    return;
                _category = value;
                NotifyPropertyChanged("Categorie");
            }
        }
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments == value)
                    return;
                _comments = value;
                NotifyPropertyChanged("Comments");
            }
        }
        public string Enclosure
        {
            get { return _enclosure; }
            set
            {
                if (_enclosure == value)
                    return;
                _enclosure = value;
                NotifyPropertyChanged("Enclosure");
            }
        }
        public string Guid
        {
            get { return _guid; }
            set
            {
                if (_guid == value)
                    return;
                _guid = value;
                NotifyPropertyChanged("Guid");
            }
        }
        public string PubDate
        {
            get { return _pubDate; }
            set
            {
                if (_pubDate == value)
                    return;
                _pubDate = value;
                NotifyPropertyChanged("PubDate");
            }
        }
        public string Source
        {
            get { return _source; }
            set
            {
                if (_source == value)
                    return;
                _source = value;
                NotifyPropertyChanged("Source");
            }
        }

        public ViewModelArticle()   
        {
            ChargerArticleCommand = new RelayCommand(ChargeArticle);
        }

        public void ChargeArticle()
        {
            Services service = new Services();
            ModelArticle article = service.LoadArticle();
            Titre = article._titre;
            UrlLink = article._urlLink;
            Description = article._description;
            Author = article._author;
            Categorie = article._category;
            Comments = article._comments;
            Enclosure = article._enclosure;
            Guid = article._guid;
            PubDate = article._pubDate;
            Source = article._source;
        }
    }
}
