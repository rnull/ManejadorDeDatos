using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorDeDatos.GUI
{
    public class FromEditarColumna : Form
    {
        private string[] columnas;
        private RadioButton[] radioButtons;
        private TextBox[] textBoxs;
        private Button aceptar;
        private FlowLayoutPanel flowLayoutPanel;

        public FromEditarColumna(string[] columnas)
        {
            // TODO: Complete member initialization
            this.columnas = columnas;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            radioButtons = new RadioButton[columnas.Length];
            textBoxs = new TextBox[columnas.Length];
            aceptar = new Button();
            flowLayoutPanel = new FlowLayoutPanel();

            for (int i = 0; i < columnas.Length; i++)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].AutoSize = true;
                radioButtons[i].Location = new Point(33, 32 + (i * 20));
                radioButtons[i].Name = "Columna" + i;
                radioButtons[i].Size = new Size(85, 17);
                radioButtons[i].TabIndex = 0;
                radioButtons[i].TabStop = true;
                radioButtons[i].Text = "Columna " + i;
                radioButtons[i].UseVisualStyleBackColor = true;
                flowLayoutPanel.Controls.Add(radioButtons[i]);
            }

            this.Controls.Add(flowLayoutPanel);
        }
    }
}
