using AdresbeheerBL.Exceptions;
using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Services
{
    public class StraatService
    {
        private IStraatRepository repo;

        public StraatService(IStraatRepository repo)
        {
            this.repo = repo;
        }

        public List<Straat> GeefStratenGemeente(int id)
        {
            try
            {
                return repo.GeefStratenGemeente(id);
            }
            catch(Exception ex) { throw new StraatServiceException("Geefstratengemeente", ex); }
        }
    }
}
