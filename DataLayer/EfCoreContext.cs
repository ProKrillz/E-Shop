using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;
public class EfCoreContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<Ordre> Ordre { get; set; }
    public DbSet<Delivery> Delivery { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<ZipCode> ZipCode { get; set; }
    public DbSet<Set> Set { get; set; }
    public DbSet<Payment> Payment { get; set; }

    public EfCoreContext()
    {
        
    }
    public EfCoreContext(DbContextOptions builder) : base(builder) { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Product Table

        modelBuilder.Entity<Product>()
            .ToTable("Products");

        modelBuilder.Entity<Product>()
           .Property(p => p.ProductId)
           .HasColumnName("product_id")
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasColumnName("product_name")
            .HasMaxLength(50);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name);

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .HasColumnName("product_description")
            .HasMaxLength(200);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnName("product_price")
            .HasPrecision(18, 2);

        #endregion

        #region Brand Table

        modelBuilder.Entity<Brand>()
            .ToTable("Brands");

        modelBuilder.Entity<Brand>()
            .HasKey(b => b.BrandId)
            .HasName("brand_id");

        modelBuilder.Entity<Brand>()
            .Property(b => b.Name)
            .HasColumnName("brand_name")
            .HasMaxLength(25);

        #endregion

        #region Category Table

        modelBuilder.Entity<Category>()
            .ToTable("Categorys");

        modelBuilder.Entity<Category>()
            .HasKey(c => c.CategoryId)
            .HasName("category_id");

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasColumnName("category_name")
            .HasMaxLength(25);

        #endregion

        #region Set Table

        modelBuilder.Entity<Set>()
            .ToTable("Sets");

        modelBuilder.Entity<Set>()
            .Property(s => s.SetId)
            .HasColumnName("set_id")
            .HasMaxLength(4);

        modelBuilder.Entity<Set>()
            .Property(s => s.SetName)
            .HasColumnName("set_name")
            .HasMaxLength(50);

        modelBuilder.Entity<Set>()
            .Property(s => s.SetRealse)
            .HasColumnName("set_realse");

        #endregion

        #region Image Table

        modelBuilder.Entity<Image>()
            .ToTable("Images");

        modelBuilder.Entity<Image>()
            .HasKey(i => i.ImageId)
            .HasName("image_id");

        modelBuilder.Entity<Image>()
            .Property(i => i.Path)
            .HasColumnName("image_path");

        #endregion

        #region Ordre Table

        modelBuilder.Entity<Ordre>()
            .ToTable("Ordres");

        modelBuilder.Entity<Ordre>()
           .Property(o => o.OrdreId)
           .HasColumnName("ordre_id")
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Ordre>()
            .Property(o => o.Created)
            .HasColumnName("ordre_created")
            .HasDefaultValueSql("GETDATE()"); // Virker ikke in memory, fordi sqlLite

        modelBuilder.Entity<Ordre>()
            .Property(o => o.Updated)
            .HasColumnName("ordre_updated");

        #endregion

        #region Delivery Table

        modelBuilder.Entity<Delivery>()
            .ToTable("Deliverys");

        modelBuilder.Entity<Delivery>()
            .HasKey(d => d.DeliveryId);

        modelBuilder.Entity<Delivery>()
            .Property(d => d.DeliveryOption)
            .HasColumnName("delivery_option")
            .HasMaxLength(15);

        #endregion

        #region Payment Table

        modelBuilder.Entity<Payment>()
            .ToTable("Payments");

        modelBuilder.Entity<Payment>()
            .HasKey(p => p.PaymentId);

        modelBuilder.Entity<Payment>()
            .Property(p => p.PaymentOption)
            .HasColumnName("payment_option")
            .HasMaxLength(15);

        #endregion

        #region User Table

        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId)
            .HasName("user_id");

        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnName("user_firstname")
            .HasMaxLength(25);

        modelBuilder.Entity<User>()
            .Property(u => u.Lastname)
            .HasColumnName("user_lastname")
            .HasMaxLength(25);

        modelBuilder.Entity<User>()
            .Property(u => u.Address)
            .HasColumnName("user_address")
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasColumnName("user_email")
            .HasMaxLength(50)
            .IsRequired()
            .HasConversion(u => u.ToLower(), u => u.ToLower());

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnName("user_password")
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.Disable)
            .HasColumnName("user_disable");

        modelBuilder.Entity<User>()
            .Property(u => u.Admin)
            .HasColumnName("user_admin");

        #endregion

        #region ZipCode Table

        modelBuilder.Entity<ZipCode>()
            .ToTable("ZipCodes");

        modelBuilder.Entity<ZipCode>()
            .Property(z => z.ZipCodeId)
            .HasColumnName("zipcode_id");

        modelBuilder.Entity<ZipCode>()
            .Property(z => z.City)
            .HasColumnName("zipcode_city")
            .HasMaxLength(50);

        #endregion

        #region Relations

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.Fk_BrandId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Image)
            .WithOne(i => i.Product)
            .HasForeignKey<Product>(p => p.Fk_ImageId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.Fk_CategoryId);

        modelBuilder.Entity<Ordre>()
            .HasOne(o => o.Payment)
            .WithMany(p => p.Ordes)
            .HasForeignKey(o => o.Fk_PayementId);

        modelBuilder.Entity<Ordre>()
            .HasOne(o => o.Delivery)
            .WithMany(d => d.Ordres)
            .HasForeignKey(o => o.Fk_DeliveryId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.ZipCode)
            .WithMany(z => z.Users)
            .HasForeignKey(u => u.Fk_ZipCodeId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Ordres)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.Fk_UserId);

        modelBuilder.Entity<OrdreProduct>()
            .ToTable("OrdreProduct");

        modelBuilder.Entity<OrdreProduct>()
            .HasKey(op => new { op.Fk_OrdreId, op.Fk_ProductId });

        modelBuilder.Entity<OrdreProduct>()
            .Property(op => op.Amount)
            .HasColumnName("ordre_product_amount")
            .HasMaxLength(100);

        modelBuilder.Entity<OrdreProduct>()
            .HasOne(op => op.Ordre)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.Fk_OrdreId);

        modelBuilder.Entity<OrdreProduct>()
            .HasOne(op => op.Product)
            .WithMany(o => o.Ordres)
            .HasForeignKey(op => op.Fk_ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Set)
            .WithMany(s => s.Product)
            .HasForeignKey(p => p.Fk_SetId);

        #endregion

        SeedSet(modelBuilder);
        SeedBrand(modelBuilder);
        SeedCategory(modelBuilder);
        SeedImage(modelBuilder);
        SeedProduct(modelBuilder);
        SeedZip(modelBuilder);
        SeedAdmin(modelBuilder);
        SeedDelvery(modelBuilder);
        SeedPayments(modelBuilder);
    }
    private void SeedSet(ModelBuilder modelBuilder)//"04-08-2022"
    {
        modelBuilder.Entity<Set>().HasData(new Set { SetId = "POTE", SetName = "Power of the Elements", SetRealse = new DateTime(2022,08,04) });
        modelBuilder.Entity<Set>().HasData(new Set { SetId = "PHHY", SetName = "Photon hypernova", SetRealse = new DateTime(2023,02,09) });
        modelBuilder.Entity<Set>().HasData(new Set { SetId = "BLCR", SetName = "Battle of legend: Crystal revenge", SetRealse = new DateTime(2022,11,17) });
        modelBuilder.Entity<Set>().HasData(new Set { SetId = "DABL", SetName = "Darkwing blast", SetRealse = new DateTime(2022,10,20) });
        modelBuilder.Entity<Set>().HasData(new Set { SetId = "MAMA", SetName = "Magnificent mavens", SetRealse = new DateTime(2022,11,03) });
    }
    private void SeedBrand(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().HasData(new Brand { BrandId = 1, Name = "Konami"});
    }
    private void SeedCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Single"},
            new Category { CategoryId = 2, Name = "Booster"},
            new Category { CategoryId = 3, Name = "Display"}
            );
    }
    private void SeedImage(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 1, Path = "/Image/Card/dpe.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 2, Path = "/Image/Card/BlcrBooster.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 3, Path = "/Image/Card/BlcrBox.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 4, Path = "/Image/Card/PoteBooster.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 5, Path = "/Image/Card/PoteBox.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 6, Path = "/Image/Card/PhhyBooster.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 7, Path = "/Image/Card/PhhyBox.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 8, Path = "/Image/Card/DablBooster.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 9, Path = "/Image/Card/DablBox.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 10, Path = "/Image/Card/MamaBooster.jpg" });
        modelBuilder.Entity<Image>().HasData(new Image { ImageId = 11, Path = "/Image/Card/MamaBox.jpg" });
    }
    private void SeedProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 100, Name = "Destiny HERO - Destroyer Phoenix Enforcer", Description = "Starligth rare", Price = 1700.00M, Fk_BrandId = 1, Fk_SetId = "POTE", Fk_CategoryId = 1, Fk_ImageId = 1 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 101, Name = "Battle of legend: Crystal revenge", Description = "4 Ultra rare og 1 secret rare i pakken", Price = 40.00M, Fk_BrandId = 1, Fk_SetId = "BLCR", Fk_CategoryId = 2, Fk_ImageId = 2 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 102, Name = "Battle of legend: Crystal revenge", Description = "24 booster i boxen", Price = 500.00M, Fk_BrandId = 1, Fk_SetId = "BLCR", Fk_CategoryId = 3, Fk_ImageId = 3 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 103, Name = "Power of the Elements", Description = "9 kort i pakken", Price = 40.00M, Fk_BrandId = 1, Fk_SetId = "POTE", Fk_CategoryId = 2, Fk_ImageId = 4 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 104, Name = "Power of the Elements", Description = "24 booster i boxen", Price = 500.00M, Fk_BrandId = 1, Fk_SetId = "POTE", Fk_CategoryId = 3, Fk_ImageId = 5 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 105, Name = "Photon hypernova", Description = "9 kort i pakken", Price = 40.00M, Fk_BrandId = 1, Fk_SetId = "PHHY", Fk_CategoryId = 2, Fk_ImageId = 6 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 106, Name = "Photon hypernova", Description = "24 booster i boxen", Price = 500.00M, Fk_BrandId = 1, Fk_SetId = "PHHY", Fk_CategoryId = 3, Fk_ImageId = 7 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 107, Name = "Darkwing blast", Description = "9 kort i pakken", Price = 40.00M, Fk_BrandId = 1, Fk_SetId = "DABL", Fk_CategoryId = 2, Fk_ImageId = 8 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 108, Name = "Darkwing blast", Description = "24 booster i boxen", Price = 500.00M, Fk_BrandId = 1, Fk_SetId = "DABL", Fk_CategoryId = 3, Fk_ImageId = 9 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 109, Name = "Magnificent mavens", Description = "5 ultra kort i pakken", Price = 35.00M, Fk_BrandId = 1, Fk_SetId = "MAMA", Fk_CategoryId = 2, Fk_ImageId = 10 });
        modelBuilder.Entity<Product>().HasData(new Product { ProductId = 110, Name = "Magnificent mavens", Description = "4 booster pack og 60 sleevs i boxen", Price = 150.00M, Fk_BrandId = 1, Fk_SetId = "MAMA", Fk_CategoryId = 3, Fk_ImageId = 11 });

    }
    private void SeedZip(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ZipCode>().HasData(new ZipCode { ZipCodeId = 6400, City = "Sønderborg"});
        modelBuilder.Entity<ZipCode>().HasData(new ZipCode { ZipCodeId = 6200, City = "Aabenraa" });
        modelBuilder.Entity<ZipCode>().HasData(new ZipCode { ZipCodeId = 6100, City = "Haderslev" });
    }
    private void SeedAdmin(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User {
            UserId = Guid.Parse("0a916c32-36a6-42e0-9b05-b46d7e643d56"),
            FirstName = "Thomas",
            Lastname = "Damkjær",
            Password = "linkin",
            Admin = true,
            Email = "admin@admin.dk",
            Address = "Alsgade 42A",
            Fk_ZipCodeId = 6400,
            Disable = false }) ;
    }
    private void SeedPayments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>().HasData(new Payment { PaymentId = 1, PaymentOption = "DanKort" });
        modelBuilder.Entity<Payment>().HasData(new Payment { PaymentId = 2, PaymentOption = "MasterKort" });
        modelBuilder.Entity<Payment>().HasData(new Payment { PaymentId = 3, PaymentOption = "Mobilpay" });
    }
    private void SeedDelvery(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Delivery>().HasData(new Delivery { DeliveryId = 1, DeliveryOption = "Postnord" });
        modelBuilder.Entity<Delivery>().HasData(new Delivery { DeliveryId = 2, DeliveryOption = "Gls" });
        modelBuilder.Entity<Delivery>().HasData(new Delivery { DeliveryId = 3, DeliveryOption = "Hent selv" });
    }
}