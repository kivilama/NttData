using NttDataApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NttDataApi.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<Account>(ConfigureAccount);  
            modelBuilder.Entity<Transaction>()
                 .HasOne(a => a.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(c => c.AccountId); ;
        }
        private void ConfigureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);
            builder.Property(a => a.AccountNumber)
                .ValueGeneratedNever();
            builder.HasOne(a => a.Client)
            .WithMany(a => a.Accounts)
            .HasForeignKey(c => c.ClientId);
        }

    }
}
