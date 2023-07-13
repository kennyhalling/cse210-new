public class Rectangle:Shape{
    private double _length;
    private double _width;

    public Rectangle(string color, string shape, double length, double width):base(color,shape){
        _length = length;
        _width = width;
    }

    public override double CalculateArea()
    {
        return Math.Round(_length*_width, 2);
    }
}