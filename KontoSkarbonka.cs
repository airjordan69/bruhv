using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powto1
{
    public class KontoSkarbonka : Konto
    {
        public double skarbonka = 0;
       
        new public void Wyplac(double kwota) {
            if (MoznaWyplacic(kwota))
            {
                _stanKonta -= kwota;
                skarbonka += kwota * (0.01);
            }
            else
                throw new ZlaOperacjaException("niewystarczajaca ilosc dutkow na koncie");

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Wlasciciel: {wlasciciel}");
            sb.AppendLine($"Numer konta: {numerKonta}");
            sb.AppendLine($"Stan konta: {stanKonta:0.00zł}");
            sb.AppendLine($"skarbonka: {skarbonka:0.00zł}");

            return sb.ToString();
        }
        public KontoSkarbonka(string wlasciciel) : base(wlasciciel)
        {

        }
    }
}
