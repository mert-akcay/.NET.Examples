namespace Oop101.Polymorphism.Models;

public class DikDortgen : Sekil, IKosegenHesapla
{
    public double Y { get; set; }

    public override double AlanHesapla() => X * Y;
    public override double CevreHesapla() => (X + Y) * 2;
    public double KosegenHesapla() 
        => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
}