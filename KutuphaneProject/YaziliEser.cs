using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneProject
{
    public class YazılıEser : IYazdirilabilir
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public int YayınYılı { get; set; }
        public int KitapID { get; set; }

        public bool Status { get; set; }
        public virtual void Yazdır()
        {
            if (Status == true)
            {
                Console.WriteLine($"Kitap ID: {KitapID}, Ad: {Ad}, Yazar: {Yazar}, Durum: Ödünç Verilmedi");
            }
            else
            {
                Console.WriteLine($"Kitap ID: {KitapID}, Ad: {Ad}, Yazar: {Yazar}, Durum: Ödünç Verildi");
            }
        }
    }

    public class Kitap : YazılıEser
    {

        public Kitap(int kitapID, string ad, string yazar, int yayınYılı)
        {
            KitapID = kitapID;
            Ad = ad;
            Yazar = yazar;
            YayınYılı = yayınYılı;
            Status = true;
        }
    }

}
