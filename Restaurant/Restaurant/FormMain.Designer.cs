
using System.Windows.Forms;

namespace Restaurant
{
    partial class FormMain
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
            this.panelRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPorucivanje = new System.Windows.Forms.Button();
            this.buttonPorudzbine = new System.Windows.Forms.Button();
            this.buttonStavkeCenovnika = new System.Windows.Forms.Button();
            this.buttonStolovi = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.LightPink;
            this.panelRight.Controls.Add(this.panel1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(474, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(335, 649);
            this.panelRight.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonPorucivanje);
            this.panel1.Controls.Add(this.buttonPorudzbine);
            this.panel1.Controls.Add(this.buttonStavkeCenovnika);
            this.panel1.Controls.Add(this.buttonStolovi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(-8, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 649);
            this.panel1.TabIndex = 1;
            // 
            // buttonPorucivanje
            // 
            this.buttonPorucivanje.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPorucivanje.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonPorucivanje.Location = new System.Drawing.Point(54, 350);
            this.buttonPorucivanje.Name = "buttonPorucivanje";
            this.buttonPorucivanje.Size = new System.Drawing.Size(239, 42);
            this.buttonPorucivanje.TabIndex = 4;
            this.buttonPorucivanje.Text = "Poručivanje";
            this.buttonPorucivanje.UseVisualStyleBackColor = true;
            this.buttonPorucivanje.Click += new System.EventHandler(this.buttonPorucivanje_Click);
            // 
            // buttonPorudzbine
            // 
            this.buttonPorudzbine.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPorudzbine.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonPorudzbine.Location = new System.Drawing.Point(54, 270);
            this.buttonPorudzbine.Name = "buttonPorudzbine";
            this.buttonPorudzbine.Size = new System.Drawing.Size(239, 42);
            this.buttonPorudzbine.TabIndex = 2;
            this.buttonPorudzbine.Text = "Porudzbine";
            this.buttonPorudzbine.UseVisualStyleBackColor = true;
            this.buttonPorudzbine.Click += new System.EventHandler(this.buttonPorudzbine_Click);
            // 
            // buttonStavkeCenovnika
            // 
            this.buttonStavkeCenovnika.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStavkeCenovnika.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonStavkeCenovnika.Location = new System.Drawing.Point(54, 176);
            this.buttonStavkeCenovnika.Name = "buttonStavkeCenovnika";
            this.buttonStavkeCenovnika.Size = new System.Drawing.Size(239, 42);
            this.buttonStavkeCenovnika.TabIndex = 1;
            this.buttonStavkeCenovnika.Text = "Stavke Cenovnika";
            this.buttonStavkeCenovnika.UseVisualStyleBackColor = true;
            this.buttonStavkeCenovnika.Click += new System.EventHandler(this.buttonStavkeCenovnika_Click);
            // 
            // buttonStolovi
            // 
            this.buttonStolovi.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStolovi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonStolovi.Location = new System.Drawing.Point(54, 99);
            this.buttonStolovi.Name = "buttonStolovi";
            this.buttonStolovi.Size = new System.Drawing.Size(239, 42);
            this.buttonStolovi.TabIndex = 0;
            this.buttonStolovi.Text = "Stolovi";
            this.buttonStolovi.UseVisualStyleBackColor = true;
            this.buttonStolovi.Click += new System.EventHandler(this.buttonStolovi_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(474, 649);
            this.panelLeft.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 649);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.panelRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonPorucivanje;
        private System.Windows.Forms.Button buttonPorudzbine;
        private System.Windows.Forms.Button buttonStavkeCenovnika;
        private System.Windows.Forms.Button buttonStolovi;

        public Panel PanelRight { get => panelRight; set => panelRight = value; }
        public Panel Panel1 { get => panel1; set => panel1 = value; }
        public Panel PanelLeft { get => panelLeft; set => panelLeft = value; }
        public Button ButtonPorucivanje { get => buttonPorucivanje; set => buttonPorucivanje = value; }
        public Button ButtonPorudzbine { get => buttonPorudzbine; set => buttonPorudzbine = value; }
        public Button ButtonStavkeCenovnika { get => buttonStavkeCenovnika; set => buttonStavkeCenovnika = value; }
        public Button ButtonStolovi { get => buttonStolovi; set => buttonStolovi = value; }
    }
}