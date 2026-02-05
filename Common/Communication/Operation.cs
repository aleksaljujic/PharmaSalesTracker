using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        None,
        LoginApotekar,
        PrikaziSmenuZaApotekara,
        DodajSmenuZaApotekara,
        PrikaziKupce,
        DodajKupca,
        UkloniKupca,
        IzmeniKupca,
        PrikaziApotekare,
        PrikaziGradove,
        PrikaziLekove,
        PrikaziRacune,
        PrikaziStavkeRacuna,
        PrikaziRacun,
        PrikaziLek,
        VratiLekID
    }
}
