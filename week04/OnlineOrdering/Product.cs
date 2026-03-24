using System;

class Product
{
    private string _name;
    private decimal _price;
    private string _productId;
    private int _quantity;

    // The total cost of this product is computed by multiplying the price per unit and the quantity. (If the price per unit was $3 and they bought 5 of them, the product total cost would be $15.)

    public Product(string name, decimal price, string productId, int quantity)
    {
        _name = name;
        _price = price;
        _productId = productId;
        _quantity = quantity;
    }
    
    public string GetName() => _name;
    public string GetProductId() => _productId;
    public decimal GetPrice() => _price;
    public int GetQuantity() => _quantity;
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}