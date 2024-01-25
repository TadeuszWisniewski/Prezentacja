using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.Validatory
{
    public class JednostkaOrganizacyjnaValidator
    {
        public bool SprawdzDane(bool? Aktywny, string? Nazwa)
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || Nazwa.StartsWith(" "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SprawdzDane2(bool? Aktywny, string? Nazwa, int? IloscGodzinTygodniowo)
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || Nazwa.StartsWith(" ") || IloscGodzinTygodniowo == null || IloscGodzinTygodniowo == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
