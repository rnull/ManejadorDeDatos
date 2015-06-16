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
        FileManager fileManager;
        DataManager dataManager;
        int MayorTamaño;

        public FormPrincipal()
        {
            MayorTamaño = 0;
            InitializeComponent();
            inhabilitaBotonesMenu();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileManager = new FileManager("DB");
            fileManager.CrearArchivo();
            definirToolStripMenuItem_Click(sender, e);
        }

        private void definirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefineColumnas windowDefineColumnas = new FormDefineColumnas();
            DialogResult dr = windowDefineColumnas.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                dataManager = new DataManager(windowDefineColumnas.GetText());
                textAreaPrincipal.Text = dataManager.ColumnasToString();
                habilitaBotonesMenu();

                definirToolStripMenuItem.Enabled = false;
            }
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                fileManager = new FileManager(openFileDialog1.FileName);
                dataManager = new DataManager(fileManager.GetColumnas());
                dataManager.ConstruirRegistros(fileManager.GetDBName());

                RepintaTextArea();
            }
        }

        private void edicarColumnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromEditarColumna us1 = new FromEditarColumna(dataManager.GetColumnas());
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
            FormAgregarRegistro fAR = new FormAgregarRegistro(dataManager);
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
            textAreaPrincipal.AppendText(dataManager.ColumnasToString() + "\r\n" + dataManager.RegistrosToString());
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileManager.GuardarCambios(textAreaPrincipal.Text);
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrdenamiento fOrdenamiento = new FormOrdenamiento(dataManager.GetColumnas());
            fOrdenamiento.ShowDialog();
            DialogResult dr = fOrdenamiento.DialogResult;
            if (dr == DialogResult.OK)
            {
                int aplicarEn = fOrdenamiento.GetColumnaSeleccionada();

                dataManager.AplicarSortDefault(aplicarEn);
                RepintaTextArea();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void burbujaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrdenamiento fOrdenamiento = new FormOrdenamiento(dataManager.GetColumnas());
            fOrdenamiento.ShowDialog();
            DialogResult dr = fOrdenamiento.DialogResult;
            if (dr == DialogResult.OK)
            {
                int aplicarEn = fOrdenamiento.GetColumnaSeleccionada();

                dataManager.aplicarBurbuja(aplicarEn);
                RepintaTextArea();
            }
        }

        private void selecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrdenamiento fOrdenamiento = new FormOrdenamiento(dataManager.GetColumnas());
            fOrdenamiento.ShowDialog();
            DialogResult dr = fOrdenamiento.DialogResult;
            if (dr == DialogResult.OK)
            {
                int aplicarEn = fOrdenamiento.GetColumnaSeleccionada();

                dataManager.aplicarSelec(aplicarEn);
                RepintaTextArea();
            }
        }

        private void heapSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrdenamiento fOrdenamiento = new FormOrdenamiento(dataManager.GetColumnas());
            fOrdenamiento.ShowDialog();
            DialogResult dr = fOrdenamiento.DialogResult;
            if (dr == DialogResult.OK)
            {
                int aplicarEn = fOrdenamiento.GetColumnaSeleccionada();

                dataManager.aplicarheapsort(aplicarEn);
                RepintaTextArea();
            }

        }

        private void quickSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrdenamiento fOrdenamiento = new FormOrdenamiento(dataManager.GetColumnas());
            fOrdenamiento.ShowDialog();
            DialogResult dr = fOrdenamiento.DialogResult;
            if (dr == DialogResult.OK)
            {
                int aplicarEn = fOrdenamiento.GetColumnaSeleccionada();

                dataManager.aplicarQuickSort(aplicarEn);
                RepintaTextArea();

            }
        }

        private void linealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusqueda fBusqueda= new FormBusqueda(dataManager.GetColumnas());
            fBusqueda.ShowDialog();
            DialogResult dr = fBusqueda.DialogResult;
            if (dr == DialogResult.OK)
            {
                string datoBusqueda = fBusqueda.GetDatoABuscar();
                int aplicarEn = fBusqueda.GetColumnaSeleccionada();

                    dataManager.
                //textAreaPrincipal.BackColor = Color.Red;
                //RepintaTextArea();
                textAreaPrincipal.Text = "";
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j <  10; j++)
                    {

                        textAreaPrincipal.SelectionColor = Color.Black;
                        if (i == 5 && j == 5)
                        {
                            textAreaPrincipal.SelectionColor = Color.Red;
                        }
                        textAreaPrincipal.AppendText("casilla (" + i + "," + j + ")");
                    }
                }
            }
        }
    }
}
