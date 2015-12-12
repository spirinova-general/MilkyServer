using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using Blogger.Core;
using Blogger.Core.Domain;
using Blogger.Data.Mapping;
namespace Blogger.Data
{
    public class ObjectContext : DbContext
    {
        public ObjectContext()
            : base("Context")
        {
        }


        public DbSet<Account> Account { get; set; }
        public DbSet<Account_Area_Mapping> AccountAreaMapping { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerSetting> CustomerSetting { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<GlobalSetting> GlobalSetting { get; set; }
        public DbSet<BillsLog> BillsLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //disable EdmMetadata generation
            modelBuilder.Configurations.Add<Account>(new Account_Mapping());
            modelBuilder.Configurations.Add<Account_Area_Mapping>(new Account_Area_Mapping_Mapping());
            modelBuilder.Configurations.Add<Area>(new Area_Mapping());
            modelBuilder.Configurations.Add<Bill>(new Bill_Mapping());
            modelBuilder.Configurations.Add<City>(new City_Mapping());
            modelBuilder.Configurations.Add<Customer>(new Customer_Mapping());
            modelBuilder.Configurations.Add<CustomerSetting>(new CustomerSetting_Mapping());
            modelBuilder.Configurations.Add<Delivery>(new Delivery_Mapping());
            modelBuilder.Configurations.Add<GlobalSetting>(new GlobalSetting_Mapping());
            modelBuilder.Configurations.Add<BillsLog>(new BillsLog_Mapping());
            base.OnModelCreating(modelBuilder);
        }

        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}