public class Circle:Shape{
    private double _radius;

    public Circle(string color, string shape, double radius):base(color,shape){
        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.Round(Math.PI*_radius*_radius, 2);
    }
}