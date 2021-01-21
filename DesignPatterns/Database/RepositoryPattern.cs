using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DesignPatterns.Database
{
    public class RepositoryPattern
    {
        //Startup.cs:
        //services.AddTransient<ShoppingContext>();
        //services.AddTransient<IRepository<Customer>, CustomerRepository>();

        //controller:
        //private readonly IRepository<Customer> repository;

        //public CustomerController(IRepository<Customer> repository)
        //{
        //    this.repository = repository;
        //}
    }

    #region DomainModels
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
    #endregion

    #region Context
    public class ShoppingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    // .UseLazyLoadingProxies()
            //    .UseSqlite("Data Source=orders.db");
        }
    }
    #endregion

    #region Repositories
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(Guid id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }

    public abstract class GenericRepository<T>
    : IRepository<T> where T : class
    {
        protected ShoppingContext context;

        public GenericRepository(ShoppingContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return context
                .Add(entity)
                .Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Get(Guid id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> All()
        {
            return context.Set<T>()
                .ToList();
        }

        public virtual T Update(T entity)
        {
            return context.Update(entity)
                .Entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override Customer Update(Customer entity)
        {
            var customer = context.Customers
                .Single(c => c.CustomerId == entity.CustomerId);

            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.Country = entity.Country;

            return base.Update(customer);
        }
    }

    #endregion
}
