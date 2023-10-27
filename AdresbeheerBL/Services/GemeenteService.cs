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
    public class GemeenteService
    {
        private IGemeenteRepository repo;

        public GemeenteService(IGemeenteRepository repo)
        {
            this.repo = repo;
        }

        public Gemeente GeefGemeente(int id)
        {
            try
            {
                return repo.GeefGemeente(id);
            }
            catch(Exception ex) { throw new GemeenteServiceException("GeefGemeente"); }
        }

        public Gemeente VoegGemeenteToe(Gemeente gemeente)
        {
            try
            {
                if (gemeente == null) { throw new GemeenteServiceException("gemeente is null"); }
                if (repo.HeeftGemeente(gemeente.NIScode)) throw new GemeenteServiceException("gemeente bestaat al");
                repo.VoegGemeenteToe(gemeente);
                return gemeente;
            }
            catch (GemeenteServiceException) {throw; }
            catch (Exception ex) { throw new GemeenteServiceException("voeggemeentetoe", ex); }
        }
    }
}
