using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class PromeniPorudzbinuSO : OpstaSistemskaOperacija
    {
        private Porudzbina _porudzbina;
        public PromeniPorudzbinuSO(Porudzbina porudzbina)
        {
            _porudzbina = porudzbina; 
        }

        protected override void Execute()
        {
            _porudzbina.Set = $" ukupna_vrednost = '{_porudzbina.UkupnaVrednost}' , status_porudzbine ='{(int)_porudzbina.StatusPorudzbine}' ";
            _porudzbina.Where = $"porudzbina_id = '{_porudzbina.PorudzbinaID}'";
            broker.Update(_porudzbina);
        }
    }
}
