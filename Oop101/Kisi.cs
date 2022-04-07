namespace Oop101
{
    public class Kisi
    {
        //Access Modifiers
        /*
         * private; sadece tanımlandığı scope içinden erişilebilir
         * internal; sadece aynı namespace(proje) içerisinden erişilebilir
         * public; referans verilen tüm projelerden erişilebilir
         * protected; sadece kalıtım içerisinden erişilebilir
         * protected internal; sadece kalıtımdan ve aynı namespace(proje) den erişilebilir
         *
         * Default Access Modifiers
         * Class interface enum gibi nesneler internal
         * Field, prop., degisken, method vs bunlar da private
         */
        
        private string _ad; //field
        private string _soyad;
        private DateTime _dogumTarihi; //kimse tarafından kullanılmıyor
        private int _a = 10;
        private readonly DateTime _olusturulmaZamani;

        //constructor

        public Kisi() // class oluşturulurken çalışacak method
        {
            _olusturulmaZamani = DateTime.Now;
            OlusturmaZamani = _olusturulmaZamani;
        }

        public Kisi(string ad, string soyad)
        {
            this.Ad = ad;
            this.Soyad = soyad;
        }

        protected int _korumali = 10;

        public int Korumali
        {
            get => _korumali;
            protected set => _korumali = value;
        } 

        public string Ad //full-property
        {
            get => _ad.ToUpper();
            set
            {
                foreach (char harf in value)
                {
                    if (char.IsDigit(harf))
                        throw new Exception("Adınızda rakam bulunamaz");
                }

                _a = 20;
                _ad = value;
            }
        }
        public string Soyad //full-property
        {
            get => _soyad;
            set => _soyad = value;
        }
        public DateTime DogumTarihi { get; set; } //auto-property
        public int Yas => DateTime.Now.Year - DogumTarihi.Year; // read-only property
        public DateTime OlusturmaZamani { get; }
    }
}
