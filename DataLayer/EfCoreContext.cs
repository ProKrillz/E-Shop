using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;
public class EfCoreContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Data Source=LAPTOP-HPD38H10\SQLEXPRESS;Database=Eshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
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
            .ToTable("Brans");

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
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Ordre>()
            .Property(o => o.Updated)
            .HasColumnName("ordre_updated");

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
            .UsingEntity(j => j.ToTable("ProductCategory"));

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Ordres)
            .WithMany(o => o.Products)
            .UsingEntity(j => j.ToTable("ProductOrdre"));

        modelBuilder.Entity<User>()
            .HasOne(u => u.ZipCode)
            .WithMany(z => z.Users)
            .HasForeignKey(u => u.Fk_ZipCodeId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Ordres)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.Fk_UserId);
            
        #endregion
    }
}