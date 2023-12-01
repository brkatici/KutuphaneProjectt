using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneProject
{
    public class Kutuphane
    {
        private List<Kitap> kitaplar;
        private List<Uyeler> üyeler;

        public Kutuphane()
        {
            kitaplar = new List<Kitap>();
            üyeler = new List<Uyeler>();
        }

        public List<Kitap> GetKitaplar()
        {
            return kitaplar;
        }

        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
        }

        public void KitapSil(int kitapID)
        {
            Kitap silinecekKitap = kitaplar.FirstOrDefault(k => k.KitapID == kitapID);
            if (silinecekKitap != null)
            {
                kitaplar.Remove(silinecekKitap);
                Console.WriteLine("Kitap silindi.");
            }
            else
            {
                Console.WriteLine("Belirtilen ID'ye sahip kitap bulunamadı.");
            }
        }
        public void UyeEkle(Uyeler uye)
        {
            üyeler.Add(uye);
        }

        public List<Uyeler> GetUyeler()
        {
            return üyeler;
        }

        public void ÖdünçVer(Uyeler üye, Kitap kitap)
        {
            üye.AldığıKitaplar.Add(kitap);
            kitaplar.Remove(kitap);
            kitap.Status=false;
            kitaplar.Add(kitap);
        }

        public void İadeEt(Uyeler üye, Kitap kitap)
        {
            üye.AldığıKitaplar.Remove(kitap);
            kitaplar.Remove(kitap);
            kitap.Status = true;
            kitaplar.Add(kitap);
        }
    }

}
