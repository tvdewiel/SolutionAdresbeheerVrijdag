using AdresbeheerBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Model
{
    public class Straat
    {
        public Straat(int id, string straatnaam, Gemeente gemeente)
        {
            ZetId(id);
            ZetStraatnaam(straatnaam);
            ZetGemeente(gemeente);
        }
        public int Id { get; private set; }
        public string Straatnaam { get;private set; }
        public Gemeente Gemeente { get; private set; }
        public void ZetStraatnaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) { throw new StraatException("Zetstraatnaam"); }
            Straatnaam = naam;
        }
        public void ZetGemeente(Gemeente nieuweGemeente)
        {
            if (nieuweGemeente == null) { throw new StraatException("zetgemeente is null"); }
            if (nieuweGemeente==Gemeente) { throw new StraatException("zetgemeente is null"); }
            Gemeente = nieuweGemeente;
        }
        public void ZetId(int id)
        {
            if (id<=0) 
            {
                { throw new StraatException("id is null"); }
            }
            Id = id;
        }
    }
}
