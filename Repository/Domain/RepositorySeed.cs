using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Entities;

namespace Repository.Domain
{
    /// <summary>
    /// The RepositorySeedClass.
    /// </summary>
    public class RepositorySeed
    {
        /// <summary>
        /// Provides data for the db.
        /// </summary>
        /// <param name="context">The db context.</param>
        public void Execute(RepositoryContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //// TODO: Replace with more generic code so this doesn't have to keep changing
                    context.DbSet<User>()
                        .AddOrUpdate(
                            new User
                            {
                                Name = "Jimi",
                                HomeAddress = new Address()
                                                  {
                                                     Name = "JimiHome"
                                                  },
                                OfficeAddress = new Address()
                                {
                                    Name = "JimiOffice"
                                }

                            });
                    //context.DbSet<ReferenceDataTypeLookUpEntity>()
                    //    .AddOrUpdate(
                    //        new ReferenceDataTypeLookUpEntity
                    //        {
                    //            Id = (int)ReferenceDataType.Titles,
                    //            Value = ReferenceDataType.Titles.ToString()
                    //        });
                    //context.DbSet<ReferenceDataTypeLookUpEntity>()
                    //    .AddOrUpdate(
                    //        new ReferenceDataTypeLookUpEntity
                    //        {
                    //            Id = (int)ReferenceDataType.PaymentType,
                    //            Value = ReferenceDataType.PaymentType.ToString()
                    //        });
                    //context.SaveChanges();

                    //context.DbSet<ReferenceDataItemEntity>().AddOrUpdate(DataSeed.ReferenceDataItem().Distinct().ToArray());
                    //context.SaveChanges();
                    //transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
