using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProizvodnja
{

    /// <summary>
    /// U ovoj klasi će biti smješteni podaci o sirovinama
    /// </summary>
    public class clsSirovine
    {
        public string sifra { get; set; }
        public string naziv { get; set; }
        public decimal cijena { get; set; }
        public decimal kolicina { get; set; }

        /// <summary>
        /// blanko konstruktor bez prenosa vrijednsti za parametre
        /// </summary>
        public clsSirovine() { }

        /// <summary>
        /// konstruktor sa parametrima
        /// </summary>
        /// <param name="s">varijabla za dodjelu šifre sirovine</param>
        /// <param name="n">varijabla za dodjelu naziva sirovine</param>
        /// <param name="c">varijabla za dodjelu cijene sirovine</param>
        /// <param name="k">varijabla za dodjelu kolicine sirovine</param>
        public clsSirovine(string s, string n, decimal c, decimal k) 
        {
            sifra = s;
            naziv = n;
            cijena = c;
            kolicina = k;
        }

        /// <summary>
        /// Property koji vraća sirovina
        /// </summary>
        public decimal UCijenaK
        {
            get
            {
                return cijena * kolicina;
            }
        }


        public override string ToString()
        {
            return $"{sifra} - {naziv} - {cijena} -> {UCijenaK}";
        }
    }
}
