using KutuphaneProject;

Kutuphane kutuphane = new Kutuphane();


Kitap kitap1 = new Kitap(1, "Sapiens: Homo Deus", "Yuval Noah Harari", 2011);
Kitap kitap2 = new Kitap(2, "1984", "George Orwell", 1949);
Kitap kitap3 = new Kitap(3, "Dune", "Frank Herbert", 1965);
Kitap kitap4 = new Kitap(4, "To Kill a Mockingbird", "Harper Lee", 1960);
Kitap kitap5 = new Kitap(5, "The Great Gatsby", "F. Scott Fitzgerald", 1925);

kutuphane.KitapEkle(kitap1);
kutuphane.KitapEkle(kitap2);
kutuphane.KitapEkle(kitap3);
kutuphane.KitapEkle(kitap4);
kutuphane.KitapEkle(kitap5);



Uyeler üye1 = new Uyeler
{
    Ad = "Ahmet",
    Soyad = "Yılmaz",
    ÜyelikNumarası = 1001,
    AldığıKitaplar = new List<Kitap>()
};
Uyeler üye2 = new Uyeler
{
    Ad = "Ayşe",
    Soyad = "Demir",
    ÜyelikNumarası = 1002,
    AldığıKitaplar = new List<Kitap>()
};
Uyeler üye3 = new Uyeler
{
    Ad = "Mehmet",
    Soyad = "Can",
    ÜyelikNumarası = 1003,
    AldığıKitaplar = new List<Kitap>()
};

kutuphane.UyeEkle(üye1);
kutuphane.UyeEkle(üye2);
kutuphane.UyeEkle(üye3);


while (true)
{
    Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
    Console.WriteLine("1. Yeni Kitap Ekle");
    Console.WriteLine("2. Kitap Sil");
    Console.WriteLine("3. Tüm Kitapları Görüntüle");
    
    Console.WriteLine("4. Yeni Üye Ekle");
    Console.WriteLine("5. Üye Sil");
    Console.WriteLine("6. Tüm üyeleri görüntüle");

    Console.WriteLine("7. Kitap ödünç ver");
    Console.WriteLine("8. Kitap geri al");

    Console.WriteLine("9. Çıkış");

    // Kullanıcının seçimini alma
    Console.Write("Seçiminiz: ");
    int secim = Convert.ToInt32(Console.ReadLine());

    switch (secim)
    {
        case 1:
            KitapEkle(kutuphane); 
            break;
        case 2:
            Console.Write("Silinecek kitabın ID'sini girin: ");
            int silinecekID = Convert.ToInt32(Console.ReadLine());
            kutuphane.KitapSil(silinecekID);
            break;
            
        case 3:
            TumKitaplariGoruntule(kutuphane);
            break;
        case 4:
            UyeEkle(kutuphane);
            break;
        case 5:
            break;
        case 6:
            TumUyeleriGoruntule(kutuphane);
            break;
        case 7:
            KitapOduncVer(kutuphane); 
            break;
        case 8:
            KitapGeriAl(kutuphane);
            break;
        case 9:
            break;
        default:
            Console.WriteLine("Geçersiz seçim!");
            break;
    }
}
 static void KitapEkle(Kutuphane kütüphane)
{
    Console.WriteLine("Yeni kitap eklemek için bilgileri girin:");
    Console.Write("Kitap Adı: ");
    string kitapAdı = Console.ReadLine();

    Console.Write("Yazar: ");
    string yazar = Console.ReadLine();

    Console.Write("Yayın Yılı: ");
    int yayınYılı = Convert.ToInt32(Console.ReadLine());

    Console.Write("Kitap ID: ");
    int kitapID = Convert.ToInt32(Console.ReadLine());

    // Yeni kitabı oluşturma
    Kitap yeniKitap = new Kitap(kitapID, kitapAdı,yazar,yayınYılı);

    // Kütüphaneye yeni kitabı ekleme
    kütüphane.KitapEkle(yeniKitap);

    // Kullanıcıya eklenen kitabın bilgilerini gösterme
    Console.WriteLine("Yeni kitap eklendi:");
    yeniKitap.Yazdır();
}
static void TumKitaplariGoruntule(Kutuphane kütüphane)
{
    Console.WriteLine("Tüm Kitaplar:");
    foreach (var kitap in kütüphane.GetKitaplar())
    {
        kitap.Yazdır();
    }
}
static void TumUyeleriGoruntule(Kutuphane kütüphane)
{
    Console.WriteLine("Tüm Üyeler:");
    foreach (var üye in kütüphane.GetUyeler())
    {
        üye.Yazdır(); // Üyelerin bilgilerini ekrana yazdırma
    }
}

