namespace MythoMagic
{
    partial class Form_Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Inicio));
            this.GameName = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.BackColor = System.Drawing.Color.Transparent;
            this.GameName.Font = new System.Drawing.Font("Yu Gothic Medium", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameName.ForeColor = System.Drawing.Color.SandyBrown;
            this.GameName.Location = new System.Drawing.Point(64, 355);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(590, 103);
            this.GameName.TabIndex = 0;
            this.GameName.Text = "Myth-O-Magic";
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPlay.Font = new System.Drawing.Font("Yu Gothic Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPlay.ForeColor = System.Drawing.Color.SandyBrown;
            this.buttonPlay.Location = new System.Drawing.Point(12, 12);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(122, 59);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonOut.Font = new System.Drawing.Font("Yu Gothic Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonOut.ForeColor = System.Drawing.Color.SandyBrown;
            this.buttonOut.Location = new System.Drawing.Point(584, 12);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(116, 59);
            this.buttonOut.TabIndex = 2;
            this.buttonOut.Text = "Exit";
            this.buttonOut.UseVisualStyleBackColor = false;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // Form_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(712, 498);
            this.Controls.Add(this.buttonOut);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.GameName);
            this.Name = "Form_Inicio";
            this.Text = "Form_Inicio";
            this.Load += new System.EventHandler(this.Form_Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label GameName;
        private Button buttonPlay;
        private Button buttonOut;
    }
}