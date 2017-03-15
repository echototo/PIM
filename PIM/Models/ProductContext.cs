namespace PIM.Models
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ProductContext : DbContext
    {

        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Product » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « PIM.Models.Product » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Product » dans le fichier de configuration de l'application.
        public ProductContext()
            : base("Product")
        {
        }

        public DbSet<Product> Products { get; set; }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public enum Famille
    {
        boisson, nourriture, electromenager
    }

    public class Product
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public int Prix { get; set; }
        public string Description { get; set; }
        public Famille? Famille { get; set; }
        public string Reference { get; set; }
        public string DateValid { get; set; }
    }
}