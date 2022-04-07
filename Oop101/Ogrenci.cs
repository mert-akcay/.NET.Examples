namespace Oop101
{
    public class Ogrenci : Kisi
    {
        public Ogrenci()
        {
            this._korumali = 25;
            this.Korumali = 25;
        }

        public string No { get; set; }
        public string Sinif { get; set; }
        public double Ortalama { get; set; }
    }
}
