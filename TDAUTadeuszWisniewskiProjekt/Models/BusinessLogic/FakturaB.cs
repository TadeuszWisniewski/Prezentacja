using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    public class FakturaB : DataBaseClass
    {
        public FakturaB(FirmaSpawalniczaEntities firmaSpawalniczaEntities) : base(firmaSpawalniczaEntities)
        {
        }
        public decimal? ObliczCenaPoczatkowa(ObservableCollection<PozycjaNaFakturzeForView> ListaPozycjiFaktury)
        {
            decimal? CenaPoczatkowa = null;
            foreach (PozycjaNaFakturzeForView p in ListaPozycjiFaktury)
            {
                if (CenaPoczatkowa == null)
                {
                    CenaPoczatkowa = p.Cena * p.Ilosc;
                }
                else
                {
                    CenaPoczatkowa = CenaPoczatkowa + (p.Cena * p.Ilosc);
                }
            }
            return CenaPoczatkowa;
        }
    }
}
