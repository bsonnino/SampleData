using System;
using Newtonsoft.Json;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
#if SAMPLEREPO
            var repository = new SampleCustomerRepository();
#else
            var repository = new CustomerRepository();
#endif
            var customers = repository.GetCustomers();
            Console.WriteLine(JsonConvert.SerializeObject(customers, 
                Formatting.Indented));
        }
    }
}
