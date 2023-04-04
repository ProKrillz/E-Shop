using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

// Make many to many class for catecory and product

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

    public EfCoreContext(DbContextOptions builder) : base(builder) { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
            options.UseSqlServer(@"Data Source=LAPTOP-HPD38H10\SQLEXPRESS;Database=Eshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Product Table

        modelBuilder.Entity<Product>()
            .ToTable("Products");

        modelBuilder.Entity<Product>()
           .Property(p => p.ProductId)
           .HasColumnName("product_id")
           .HasDefaultValue(100)
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
            .HasPrecision(6, 2);

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
           .HasDefaultValue(10000)
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
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnName("user_password");

        modelBuilder.Entity<User>()
            .Property(u => u.Disable)
            .HasColumnName("user_disable");

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
            .HasForeignKey<Image>(i => i.Fk_ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categorys)
            .WithMany(c => c.Products)
            .UsingEntity(j => j.ToTable("ProductCategory")); // remove later

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

        #endregion
    }
}