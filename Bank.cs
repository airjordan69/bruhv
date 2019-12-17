using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace powto1
{
    [Serializable]
    public class Bank
    {
        public string NazwaBanku { get; set; }
        private LinkedList<Konto> ListaKont { get; set; }

        public Bank(string NazwaBankuu)
        {
            NazwaBanku = NazwaBankuu;
            ListaKont = new LinkedList<Konto>();
        }
        public void UtworzKonto(Konto k)
        {
            ListaKont.AddLast(k);
        }
        public void UsunKonto(ulong nrkonta)
        {
            foreach (Konto k in ListaKont)
            {
                if (k.numerKonta == nrkonta)
                {
                    ListaKont.Remove(k);
                }
            }
        }
        public Konto PodajKonto(ulong nrkonta)
        {
            foreach (Konto k in ListaKont)
            {
                if (k.numerKonta == nrkonta)
                {
                    return k;
                }
            }
            throw new Exception(String.Format("Brak konta o nr {0} w systemie banku", nrkonta));
        }
        public Konto PodajKonto(string nazwakonta)
        {
            foreach (Konto k in ListaKont)
            {
                if (k._wlasciciel == nazwakonta)
                {
                    return k;
                }
            }
            throw new Exception(String.Format("Brak konta o nazwie {0} w banku", nazwakonta));
        }
        public double SaldoBanku()
        {
            double saldo = 0;
            foreach (Konto k in ListaKont)
            {
                saldo += k.stanKonta;
            }
            return saldo;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"nazwa banku: {NazwaBanku}");
            sb.AppendLine(String.Format("Saldo banku: {0:0.00}", SaldoBanku()));
            sb.AppendLine("konta: ");
            foreach (Konto k in ListaKont)
            {
                sb.AppendLine(k.ToString());
            }

            return sb.ToString();
        }
        public void zapiszplik(string nazwapliku)
        {
            using (var stream = new FileStream(nazwapliku, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(Bank));
                XML.Serialize(stream, this);
            }
        }
        public void Zapisz(string nazwaPliku)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(nazwaPliku)) File.Delete(nazwaPliku);
            fileStream = File.Create(nazwaPliku);
            bf.Serialize(fileStream, this);
            fileStream.Close();
        }
        public static Bank Odczytaj(string nazwaPliku)
        {
            Bank b = null;
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(nazwaPliku))
            {
                fileStream = File.OpenRead(nazwaPliku);
                b = (Bank)bf.Deserialize(fileStream);
                fileStream.Close();
            }
            return b;
        }
    }
}
