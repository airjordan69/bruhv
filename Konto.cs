using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powto1
{
    public class Konto : IComparable<Konto>
    {
        public string _wlasciciel;
        public double _stanKonta = 0;
        public ulong _numerKonta;
        static ulong _biezacynumerKonta = 100;

        protected string wlasciciel
        {
            get { return _wlasciciel; }
        }

        public double stanKonta
        {
            get { return _stanKonta; }
        }
        public ulong numerKonta
        {
            get { return _numerKonta; }
        }


        public Konto(string wlasciciel)
        {
            if (wlasciciel.Length < 5)
            {
                throw new ZlaNazwaException("nazwa wlasciciela ponizej 5 znakow");
            }
            else
            {
                _wlasciciel = wlasciciel;
            }
            _stanKonta = 0;
            _numerKonta = ++_biezacynumerKonta;

        }
      //  public int CompareTo(Konto other)
     //   {
    //        return this.stanKonta.CompareTo(Konto.stanKonta);
   //     }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Wlasciciel: {wlasciciel}");
            sb.AppendLine($"Numer konta: {numerKonta}");
            sb.AppendLine($"Stan konta: {stanKonta:0.00zł}");

            return sb.ToString();
        }

        public void Wplac(double kwota)
        {
            _stanKonta = _stanKonta + kwota;
        }
        public bool MoznaWyplacic(double kwota)
        {
            if(stanKonta - kwota < 0)
            {
                return false;
            }
            else { return true; }
        }
        public void Wyplac(double kwota)
        {
            if (MoznaWyplacic(kwota))
            {
                _stanKonta -= kwota;
            }
            else
                throw new ZlaOperacjaException("niewystarczajaca ilosc dutkow na koncie");
        }
        static public void Przelej(Konto k1, Konto k2, double kwota)
        {
            if (kwota <= k1._stanKonta)
            {
                k1._stanKonta = k1._stanKonta - kwota;
                k2._stanKonta = k2._stanKonta + kwota;
            }
            else
                throw new ZlaOperacjaException("mierz sily na zamiary wariacie");
        }

        
    }
    class ZlaNazwaException : Exception
    {
        public ZlaNazwaException(string message) : base(message)
        {
        }
    }
    class ZlaOperacjaException : Exception
    {
        public ZlaOperacjaException(string message) : base(message)
        {
        }
    }


}
