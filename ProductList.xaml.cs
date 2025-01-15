using System.Collections.ObjectModel;
using TechShop.Models;
using Microsoft.EntityFrameworkCore;

namespace TechShop
{
    public partial class ProductList : ContentPage
    {
        private string SelectedCategory { get; set; }
        public ObservableCollection<Product> ProductsCollection { get; set; }
        private List<Product> AllProducts { get; set; }

        public ProductList(string category) //ovo je samo konstruktor
        {
            InitializeComponent();
            SelectedCategory = category;
            ProductsCollection = new ObservableCollection<Product>();
            ProductsCollectionView.ItemsSource = ProductsCollection;
            LoadProducts();
        }

        private async void LoadProducts() //metoda za ucitavanje proizvoda
        {
            AllProducts = await GetProductsByCategoryAsync(SelectedCategory);
            foreach (var product in AllProducts)
            {
                ProductsCollection.Add(product);
            }
        }

        private async Task<List<Product>> GetProductsByCategoryAsync(string category) //metoda za dohvatanje proizvoda po kategoriji
        {
            using (var context = new ProductContext())
            {
                return await context.Products.Where(p => p.Category == category).ToListAsync();
            }
        }

        private void SearchBar_Proizvodi(object sender, TextChangedEventArgs e) //metoda za pretragu proizvoda
        {
            var searchText = e.NewTextValue.ToLower();
            ProductsCollection.Clear();
            var filteredProducts = AllProducts.Where(p =>
                p.Name.ToLower().Contains(searchText) ||
                p.Type.ToLower().Contains(searchText) ||
                p.Tag1.ToLower().Contains(searchText) ||
                p.Tag2.ToLower().Contains(searchText) ||
                p.Description.ToLower().Contains(searchText)).ToList();
            foreach (var product in filteredProducts)
            {
                ProductsCollection.Add(product);
            }
        }

        private async void OnProductTapped(object sender, EventArgs e) //metoda za otvaranje proizvoda
        {
            var tappedProduct = (sender as Frame)?.BindingContext as Product;
            if (tappedProduct != null)
            {
                await Navigation.PushAsync(new ProductPreview(tappedProduct));
            }
        }

        private async void OnLogoTapped(object sender, EventArgs e) //metoda za otvaranje glavne stranice
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnKorpaTapped(object sender, EventArgs e) //metoda za otvaranje korpe
        {
            await Navigation.PushAsync(new Korpa());
        }
    }
}
