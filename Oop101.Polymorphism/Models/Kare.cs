namespace Oop101.Polymorphism.Models
{
    public class Kare : Sekil, IKosegenHesapla
    {
        public override double CevreHesapla() => 4 * X;
        public double KosegenHesapla() => Math.Sqrt(2) * X;
    }
}