
namespace Restaurant.UserControls
{
    partial class UserControlStolovi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBrojStolica = new System.Windows.Forms.ComboBox();
            this.dataGridViewStolovi = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDodajSto = new System.Windows.Forms.Button();
            this.buttonIzbrisiSto = new System.Windows.Forms.Button();
            this.buttonIzmeniSto = new System.Windows.Forms.Button();
            this.comboBoxBrojStola = new System.Windows.Forms.ComboBox();
            this.comboBoxIzmenjeniBrojeviStola = new System.Windows.Forms.ComboBox();
            this.buttonSacuvajIzmene = new System.Windows.Forms.Button();
            this.comboBoxIzmenjeniBrojeviStolica = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStolovi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj Stola";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Broj stolica za stolom";
            // 
            // comboBoxBrojStolica
            // 
            this.comboBoxBrojStolica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrojStolica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBrojStolica.FormattingEnabled = true;
            this.comboBoxBrojStolica.Location = new System.Drawing.Point(212, 71);
            this.comboBoxBrojStolica.Name = "comboBoxBrojStolica";
            this.comboBoxBrojStolica.Size = new System.Drawing.Size(168, 30);
            this.comboBoxBrojStolica.TabIndex = 6;
            // 
            // dataGridViewStolovi
            // 
            this.dataGridViewStolovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStolovi.Location = new System.Drawing.Point(212, 330);
            this.dataGridViewStolovi.Name = "dataGridViewStolovi";
            this.dataGridViewStolovi.RowHeadersWidth = 51;
            this.dataGridViewStolovi.RowTemplate.Height = 24;
            this.dataGridViewStolovi.Size = new System.Drawing.Size(497, 245);
            this.dataGridViewStolovi.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(345, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Svi stolovi : ";
            // 
            // buttonDodajSto
            // 
            this.buttonDodajSto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDodajSto.Location = new System.Drawing.Point(212, 120);
            this.buttonDodajSto.Name = "buttonDodajSto";
            this.buttonDodajSto.Size = new System.Drawing.Size(168, 46);
            this.buttonDodajSto.TabIndex = 9;
            this.buttonDodajSto.Text = "Dodaj novi sto";
            this.buttonDodajSto.UseVisualStyleBackColor = true;
            this.buttonDodajSto.Click += new System.EventHandler(this.buttonDodajSto_Click);
            // 
            // buttonIzbrisiSto
            // 
            this.buttonIzbrisiSto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzbrisiSto.Location = new System.Drawing.Point(541, 281);
            this.buttonIzbrisiSto.Name = "buttonIzbrisiSto";
            this.buttonIzbrisiSto.Size = new System.Drawing.Size(168, 46);
            this.buttonIzbrisiSto.TabIndex = 10;
            this.buttonIzbrisiSto.Text = "Izbrisi izabrani sto";
            this.buttonIzbrisiSto.UseVisualStyleBackColor = true;
            this.buttonIzbrisiSto.Click += new System.EventHandler(this.buttonIzbrisiSto_Click);
            // 
            // buttonIzmeniSto
            // 
            this.buttonIzmeniSto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzmeniSto.Location = new System.Drawing.Point(7, 281);
            this.buttonIzmeniSto.Name = "buttonIzmeniSto";
            this.buttonIzmeniSto.Size = new System.Drawing.Size(199, 40);
            this.buttonIzmeniSto.TabIndex = 11;
            this.buttonIzmeniSto.Text = "Izmeni Izabrani Sto";
            this.buttonIzmeniSto.UseVisualStyleBackColor = true;
            this.buttonIzmeniSto.Click += new System.EventHandler(this.buttonIzmeniSto_Click);
            // 
            // comboBoxBrojStola
            // 
            this.comboBoxBrojStola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrojStola.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBrojStola.FormattingEnabled = true;
            this.comboBoxBrojStola.Location = new System.Drawing.Point(212, 13);
            this.comboBoxBrojStola.Name = "comboBoxBrojStola";
            this.comboBoxBrojStola.Size = new System.Drawing.Size(168, 30);
            this.comboBoxBrojStola.TabIndex = 12;
            // 
            // comboBoxIzmenjeniBrojeviStola
            // 
            this.comboBoxIzmenjeniBrojeviStola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIzmenjeniBrojeviStola.Enabled = false;
            this.comboBoxIzmenjeniBrojeviStola.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxIzmenjeniBrojeviStola.FormattingEnabled = true;
            this.comboBoxIzmenjeniBrojeviStola.Location = new System.Drawing.Point(121, 370);
            this.comboBoxIzmenjeniBrojeviStola.Name = "comboBoxIzmenjeniBrojeviStola";
            this.comboBoxIzmenjeniBrojeviStola.Size = new System.Drawing.Size(56, 30);
            this.comboBoxIzmenjeniBrojeviStola.TabIndex = 17;
            // 
            // buttonSacuvajIzmene
            // 
            this.buttonSacuvajIzmene.Enabled = false;
            this.buttonSacuvajIzmene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSacuvajIzmene.Location = new System.Drawing.Point(7, 470);
            this.buttonSacuvajIzmene.Name = "buttonSacuvajIzmene";
            this.buttonSacuvajIzmene.Size = new System.Drawing.Size(171, 46);
            this.buttonSacuvajIzmene.TabIndex = 16;
            this.buttonSacuvajIzmene.Text = "Sacuvaj Izmene";
            this.buttonSacuvajIzmene.UseVisualStyleBackColor = true;
            this.buttonSacuvajIzmene.Click += new System.EventHandler(this.buttonSacuvajIzmene_Click);
            // 
            // comboBoxIzmenjeniBrojeviStolica
            // 
            this.comboBoxIzmenjeniBrojeviStolica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIzmenjeniBrojeviStolica.Enabled = false;
            this.comboBoxIzmenjeniBrojeviStolica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxIzmenjeniBrojeviStolica.FormattingEnabled = true;
            this.comboBoxIzmenjeniBrojeviStolica.Location = new System.Drawing.Point(121, 422);
            this.comboBoxIzmenjeniBrojeviStolica.Name = "comboBoxIzmenjeniBrojeviStolica";
            this.comboBoxIzmenjeniBrojeviStolica.Size = new System.Drawing.Size(56, 30);
            this.comboBoxIzmenjeniBrojeviStolica.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Broj stolica";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Broj Stola";
            // 
            // UserControlStolovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxIzmenjeniBrojeviStola);
            this.Controls.Add(this.buttonSacuvajIzmene);
            this.Controls.Add(this.comboBoxIzmenjeniBrojeviStolica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxBrojStola);
            this.Controls.Add(this.buttonIzmeniSto);
            this.Controls.Add(this.buttonIzbrisiSto);
            this.Controls.Add(this.buttonDodajSto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewStolovi);
            this.Controls.Add(this.comboBoxBrojStolica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserControlStolovi";
            this.Size = new System.Drawing.Size(745, 595);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStolovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBrojStolica;
        private System.Windows.Forms.DataGridView dataGridViewStolovi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDodajSto;
        private System.Windows.Forms.Button buttonIzbrisiSto;
        private System.Windows.Forms.Button buttonIzmeniSto;
        private System.Windows.Forms.ComboBox comboBoxBrojStola;
        private System.Windows.Forms.ComboBox comboBoxIzmenjeniBrojeviStola;
        private System.Windows.Forms.Button buttonSacuvajIzmene;
        private System.Windows.Forms.ComboBox comboBoxIzmenjeniBrojeviStolica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
