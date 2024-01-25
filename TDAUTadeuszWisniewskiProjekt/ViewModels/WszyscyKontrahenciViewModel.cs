using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;


namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahentForView>
    {
        
        #region Command
        private KontrahentForView _WybranyK;
        public KontrahentForView WybranyK
        {
            set
            {
                if (_WybranyK != value)
                {
                    _WybranyK = value;
                    Messenger.Default.Send(_WybranyK);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyK;
            }
        }
        #endregion
        public WszyscyKontrahenciViewModel() 
            :base("Kontrahenci")
        {

        }


        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "NIP" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<KontrahentForView>(List.OrderBy(item => item.Bazwa));
            if (SortField == "NIP")
                List = new ObservableCollection<KontrahentForView>(List.OrderBy(item => item.Nip));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "NIP" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<KontrahentForView>(List.Where(item => item.Bazwa != null && item.Bazwa.StartsWith(FindTextBox)));
            if (FindField == "NIP")
                List = new ObservableCollection<KontrahentForView>(List.Where(item => item.Nip != null && item.Nip.StartsWith(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<KontrahentForView>
                (
                from Kontrahent in firmaSpawalniczaEntities.Kontrahents
                select new KontrahentForView
                {
                    Id = Kontrahent.Id,
                    Bazwa = Kontrahent.Bazwa,//
                    Kod = Kontrahent.Kod,//
                    Nip = Kontrahent.Nip,//
                    Krs = Kontrahent.Krs,
                    PodatnikVat=Kontrahent.PodatnikVat,
                    BlokadaSprzedazy= Kontrahent.BlokadaSprzedazy,
                    LimitKredytu=Kontrahent.LimitKredytu,
                    WalutaNazwa=Kontrahent.IdWalutaNavigation.Nazwa,
                    FormaPrawnaNazwa = Kontrahent.IdFormaPrawnaNavigation.Nazwa,
                    StronaWww = Kontrahent.StronaWww,
                    Regon=Kontrahent.Regon,
                    Opis=Kontrahent.Opis,
                    Aktywny=Kontrahent.Aktywny,
                    KiedyUtworzone=Kontrahent.KiedyUtworzone  
                }
                ) ;
        }
        
    }
}
