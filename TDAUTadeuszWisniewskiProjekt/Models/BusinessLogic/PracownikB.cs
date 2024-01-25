using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    public class PracownikB : DataBaseClass
    {
        #region Konstruktor
        public PracownikB(FirmaSpawalniczaEntities firmaSpawalniczaEntities)
            : base(firmaSpawalniczaEntities)
        {

        }
        #endregion
        #region Metody
        public IQueryable<KeyAndValue2> GetNipKeyAndValueItems()
        {
            return
                (
                 from n in firmaSpawalniczaEntities.TypNips
                 select new KeyAndValue2
                 {
                     Key = n.Id,
                     Value = n.IloscCyfr
                 }
                ).ToList().AsQueryable();
        }
        public string? StworzKod(string? Imie, string? Nazwisko)
        {
            return Imie.Substring(0, 2) + Nazwisko.Substring(0, 2);
        }
        #endregion
    }
}
