namespace Proyecto3Analisis
{
    partial class Inicio
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.generaciones = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arbol = new System.Windows.Forms.Button();
            this.bRuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "fitness";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "tablero";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // generaciones
            // 
            this.generaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generaciones.FormattingEnabled = true;
            this.generaciones.Location = new System.Drawing.Point(64, 40);
            this.generaciones.Name = "generaciones";
            this.generaciones.Size = new System.Drawing.Size(200, 21);
            this.generaciones.TabIndex = 2;
            this.generaciones.SelectedIndexChanged += new System.EventHandler(this.generaciones_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(64, 84);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(281, 290);
            this.listBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione una generacion";
            // 
            // arbol
            // 
            this.arbol.Location = new System.Drawing.Point(22, 398);
            this.arbol.Name = "arbol";
            this.arbol.Size = new System.Drawing.Size(75, 23);
            this.arbol.TabIndex = 5;
            this.arbol.Text = "arbol";
            this.arbol.UseVisualStyleBackColor = true;
            this.arbol.Click += new System.EventHandler(this.arbol_Click);
            // 
            // bRuta
            // 
            this.bRuta.Location = new System.Drawing.Point(270, 398);
            this.bRuta.Name = "bRuta";
            this.bRuta.Size = new System.Drawing.Size(75, 23);
            this.bRuta.TabIndex = 6;
            this.bRuta.Text = "Ruta";
            this.bRuta.UseVisualStyleBackColor = true;
            this.bRuta.Click += new System.EventHandler(this.bRuta_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(426, 433);
            this.Controls.Add(this.bRuta);
            this.Controls.Add(this.arbol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.generaciones);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Inicio";
            this.Text = "Algoritmo Genetico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox generaciones;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button arbol;
        private System.Windows.Forms.Button bRuta;
    }
}

