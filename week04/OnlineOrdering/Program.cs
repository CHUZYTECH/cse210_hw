// Address.cs
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA() => _country.ToLower() == "usa";
    public override string ToString() => $"{_street}, {_city}, {_state}, {_country}";
}

// Customer.cs
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA() => _address.IsInUSA();
    public override string ToString() => $"{_name}\n{_address}";
}

// Product.cs
public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalPrice() => _price * _quantity;
    public override string ToString() => $"{_name} (ID: {_id}) - ${_price} x {_quantity}";
}

// Order.cs
public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product) => _products.Add(product);
    public double GetTotalPrice() => _products.Sum(p => p.GetTotalPrice()) + (_customer.IsInUSA() ? 5.0 : 35.0);
    public string GetPackingLabel() => string.Join("\n", _products);
    public string GetShippingLabel() => _customer.ToString();
}

// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "Canada");
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Alice Smith", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 49.99, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "M789", 199.99, 1));
        order2.AddProduct(new Product("Keyboard", "K101", 89.99, 1));

        PrintOrderDetails(order1);
        PrintOrderDetails(order2);
    }

    static void PrintOrderDetails(Order order)
    {
        Console.WriteLine("\nORDER DETAILS");
        Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}\n");
    }
}
