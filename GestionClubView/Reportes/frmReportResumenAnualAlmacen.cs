﻿using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.Consultas;
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
    public partial class frmReportResumenAnualAlmacen : Form
    {
        public frmIngresarAnioMesAlmacen wFrm;
        //CreditsReportController objReportController = new CreditsReportController();
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoResumenAnioMesAlmacen.rdlc";
        public string formaReporte = "Normal";
        public frmReportResumenAnualAlmacen()
        {
            InitializeComponent();
        }

        private void frmReportListadoDeComprobantesDelDia_Load(object sender, EventArgs e)
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
            try
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsResumenAnoMesAlmacen";
                rds.Value = GestionClubResumenAlmacenController.ResumenAnioMesAlmacen(this.wFrm.txtAnio.Text, Cmb.ObtenerValor(this.wFrm.cboMes));

                ReportParameter[] rp = new ReportParameter[3];

                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("anio", this.wFrm.txtAnio.Text);
                rp[2] = new ReportParameter("mes", Cmb.ObtenerTexto(this.wFrm.cboMes));

                this.rpvResumenAnualProducto.Reset();
                this.rpvResumenAnualProducto.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rpvResumenAnualProducto.LocalReport.SetParameters(rp);
                this.rpvResumenAnualProducto.LocalReport.EnableExternalImages = true;
                this.rpvResumenAnualProducto.LocalReport.DataSources.Clear();
                this.rpvResumenAnualProducto.LocalReport.DataSources.Add(rds);
                this.rpvResumenAnualProducto.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvResumenAnualProducto.ZoomMode = ZoomMode.Percent;
                this.rpvResumenAnualProducto.ZoomPercent = 100;

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
                this.rpvResumenAnualProducto.SetPageSettings(pg);

                this.rpvResumenAnualProducto.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportListadoDeComprobantesDelDia_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
