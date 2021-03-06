﻿namespace ManejadorDeDatos.GUI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edicarColumnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarColumnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aOrdenamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burbujaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heapSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBusquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textAreaPrincipal = new System.Windows.Forms.RichTextBox();
            this.binariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.columnasToolStripMenuItem,
            this.registroToolStripMenuItem,
            this.aOrdenamientoToolStripMenuItem,
            this.aBusquedaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem,
            this.verToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.crearToolStripMenuItem.Text = "Crear";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.verToolStripMenuItem.Text = "Ver";
            this.verToolStripMenuItem.Click += new System.EventHandler(this.verToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // columnasToolStripMenuItem
            // 
            this.columnasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.definirToolStripMenuItem,
            this.edicarColumnaToolStripMenuItem,
            this.agregarColumnaToolStripMenuItem});
            this.columnasToolStripMenuItem.Name = "columnasToolStripMenuItem";
            this.columnasToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.columnasToolStripMenuItem.Text = "Columnas";
            // 
            // definirToolStripMenuItem
            // 
            this.definirToolStripMenuItem.Name = "definirToolStripMenuItem";
            this.definirToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.definirToolStripMenuItem.Text = "Definir";
            this.definirToolStripMenuItem.Click += new System.EventHandler(this.definirToolStripMenuItem_Click);
            // 
            // edicarColumnaToolStripMenuItem
            // 
            this.edicarColumnaToolStripMenuItem.Name = "edicarColumnaToolStripMenuItem";
            this.edicarColumnaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.edicarColumnaToolStripMenuItem.Text = "Edicar Columna";
            this.edicarColumnaToolStripMenuItem.Click += new System.EventHandler(this.edicarColumnaToolStripMenuItem_Click);
            // 
            // agregarColumnaToolStripMenuItem
            // 
            this.agregarColumnaToolStripMenuItem.Name = "agregarColumnaToolStripMenuItem";
            this.agregarColumnaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.agregarColumnaToolStripMenuItem.Text = "Agregar Columna";
            this.agregarColumnaToolStripMenuItem.Click += new System.EventHandler(this.agregarColumnaToolStripMenuItem_Click);
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.registroToolStripMenuItem.Text = "Registro";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // aOrdenamientoToolStripMenuItem
            // 
            this.aOrdenamientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.burbujaToolStripMenuItem,
            this.selecciónToolStripMenuItem,
            this.heapSortToolStripMenuItem,
            this.quickSortToolStripMenuItem});
            this.aOrdenamientoToolStripMenuItem.Name = "aOrdenamientoToolStripMenuItem";
            this.aOrdenamientoToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.aOrdenamientoToolStripMenuItem.Text = "A. Ordenamiento";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // burbujaToolStripMenuItem
            // 
            this.burbujaToolStripMenuItem.Name = "burbujaToolStripMenuItem";
            this.burbujaToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.burbujaToolStripMenuItem.Text = "Burbuja";
            this.burbujaToolStripMenuItem.Click += new System.EventHandler(this.burbujaToolStripMenuItem_Click);
            // 
            // selecciónToolStripMenuItem
            // 
            this.selecciónToolStripMenuItem.Name = "selecciónToolStripMenuItem";
            this.selecciónToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.selecciónToolStripMenuItem.Text = "Selección";
            this.selecciónToolStripMenuItem.Click += new System.EventHandler(this.selecciónToolStripMenuItem_Click);
            // 
            // heapSortToolStripMenuItem
            // 
            this.heapSortToolStripMenuItem.Name = "heapSortToolStripMenuItem";
            this.heapSortToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.heapSortToolStripMenuItem.Text = "HeapSort";
            this.heapSortToolStripMenuItem.Click += new System.EventHandler(this.heapSortToolStripMenuItem_Click);
            // 
            // quickSortToolStripMenuItem
            // 
            this.quickSortToolStripMenuItem.Name = "quickSortToolStripMenuItem";
            this.quickSortToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.quickSortToolStripMenuItem.Text = "QuickSort";
            this.quickSortToolStripMenuItem.Click += new System.EventHandler(this.quickSortToolStripMenuItem_Click);
            // 
            // aBusquedaToolStripMenuItem
            // 
            this.aBusquedaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linealToolStripMenuItem,
            this.binariaToolStripMenuItem});
            this.aBusquedaToolStripMenuItem.Name = "aBusquedaToolStripMenuItem";
            this.aBusquedaToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.aBusquedaToolStripMenuItem.Text = "A. Busqueda";
            // 
            // linealToolStripMenuItem
            // 
            this.linealToolStripMenuItem.Name = "linealToolStripMenuItem";
            this.linealToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.linealToolStripMenuItem.Text = "Lineal";
            this.linealToolStripMenuItem.Click += new System.EventHandler(this.linealToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textAreaPrincipal
            // 
            this.textAreaPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAreaPrincipal.Location = new System.Drawing.Point(0, 24);
            this.textAreaPrincipal.Name = "textAreaPrincipal";
            this.textAreaPrincipal.Size = new System.Drawing.Size(629, 385);
            this.textAreaPrincipal.TabIndex = 2;
            this.textAreaPrincipal.Text = "";
            // 
            // binariaToolStripMenuItem
            // 
            this.binariaToolStripMenuItem.Name = "binariaToolStripMenuItem";
            this.binariaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.binariaToolStripMenuItem.Text = "Binaria";
            this.binariaToolStripMenuItem.Click += new System.EventHandler(this.binariaToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 409);
            this.Controls.Add(this.textAreaPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Administracion de Archivos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void inhabilitaBotonesMenu()
        {
            columnasToolStripMenuItem.Enabled = false;
            registroToolStripMenuItem.Enabled = false;
        }

        private void habilitaBotonesMenu()
        {
            columnasToolStripMenuItem.Enabled = true;
            registroToolStripMenuItem.Enabled = true;
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem definirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem edicarColumnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarColumnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aOrdenamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burbujaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heapSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBusquedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linealToolStripMenuItem;
        private System.Windows.Forms.RichTextBox textAreaPrincipal;
        private System.Windows.Forms.ToolStripMenuItem binariaToolStripMenuItem;
    }
}

