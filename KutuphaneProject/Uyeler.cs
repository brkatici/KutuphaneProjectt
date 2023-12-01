using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneProject
{
    public class Uyeler : IYazdirilabilir
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int ÜyelikNumarası { get; set; }
        public List<Kitap> AldığıKitaplar { get; set; }

        public void Yazdır()
        {
            Console.WriteLine($"Üye Adı: {Ad}, Soyadı: {Soyad}, Üyelik Numarası: {ÜyelikNumarası}");
        }
    }

}
