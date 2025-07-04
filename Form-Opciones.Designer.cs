namespace MythoMagic
{
    partial class Form_Opciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Opciones));
            this.textBoxPlayer = new System.Windows.Forms.TextBox();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAtenea = new System.Windows.Forms.Label();
            this.labelPoseidon = new System.Windows.Forms.Label();
            this.labelHermes = new System.Windows.Forms.Label();
            this.buttonPoseidon = new System.Windows.Forms.Button();
            this.buttonHermes = new System.Windows.Forms.Button();
            this.buttonAtenea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPlayer
            // 
            this.textBoxPlayer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.textBoxPlayer.Location = new System.Drawing.Point(366, 9);
            this.textBoxPlayer.Name = "textBoxPlayer";
            this.textBoxPlayer.Size = new System.Drawing.Size(135, 27);
            this.textBoxPlayer.TabIndex = 0;
            this.textBoxPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPlayer.TextChanged += new System.EventHandler(this.textBoxPlayer_TextChanged);
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonContinuar.Location = new System.Drawing.Point(278, 373);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(135, 40);
            this.buttonContinuar.TabIndex = 0;
            this.buttonContinuar.Text = "Continue";
            this.buttonContinuar.UseVisualStyleBackColor = false;
            this.buttonContinuar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(183, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Insert Player Name:";
            // 
            // labelAtenea
            // 
            this.labelAtenea.Location = new System.Drawing.Point(110, 229);
            this.labelAtenea.Name = "labelAtenea";
            this.labelAtenea.Size = new System.Drawing.Size(121, 117);
            this.labelAtenea.TabIndex = 5;
            this.labelAtenea.Text = "Speed: 5 \r\nCoolDown: 3\r\nPower: Turn box into a paralyzing trap";
            this.labelAtenea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoseidon
            // 
            this.labelPoseidon.Location = new System.Drawing.Point(295, 229);
            this.labelPoseidon.Name = "labelPoseidon";
            this.labelPoseidon.Size = new System.Drawing.Size(118, 117);
            this.labelPoseidon.TabIndex = 6;
            this.labelPoseidon.Text = "Speed: 4 \r\nCoolDown: 4\r\nPower: Add 3 to the speed ";
            this.labelPoseidon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHermes
            // 
            this.labelHermes.Location = new System.Drawing.Point(472, 229);
            this.labelHermes.Name = "labelHermes";
            this.labelHermes.Size = new System.Drawing.Size(120, 117);
            this.labelHermes.TabIndex = 7;
            this.labelHermes.Text = "Speed: 5 \r\nCoolDown: 4\r\nPower: Multiply the speed by 2";
            this.labelHermes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPoseidon
            // 
            this.buttonPoseidon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPoseidon.BackgroundImage")));
            this.buttonPoseidon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPoseidon.Location = new System.Drawing.Point(281, 72);
            this.buttonPoseidon.Name = "buttonPoseidon";
            this.buttonPoseidon.Size = new System.Drawing.Size(146, 139);
            this.buttonPoseidon.TabIndex = 9;
            this.buttonPoseidon.UseVisualStyleBackColor = true;
            // 
            // buttonHermes
            // 
            this.buttonHermes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHermes.BackgroundImage")));
            this.buttonHermes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHermes.Location = new System.Drawing.Point(459, 72);
            this.buttonHermes.Name = "buttonHermes";
            this.buttonHermes.Size = new System.Drawing.Size(146, 139);
            this.buttonHermes.TabIndex = 10;
            this.buttonHermes.UseVisualStyleBackColor = true;
            // 
            // buttonAtenea
            // 
            this.buttonAtenea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAtenea.BackgroundImage")));
            this.buttonAtenea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAtenea.Location = new System.Drawing.Point(110, 72);
            this.buttonAtenea.Name = "buttonAtenea";
            this.buttonAtenea.Size = new System.Drawing.Size(146, 139);
            this.buttonAtenea.TabIndex = 11;
            this.buttonAtenea.UseVisualStyleBackColor = true;
            // 
            // Form_Opciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(669, 425);
            this.Controls.Add(this.buttonAtenea);
            this.Controls.Add(this.buttonHermes);
            this.Controls.Add(this.buttonPoseidon);
            this.Controls.Add(this.labelHermes);
            this.Controls.Add(this.labelPoseidon);
            this.Controls.Add(this.labelAtenea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.textBoxPlayer);
            this.Name = "Form_Opciones";
            this.Text = "Form_Opciones";
            this.Load += new System.EventHandler(this.Form_Opciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxPlayer;
        private Button buttonContinuar;
        private Label label1;
        private Label labelAtenea;
        private Label labelPoseidon;
        private Label labelHermes;
        private Button buttonPoseidon;
        private Button buttonHermes;
        private Button buttonAtenea;
    }
}