using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TechShop.Services
{
    public class CartService : INotifyPropertyChanged
    {
        private static readonly Lazy<CartService> lazy = new Lazy<CartService>(() => new CartService());
        public static CartService Instance => lazy.Value;

        public ObservableCollection<Product> CartItems { get; private set; }

        private CartService()
        {
            CartItems = new ObservableCollection<Product>();
            CartItems.CollectionChanged += (s, e) => OnCartItemsChanged();
        }

        public void AddToCart(Product product)
        {
            CartItems.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            CartItems.Remove(product);
        }

        public decimal TotalPrice => CartItems.Sum(item => item.NewPrice);

        private void OnCartItemsChanged()
        {
            OnPropertyChanged(nameof(TotalPrice));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class CartViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> CartItems => CartService.Instance.CartItems;
        public decimal TotalPrice => CartService.Instance.TotalPrice;

        public ICommand RemoveFromCartCommand { get; }

        public CartViewModel()
        {
            RemoveFromCartCommand = new Command<Product>(RemoveFromCart);
            CartService.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(CartService.TotalPrice))
                {
                    OnPropertyChanged(nameof(TotalPrice));
                }
            };
        }

        private void RemoveFromCart(Product product)
        {
            CartService.Instance.RemoveFromCart(product);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
