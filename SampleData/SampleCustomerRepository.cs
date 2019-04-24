using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace SampleData
{
    public class SampleCustomerRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {
            Randomizer.Seed = new Random(123456);
            var ordergenerator = new Faker<Order>()
                .RuleFor(o => o.Id, Guid.NewGuid)
                .RuleFor(o => o.Date, f => f.Date.Past(3))
                .RuleFor(o => o.OrderValue, f => f.Finance.Amount(0, 10000))
                .RuleFor(o => o.Shipped, f => f.Random.Bool(0.9f));
            var customerGenerator = new Faker<Customer>()
                .RuleFor(c => c.Id, Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.ContactName, (f, c) => f.Name.FullName())
                .RuleFor(c => c.Orders, f => ordergenerator.Generate(f.Random.Number(10)).ToList());
            return customerGenerator.Generate(100);
        }
        
       
        
    }
}
