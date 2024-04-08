﻿using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.MdiPrincipal;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace GestionClubView.Reportes
{
    public partial class frmReportRegistroTicket : Form
    {
        public frmIngresarAnioMesTicketAnual wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoTicket.rdlc";
        public string formaReporte = "Normal";
        public frmReportRegistroTicket()
        {
            InitializeComponent();
        }

        private void frmReportRegistroVentas_Load(object sender, EventArgs e)
        {

        }
        public void VentanaVisualizar()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.GenerarInforme();
        }
        public void GenerarInforme()
        {
            this.Dock = DockStyle.Fill;
            try
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsRegistroVentas";
                rds.Value = GestionClubComprobanteController.ListarComprobantes()
                    .Where(x => Fecha.ObtenerAño(x.fecComprobante.ToShortDateString()) == this.wFrm.txtAnio.Text
                    && Fecha.ObtenerMes(x.fecComprobante.ToShortDateString()) == Cmb.ObtenerValor(this.wFrm.cboMes, string.Empty)
                    && x.tipComprobante == "03")
                    .ToList();

                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("anio", this.wFrm.txtAnio.Text);
                rp[2] = new ReportParameter("mes", Cmb.ObtenerTexto(this.wFrm.cboMes));


                this.rvRegistroVentas.Reset();
                this.rvRegistroVentas.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvRegistroVentas.LocalReport.SetParameters(rp);
                this.rvRegistroVentas.LocalReport.EnableExternalImages = true;
                this.rvRegistroVentas.LocalReport.DataSources.Clear();
                this.rvRegistroVentas.LocalReport.DataSources.Add(rds);
                this.rvRegistroVentas.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvRegistroVentas.ZoomMode = ZoomMode.Percent;
                this.rvRegistroVentas.ZoomPercent = 100;

                PageSettings pg = new PageSettings
                {
                    Landscape = false
                };
                pg.Margins = new Margins(0, 0, 0, 0);
                PaperSize size = new PaperSize("A4", 827, 1169);
                pg.PaperSize = size;

                if (formaReporte == "Horizontal")
                {
                    pg.Landscape = true;
                }
                this.rvRegistroVentas.SetPageSettings(pg);

                this.rvRegistroVentas.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmRegistroVentas, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportRegistroVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Cerrar();
        }
    }
}