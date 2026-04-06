using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square(5);
        square1.SetColor("Red");
        Console.WriteLine($"Square: Color = {square1.GetColor()}, Area = {square1.GetArea()}");
 
        Rectangle rectangle1 = new Rectangle(4.5, 6);
        rectangle1.SetColor("Blue");
        Console.WriteLine($"Rectangle: Color = {rectangle1.GetColor()}, Area = {rectangle1.GetArea()}");

        Circle circle1 = new Circle(3.68);
        circle1.SetColor("Green");
        Console.WriteLine($"Circle: Color = {circle1.GetColor()}, Area = {circle1.GetArea()}");
    }
}