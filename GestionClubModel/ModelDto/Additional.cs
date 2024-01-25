using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class Additional
    {
        private string _CampoOrden;
        private string _Mensaje = string.Empty;
        private bool _EsVerdad = true;
        private decimal _Maximo = 0;
        private decimal _Minimo = 0;
        private string _Desde1 = string.Empty;
        private string _Desde2 = string.Empty;
        private string _Desde3 = string.Empty;
        private string _Hasta1 = string.Empty;
        private string _Hasta2 = string.Empty;
        private string _Hasta3 = string.Empty;
        private string _Valor1 = string.Empty;
        private DateTime _FechaDesde = DateTime.Today;
        private DateTime _FechaHasta = DateTime.Today;
        private decimal _Numero = 0;




        public string CampoOrden
        {
            get { return this._CampoOrden; }
            set { this._CampoOrden = value; }
        }

        public string Mensaje
        {
            get { return this._Mensaje; }
            set { this._Mensaje = value; }
        }

        public bool EsVerdad
        {
            get { return this._EsVerdad; }
            set { this._EsVerdad = value; }
        }

        public decimal Maximo
        {
            get { return this._Maximo; }
            set { this._Maximo = value; }
        }

        public decimal Minimo
        {
            get { return this._Minimo; }
            set { this._Minimo = value; }
        }

        public string Desde1
        {
            get { return this._Desde1; }
            set { this._Desde1 = value; }
        }

        public string Desde2
        {
            get { return this._Desde2; }
            set { this._Desde2 = value; }
        }

        public string Desde3
        {
            get { return this._Desde3; }
            set { this._Desde3 = value; }
        }

        public string Hasta1
        {
            get { return this._Hasta1; }
            set { this._Hasta1 = value; }
        }

        public string Hasta2
        {
            get { return this._Hasta2; }
            set { this._Hasta2 = value; }
        }

        public string Hasta3
        {
            get { return this._Hasta3; }
            set { this._Hasta3 = value; }
        }

        public string Valor1
        {
            get { return this._Valor1; }
            set { this._Valor1 = value; }
        }

        public DateTime FechaDesde
        {
            get { return this._FechaDesde; }
            set { this._FechaDesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return this._FechaHasta; }
            set { this._FechaHasta = value; }
        }

        public decimal Numero
        {
            get { return this._Numero; }
            set { this._Numero = value; }
        }
    }
}
