using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorDeDatos.GUI
{
    public class FormOrdenamiento : Form
    {
        private RadioButton[] radioButtons;
        private Label[] columnas;
        private Button aceptar;
        private Button cancelar;
        private FlowLayoutPanel flowLayoutPanel;

        public FormOrdenamiento(string[] columnas)
        {
            iniciarComponentes(columnas);
        }

        private void iniciarComponentes(string[] columnas)
        {
            radioButtons = new RadioButton[columnas.Length];
            flowLayoutPanel = new FlowLayoutPanel();
            aceptar = new Button();

            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].AutoSize = true;
                //radioButtons[i].Location = new Point(33, 32 + (i * 20));
                radioButtons[i].Name = "Columna: " + columnas[i];
                radioButtons[i].Size = new Size(85, 17);
                radioButtons[i].TabIndex = 0;
                radioButtons[i].TabStop = true;
                radioButtons[i].Text = "Columna: " + columnas[i];
                radioButtons[i].UseVisualStyleBackColor = true;
                flowLayoutPanel.Controls.Add(radioButtons[i]);
            }

            aceptar.Text = "Aplicar";
            aceptar.Click += aceptar_Click;
            flowLayoutPanel.Controls.Add(aceptar);

            this.Controls.Add(flowLayoutPanel);
        }

        public void aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        public int GetColumnaSeleccionada()
        {
            for (int i = 0; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked == true)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
