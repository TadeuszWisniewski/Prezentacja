using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class PracownikForView
    {
        public int Id { get; set; }

        public int? IdJednostkaOrganizacyjna { get; set; }

        public string? JednostkaOrganizacyjnaNazwa {  get; set; }

        public DateTime? DataZawarciaUmowy { get; set; }

        public int? IdPodstawyZatrudnienia { get; set; }

        public int? IdTypUmowyOprace { get; set; }

        public int? IdStanowisko { get; set; }

        public int? IdWymiaruEtatu { get; set; }

        public decimal? Stawka { get; set; }

        public int? IdTypStawki { get; set; }

        public string? Akronim { get; set; }

        public string? Imie { get; set; }

        public string? Pesel { get; set; }

        public DateTime? DataUrodzenia { get; set; }

        public string? ImieOjca { get; set; }

        public string? NazwiskoRodowe { get; set; }

        public string? Nazwisko { get; set; }

        public string? DrugieImie { get; set; }

        public int? IdTypNip { get; set; }

        public string? Nip { get; set; }

        public int? IdMiejsceUrodzenia { get; set; }

        public string? ImieMatki { get; set; }

        public string? NazwiskoRodoweMatki { get; set; }

        public int? IdAdresuZamieszkania { get; set; }

        public int? IdAdresuKorespondencji { get; set; }

        public bool? Aktywny { get; set; }

        public DateTime? KiedyUtworzone { get; set; }

        public string? KtoUtworzyl { get; set; }

        public DateTime? KiedyZmieniono { get; set; }

        public string? KtoZmienil { get; set; }

        public DateTime? KiedyDezaktywowano { get; set; }

        public string? KtoDezaktyowal { get; set; }
    }
}
