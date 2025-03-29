using System;
using System.Collections.Generic;

class Order
{
    private string _customerName;
    private List<(string Item, double Price)> _items;

    // Constructor
    public Order(string customerName)
    {
        _customerName = customerName;
        _items = new List<(string, double)>();
    }

    // Property for Customer Name with validation
    public string CustomerName
    {
        get { return _customerName; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                _customerName = value;
            else
                Console.WriteLine("Invalid customer name!");
        }
    }

    // Method to add an item to the order
    public void AddItem(string item, double price)
    {
        _items.Add((item, price));
        Console.WriteLine($"Added {item} - ${price:F2}");
    }

    // Method to calculate total price
    public double GetTotal()
    {
        double total = 0;
        foreach (var item in _items)
        {
            total += item.Price;
        }
        return total;
    }

    // Method to display order summary
    public string GetOrderSummary()
    {
        string summary = $"Order for {_customerName}:\n";
        foreach (var item in _items)
        {
            summary += $"- {item.Item}: ${item.Price:F2}\n";
        }
        summary += $"Total: ${GetTotal():F2}";
        return summary;
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Order order1 = new Order("Jessica");
        order1.AddItem("Laptop", 1200.00);
        order1.AddItem("Mouse", 25.00);
        Console.WriteLine(order1.GetOrderSummary());
    }
}
