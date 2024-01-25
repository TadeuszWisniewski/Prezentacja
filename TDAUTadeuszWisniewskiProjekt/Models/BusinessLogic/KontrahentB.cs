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
    public class KontrahentB : DataBaseClass
    {
        
        #region Konstruktor
        public KontrahentB(FirmaSpawalniczaEntities f)
            : base(f)
        {
            //firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion
        #region Metody
        public IQueryable<KeyAndValue> GetKontrahenciKeyAndValueItems()
        {
            return
                (
                    from k in firmaSpawalniczaEntities.Kontrahents
                    select new KeyAndValue
                    {
                        Key = k.Id,
                        Value = k.Bazwa
                    }
                ).ToList().AsQueryable();
        }
        //chwilowo brak użycia
        public void ObliczDlaWszystkich()
        {
            List<Kontrahent> kontrahenci = new List<Kontrahent>(
                from k in firmaSpawalniczaEntities.Kontrahents
                select k
                );

            foreach (Kontrahent k in kontrahenci)
            {
                if (k.Aktywny == true)
                {
                    ObliczDlaWszystkichPol(k.Id);                   
                }
            }
        }
        public void ObliczDlaWszystkichPol(int? IdKontrahent)
        {          
            Kontrahent? kontrahent =firmaSpawalniczaEntities.Kontrahents.FirstOrDefault(k => k.Id == IdKontrahent);
            kontrahent.LacznaWartoscFaktur = SumaOgolem(IdKontrahent);
            kontrahent.SumaZaleglychNaleznosci = ObliczZalegle(IdKontrahent);
            kontrahent.PozostalyLimit = kontrahent.LimitKredytu - kontrahent.SumaZaleglychNaleznosci;
            if (kontrahent.PozostalyLimit <= 0)
            {
                kontrahent.BlokadaSprzedazy = true;
            }
            kontrahent.KiedyZmieniono = DateTime.Today;
            firmaSpawalniczaEntities.SaveChanges();
        }
       
        public decimal? ObliczZalegle(int? IdKontrahenta)
        {
            decimal? ogolem = SumaOgolem(IdKontrahenta);
            decimal? zaplacone = SumaZaplacone(IdKontrahenta);
            return ogolem - zaplacone;
        }
        public decimal? SumaOgolem(int? Id)
        {
            decimal? wynik = (from f in firmaSpawalniczaEntities.Fakturas where f.IdKontrahenta == Id select f.WartoscPoRabacie).Sum();
            if (wynik == null)
            {
                return 0;
            }
            return wynik;
        }
        public decimal? SumaZaplacone(int? Id)
        {

            decimal? wynik = (from f in firmaSpawalniczaEntities.Fakturas where f.IdKontrahenta == Id && f.Zaplacone == true select f.WartoscPoRabacie).Sum();
            if (wynik == null)
            {
                return 0;
            }
            return wynik;
        }
        public string? StworzKod(string? Nazwa)
        {
            return Nazwa.Substring(0, 3);
        }
        public IQueryable<KeyAndValue> GetWalutyKeyAndValueItems()
        {
            return
                (
                    from w in firmaSpawalniczaEntities.Waluta
                    select new KeyAndValue
                    {
                        Key = w.Id,
                        Value = w.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
