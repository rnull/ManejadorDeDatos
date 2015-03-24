using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadorDeDatos.Core;
using System.IO;

namespace ManejadorDeDatos.GUI
{
    public partial class FormPrincipal : Form, IRecuperaDatos
    {
        public FormPrincipal()
        {
            InitializeComponent();
            inhabilitaBotonesMenu();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.CrearArchivo("DB");
            definirToolStripMenuItem_Click(sender, e);
        }

        private void definirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataManager.ExistenColumnas())
            {
                MessageBox.Show("No puedes redefinir las columnas. Las puedes editar, en Colunas > Editar.");
                return;
            }
            FormDefineColumnas windowDefineColumnas = new FormDefineColumnas();
            DialogResult dr = windowDefineColumnas.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                DataManager.DefinirColumnas(windowDefineColumnas.GetText());
                FileManager.EscribeColumnas(DataManager.GetColumnas());

                textAreaPrincipal.Text = DataManager.ColumnasToString();

                habilitaBotonesMenu();
            }
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                textAreaPrincipal.Text="";
                textAreaPrincipal.AppendText(FileManager.ObtenerDatos(openFileDialog1.FileName));
                
            }
        }

        private void edicarColumnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromEditarColumna us1 = new FromEditarColumna(DataManager.GetColumnas());
            us1.ShowDialog(this);
        }

        public string RecuperarTexto(string texto)
        {
            return texto;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("nuevo.txt");
            }
            catch (System.IO.IOException exc)
            {
                textAreaPrincipal.Text = exc.Message;
                return;
            }
        }

        private void agregarColumnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromAgregarColumna form = new FromAgregarColumna();
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string nombre = form.GetNombreColumna();


            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgregarRegistro fAR = new FormAgregarRegistro();
            fAR.ShowDialog();
            DialogResult dr = fAR.DialogResult;
            if (dr == DialogResult.OK)
            {
                RepintaTextArea();
            }
        }

        private void RepintaTextArea()
        {
            textAreaPrincipal.Text = "";
            textAreaPrincipal.AppendText(DataManager.ColumnasToString() + "\r\n" + DataManager.RegistrosToString());
        }
    }
}
