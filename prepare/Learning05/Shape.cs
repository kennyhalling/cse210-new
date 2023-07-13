public abstract class Shape{
    private string _color;
    private string _shape;

    public Shape(string color, string shape){
        _color = color;
        _shape = shape;
    }

    public void DisplayInfo(double area){
        Console.WriteLine($"{_color.ToUpper()} {_shape.ToUpper()}: {area}");
    }

    public abstract double CalculateArea();
}