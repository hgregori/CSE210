using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.\n");

        // ----- FIRST ORDER -----
        Address a1 = new Address("123 Maple St", "Chicago", "IL", "USA");
        Customer c1 = new Customer("John Smith", a1);

        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Keyboard", 30m, "K001", 1));
        o1.AddProduct(new Product("Mouse", 15m, "M100", 2));

        Console.WriteLine(o1.GetPackingLabel());
        Console.WriteLine(o1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${o1.GetTotalCost()}\n");

        // ----- SECOND ORDER -----
        Address a2 = new Address("45 Avenida Brasil", "Rio de Janeiro", "RJ", "Brazil");
        Customer c2 = new Customer("Maria Oliveira", a2);

        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Laptop", 1200m, "L500", 1));
        o2.AddProduct(new Product("USB Cable", 5m, "U200", 3));

        Console.WriteLine(o2.GetPackingLabel());
        Console.WriteLine(o2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${o2.GetTotalCost()}");
    }
}