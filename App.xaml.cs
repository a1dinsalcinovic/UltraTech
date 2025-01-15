using TechShop.Models;

namespace TechShop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeDatabase();

            MainPage = new NavigationPage(new MainPage());
        }

        private void InitializeDatabase()
        {
            using (var context = new ProductContext())
            {
                context.Database.EnsureDeleted(); // Deletes the database if it exists
                context.Database.EnsureCreated(); // Creates the database
            }
        }
    }

}
