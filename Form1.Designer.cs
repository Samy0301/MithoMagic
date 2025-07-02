namespace MythoMagic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLab = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.comboFichas = new System.Windows.Forms.ComboBox();
            this.btnUsarPoder = new System.Windows.Forms.Button();
            this.listBoxSalida = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfoJugador = new System.Windows.Forms.TextBox();
            this.panelLab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLab
            // 
            this.panelLab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLab.Controls.Add(this.panelData);
            this.panelLab.Location = new System.Drawing.Point(0, 1);
            this.panelLab.Name = "panelLab";
            this.panelLab.Size = new System.Drawing.Size(501, 456);
            this.panelLab.TabIndex = 0;
            // 
            // panelData
            // 
            this.panelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelData.Location = new System.Drawing.Point(505, -2);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(191, 456);
            this.panelData.TabIndex = 0;
            // 
            // comboFichas
            // 
            this.comboFichas.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.comboFichas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFichas.FormattingEnabled = true;
            this.comboFichas.Location = new System.Drawing.Point(522, 97);
            this.comboFichas.Name = "comboFichas";
            this.comboFichas.Size = new System.Drawing.Size(151, 28);
            this.comboFichas.TabIndex = 2;
            // 
            // btnUsarPoder
            // 
            this.btnUsarPoder.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnUsarPoder.Location = new System.Drawing.Point(550, 151);
            this.btnUsarPoder.Name = "btnUsarPoder";
            this.btnUsarPoder.Size = new System.Drawing.Size(94, 29);
            this.btnUsarPoder.TabIndex = 3;
            this.btnUsarPoder.Text = "Active";
            this.btnUsarPoder.UseVisualStyleBackColor = false;
            // 
            // listBoxSalida
            // 
            this.listBoxSalida.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.listBoxSalida.FormattingEnabled = true;
            this.listBoxSalida.ItemHeight = 20;
            this.listBoxSalida.Location = new System.Drawing.Point(528, 246);
            this.listBoxSalida.Name = "listBoxSalida";
            this.listBoxSalida.Size = new System.Drawing.Size(150, 104);
            this.listBoxSalida.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // txtInfoJugador
            // 
            this.txtInfoJugador.Location = new System.Drawing.Point(522, 23);
            this.txtInfoJugador.Name = "txtInfoJugador";
            this.txtInfoJugador.Size = new System.Drawing.Size(151, 27);
            this.txtInfoJugador.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(701, 457);
            this.Controls.Add(this.txtInfoJugador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxSalida);
            this.Controls.Add(this.btnUsarPoder);
            this.Controls.Add(this.comboFichas);
            this.Controls.Add(this.panelLab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelLab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelLab;
        private Panel panelData;
        
        private ListBox listBoxSalida;
        private Label label1;
        private Label label2;
        private TextBox txtInfoJugador;
    }
}