static void UyeEkle(Kutuphane kütüphane)
{
    Console.WriteLine("Yeni üye eklemek için bilgileri girin:");

    Console.Write("Ad: ");
    string ad = Console.ReadLine();

    Console.Write("Soyad: ");
    string soyad = Console.ReadLine();

    // Rastgele üyelik numarası üretme
    Random rastgele = new Random();
    int uyelikNumarasi = rastgele.Next(100, 1000);

    Uyeler yeniÜye = new Uyeler
    {
        Ad = ad,
        Soyad = soyad,
        ÜyelikNumarası = uyelikNumarasi,
        AldığıKitaplar = new List<Kitap>()
    };

    kütüphane.UyeEkle(yeniÜye);
    Console.WriteLine($"Üye eklendi: {yeniÜye.Ad} {yeniÜye.Soyad}");
}
 static void KitapOduncVer(Kutuphane kütüphane)
{
    Console.WriteLine("Kitap ödünç vermek için bilgileri girin:");

    Console.Write("Kitap ID'si: ");
    int kitapID = Convert.ToInt32(Console.ReadLine());

    Console.Write("Üyelik Numarası: ");
    int uyelikNumarasi = Convert.ToInt32(Console.ReadLine());

    // Kullanıcının belirttiği kitapı bul
    Kitap oduncVerilecekKitap = kütüphane.GetKitaplar().FirstOrDefault(k => k.KitapID == kitapID);

    // Kullanıcının belirttiği üyeyi bul
    Uyeler uyeyiBul = kütüphane.GetUyeler().FirstOrDefault(u => u.ÜyelikNumarası == uyelikNumarasi);

    if (oduncVerilecekKitap != null && uyeyiBul != null)
    {
        kütüphane.ÖdünçVer(uyeyiBul, oduncVerilecekKitap);
        Console.WriteLine("Kitap ödünç verildi.");
    }
    else
    {
        Console.WriteLine("Kitap veya üye bulunamadı.");
    }
}

static void KitapGeriAl(Kutuphane kütüphane)
{
    Console.WriteLine("Kitabı geri almak için bilgileri girin:");

    Console.Write("Kitap ID'si: ");
    int kitapID = Convert.ToInt32(Console.ReadLine());

    Console.Write("Üyelik Numarası: ");
    int uyelikNumarasi = Convert.ToInt32(Console.ReadLine());

    // Kullanıcının belirttiği kitapı bul
    Kitap oduncVerilenKitap = kütüphane.GetKitaplar().FirstOrDefault(k => k.KitapID == kitapID);

    // Kullanıcının belirttiği üyeyi bul
    Uyeler uyeyiBul = kütüphane.GetUyeler().FirstOrDefault(u => u.ÜyelikNumarası == uyelikNumarasi);

    if (oduncVerilenKitap != null && uyeyiBul != null)
    {
        kütüphane.İadeEt(uyeyiBul, oduncVerilenKitap);
        Console.WriteLine("Kitap iade edildi.");
    }
    else
    {
        Console.WriteLine("Kitap veya üye bulunamadı.");
    }
}

