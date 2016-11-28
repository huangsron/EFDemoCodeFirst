using System.Data.Entity;

namespace EfDemo
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<AccountDataModel> Accounts { get; set; }
    }
}