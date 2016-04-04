using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Repository.Interface;
using Repository.Schema;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Domain
{
    /// <summary>
    /// The RepositoryContext class.
    /// </summary>
    public sealed class RepositoryContext : DbContext, IRepositoryContext 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext" /> class.
        /// </summary>
        public RepositoryContext()
            : base("ApiConn")
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ObjectStateManagerChanged += this.OnSaveChanges;
            //this.CreateConnection("ApiConn");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="enableOnSaveChanges">if set to <c>true</c> [enable on save changes].</param>
        public RepositoryContext(string connectionString, bool enableOnSaveChanges)
            : base(connectionString)
        {
            if (enableOnSaveChanges)
            {
                ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ObjectStateManagerChanged += OnSaveChanges;
            }
           // this.CreateConnection(connectionString);
        }

        //public DbConnection CreateConnection(string nameOrConnectionString)
        //{
        //    return new SqlConnection(nameOrConnectionString);
        //}

        /// <summary>
        /// Provides the DbSet for T.
        /// </summary>
        /// <typeparam name="T">Type T.</typeparam>
        /// <returns>The <see cref="DbSet"/>.</returns>
        public IDbSet<T> DbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        /// <summary>
        /// Hooks on the OnModelCreating event.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // conventions            
            //modelBuilder.Conventions.Add(new ServiceConvention());

            //// lookup tables
            modelBuilder.Configurations.Add(new CustomerSchema());
            modelBuilder.Configurations.Add(new UserSchema());
            modelBuilder.Configurations.Add(new AddressSchema());
            //modelBuilder.Configurations.Add(new OrderStatusSchema());
            //modelBuilder.Configurations.Add(new OrderLineStatusSchema());
            //modelBuilder.Configurations.Add(new AddressTypeSchema());

            //// base tables
            //modelBuilder.Configurations.Add(new OrderSchema());
            //modelBuilder.Configurations.Add(new OrderLineSchema());
            //modelBuilder.Configurations.Add(new AddressSchema());
            //modelBuilder.Configurations.Add(new OrderStatusHistorySchema());
            //modelBuilder.Configurations.Add(new OrderLineStatusHistorySchema());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Hooks on the OnSaveChanges event.
        /// </summary>
        /// <param name="obj">The associated object.</param>
        /// <param name="args">The associated arguments.</param>
        private void OnSaveChanges(object obj, EventArgs args)
        {
            //var currentObj = ((System.ComponentModel.CollectionChangeEventArgs)args).Element;
            //new DataOperation().SetModifiedAndCreatedDate(currentObj);
        }
    }
}
