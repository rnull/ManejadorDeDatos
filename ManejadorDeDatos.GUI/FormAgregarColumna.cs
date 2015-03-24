using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorDeDatos.GUI
{
    public class FromAgregarColumna : Form
    {
        //private string[] columnas;
        //private RadioButton[] radioButtons;
        private TextBox textBoxs;
        private Button aceptar;
        private FlowLayoutPanel flowLayoutPanel;

        public FromAgregarColumna()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            textBoxs = new TextBox();
            aceptar = new Button();
            aceptar.Click += _aceptar_click;
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Controls.Add(textBoxs);
            flowLayoutPanel.Controls.Add(aceptar);

            this.Controls.Add(flowLayoutPanel);
        }

        private void _aceptar_click(object sender, EventArgs e)
        {
            if(textBoxs.Text.Length == 0)
            {
                MessageBox.Show("Escrbe el nombre de la columna.");
                return;
            }


            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        public string GetNombreColumna()
        {
            return textBoxs.Text;
        }
    }
}
