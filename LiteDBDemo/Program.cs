// See https://aka.ms/new-console-template for more information
using LiteDB;

Console.WriteLine("Hello, World!");



// Open database (or create if doesn't exist)
using (var db = new LiteDatabase(@"MyData.db"))
{
    // Get customer collection
    var col = db.GetCollection<Customer>("customers");

    // Create your new customer instance
    var customer = new Customer
    {
        Name = "John Doe",
        Phones = new string[] { "8000-0000", "9000-0000" },
        Age = 39,
        IsActive = true
    };

    // Create unique index in Name field
    //col.EnsureIndex(x => x.Name, true);

    // Insert new customer document (Id will be auto-incremented)
    //col.Insert(customer);

    // Update a document inside a collection
    customer.Name = "Joana Doe";

    col.Update(customer);

    // Use LINQ to query documents (with no index)
    var results = col.Find(x => x.Age > 20);
}