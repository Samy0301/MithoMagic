namespace MythoMagic
{
    partial class Form_Opciones2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Opciones2));
            this.labelPlayer = new System.Windows.Forms.Label();
            this.textBoxPlayer = new System.Windows.Forms.TextBox();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.labelAfrodita = new System.Windows.Forms.Label();
            this.labelAres = new System.Windows.Forms.Label();
            this.labelPoseidon = new System.Windows.Forms.Label();
            this.buttonAfrodita = new System.Windows.Forms.Button();
            this.buttonAres = new System.Windows.Forms.Button();
            this.buttonApolo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPlayer
            // 
            this.labelPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPlayer.Location = new System.Drawing.Point(184, 9);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(160, 27);
            this.labelPlayer.TabIndex = 3;
            this.labelPlayer.Text = "Insert Player Name:";
            this.labelPlayer.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxPlayer
            // 
            this.textBoxPlayer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.textBoxPlayer.Location = new System.Drawing.Point(359, 9);
            this.textBoxPlayer.Name = "textBoxPlayer";
            this.textBoxPlayer.Size = new System.Drawing.Size(148, 27);
            this.textBoxPlayer.TabIndex = 4;
            this.textBoxPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPlayer.TextChanged += new System.EventHandler(this.textBoxPlayer_TextChanged);
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonContinuar.Location = new System.Drawing.Point(279, 371);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(135, 40);
            this.buttonContinuar.TabIndex = 6;
            this.buttonContinuar.Text = "Continue";
            this.buttonContinuar.UseVisualStyleBackColor = false;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // labelAfrodita
            // 
            this.labelAfrodita.Location = new System.Drawing.Point(99, 217);
            this.labelAfrodita.Name = "labelAfrodita";
            this.labelAfrodita.Size = new System.Drawing.Size(124, 117);
            this.labelAfrodita.TabIndex = 8;
            this.labelAfrodita.Text = "Speed: 2\r\nCoolDown: 4\r\nPower: Remove the trap in front ";
            this.labelAfrodita.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAres
            // 
            this.labelAres.Location = new System.Drawing.Point(295, 217);
            this.labelAres.Name = "labelAres";
            this.labelAres.Size = new System.Drawing.Size(119, 117);
            this.labelAres.TabIndex = 9;
            this.labelAres.Text = "Speed: 3\r\nCoolDown: 4\r\nPower: Immune to traps";
            this.labelAres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoseidon
            // 
            this.labelPoseidon.BackColor = System.Drawing.Color.Transparent;
            this.labelPoseidon.Location = new System.Drawing.Point(476, 217);
            this.labelPoseidon.Name = "labelPoseidon";
            this.labelPoseidon.Size = new System.Drawing.Size(119, 117);
            this.labelPoseidon.TabIndex = 10;
            this.labelPoseidon.Text = "Speed: 2\r\nCoolDown: 3\r\nPower: Go through walls ";
            this.labelPoseidon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAfrodita
            // 
            this.buttonAfrodita.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAfrodita.BackgroundImage")));
            this.buttonAfrodita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAfrodita.ImageKey = "(none)";
            this.buttonAfrodita.Location = new System.Drawing.Point(90, 64);
            this.buttonAfrodita.Name = "buttonAfrodita";
            this.buttonAfrodita.Size = new System.Drawing.Size(146, 139);
            this.buttonAfrodita.TabIndex = 11;
            this.buttonAfrodita.UseVisualStyleBackColor = true;
            // 
            // buttonAres
            // 
            this.buttonAres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAres.BackgroundImage")));
            this.buttonAres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAres.ImageKey = "(none)";
            this.buttonAres.Location = new System.Drawing.Point(279, 64);
            this.buttonAres.Name = "buttonAres";
            this.buttonAres.Size = new System.Drawing.Size(146, 139);
            this.buttonAres.TabIndex = 12;
            this.buttonAres.UseVisualStyleBackColor = true;
            // 
            // buttonApolo
            // 
            this.buttonApolo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonApolo.BackgroundImage")));
            this.buttonApolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonApolo.ImageKey = "(none)";
            this.buttonApolo.Location = new System.Drawing.Point(465, 64);
            this.buttonApolo.Name = "buttonApolo";
            this.buttonApolo.Size = new System.Drawing.Size(146, 139);
            this.buttonApolo.TabIndex = 13;
            this.buttonApolo.UseVisualStyleBackColor = true;
            // 
            // Form_Opciones2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 423);
            this.Controls.Add(this.buttonApolo);
            this.Controls.Add(this.buttonAres);
            this.Controls.Add(this.buttonAfrodita);
            this.Controls.Add(this.labelPoseidon);
            this.Controls.Add(this.labelAres);
            this.Controls.Add(this.labelAfrodita);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.textBoxPlayer);
            this.Controls.Add(this.labelPlayer);
            this.Name = "Form_Opciones2";
            this.Text = "Form_Opciones2";
            this.Load += new System.EventHandler(this.Form_Opciones2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelPlayer;
        private TextBox textBoxPlayer;
        private Button buttonContinuar;
        private Label labelAfrodita;
        private Label labelAres;
        private Label labelPoseidon;
        private Button buttonAfrodita;
        private Button buttonAres;
        private Button buttonApolo;
    }
}