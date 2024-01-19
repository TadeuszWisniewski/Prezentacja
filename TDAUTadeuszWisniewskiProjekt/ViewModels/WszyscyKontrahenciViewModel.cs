using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyK);
                    //zamyka okno
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
