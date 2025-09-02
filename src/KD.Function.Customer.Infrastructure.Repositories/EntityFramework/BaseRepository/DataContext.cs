using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Models;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.BaseRepository
{
    [ExcludeFromCodeCoverage]
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Models.Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerEconomicActivity> CustomerEconomicActivities { get; set; }
        public virtual DbSet<CustomerPortal> CustomerPortals { get; set; } 
        public virtual DbSet<EconomicActivity> EconomicActivities { get; set; }
        public virtual DbSet<Portal> Portals { get; set; }
        public virtual DbSet<Uf> Ufs { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.IdUf).HasColumnName("id_uf");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdUfNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdUf)
                    .HasConstraintName("FK_city_to_uf");
            });

            modelBuilder.Entity<Models.Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cell_phone");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("document");

                entity.Property(e => e.CorporateName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("corporate_name");

                entity.Property(e => e.DateFoundation)
                    .HasColumnType("date")
                    .HasColumnName("date_foundation");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.CorporateEmail)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("corporate_email");

                entity.Property(e => e.FantasyName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("fantasy_name");

                entity.Property(e => e.Ie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ie");

                entity.Property(e => e.IntegrateOnpremise).HasColumnName("integrate_onpremise");

                entity.Property(e => e.LandlinePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("landline_phone");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("owner");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("customer_address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("zipcode");

                entity.Property(e => e.Complement)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("complement");

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdUf).HasColumnName("id_uf");

                entity.Property(e => e.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("neighborhood");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_address_to_city");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_customer_address_to_customer");

                entity.HasOne(d => d.IdUfNavigation)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.IdUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer_address_to_uf");
            });

            modelBuilder.Entity<CustomerEconomicActivity>(entity =>
            {
                entity.ToTable("customer_economic_activities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdEconomicActivity).HasColumnName("id_economic_activity");

                entity.Property(e => e.TypeEconomicActivity)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type_economic_activity");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.CustomerEconomicActivities)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_economic_activities_to_customer");

                entity.HasOne(d => d.IdEconomicActivityNavigation)
                    .WithMany(p => p.CustomerEconomicActivities)
                    .HasForeignKey(d => d.IdEconomicActivity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_economic_activities_to_customer_economic_activities");
            });

            modelBuilder.Entity<CustomerPortal>(entity =>
            {
                entity.ToTable("customer_portal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdPortal).HasColumnName("id_portal");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.CustomerPortals)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_customer_portal_to_customer");

                entity.HasOne(d => d.IdPortalNavigation)
                    .WithMany(p => p.CustomerPortals)
                    .HasForeignKey(d => d.IdPortal)
                    .HasConstraintName("FK_customer_portal_to_portal");
            });

            modelBuilder.Entity<EconomicActivity>(entity =>
            {
                entity.ToTable("economic_activities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Portal>(entity =>
            {
                entity.ToTable("portal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Logo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Url)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.ToTable("uf");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");

                entity.Property(e => e.IdPortal).HasColumnName("id_portal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .HasColumnName("cpf");

                entity.Property(e => e.Active)
                    .HasColumnName("active");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.ValidationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("validation_date");
            });

            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.ToTable("CUSTOMER_ACCOUNT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdAccount).HasColumnName("ID_ACCOUNT");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_CUSTOMER");

                entity.Property(e => e.IsMasterUser).HasColumnName("IS_MASTER_USER");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.CustomerAccounts)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_ACCOUNT_TO_ACCOUNT");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.CustomerAccounts)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_ACCOUNT_TO_CUSTOMER");
            });
        }
    }
}
