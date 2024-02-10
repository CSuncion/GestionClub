using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using Comun;
using GestionClubModel.ModelDto;
using GestionClubController.Controller;
using WinControles.ControlesWindows;
using GestionClubUtil.Util;
using GestionClubView.Listas;

namespace GestionClubView.Login
{
    public partial class frmLogin : Form
    {
        #region Owner
        Masivo eMas = new Masivo();
        public frmPrincipal frmPrincipal;
        GestionClubAccessController GestionClubAccessController = new GestionClubAccessController();
        UtilGestionClub utilGestionClub = new UtilGestionClub();
        public int eFlagInvoca = 0;//0: al iniciar el sistema,1: cambio de usuario
        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        #region Methods
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNameUsr, this.txtDniUsuario, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtProfile, this.txtDniUsuario, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDniUsuario, true, "Usuario", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtPwd, true, "Contraseña", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodEmp, true, "Empresa", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnGetInto, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancel, "f");
            xLis.Add(xCtrl);

            return xLis;
        }
        public void InitWindow()
        {
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
        }
        public void NewWindow()
        {
            this.InitWindow();
            this.MostrarPersistencia();
            this.ShowDialog();
        }

        public void MostrarPersistencia()
        {
            this.txtIdAcceso.Text = Properties.Settings.Default.GuardarIdAcceso;
            this.txtNameUsr.Text = Properties.Settings.Default.GuardarNombreUsuario;
            this.txtDniUsuario.Text = Properties.Settings.Default.GuardarCodigoUsuario;
            this.txtProfile.Text = Properties.Settings.Default.GuardarNombrePerfil;
            this.txtPwd.Text = Properties.Settings.Default.GuardarClaveUsuario;
            this.txtIdEmpresa.Text = Properties.Settings.Default.GuardarIdEmpresa;
            this.txtCodEmp.Text = Properties.Settings.Default.GuardarCodigoEmpresa;
            this.txtNomEmp.Text = Properties.Settings.Default.GuardarNombreEmpresa;
            this.ckbUsr.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckUsuario, false);
            this.ckbPwd.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckClave, false);
            this.ckbEmp.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckEmpresa, false);
        }
        public void AccessSystem()
        {
            if (eMas.CamposObligatorios() == false) { return; }

            //chequear si el usuario es valido
            if (this.EsUsuarioValido() == false) { return; }
            //comprobar si la clave es correcta     
            if (this.EsClaveDeUsuario() == false) { return; }

            //aqui paso todas las validaciones
            //pasamos las variables globales
            this.GuardarValoresUniversales();

            //Guardar la persistencia de datos
            this.GrabarPersistencia();

            //barra de estado para el menu         
            this.frmPrincipal.tssStatusBar.Text = Universal.EstadoBarra();

            //eliminar todas las ventanas abiertas
            this.frmPrincipal.EliminarTodasLasVentanasAbiertas();

            //eliminar todos los TabModulos que esten abiertos
            this.frmPrincipal.EliminarTodosLosTabVentanas();

            //habilitar los items del menu
            //MeSt.HabilitarMenu(this.frmPrincipal.msMenu, true);

            //cerrar ventana acceso
            this.Close();
        }
        public bool EsUsuarioValido()
        {
            GestionClubAccessDto iUsuEN = new GestionClubAccessDto();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = this.GestionClubAccessController.EsUsuarioValido(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
                this.txtDniUsuario.Focus();
            }
            this.txtDniUsuario.Text = iUsuEN.dniAcceso;
            this.txtNameUsr.Text = iUsuEN.nombresAcceso.Trim() + ' ' + iUsuEN.paternoAcceso.Trim() + ' ' + iUsuEN.maternoAcceso.Trim();
            this.txtProfile.Text = iUsuEN.cargoAcceso;
            this.txtIdAcceso.Text = iUsuEN.idAcceso.ToString();
            this.txtCodUsuario.Text = iUsuEN.codAcceso.ToString();
            return iUsuEN.Adicionales.EsVerdad;
        }
        public void AsignarUsuario(GestionClubAccessDto pUsu)
        {
            pUsu.dniAcceso = this.txtDniUsuario.Text.Trim();
            pUsu.nombresAcceso = this.txtNameUsr.Text.Trim();
            pUsu.passAcceso = utilGestionClub.Encripta(this.txtPwd.Text.Trim());
        }

        public bool EsClaveDeUsuario()
        {
            GestionClubAccessDto iUsuEN = new GestionClubAccessDto();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = this.GestionClubAccessController.EsContrasenaDeUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Clave");
                this.txtPwd.Clear();
                this.txtPwd.Focus();
            }
            return iUsuEN.Adicionales.EsVerdad;
        }

        public void GuardarValoresUniversales()
        {
            Universal.gCodigoUsuario = this.txtDniUsuario.Text.Trim();
            Universal.gNombreUsuario = this.txtNameUsr.Text.Trim();
            Universal.gNombrePerfil = this.txtProfile.Text.Trim();
            Universal.gIdAcceso = Convert.ToInt32(this.txtIdAcceso.Text);
            Universal.gIdEmpresa = Convert.ToInt32(this.txtIdEmpresa.Text);
        }

        public void GrabarPersistencia()
        {
            //guardando datos usuario
            Properties.Settings.Default.GuardarCheckUsuario = this.ckbUsr.Checked.ToString().ToLower();
            bool iValor = this.ckbUsr.Checked;
            Properties.Settings.Default.GuardarCodigoUsuario = Cadena.ObtenerValor(iValor, this.txtDniUsuario.Text);
            Properties.Settings.Default.GuardarNombreUsuario = Cadena.ObtenerValor(iValor, this.txtNameUsr.Text);
            Properties.Settings.Default.GuardarCodigoPerfil = Cadena.ObtenerValor(iValor, this.txtCodPerfil.Text);
            Properties.Settings.Default.GuardarNombrePerfil = Cadena.ObtenerValor(iValor, this.txtProfile.Text);

            //guardando datos clave
            Properties.Settings.Default.GuardarCheckClave = this.ckbPwd.Checked.ToString().ToLower();
            iValor = this.ckbPwd.Checked;
            Properties.Settings.Default.GuardarClaveUsuario = Cadena.ObtenerValor(iValor, this.txtPwd.Text);

            //guardando datos empresa
            Properties.Settings.Default.GuardarCheckEmpresa = this.ckbEmp.Checked.ToString().ToLower();
            iValor = this.ckbEmp.Checked;
            Properties.Settings.Default.GuardarCodigoEmpresa = Cadena.ObtenerValor(iValor, this.txtCodEmp.Text);
            Properties.Settings.Default.GuardarNombreEmpresa = Cadena.ObtenerValor(iValor, this.txtNomEmp.Text);
            Properties.Settings.Default.GuardarIdEmpresa = Cadena.ObtenerValor(iValor, this.txtIdEmpresa.Text);
            Properties.Settings.Default.GuardarIdAcceso = Cadena.ObtenerValor(iValor, this.txtIdAcceso.Text);

            //guardar todos los datos
            Properties.Settings.Default.Save();
        }
        public void Cancelar()
        {
            //segun flag de invocacion de la ventana
            if (this.eFlagInvoca == 0)
            {
                Application.Exit();
            }
            else
            {
                //habilitamos el menu principal
                if (this.frmPrincipal.tbcContainer.TabPages.Count != 0)
                {
                    this.frmPrincipal.tbcContainer.Visible = true;
                    this.frmPrincipal.BackColor = Color.LightYellow;
                }
                this.Close();
            }
        }
        public bool EsEmpresaDeUsuario()
        {
            //preguntamos si la empresa que se digita es del usuario seleccionado
            GestionClubPermisoEmpresaDto iPermEmpresa = new GestionClubPermisoEmpresaDto();
            iPermEmpresa.codAcceso = this.txtCodUsuario.Text.Trim();
            iPermEmpresa.codEmpresa = this.txtCodEmp.Text.Trim();
            iPermEmpresa.codPermisoEmpresa = GestionClubPermisoEmpresaController.ObtenerClavePermisoEmpresa(iPermEmpresa);
            iPermEmpresa = GestionClubPermisoEmpresaController.EsEmpresaDeUsuario(iPermEmpresa);
            if (iPermEmpresa.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPermEmpresa.Adicionales.Mensaje, "Empresa");
                this.txtCodEmp.Focus();
            }
            this.txtIdEmpresa.Text = iPermEmpresa.idEmpresa.ToString();
            this.txtCodEmp.Text = iPermEmpresa.codEmpresa;
            this.txtNomEmp.Text = iPermEmpresa.desEmpresa;
            return iPermEmpresa.Adicionales.EsVerdad;
        }
        public void ListarEmpresasDeUsuario()
        {
            frmListarEmpresas win = new frmListarEmpresas();
            win.eVentana = this;
            win.eTituloVentana = "Empresas autorizadas";
            win.eCtrlValor = this.txtCodEmp;
            win.eCtrlFoco = this.btnGetInto;
            //condicion
            win.ePerm.codAcceso = this.txtCodUsuario.Text.Trim();
            win.eCondicionLista = frmListarEmpresas.Condicion.EmpresasAutorizadasDeUsuario;
            win.NuevaVentana();
        }
        #endregion

        #region Eventos
        private void btnGetInto_Click(object sender, EventArgs e)
        {
            this.AccessSystem();
        }
        #endregion

        private void txtCodUsr_Validating(object sender, CancelEventArgs e)
        {
            this.EsUsuarioValido();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodEmp_Validating(object sender, CancelEventArgs e)
        {
            this.EsEmpresaDeUsuario();
        }

        private void txtCodEmp_DoubleClick(object sender, EventArgs e)
        {
            this.ListarEmpresasDeUsuario();
        }

        private void txtCodEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarEmpresasDeUsuario(); }
        }
    }
}
