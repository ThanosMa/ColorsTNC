using MyDatabase;
using RepositoryServices.Core;
using RepositoryServices.Core.IRepositories;
using RepositoryServices.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            ColorFormulas = new ColorFormulaRepository(context);
            Customers = new CustomerRepository(context);
            Products = new ProductRepository(context);
        }

        public IColorFormulaRepository ColorFormulas { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IProductRepository Products { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
