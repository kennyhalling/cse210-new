public class Square:Shape{
    private double _side;

    public Square(string color, string shape, double side):base(color,shape){
        _side = side;
    }

    public override double CalculateArea()
    {
        return Math.Round(_side*_side, 2);
    }
}