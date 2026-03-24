using System;

class Order
{
    private List<string> items;
    private string customerName;

    public Order(string customerName)
    {
        this.customerName = customerName;
        this.items = new List<string>();
    }

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public string DisplayPackingLabel()
    {
        return $"Packing label for {customerName}:\n{string.Join("\n", items)}";
    }
    public string DisplayShippingLabel()
    {
        return $"Shipping label for {customerName}:\n{string.Join("\n", items)}";
    }
}