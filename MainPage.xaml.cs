using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using TechShop.Models;
using System.ComponentModel;


namespace TechShop
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            var items = new List<CollectionItem> //ovo je pak hardkodirana lista za carousel

            {
                new CollectionItem { Title = "NOVI LAPTOP: Hyper Beast 6000 Ultra Pro Max PREMIUM++ Edition!", Slika = "mainad.jpg", Scale = 1.25f },
                new CollectionItem { Title = "PREMIUM GAMING PC: Intel i13 - 15th GEN, RTX 4090, 64GB RAM-a, 2TB SSD!", Slika = "mainad2.jpg" },
                new CollectionItem { Title = "MULTIMEDIJALNI LAPTOP: Laptopp UltraBook G750, Intel i9 - 17th GEN!", Slika = "mainad3.jpg", Scale = 1.17f},
                new CollectionItem { Title = "RASPRODAJA: Mehaničke Tastature i Gaming Miševi na ULTRA POPUSTU!", Slika = "mainad4.jpg" },
                new CollectionItem { Title = "ASUS GX15 SOUND-X: Omnivoice Mikrofon u Najnovijem Izdanju, SAMO OD 129,99KM!", Slika = "mainad5.jpg" },
                new CollectionItem { Title = "PREDATOR-X 2000: SurroundSound u Vašim Ušima, Novi PREDATOR-X Model!", Slika = "mainad6.jpg" },
                new CollectionItem { Title = "FLAGSHIP SONY TV: Ultra LED HD+, 75 Inch-a, ULTRA Black Pixel Darkening Mod!", Slika = "mainad7.jpg" }
            };

            mainads.ItemsSource = items;
            StartCarousel();
        }

        private int _currentPosition = 0;
        private void StartCarousel() //metoda za carousel
        {
            Dispatcher.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                if (mainads.ItemsSource is IList<CollectionItem> images && images.Count > 0)
                {
                    _currentPosition = (_currentPosition + 1) % images.Count;
                    mainads.Position = _currentPosition;
                }

                return true; //vraca true da nastavi timer
            });
        }

        private async void OnKorpaClicked(object sender, EventArgs e) //samo navigacija
        {
            await Navigation.PushAsync(new Korpa());
        }

        private async void OnImageClicked(object sender, EventArgs e) //samo navigacija
        {
            var tappedImage = sender as Image;
            if (tappedImage != null)
            {
                var category = (string)((TapGestureRecognizer)tappedImage.GestureRecognizers[0]).CommandParameter;
                await Navigation.PushAsync(new ProductList(category));
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) //metoda za pretragu kategorija
        {
            var viewModel = BindingContext as MainPageViewModel;
            if (viewModel != null)
            {
                viewModel.FilterCategories(e.NewTextValue);
            }
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged //viewmodel za MainPage
    {
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private ObservableCollection<Category> AllCategories { get; set; }

        public MainPageViewModel()
        {
            AllCategories = new ObservableCollection<Category> // i <3 hard-coding image scales :D
                    {
                        new Category { Name = "AKCIJE", ImageSource = "sales.png", ImageScale = 2},
                        new Category { Name = "LAPTOPI", ImageSource = "laptops.png", ImageScale = 1.5},
                        new Category {Name = "RAČUNARI", ImageSource = "pc.png", ImageScale = 1.5},
                        new Category {Name = "TELEVIZORI", ImageSource = "tv.png", ImageScale = 1.5},
                        new Category {Name = "SLUŠALICE", ImageSource = "headphones.png", ImageScale = 1.5},
                        new Category {Name = "MONITORI", ImageSource = "monitor.png"},
                        new Category {Name = "U/I UREĐAJI", ImageSource = "kbm.png", ImageScale = 1.2},
                        new Category {Name = "MIKROFONI", ImageSource = "mic.png", ImageScale = 1.4},
                        new Category {Name = "KOMPONENTE", ImageSource = "cpu.png", ImageScale = 0.9},
                        new Category {Name = "MOBITELI", ImageSource = "phone.png", ImageScale = 1.1}
                    };
            Categories = new ObservableCollection<Category>(AllCategories);
        }

        public void FilterCategories(string searchText) //metoda za filtriranje kategorija na osnovu pretrage
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Categories = new ObservableCollection<Category>(AllCategories);
            }
            else
            {
                var filteredCategories = AllCategories.Where(c => c.Name.ToLower().Contains(searchText.ToLower())).ToList();
                Categories.Clear();
                foreach (var category in filteredCategories)
                {
                    Categories.Add(category);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; //event handler za promjenu property-a u viewmodelu (kada se promijeni lista kategorija, da se azurira i prikaz na MainPage-u)
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
