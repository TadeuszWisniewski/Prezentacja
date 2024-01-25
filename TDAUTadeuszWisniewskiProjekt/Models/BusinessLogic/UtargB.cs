using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    public class UtargB:DataBaseClass
    {
        #region Konstruktor
        public UtargB(FirmaSpawalniczaEntities firmaSpawalniczaEntities)
            :base(firmaSpawalniczaEntities)
        {

        }
        #endregion
        #region BusinessFunction
        public decimal? UtargOkres( DateTime? dataOd, DateTime? dataDo)
        {
            return
                (
                    from faktura in firmaSpawalniczaEntities.Fakturas
                    where
                        faktura.KiedyUtworzono >= dataOd &&
                        faktura.KiedyUtworzono <= dataDo
                    select faktura.WartoscPoRabacie
                ).Sum();
        }
        #endregion
    }
}
