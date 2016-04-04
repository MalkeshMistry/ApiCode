using System.Data.Entity.Migrations;

using Repository.Domain;

namespace Repository.Migrations
{
    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<RepositoryContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepositoryContext context)
        {
            new RepositorySeed().Execute(context);
            base.Seed(context);
        }
    }
}
