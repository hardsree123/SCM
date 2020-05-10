using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCM.Business.DbModel
{
    public partial class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Covid> Covid { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.3.102;port=3306;user=dsuser;password=dsuserpwd1;database=SCM", x => x.ServerVersion("5.7.7-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Covid>(entity =>
            {
                entity.HasKey(e => e.ForecastId)
                    .HasName("PRIMARY");

                entity.ToTable("covid");

                entity.Property(e => e.ForecastId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AdditionalDetails).HasColumnType("blob");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Lat).HasColumnType("decimal(11,8)");

                entity.Property(e => e.Long).HasColumnType("decimal(11,8)");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.HasIndex(e => e.ItemCode)
                    .HasName("stock_un")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AdditionalDetails).HasColumnType("blob");

                entity.Property(e => e.ItemAddedOn).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ItemDiscountPer)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ItemEmptiedOn).HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ItemStatus)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ItemStockUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ItemTaxPer)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ItemUnitPrice).HasColumnType("decimal(19,4)");

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.HasIndex(e => e.VendorCode)
                    .HasName("vendor_un")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.AdditionalDetails).HasColumnType("blob");

                entity.Property(e => e.Country)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone2)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.State)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VendorAddr)
                    .IsRequired()
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
