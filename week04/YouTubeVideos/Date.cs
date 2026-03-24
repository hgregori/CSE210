using System;

class Date
{
    private int _day;
    private int _month;
    private int _year;

    public Date(int day, int month, int year)
    {
        _day = day;
        _month = month;
        _year = year;
    }

    public string GetFullDate()
    {
        return $"{_month}/{_day}/{_year}";
    }

}