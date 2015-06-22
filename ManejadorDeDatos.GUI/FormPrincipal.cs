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


               int  index = dataManager.AplicarBusquedaLineal(aplicarEn, datoBusqueda);
               string numero = Convert.ToString(index);
               string nuevo = dataManager.RegistrosToString();
               int num = index + 1;
               string[] elementos = nuevo.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                 if (index < 0)
               {
                   MessageBox.Show("El elemento buscado no existe, asegurese de que lo escribio igual o intentelo en otra columna");
               }
               else
               {
                  
                   MessageBox.Show("Se econtro el elemento: " + datoBusqueda + "\r\nEn la posicion: " + num + "\r\nDatos completos: " + elementos[index]);
                   string elementoEncontrado = elementos[index];
              
                   textAreaPrincipal.Text = "";
                   textAreaPrincipal.AppendText(dataManager.ColumnasToString() + "\r\n");
                   string[] elementoSeparado = elementoEncontrado.Split(' ');
                   for (int i = 0; i < elementos.Length; i++)
                   {
                       if (index == i)
                       {
                           for (int j = 0; j < elementoSeparado.Length; j++)
                           {
                               if (aplicarEn == j)
                               {
                                   textAreaPrincipal.SelectionColor = Color.Red;
                                   textAreaPrincipal.AppendText(elementoSeparado[j] + " ");


                               }
                               else
                               {
                                   textAreaPrincipal.SelectionColor = Color.Black;
                                   textAreaPrincipal.AppendText(elementoSeparado[j] + " ");


                               }
                               if (j == elementoSeparado.Length - 1)
                               {

                                   textAreaPrincipal.AppendText("\r\n");


                               }
                           }

                       }
                       else if (i == elementos.Length - 1)
                       {
                           textAreaPrincipal.AppendText(elementos[i]);
                       }
                       else
                       {
                           textAreaPrincipal.SelectionColor = Color.Black;
                           textAreaPrincipal.AppendText(elementos[i] + "\r\n");
                       }


                   }

               }
               }
                //RepintaTextArea();
              



            }

        private void binariaToolStripMenuItem_Click(object sender, EventArgs e)
            {
            FormBusqueda fBusqueda = new FormBusqueda(dataManager.GetColumnas());
            fBusqueda.ShowDialog();
            DialogResult dr = fBusqueda.DialogResult;
             if (dr == DialogResult.OK)
             {

                 string datoBusqueda = fBusqueda.GetDatoABuscar();
                 int aplicarEn = fBusqueda.GetColumnaSeleccionada();
                 

                 int index = dataManager.AplicarBusquedaBinaria(aplicarEn, datoBusqueda);
                 //Ya se tiene el index del dato buscado
                 string numero = Convert.ToString(index);
                 string nuevo = dataManager.RegistrosToString();
                 int num = index + 1;
                 string[] elementos = nuevo.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                 
                 if (index > 0) 
                 {
                     MessageBox.Show("Se econtro el elemento: " + datoBusqueda + "\r\nEn la posicion: " + num + "\r\nDatos completos: " + elementos[index]);
                 }
                 else MessageBox.Show("El dato ingresado no se ha encontrado");
             }
            }
           }
        }
