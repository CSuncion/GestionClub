using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsProcesoPagoDto
    {
        public decimal Id_ProcesoPagos { get; set; }
        public DateTime F_Proces { get; set; }
        public int IdUnidadDscto { get; set; }
        public int Situacion { get; set; }
        public string IdBanca { get; set; }
        public int IdCheqOpe { get; set; }
        public string NumCheqOpe { get; set; }
        public decimal ImporteCheqOpe { get; set; }
        public string Anotacion { get; set; }
        public decimal UserProces { get; set; }
        public decimal impbruto { get; set; }
        public decimal impdscto { get; set; }
        public decimal impneto { get; set; }
    }
}
