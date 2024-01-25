using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    public class MiejsceUrodzeniaB:DataBaseClass
    {
    
        #region Konstruktor
        public MiejsceUrodzeniaB(FirmaSpawalniczaEntities firmaSpawalniczaEntities)
            :base(firmaSpawalniczaEntities)
        {

        }
        #endregion

        #region Metody
        public IQueryable<KeyAndValue> GetMiejscowosciKeyAndValueItems()
        {
            return
                (
                 from m in firmaSpawalniczaEntities.Miejscowoscs
                 select new KeyAndValue
                 {
                     Key = m.Id,
                     Value = m.Nazwa
                 }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
