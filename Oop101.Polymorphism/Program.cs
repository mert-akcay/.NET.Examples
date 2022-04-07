using Oop101.Polymorphism.Models;

List<Sekil> sekiller = new();

Sekil kare1 = new Kare()
{
    X = 5
};
Sekil kare2 = new Kare()
{
    X = 3
};

Sekil dikdortgen1 = new DikDortgen()
{
    X = 3,
    Y = 4
};

DikDortgen dikdortgen2 = new DikDortgen()
{
    X = 5,
    Y = 12
};

sekiller.Add(kare1);
sekiller.Add(kare2);
sekiller.Add(dikdortgen1);
sekiller.Add(dikdortgen2);

Sekil ucgen1 = new Ucgen()
{
    X = 3,
    Y = 4
};

Sekil ucgen2 = new Ucgen()
{
    X = 5,
    Y = 12
};

sekiller.Add(ucgen1);
sekiller.Add(ucgen2);

//Sekil sekil1 = new Sekil()
//{
//    X = 6
//};

foreach (Sekil item in sekiller)
{
    if (item is Kare) Console.WriteLine("Kare");
    else if (item is Ucgen) Console.WriteLine("Üçgen");
    else if (item is DikDortgen) Console.WriteLine("Dikdörtgen");

    Console.WriteLine($"Alan: {item.AlanHesapla()}m²");
    Console.WriteLine($"Çevresi: {item.CevreHesapla()}m");
}

/*
 * Factory 
 * Observer
 * Decorator
 */


/*
 * tüm kişi nesnelerinin validasyonları yapılacak
 * TCKN validasyonu
 * telefon validasyonu
 * ad soyad email validasyonu
 * 
 *
 * Müşteri - bakiye validasyonu 
 * Personel, birim müdürü, genel müdür
 *  çalışanların maaş hesabı olacak
 * birimler- birimlerin hangi müdüre/birim müdürüne bağlı olduğu ayarlanabilecek
 * müşterilerin bakiyeleri hesaplanabilecek
 * 
 */

Sekiller seciliSekil = Sekiller.Ucgen;

var uretilenSekil = SekilFactory(seciliSekil);

Sekil SekilFactory(Sekiller sekil)
{
    Sekil model;
    switch (sekil)
    {
        case Sekiller.Kare:
            model = new Kare();
            break;
        case Sekiller.DikDortgen:
            model = new DikDortgen();
            break;
        case Sekiller.Ucgen:
            model = new Ucgen();
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(sekil), sekil, null);
    }

    return model;
}

Stack<Sekil> sekilStack = new(); //lifo
Queue<Sekil> sekilQueue = new(); //fifo

