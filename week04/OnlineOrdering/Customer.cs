using System;

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public decimal CalculateShippingCost()
    {
        if (_address.IsInUSA())
        {
            return 5.00m; // Flat rate for USA
        }
        else
        {
            return 35.00m; // Flat rate for international
        }
    }
}