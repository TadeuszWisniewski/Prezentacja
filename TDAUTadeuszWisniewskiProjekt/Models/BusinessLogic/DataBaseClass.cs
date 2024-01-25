using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    //Wszystkie klasy logiki biznesowej które będą używały bazy danych będą dziedziczyły po tej klasie
    public class DataBaseClass
    {
        #region Pola
        protected FirmaSpawalniczaEntities firmaSpawalniczaEntities;
        #endregion
        #region Konstruktor
        public DataBaseClass(FirmaSpawalniczaEntities firmaSpawalniczaEntities)
        {
            this.firmaSpawalniczaEntities = firmaSpawalniczaEntities;
        }
        #endregion
    }
}
