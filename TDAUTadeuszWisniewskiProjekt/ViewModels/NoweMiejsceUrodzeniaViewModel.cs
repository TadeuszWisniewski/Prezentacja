using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NoweMiejsceUrodzeniaViewModel : JedenViewModel<MiejsceUrodzenium>
    {
        public NoweMiejsceUrodzeniaViewModel() 
            : base("Miejsce urodzenia")
        {
            item = new MiejsceUrodzenium();
            _DataUtworzenia = DateTime.Now;
        }
        //dopisać warunek zabetonowania
        private readonly DateTime? _DataUtworzenia;
        public DateTime? DataUtworzenia
        {
            get
            {
                if (item.KiedyUtworzone != _DataUtworzenia)
                {
                    item.KiedyUtworzone = _DataUtworzenia;
                }
                return item.KiedyUtworzone;
            }
        }
        public int? MiejscowoscId
        {
            get
            {
                return item.IdMiejscowosc;
            }
            set
            {
                if(item.IdMiejscowosc != value)
                {
                    item.IdMiejscowosc = value;
                    base.OnPropertyChanged(() => MiejscowoscId);
                }
            }
        }
        public IQueryable<Miejscowosc> MiejscowoscComboBoxItems
        {
            get
            {
                return
                    (
                    from Miejscowosc in firmaSpawalniczaEntities.Miejscowoscs
                    select Miejscowosc
                    ).ToList().AsQueryable();
            }
        }
        public bool? Aktywny
        {
            get
            {
                return item.Aktywny;
            }
            set
            {
                if (item.Aktywny != value)
                {
                    item.Aktywny = value;
                    OnPropertyChanged(() => Aktywny);
                }
            }
        }
        public string? Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if(item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }
    }
}
