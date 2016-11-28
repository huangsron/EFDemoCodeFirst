using System.Data.Entity.ModelConfiguration;

namespace EfDemo
{
    public class AccountConfiguration : EntityTypeConfiguration<AccountDataModel>
    {
        public AccountConfiguration()
        {
            this.ToTable("Account");
        }
    }
}