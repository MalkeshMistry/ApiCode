using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using System.Data;
using Repository.Dapper;

namespace Repository
{
    //internal class Repository : IRepository
    // {

    //     private readonly Func<IDbConnection> _connectionFactory;

    //     public Repository(Func<IDbConnection> connectionFactory)
    //     {
    //         _connectionFactory = connectionFactory;
    //     }

    //     public IWidget Get(string key)
    //     {
    //         using (var conn = _connectionFactory())
    //         {
    //             return conn.Query<Widget>(
    //                "select * from widgets with(nolock) where widgetkey=@WidgetKey", new { WidgetKey = key });
    //         }
    //     }
    // }
    //var connectionFactory = new Func<IDbConnection>(() => {
    //    var conn = new SqlConnection(
    //        ConfigurationManager.ConnectionStrings["connectionString-name"];
    //    conn.Open();
    //    return conn;
    //});
    public class DapperRepository : IRepository
    {
        private readonly IDbConnection _context;

        public DapperRepository(IDbConnection context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this._context = context;
        }

        public CustomerEntity CreateCustomer(CustomerEntity customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public CustomerEntity FindCustomerByName(string customerName)
        {
            throw new NotImplementedException();
        }

        public CustomerEntity GetCustomer(int customerId)
        {
            return _context.Get<CustomerEntity>(customerId);
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
