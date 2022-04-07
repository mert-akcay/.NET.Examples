namespace Oop101.Polymorphism.Models
{
    public abstract class Sekil
    {
        public double X { get; set; }

        public virtual double AlanHesapla() => X * X;

        public abstract double CevreHesapla();
    }

    public abstract class UcBoyutluSekil : Sekil
    {

    }
}
