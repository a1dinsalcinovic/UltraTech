using Microsoft.EntityFrameworkCore;

namespace TechShop.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "techshop.db");
            if (!File.Exists(dbPath))
            {
                Console.WriteLine("Database ne postoji. Kreirati ce se.");
            }
            else
            {
                Console.WriteLine("Database postoji.");
            }
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Recenzije)
                .WithOne()
                .HasForeignKey(r => r.ProductId);


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Biznis Laptop", Type = "ASUS Pro G150", Tag1 = "Posao", Tag2 = "Laptop", OldPrice = 1200, NewPrice = 1000, Image = "Resources/Images/laptop1.jpg", Description = "Odličan laptop za poslovne korisnike.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 2, Name = "Gaming Laptop", Type = "MSI Stealth 15M", Tag1 = "Gaming", Tag2 = "Laptop", OldPrice = 1500, NewPrice = 1300, Image = "Resources/Images/laptop2.jpg", Description = "Visokoperformansni laptop za gaming.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 3, Name = "UltraBook", Type = "Dell XPS 13", Tag1 = "UltraBook", Tag2 = "Laptop", OldPrice = 1400, NewPrice = 1200, Image = "Resources/Images/laptop3.jpg", Description = "Tanak i lagan laptop za svakodnevnu upotrebu.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 4, Name = "StudyBook", Type = "HP Pavilion 14", Tag1 = "Student", Tag2 = "Laptop", OldPrice = 0, NewPrice = 800, Image = "Resources/Images/laptop4.jpg", Description = "Savršen laptop za studente.", Category = "LAPTOPI", Popust = false },

                new Product { Id = 5, Name = "Gaming PC", Type = "Alienware Aurora R10", Tag1 = "Gaming", Tag2 = "PC", OldPrice = 2000, NewPrice = 1800, Image = "Resources/Images/pc1.jpg", Description = "Visokoperformansni gaming računar.", Category = "RAČUNARI", Popust = true },
                new Product { Id = 6, Name = "Biznis PC", Type = "Lenovo ThinkCentre M720", Tag1 = "Posao", Tag2 = "PC", OldPrice = 1200, NewPrice = 1000, Image = "Resources/Images/pc2.jpg", Description = "Pouzdan računar za poslovne korisnike.", Category = "RAČUNARI", Popust = true },
                new Product { Id = 7, Name = "All-in-One PC", Type = "Apple iMac 24", Tag1 = "All-in-One", Tag2 = "PC", OldPrice = 1800, NewPrice = 1600, Image = "Resources/Images/pc3.jpg", Description = "Sve-u-jednom računar za svakodnevnu upotrebu.", Category = "RAČUNARI", Popust = true },
                new Product { Id = 8, Name = "Student PC", Type = "Acer Aspire TC", Tag1 = "Student", Tag2 = "PC", OldPrice = 0, NewPrice = 600, Image = "Resources/Images/pc4.jpg", Description = "Računar za studente.", Category = "RAČUNARI", Popust = false },

                new Product { Id = 9, Name = "Gaming Monitor", Type = "ASUS ROG Swift PG259QN", Tag1 = "Gaming", Tag2 = "Monitor", OldPrice = 700, NewPrice = 600, Image = "Resources/Images/monitor1.jpg", Description = "Visokoperformansni gaming monitor.", Category = "MONITORI", Popust = true },
                new Product { Id = 10, Name = "Biznis Monitor", Type = "Dell UltraSharp U2720Q", Tag1 = "Posao", Tag2 = "Monitor", OldPrice = 800, NewPrice = 700, Image = "Resources/Images/monitor2.jpg", Description = "Monitor za poslovne korisnike.", Category = "MONITORI", Popust = true },
                new Product { Id = 11, Name = "4K Monitor", Type = "LG 27UK850-W", Tag1 = "4K", Tag2 = "Monitor", OldPrice = 600, NewPrice = 500, Image = "Resources/Images/monitor3.jpg", Description = "4K monitor za svakodnevnu upotrebu.", Category = "MONITORI", Popust = true },
                new Product { Id = 12, Name = "Student Monitor", Type = "HP 24mh", Tag1 = "Student", Tag2 = "Monitor", OldPrice = 0, NewPrice = 250, Image = "Resources/Images/monitor4.jpg", Description = "Monitor za studente.", Category = "MONITORI", Popust = false },

                new Product { Id = 13, Name = "Gaming Televizor", Type = "Samsung QN90A Neo QLED", Tag1 = "Gaming", Tag2 = "Televizor", OldPrice = 1500, NewPrice = 1300, Image = "Resources/Images/tv1.jpg", Description = "Visokoperformansni gaming televizor.", Category = "TELEVIZORI", Popust = true },
                new Product { Id = 14, Name = "Smart Televizor", Type = "LG CX OLED", Tag1 = "Smart", Tag2 = "Televizor", OldPrice = 1800, NewPrice = 1600, Image = "Resources/Images/tv2.jpg", Description = "Smart televizor za svakodnevnu upotrebu.", Category = "TELEVIZORI", Popust = true },
                new Product { Id = 15, Name = "4K Televizor", Type = "Sony X900H", Tag1 = "4K", Tag2 = "Televizor", OldPrice = 1200, NewPrice = 1000, Image = "Resources/Images/tv3.jpg", Description = "4K televizor za svakodnevnu upotrebu.", Category = "TELEVIZORI", Popust = true },
                new Product { Id = 16, Name = "Student Televizor", Type = "TCL 6-Series", Tag1 = "Student", Tag2 = "Televizor", OldPrice = 0, NewPrice = 600, Image = "Resources/Images/tv4.jpg", Description = "Televizor za studente.", Category = "TELEVIZORI", Popust = false },

                new Product { Id = 17, Name = "Gaming Slušalice", Type = "HyperX Cloud II", Tag1 = "Gaming", Tag2 = "Slušalice", OldPrice = 120, NewPrice = 100, Image = "Resources/Images/slusalice1.jpg", Description = "Visokoperformansne gaming slušalice.", Category = "SLUŠALICE", Popust = true },
                new Product { Id = 18, Name = "Biznis Slušalice", Type = "Bose QuietComfort 35 II", Tag1 = "Posao", Tag2 = "Slušalice", OldPrice = 270, NewPrice = 200, Image = "Resources/Images/slusalice2.jpg", Description = "Slušalice za poslovne korisnike.", Category = "SLUŠALICE", Popust = true },
                new Product { Id = 19, Name = "Bežične Slušalice", Type = "Sony WH-1000XM4", Tag1 = "Bežične", Tag2 = "Slušalice", OldPrice = 300, NewPrice = 250, Image = "Resources/Images/slusalice3.jpg", Description = "Bežične slušalice za svakodnevnu upotrebu.", Category = "SLUŠALICE", Popust = true },
                new Product { Id = 20, Name = "Student Slušalice", Type = "JBL Tune 500BT", Tag1 = "Student", Tag2 = "Slušalice", OldPrice = 0, NewPrice = 80, Image = "Resources/Images/slusalice4.jpg", Description = "Slušalice za studente.", Category = "SLUŠALICE", Popust = false },

                new Product { Id = 21, Name = "Gaming Mikrofon", Type = "Blue Yeti", Tag1 = "Gaming", Tag2 = "Mikrofon", OldPrice = 150, NewPrice = 130, Image = "Resources/Images/mikrofon1.jpg", Description = "Visokoperformansni gaming mikrofon.", Category = "MIKROFONI", Popust = true },
                new Product { Id = 22, Name = "Biznis Mikrofon", Type = "Shure MV5", Tag1 = "Posao", Tag2 = "Mikrofon", OldPrice = 120, NewPrice = 100, Image = "Resources/Images/mikrofon2.jpg", Description = "Mikrofon za poslovne korisnike.", Category = "MIKROFONI", Popust = true },
                new Product { Id = 23, Name = "Podcast Mikrofon", Type = "Rode NT-USB", Tag1 = "Podcast", Tag2 = "Mikrofon", OldPrice = 200, NewPrice = 180, Image = "Resources/Images/mikrofon3.jpg", Description = "Mikrofon za podcaste.", Category = "MIKROFONI", Popust = true },
                new Product { Id = 24, Name = "Student Mikrofon", Type = "Samson Go Mic", Tag1 = "Student", Tag2 = "Mikrofon", OldPrice = 0, NewPrice = 60, Image = "Resources/Images/mikrofon4.jpg", Description = "Mikrofon za studente.", Category = "MIKROFONI", Popust = false },

                new Product { Id = 25, Name = "Gaming Komponente", Type = "NVIDIA GeForce RTX 3080", Tag1 = "Gaming", Tag2 = "Komponente", OldPrice = 800, NewPrice = 700, Image = "Resources/Images/komponente1.jpg", Description = "Visokoperformansne gaming komponente.", Category = "KOMPONENTE", Popust = true },
                new Product { Id = 26, Name = "Biznis Komponente", Type = "Intel Core i7-10700K", Tag1 = "Posao", Tag2 = "Komponente", OldPrice = 400, NewPrice = 350, Image = "Resources/Images/komponente2.jpg", Description = "Komponente za poslovne korisnike.", Category = "KOMPONENTE", Popust = true },
                new Product { Id = 27, Name = "RAM Memorija", Type = "Corsair Vengeance LPX 16GB", Tag1 = "RAM", Tag2 = "Komponente", OldPrice = 150, NewPrice = 130, Image = "Resources/Images/komponente3.jpg", Description = "RAM memorija za svakodnevnu upotrebu.", Category = "KOMPONENTE", Popust = true },
                new Product { Id = 28, Name = "SSD Disk", Type = "Samsung 970 EVO 1TB", Tag1 = "SSD", Tag2 = "Komponente", OldPrice = 0, NewPrice = 180, Image = "Resources/Images/komponente4.jpg", Description = "SSD disk za svakodnevnu upotrebu.", Category = "KOMPONENTE", Popust = false },

                new Product { Id = 29, Name = "Gaming Mobitel", Type = "ASUS ROG Phone 5", Tag1 = "Gaming", Tag2 = "Mobitel", OldPrice = 1000, NewPrice = 900, Image = "Resources/Images/mobitel1.jpg", Description = "Visokoperformansni gaming mobitel.", Category = "MOBITELI", Popust = true },
                new Product { Id = 30, Name = "Biznis Mobitel", Type = "Samsung Galaxy Note 20", Tag1 = "Posao", Tag2 = "Mobitel", OldPrice = 1200, NewPrice = 1100, Image = "Resources/Images/mobitel2.jpg", Description = "Mobitel za poslovne korisnike.", Category = "MOBITELI", Popust = true },
                new Product { Id = 31, Name = "Smartphone", Type = "Apple iPhone 12", Tag1 = "Smartphone", Tag2 = "Mobitel", OldPrice = 1300, NewPrice = 1200, Image = "Resources/Images/mobitel3.jpg", Description = "Smartphone za svakodnevnu upotrebu.", Category = "MOBITELI", Popust = true },
                new Product { Id = 32, Name = "Student Mobitel", Type = "OnePlus Nord", Tag1 = "Student", Tag2 = "Mobitel", OldPrice = 0, NewPrice = 450, Image = "Resources/Images/mobitel4.jpg", Description = "Mobitel za studente.", Category = "MOBITELI", Popust = false },

                new Product { Id = 33, Name = "Akcija 1", Type = "Type1", Tag1 = "TagA", Tag2 = "TagB", OldPrice = 120, NewPrice = 100, Image = "Resources/Images/akcija1.jpg", Description = "Sample Product", Category = "AKCIJE", Popust = true },
                new Product { Id = 34, Name = "Akcija 2", Type = "Type2", Tag1 = "TagC", Tag2 = "TagD", OldPrice = 270, NewPrice = 200, Image = "Resources/Images/akcija2.jpg", Description = "Sample Product", Category = "AKCIJE", Popust = true },
                new Product { Id = 35, Name = "Akcija 3", Type = "Type3", Tag1 = "TagE", Tag2 = "TagF", OldPrice = 0, NewPrice = 100, Image = "Resources/Images/akcija3.jpg", Description = "Sample Product", Category = "AKCIJE", Popust = false },
                new Product { Id = 36, Name = "Akcija 4", Type = "Type4", Tag1 = "TagG", Tag2 = "TagH", OldPrice = 270, NewPrice = 200, Image = "Resources/Images/akcija4.jpg", Description = "Sample Product", Category = "AKCIJE", Popust = true },

                new Product { Id = 37, Name = "U/I uređaji 1", Type = "Type1", Tag1 = "TagA", Tag2 = "TagB", OldPrice = 120, NewPrice = 100, Image = "Resources/Images/ui1.jpg", Description = "Sample Product", Category = "U/I UREĐAJI", Popust = true },
                new Product { Id = 38, Name = "U/I uređaji 2", Type = "Type2", Tag1 = "TagC", Tag2 = "TagD", OldPrice = 270, NewPrice = 200, Image = "Resources/Images/ui2.jpg", Description = "Sample Product", Category = "U/I UREĐAJI", Popust = true },
                new Product { Id = 39, Name = "U/I uređaji 3", Type = "Type3", Tag1 = "TagE", Tag2 = "TagF", OldPrice = 0, NewPrice = 100, Image = "Resources/Images/ui3.jpg", Description = "Sample Product", Category = "U/I UREĐAJI", Popust = false },
                new Product { Id = 40, Name = "U/I uređaji 4", Type = "Type4", Tag1 = "TagG", Tag2 = "TagH", OldPrice = 270, NewPrice = 200, Image = "Resources/Images/ui4.jpg", Description = "Sample Product", Category = "U/I UREĐAJI", Popust = true },

                new Product { Id = 41, Name = "Gaming Laptop", Type = "Acer Apex G3000", Tag1 = "Gaming", Tag2 = "Laptop", OldPrice = 1600, NewPrice = 1400, Image = "Resources/Images/laptop5.jpg", Description = "Visokoperformansni gaming laptop.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 42, Name = "Poslovni Laptop", Type = "HP EliteBook 850 G7", Tag1 = "Posao", Tag2 = "Laptop", OldPrice = 1300, NewPrice = 1100, Image = "Resources/Images/laptop6.jpg", Description = "Pouzdan laptop za poslovne korisnike.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 43, Name = "MultiBook", Type = "Lenovo IdeaPad 5", Tag1 = "Multimedija", Tag2 = "Laptop", OldPrice = 0, NewPrice = 900, Image = "Resources/Images/laptop7.jpg", Description = "Laptop za multimedijalne sadržaje.", Category = "LAPTOPI", Popust = false },
                new Product { Id = 44, Name = "StudyBook", Type = "Dell Inspiron 15", Tag1 = "Student", Tag2 = "Laptop", OldPrice = 0, NewPrice = 700, Image = "Resources/Images/laptop8.jpg", Description = "Laptop za studente.", Category = "LAPTOPI", Popust = false },

                new Product { Id = 45, Name = "Gaming PC", Type = "MSI Trident 3", Tag1 = "Gaming", Tag2 = "PC", OldPrice = 1800, NewPrice = 1600, Image = "Resources/Images/pc5.jpg", Description = "Visokoperformansni gaming računar.", Category = "RAČUNARI", Popust = true },
                new Product { Id = 46, Name = "Poslovni PC", Type = "HP ProDesk 600 G5", Tag1 = "Posao", Tag2 = "PC", OldPrice = 1100, NewPrice = 900, Image = "Resources/Images/pc6.jpg", Description = "Pouzdan računar za poslovne korisnike.", Category = "RAČUNARI", Popust = true },
                new Product { Id = 47, Name = "All-in-One PC", Type = "Lenovo Yoga A940", Tag1 = "All-in-One", Tag2 = "PC", OldPrice = 1700, NewPrice = 1500, Image = "Resources/Images/pc7.jpg", Description = "Sve-u-jednom računar za svakodnevnu upotrebu.", Category = "RAČUNARI", Popust = true },
                new Product { Id = 48, Name = "Student PC", Type = "Dell OptiPlex 3070", Tag1 = "Student", Tag2 = "PC", OldPrice = 0, NewPrice = 500, Image = "Resources/Images/pc8.jpg", Description = "Računar za studente.", Category = "RAČUNARI", Popust = false },

                new Product { Id = 49, Name = "Gaming Monitor", Type = "Acer Nitro XV273K", Tag1 = "Gaming", Tag2 = "Monitor", OldPrice = 800, NewPrice = 700, Image = "Resources/Images/monitor5.jpg", Description = "Visokoperformansni gaming monitor.", Category = "MONITORI", Popust = true },
                new Product { Id = 50, Name = "Poslovni Monitor", Type = "Samsung Business SR650", Tag1 = "Posao", Tag2 = "Monitor", OldPrice = 600, NewPrice = 500, Image = "Resources/Images/monitor6.jpg", Description = "Monitor za poslovne korisnike.", Category = "MONITORI", Popust = true },
                new Product { Id = 51, Name = "4K Monitor", Type = "BenQ PD3200U", Tag1 = "4K", Tag2 = "Monitor", OldPrice = 700, NewPrice = 600, Image = "Resources/Images/monitor7.jpg", Description = "4K monitor za svakodnevnu upotrebu.", Category = "MONITORI", Popust = true },
                new Product { Id = 52, Name = "Student Monitor", Type = "ASUS ProArt PA248QV", Tag1 = "Student", Tag2 = "Monitor", OldPrice = 0, NewPrice = 300, Image = "Resources/Images/monitor8.jpg", Description = "Monitor za studente.", Category = "MONITORI", Popust = false },

                new Product { Id = 53, Name = "Gaming Televizor", Type = "LG OLED55CXPUA", Tag1 = "Gaming", Tag2 = "Televizor", OldPrice = 1600, NewPrice = 1400, Image = "Resources/Images/tv5.jpg", Description = "Visokoperformansni gaming televizor.", Category = "TELEVIZORI", Popust = true },
                new Product { Id = 54, Name = "Smart Televizor", Type = "Samsung Q80T", Tag1 = "Smart", Tag2 = "Televizor", OldPrice = 1700, NewPrice = 1500, Image = "Resources/Images/tv6.jpg", Description = "Smart televizor za svakodnevnu upotrebu.", Category = "TELEVIZORI", Popust = true },
                new Product { Id = 55, Name = "4K Televizor", Type = "Vizio P-Series Quantum X", Tag1 = "4K", Tag2 = "Televizor", OldPrice = 1400, NewPrice = 1200, Image = "Resources/Images/tv7.jpg", Description = "4K televizor za svakodnevnu upotrebu.", Category = "TELEVIZORI", Popust = true },
                new Product { Id = 56, Name = "Student Televizor", Type = "Hisense H8G", Tag1 = "Student", Tag2 = "Televizor", OldPrice = 0, NewPrice = 700, Image = "Resources/Images/tv8.jpg", Description = "Televizor za studente.", Category = "TELEVIZORI", Popust = false },

                new Product { Id = 57, Name = "Gaming Slušalice", Type = "SteelSeries Arctis 7", Tag1 = "Gaming", Tag2 = "Slušalice", OldPrice = 150, NewPrice = 130, Image = "Resources/Images/slusalice5.jpg", Description = "Visokoperformansne gaming slušalice.", Category = "SLUŠALICE", Popust = true },
                new Product { Id = 58, Name = "Poslovne Slušalice", Type = "Sennheiser HD 450BT", Tag1 = "Posao", Tag2 = "Slušalice", OldPrice = 200, NewPrice = 180, Image = "Resources/Images/slusalice6.jpg", Description = "Slušalice za poslovne korisnike.", Category = "SLUŠALICE", Popust = true },
                new Product { Id = 59, Name = "Bežične Slušalice", Type = "Apple AirPods Pro", Tag1 = "Bežične", Tag2 = "Slušalice", OldPrice = 250, NewPrice = 220, Image = "Resources/Images/slusalice7.jpg", Description = "Bežične slušalice za svakodnevnu upotrebu.", Category = "SLUŠALICE", Popust = true },
                new Product { Id = 60, Name = "Student Slušalice", Type = "Anker Soundcore Life Q20", Tag1 = "Student", Tag2 = "Slušalice", OldPrice = 0, NewPrice = 60, Image = "Resources/Images/slusalice8.jpg", Description = "Slušalice za studente.", Category = "SLUŠALICE", Popust = false },

                new Product { Id = 61, Name = "Gaming Mikrofon", Type = "Razer Seiren X", Tag1 = "Gaming", Tag2 = "Mikrofon", OldPrice = 120, NewPrice = 100, Image = "Resources/Images/mikrofon5.jpg", Description = "Visokoperformansni gaming mikrofon.", Category = "MIKROFONI", Popust = true },
                new Product { Id = 62, Name = "Poslovni Mikrofon", Type = "Audio-Technica AT2020", Tag1 = "Posao", Tag2 = "Mikrofon", OldPrice = 150, NewPrice = 130, Image = "Resources/Images/mikrofon6.jpg", Description = "Mikrofon za poslovne korisnike.", Category = "MIKROFONI", Popust = true },
                new Product { Id = 63, Name = "Podcast Mikrofon", Type = "Elgato Wave:3", Tag1 = "Podcast", Tag2 = "Mikrofon", OldPrice = 200, NewPrice = 180, Image = "Resources/Images/mikrofon7.jpg", Description = "Mikrofon za podcaste.", Category = "MIKROFONI", Popust = true },
                new Product { Id = 64, Name = "Student Mikrofon", Type = "Fifine USB Microphone", Tag1 = "Student", Tag2 = "Mikrofon", OldPrice = 0, NewPrice = 50, Image = "Resources/Images/mikrofon8.jpg", Description = "Mikrofon za studente.", Category = "MIKROFONI", Popust = false },

                new Product { Id = 65, Name = "Gaming Komponente", Type = "AMD Ryzen 9 5900X", Tag1 = "Gaming", Tag2 = "Komponente", OldPrice = 600, NewPrice = 500, Image = "Resources/Images/komponente5.jpg", Description = "Visokoperformansne gaming komponente.", Category = "KOMPONENTE", Popust = true },
                new Product { Id = 66, Name = "Poslovne Komponente", Type = "Intel Core i9-10900K", Tag1 = "Posao", Tag2 = "Komponente", OldPrice = 500, NewPrice = 450, Image = "Resources/Images/komponente6.jpg", Description = "Komponente za poslovne korisnike.", Category = "KOMPONENTE", Popust = true },
                new Product { Id = 67, Name = "RAM Memorija", Type = "G.Skill Trident Z RGB 32GB", Tag1 = "RAM", Tag2 = "Komponente", OldPrice = 200, NewPrice = 180, Image = "Resources/Images/komponente7.jpg", Description = "RAM memorija za svakodnevnu upotrebu.", Category = "KOMPONENTE", Popust = true },
                new Product { Id = 68, Name = "SSD Disk", Type = "WD Black SN750 1TB", Tag1 = "SSD", Tag2 = "Komponente", OldPrice = 0, NewPrice = 150, Image = "Resources/Images/komponente8.jpg", Description = "SSD disk za svakodnevnu upotrebu.", Category = "KOMPONENTE", Popust = false },

                new Product { Id = 69, Name = "Gaming Mobitel", Type = "Xiaomi Black Shark 3", Tag1 = "Gaming", Tag2 = "Mobitel", OldPrice = 900, NewPrice = 800, Image = "Resources/Images/mobitel5.jpg", Description = "Visokoperformansni gaming mobitel.", Category = "MOBITELI", Popust = true },
                new Product { Id = 70, Name = "Poslovni Mobitel", Type = "Google Pixel 5", Tag1 = "Posao", Tag2 = "Mobitel", OldPrice = 800, NewPrice = 700, Image = "Resources/Images/mobitel6.jpg", Description = "Mobitel za poslovne korisnike.", Category = "MOBITELI", Popust = true },
                new Product { Id = 71, Name = "Smartphone", Type = "Samsung Galaxy S21", Tag1 = "Smartphone", Tag2 = "Mobitel", OldPrice = 1000, NewPrice = 900, Image = "Resources/Images/mobitel7.jpg", Description = "Smartphone za svakodnevnu upotrebu.", Category = "MOBITELI", Popust = true },
                new Product { Id = 72, Name = "Student Mobitel", Type = "Nokia 5.3", Tag1 = "Student", Tag2 = "Mobitel", OldPrice = 0, NewPrice = 200, Image = "Resources/Images/mobitel8.jpg", Description = "Mobitel za studente.", Category = "MOBITELI", Popust = false },

                new Product { Id = 73, Name = "Gaming U/I uređaj", Type = "Razer Huntsman Elite", Tag1 = "Gaming", Tag2 = "U/I uređaj", OldPrice = 200, NewPrice = 180, Image = "Resources/Images/ui5.jpg", Description = "Visokoperformansni gaming U/I uređaj.", Category = "U/I UREĐAJI", Popust = true },
                new Product { Id = 74, Name = "Poslovni U/I uređaj", Type = "Logitech MX Keys", Tag1 = "Posao", Tag2 = "U/I uređaj", OldPrice = 100, NewPrice = 90, Image = "Resources/Images/ui6.jpg", Description = "U/I uređaj za poslovne korisnike.", Category = "U/I UREĐAJI", Popust = true },
                new Product { Id = 75, Name = "Multimedijalni U/I uređaj", Type = "Corsair K95 RGB Platinum", Tag1 = "Multimedija", Tag2 = "U/I uređaj", OldPrice = 0, NewPrice = 150, Image = "Resources/Images/ui7.jpg", Description = "U/I uređaj za multimedijalne sadržaje.", Category = "U/I UREĐAJI", Popust = false },
                new Product { Id = 76, Name = "Student U/I uređaj", Type = "Microsoft Sculpt Ergonomic", Tag1 = "Student", Tag2 = "U/I uređaj", OldPrice = 0, NewPrice = 80, Image = "Resources/Images/ui8.jpg", Description = "U/I uređaj za studente.", Category = "U/I UREĐAJI", Popust = false },

                new Product { Id = 77, Name = "Gaming Laptop", Type = "Gigabyte Aorus 15G", Tag1 = "Gaming", Tag2 = "Laptop", OldPrice = 1700, NewPrice = 1500, Image = "Resources/Images/laptop9.jpg", Description = "Visokoperformansni gaming laptop.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 78, Name = "Poslovni Laptop", Type = "Dell Latitude 7410", Tag1 = "Posao", Tag2 = "Laptop", OldPrice = 1400, NewPrice = 1200, Image = "Resources/Images/laptop10.jpg", Description = "Pouzdan laptop za poslovne korisnike.", Category = "LAPTOPI", Popust = true },
                new Product { Id = 79, Name = "Multi Laptop", Type = "HP Envy x360", Tag1 = "Multimedija", Tag2 = "Laptop", OldPrice = 0, NewPrice = 1000, Image = "Resources/Images/laptop11.jpg", Description = "Laptop za multimedijalne sadržaje.", Category = "LAPTOPI", Popust = false },
                new Product { Id = 80, Name = "StudyBook", Type = "Acer Swift 3", Tag1 = "Student", Tag2 = "Laptop", OldPrice = 0, NewPrice = 600, Image = "Resources/Images/laptop12.jpg", Description = "Laptop za studente.", Category = "LAPTOPI", Popust = false }
            );
        }
    }
}

