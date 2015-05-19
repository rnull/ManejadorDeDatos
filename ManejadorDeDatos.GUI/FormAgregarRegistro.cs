using ManejadorDeDatos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorDeDatos.GUI
{
    public class FormAgregarRegistro : Form
    {
        private TableLayoutPanel tableLayout;
        private Label[] nombreColumnas;
        private TextBox[] datosColumna;
        private Button continuar;
        private Button cancelar;
        private DataManager dm;

        public FormAgregarRegistro(DataManager dm)
        {
            this.dm = dm;
            inicializaComponentes();
        }

        private void inicializaComponentes()
        {
            string[] _columnas = dm.GetColumnas();

            nombreColumnas = new Label[_columnas.Length];
            datosColumna = new TextBox[_columnas.Length];
            continuar = new Button();
            cancelar = new Button();
            tableLayout = new TableLayoutPanel();

            for (int i = 0; i < _columnas.Length; i++)
            {
                nombreColumnas[i] = new Label();
                nombreColumnas[i].Text = _columnas[i];
                datosColumna[i] = new TextBox();

                tableLayout.Controls.Add(nombreColumnas[i],0, i);
                tableLayout.Controls.Add(datosColumna[i],2, i);
            }

            continuar.Text = "Continuar";
            continuar.Click += continuar_Click;
            cancelar.Text = "Cancelar";

            tableLayout.Controls.Add(continuar, 0, _columnas.Length + 1);
            tableLayout.Controls.Add(cancelar, 0, _columnas.Length + 1);
            tableLayout.Dock = DockStyle.Fill;

            this.Controls.Add(tableLayout);
        }

        void continuar_Click(object sender, EventArgs e)
        {
            if (!ValidaCamposConTexto())
            {
                MessageBox.Show("Un campo esta vacio.");
                return;
            }

            string[] _registro = new string[datosColumna.Length];
            for (int i = 0; i < datosColumna.Length; i++)
            {
                _registro[i] = datosColumna[i].Text;
            }

            dm.AgregarRegistro(_registro);
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private bool ValidaCamposConTexto()
        {
            for (int i = 0; i < datosColumna.Length; i++)
            {
                if (datosColumna[i].TextLength == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
