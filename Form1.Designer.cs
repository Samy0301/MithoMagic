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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.listBoxFichas = new System.Windows.Forms.ListBox();
            this.listBoxFichaFinal = new System.Windows.Forms.ListBox();
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
            this.panelLab.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLab_Paint);
            // 
            // panelData
            // 
            this.panelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelData.Location = new System.Drawing.Point(505, -2);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(191, 456);
            this.panelData.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Location = new System.Drawing.Point(538, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(125, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // listBoxFichas
            // 
            this.listBoxFichas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxFichas.FormattingEnabled = true;
            this.listBoxFichas.ItemHeight = 20;
            this.listBoxFichas.Location = new System.Drawing.Point(526, 69);
            this.listBoxFichas.Name = "listBoxFichas";
            this.listBoxFichas.Size = new System.Drawing.Size(150, 102);
            this.listBoxFichas.TabIndex = 2;
            // 
            // listBoxFichaFinal
            // 
            this.listBoxFichaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxFichaFinal.FormattingEnabled = true;
            this.listBoxFichaFinal.ItemHeight = 20;
            this.listBoxFichaFinal.Location = new System.Drawing.Point(526, 255);
            this.listBoxFichaFinal.Name = "listBoxFichaFinal";
            this.listBoxFichaFinal.Size = new System.Drawing.Size(150, 102);
            this.listBoxFichaFinal.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 457);
            this.Controls.Add(this.listBoxFichaFinal);
            this.Controls.Add(this.listBoxFichas);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.panelLab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelLab;
        private Panel panelData;
        private TextBox textBoxName;
        private ListBox listBoxFichas;
        private ListBox listBoxFichaFinal;
    }
}