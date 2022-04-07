namespace Oop101.Polymorphism.Models
{
    public class Ucgen : DikDortgen
    {
        public override double AlanHesapla() => base.AlanHesapla() / 2;

        public override double CevreHesapla()
        {
            return base.CevreHesapla() / 2 + this.KosegenHesapla();
        }
    }
}