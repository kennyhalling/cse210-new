using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> Shapes = new List<Shape>();
        Shapes.Add(new Square("blue","square",5.0));
        Shapes.Add(new Rectangle("orange","rectangle",4.0,3.0));
        Shapes.Add(new Circle("green","circle",1.0));

        Console.Clear();
        foreach (Shape shape in Shapes){
            shape.DisplayInfo(shape.CalculateArea());
        }
    }
}