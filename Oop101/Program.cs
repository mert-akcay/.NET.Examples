using Oop101;

var tarih = DateTime.Now;
var rastgeleSayi = new Random().Next(1, 100);

try
{
    var kisi1 = new Kisi() //Object - initilazer
    {
        Ad = "Kamil",
        Soyad = "Fıdıl",
        DogumTarihi = new DateTime(2000, 1, 1).AddYears(22).AddMonths(3).AddDays(3)
    };
    Console.WriteLine($"Yaş: {kisi1.Yas}");
    Console.WriteLine($"Oluşturma Zamanı: {kisi1.OlusturmaZamani}");

    var kisi2 = new Kisi("Ayşe", "Fıdıl")
    {
        DogumTarihi = new DateTime(2000, 1, 1)
    };

    Kisi kisi3 = new();
    //kisi3.Korumali = 30;
    Console.WriteLine();

    Kisi ogrenci1 = new Ogrenci()
    {
        Ad = "Ahmet",
        Soyad = "Fıdıl",
        DogumTarihi = new DateTime(2000, 1, 1),
        No = "1234",
        Ortalama = 4,
        Sinif = "10/F"
    };
    

    Kisi ogretmen1 = new Ogretmen()
    {
        Ad = "Hakkı",
        Soyad = "Fıdıl",
        DogumTarihi = new DateTime(1975, 1, 1),
        Brans = "Matematik",
        Maas = 10000,
        SicilNo = "124346546dsfslşkmdf"
    };


    var kisiler = new List<Kisi>();

    kisiler.Add(ogrenci1);
    kisiler.Add(ogretmen1);

    foreach (var item in kisiler)
    {
        if (item is Ogrenci ogr)
        {
            Console.WriteLine("Öğrenci");
            //var ogr = item as Ogrenci;
            Console.WriteLine(ogr.Sinif);
        }
        else if (item is Ogretmen ogm)
        {
            Console.WriteLine("Öğretmen");
            //var ogm = item as Ogretmen;
            Console.WriteLine(ogm.Brans);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}