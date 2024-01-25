using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    public class WyplatyB : DataBaseClass
    {
        #region Konstruktor
        public WyplatyB(FirmaSpawalniczaEntities f)
            : base(f)
        {
            firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion
        #region Metody
        public IQueryable<KeyAndValue> GetPracownicyKeyAndValueItems()
        {
            return
                (
                    from k in firmaSpawalniczaEntities.Pracowniks
                    select new KeyAndValue
                    {
                        Key = k.Id,
                        Value = k.Akronim,
                    }
                ).ToList().AsQueryable();
        }
       
        public decimal? WyplataZaTenMiesiac(decimal? IloscDni, decimal? WysokoscWymiaruEtatu, decimal? Stawka)
        {
            decimal? iloscGodzinDziennie = WysokoscWymiaruEtatu / 5;
            return (iloscGodzinDziennie * Stawka) * IloscDni;
        }
        public string? UstawImieINazwisko(Pracownik? pracownik)
        {
            return pracownik.Imie + " " + pracownik.Nazwisko;
        }
        public decimal? IloscGodzinWTyg(Pracownik? pracownik)
        {
            WymiarEtatu? wymiarEtatu = firmaSpawalniczaEntities.WymiarEtatus.FirstOrDefault(w => w.Id == pracownik.IdWymiaruEtatu);
            return wymiarEtatu.IloscGodzinTygodniowo;
        }
        public decimal? LiczbaDniPracujacych()
        {
            int rok = DateTime.Now.Year;
            int miesiac = DateTime.Now.Month;
            int dniWMiesiacu = DateTime.DaysInMonth(rok, miesiac);
            int dniPracujace = 0;
            for(int dzien = 1; dzien <= dniWMiesiacu; dzien++)
            {
                DateTime data = new DateTime(rok, miesiac, dzien);
                if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                {
                    if(!(DniWolne().Contains(data)))
                    {
                        dniPracujace++;
                    }
                }
            }
            return dniPracujace;
        }
        public DateTime[] DniWolne()
        {
            //dni wolne 2024 wypadające poza weekendami
            DateTime[] dniWolne = new DateTime[] { new DateTime(2024, 1, 1), new DateTime(2024, 4, 1), new DateTime(2024, 5, 1), new DateTime(2024, 5, 3),
            new DateTime(2024, 5, 30), new DateTime(2024, 8, 15), new DateTime(2024, 11, 1), new DateTime(2024, 11, 11),
            new DateTime(2024, 12, 25), new DateTime(2024, 12, 26),
            };
            return dniWolne;
        }
    }
    
}
    #endregion


