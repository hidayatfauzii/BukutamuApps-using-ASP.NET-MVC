using System.Data.Entity;

namespace TAS_SIUKDWStore.Models
{
    public class TAS_SIUKDWStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TAS_SIUKDWStore.Models.TAS_SIUKDWStoreContext>());

        public TAS_SIUKDWStoreContext() : base("name=TAS_SIUKDWStoreContext")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
    public class TAS_SIUKDWStoreContextInitializer:
        DropCreateDatabaseIfModelChanges<TAS_SIUKDWStoreContext>
    
    {
        protected override void Seed(TAS_SIUKDWStoreContext context)
        {
            //Category cat1 = new Category
            //{
            //    CategoryName = "Komik"
            //};

            // Category cat2 = new Category
            // {
            //    CategoryName = "Novel"
            //};
            // Category cat3= new Category
            //{
            //    CategoryName = "Komputer"
            //};


            //context.BooksModels.Add(new BookModels
            //{
            //    id_buku=1,
            //    ISBN="72120077",
            //    Judul="Novela",
            //    Pengarang="Indonesian Idol",
            //    TahunTerbit="2014",
            //    Penerbit="ANDI",
            //    Sinopsis="Nyanyi sesuka hati",
            //    TebalHalaman=100,
                
            //    CategoryID = cat2.CategoryID,
            //    category =cat2});


            //context.BooksModels.Add(new BookModels
            //{
            //    id_buku = 2,
            //    ISBN = "72120090",
            //    Judul = "ASP.NET",
            //    Pengarang = "Erick Kurniawan",
            //    TahunTerbit = "2014",
            //    Penerbit = "UKDW",
            //    Sinopsis = "Pengenalan ASP.NET",
            //    TebalHalaman = 100,

            //    CategoryID = cat3.CategoryID,
            //    category = cat3
            //});               

        }
    }
}
