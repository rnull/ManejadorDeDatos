using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorDeDatos.GUI
{
    public partial class FormDefineColumnas : Form
    {
        public FormDefineColumnas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Debes escribir al menos el nombre de una columna.");
                return;
            }

            IRecuperaDatos IFormPadre = this.Owner as IRecuperaDatos;
            if (IFormPadre != null)
                IFormPadre.RecuperarTexto(textBox1.Text);

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        public string GetText()
        {
            return textBox1.Text;
        }
    }
}
