using E_commerce_fashion_store.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_fashion_store.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ImportReceipt> ImportReceipts { get; set; }
        public DbSet<ImportReceiptDetail> ImportReceiptDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<PaymentToSupplier> PaymentToSuppliers { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<OrderDiscount> OrderDiscounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Emloyee> Emloyees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductTag>(x => x.HasKey(p => new { p.ProductId, p.TagId }));
            builder.Entity<ProductTag>()
                .HasOne(u => u.Product)
                .WithMany(u => u.ProductTag)
                .HasForeignKey(u => u.ProductId);
            builder.Entity<ProductTag>()
                .HasOne(u => u.Tag)
                .WithMany(u => u.ProductTags)
                .HasForeignKey(u => u.TagId);

            builder.Entity<OrderDiscount>(x => x.HasKey(p => new { p.OrderId, p.DiscountCodeId }));
            builder.Entity<OrderDiscount>()
                .HasOne(u => u.DiscountCode)
                .WithMany(u => u.OrderDiscounts)
                .HasForeignKey(u => u.DiscountCodeId);
            builder.Entity<OrderDiscount>()
                .HasOne(u => u.Order)
                .WithMany(u => u.OrderDiscounts)
                .HasForeignKey(u => u.OrderId);

        }
    }
}
