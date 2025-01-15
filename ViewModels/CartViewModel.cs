using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TechShop.Models;
using TechShop.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.ViewModels
{
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
