using TechShop.Models;
using TechShop.Services;


namespace TechShop;

public partial class ProductPreview : ContentPage
{
    private Product _selectedProduct;
    private int selectedRating = 0;
    private readonly RecenzijaService recenzijaService;

    public ProductPreview(Product selectedProduct) //samo jedan konstruktor
    {
        InitializeComponent();
        _selectedProduct = selectedProduct;
        recenzijaService = new RecenzijaService();
        InitializeRatingFrames();
        LoadProductDetails(selectedProduct);
        LoadProductReviews(selectedProduct.Id);
    }

    private async void OnBackTapped(object sender, EventArgs e) //samo jedan event handler
    {
        await Navigation.PopAsync();
    }

    private async void OnKorpaTapped(object sender, EventArgs e) //opet samo jedan event handler
    {
        await Navigation.PushAsync(new Korpa());
    }

    private async void OnLogoTapped(object sender, EventArgs e) //nikad neces pogoditi
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void LoadProductDetails(Product product) //metoda za ucitavanje detalja proizvoda
    {
        ProductImage.Source = product.Image;
        ProductName.Text = product.Name;
        ProductType.Text = product.Type;
        Tag1.Text = product.Tag1;
        Tag2.Text = product.Tag2;
        OldPrice.Text = product.OldPrice.ToString("C");
        NewPrice.Text = product.NewPrice.ToString("C");
        ProductDescription.Text = product.Description;
    }

    private void LoadProductReviews(int productId) //metoda za ucitavanje recenzija proizvoda
    {
        using (var context = new ProductContext())
        {
            var reviews = context.Recenzije.Where(r => r.ProductId == productId).ToList();
            ReviewsStackLayout.Children.Clear();

            if (reviews.Any())
            {
                double averageRating = Math.Floor(reviews.Average(r => r.Ocjena));
                DisplayAverageRating(averageRating);
            }
            else
            {
                DisplayAverageRating(0);
            }

            foreach (var review in reviews)
            {
                var reviewLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(20),
                    HeightRequest = 150,
                    WidthRequest = 250
                };

                var reviewHeader = new FlexLayout
                {
                    JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceBetween
                };

                var reviewerName = new Label
                {
                    Text = review.Ime,
                    FontSize = 16,
                    FontAttributes = FontAttributes.Bold
                };

                var ratingLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 7
                };

                for (int i = 0; i < 5; i++)
                {
                    var starFrame = new Frame
                    {
                        BorderColor = Colors.Gray,
                        Rotation = 45,
                        HeightRequest = 10,
                        WidthRequest = 10,
                        CornerRadius = 3,
                        BackgroundColor = i < review.Ocjena ? Colors.Gold : Colors.LightGray
                    };
                    ratingLayout.Children.Add(starFrame);
                }

                reviewHeader.Children.Add(reviewerName);
                reviewHeader.Children.Add(ratingLayout);

                var reviewComment = new Label
                {
                    Text = review.Komentar,
                    Margin = new Thickness(0, 10, 0, 0)
                };

                reviewLayout.Children.Add(reviewHeader);
                reviewLayout.Children.Add(reviewComment);

                ReviewsStackLayout.Children.Add(reviewLayout);
            }
        }
    }

    private void DisplayAverageRating(double averageRating) //metoda za prikaz prosjecne ocjene
    {
        AverageRatingLayout.Children.Clear();
        for (int i = 0; i < 5; i++)
        {
            var starFrame = new Frame
            {
                BorderColor = Colors.Gray,
                Rotation = 45,
                HeightRequest = 25,
                WidthRequest = 25,
                CornerRadius = 3,
                BackgroundColor = i < averageRating ? Colors.Gold : Colors.LightGray
            };
            AverageRatingLayout.Children.Add(starFrame);
        }
    }

    private void OnAddToCartTapped(object sender, EventArgs e) //metoda za dodavanje proizvoda u korpu
    {
        CartService.Instance.AddToCart(_selectedProduct);
        DisplayAlert("Dodano u korpu", "Proizvod uspješno dodan u korpu.", "OK");
    }

    private async void OnKorpaClicked(object sender, EventArgs e) //samo navigacija 
    {
        await Navigation.PushAsync(new Korpa());
    }

    private void InitializeRatingFrames() //metoda za inicijalizaciju ocjena
    {
        var ratingFrames = new[] { ocjena1, ocjena2, ocjena3, ocjena4, ocjena5 };
        for (int i = 0; i < ratingFrames.Length; i++)
        {
            int rating = i + 1;
            ratingFrames[i].GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => SetRating(rating))
            });
        }
    }

    private void SetRating(int rating) //metoda za postavljanje ocjene
    {
        selectedRating = rating;
        var ratingFrames = new[] { ocjena1, ocjena2, ocjena3, ocjena4, ocjena5 };
        for (int i = 0; i < ratingFrames.Length; i++)
        {
            ratingFrames[i].BackgroundColor = i < rating ? Colors.Gold : Colors.LightGray;
        }
    }

    private async void OnSubmitReviewClicked(object sender, EventArgs e) //metoda za slanje recenzije
    {
        var recenzija = new Recenzija
        {
            Ime = nazivKorisnika.Text,
            Ocjena = selectedRating,
            Komentar = sadrzajRecenzije.Text,
            ProductId = _selectedProduct.Id
        };

        recenzijaService.AddRecenzija(recenzija);

        await DisplayAlert("Uspjeh", "Vaša recenzija je spremljena.", "OK");
        LoadProductReviews(_selectedProduct.Id);
    }
}
