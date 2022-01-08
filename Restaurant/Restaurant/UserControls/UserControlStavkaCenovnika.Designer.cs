
namespace Restaurant.UserControls
{
    partial class UserControlStavkaCenovnika
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
            this.buttonIzmeniStavku = new System.Windows.Forms.Button();
            this.buttonIzbrisiStavku = new System.Windows.Forms.Button();
            this.buttonDodajStavku = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewStavke = new System.Windows.Forms.DataGridView();
            this.comboBoxValuta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNazivStavke = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCenaSaPDV = new System.Windows.Forms.TextBox();
            this.textBoxCenaBezPDV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxKategorija = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSacuvajIzmene = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFilterKategorije = new System.Windows.Forms.ComboBox();
            this.textBoxProcenatPDV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStavke)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonIzmeniStavku
            // 
            this.buttonIzmeniStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzmeniStavku.Location = new System.Drawing.Point(24, 435);
            this.buttonIzmeniStavku.Name = "buttonIzmeniStavku";
            this.buttonIzmeniStavku.Size = new System.Drawing.Size(167, 64);
            this.buttonIzmeniStavku.TabIndex = 25;
            this.buttonIzmeniStavku.Text = "Izmeni Izabranu Stavku";
            this.buttonIzmeniStavku.UseVisualStyleBackColor = true;
            this.buttonIzmeniStavku.Click += new System.EventHandler(this.buttonIzmeniStavku_Click);
            // 
            // buttonIzbrisiStavku
            // 
            this.buttonIzbrisiStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzbrisiStavku.Location = new System.Drawing.Point(514, 435);
            this.buttonIzbrisiStavku.Name = "buttonIzbrisiStavku";
            this.buttonIzbrisiStavku.Size = new System.Drawing.Size(190, 62);
            this.buttonIzbrisiStavku.TabIndex = 24;
            this.buttonIzbrisiStavku.Text = "Izbrisi izabranu stavku";
            this.buttonIzbrisiStavku.UseVisualStyleBackColor = true;
            this.buttonIzbrisiStavku.Click += new System.EventHandler(this.buttonIzbrisiStavku_Click);
            // 
            // buttonDodajStavku
            // 
            this.buttonDodajStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDodajStavku.Location = new System.Drawing.Point(230, 306);
            this.buttonDodajStavku.Name = "buttonDodajStavku";
            this.buttonDodajStavku.Size = new System.Drawing.Size(119, 76);
            this.buttonDodajStavku.TabIndex = 23;
            this.buttonDodajStavku.Text = "Dodaj novu stavku";
            this.buttonDodajStavku.UseVisualStyleBackColor = true;
            this.buttonDodajStavku.Click += new System.EventHandler(this.buttonDodajStavku_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(279, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Filter po kategorijama ";
            // 
            // dataGridViewStavke
            // 
            this.dataGridViewStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStavke.Location = new System.Drawing.Point(24, 505);
            this.dataGridViewStavke.Name = "dataGridViewStavke";
            this.dataGridViewStavke.RowHeadersWidth = 51;
            this.dataGridViewStavke.RowTemplate.Height = 24;
            this.dataGridViewStavke.Size = new System.Drawing.Size(702, 229);
            this.dataGridViewStavke.TabIndex = 21;
            // 
            // comboBoxValuta
            // 
            this.comboBoxValuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxValuta.FormattingEnabled = true;
            this.comboBoxValuta.Location = new System.Drawing.Point(181, 199);
            this.comboBoxValuta.Name = "comboBoxValuta";
            this.comboBoxValuta.Size = new System.Drawing.Size(168, 30);
            this.comboBoxValuta.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Valuta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cena Sa PDV";
            // 
            // textBoxNazivStavke
            // 
            this.textBoxNazivStavke.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNazivStavke.Location = new System.Drawing.Point(181, 24);
            this.textBoxNazivStavke.Name = "textBoxNazivStavke";
            this.textBoxNazivStavke.Size = new System.Drawing.Size(168, 28);
            this.textBoxNazivStavke.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "Naziv Stavke ";
            // 
            // textBoxCenaSaPDV
            // 
            this.textBoxCenaSaPDV.Enabled = false;
            this.textBoxCenaSaPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCenaSaPDV.Location = new System.Drawing.Point(181, 153);
            this.textBoxCenaSaPDV.Name = "textBoxCenaSaPDV";
            this.textBoxCenaSaPDV.Size = new System.Drawing.Size(168, 28);
            this.textBoxCenaSaPDV.TabIndex = 35;
            // 
            // textBoxCenaBezPDV
            // 
            this.textBoxCenaBezPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCenaBezPDV.Location = new System.Drawing.Point(181, 73);
            this.textBoxCenaBezPDV.Name = "textBoxCenaBezPDV";
            this.textBoxCenaBezPDV.Size = new System.Drawing.Size(168, 28);
            this.textBoxCenaBezPDV.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 24);
            this.label7.TabIndex = 36;
            this.label7.Text = "Cena bez PDV";
            // 
            // comboBoxKategorija
            // 
            this.comboBoxKategorija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKategorija.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKategorija.FormattingEnabled = true;
            this.comboBoxKategorija.Location = new System.Drawing.Point(181, 241);
            this.comboBoxKategorija.Name = "comboBoxKategorija";
            this.comboBoxKategorija.Size = new System.Drawing.Size(168, 30);
            this.comboBoxKategorija.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 24);
            this.label8.TabIndex = 38;
            this.label8.Text = "Kategorija";
            // 
            // buttonSacuvajIzmene
            // 
            this.buttonSacuvajIzmene.Enabled = false;
            this.buttonSacuvajIzmene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSacuvajIzmene.Location = new System.Drawing.Point(105, 306);
            this.buttonSacuvajIzmene.Name = "buttonSacuvajIzmene";
            this.buttonSacuvajIzmene.Size = new System.Drawing.Size(111, 76);
            this.buttonSacuvajIzmene.TabIndex = 40;
            this.buttonSacuvajIzmene.Text = "Sacuvaj Izmene";
            this.buttonSacuvajIzmene.UseVisualStyleBackColor = true;
            this.buttonSacuvajIzmene.Click += new System.EventHandler(this.buttonSacuvajIzmene_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxProcenatPDV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxCenaSaPDV);
            this.groupBox1.Controls.Add(this.buttonSacuvajIzmene);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxKategorija);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxValuta);
            this.groupBox1.Controls.Add(this.textBoxCenaBezPDV);
            this.groupBox1.Controls.Add(this.buttonDodajStavku);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxNazivStavke);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(141, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 406);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "PDV ";
            // 
            // comboBoxFilterKategorije
            // 
            this.comboBoxFilterKategorije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterKategorije.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFilterKategorije.FormattingEnabled = true;
            this.comboBoxFilterKategorije.Location = new System.Drawing.Point(283, 469);
            this.comboBoxFilterKategorije.Name = "comboBoxFilterKategorije";
            this.comboBoxFilterKategorije.Size = new System.Drawing.Size(179, 30);
            this.comboBoxFilterKategorije.TabIndex = 41;
            this.comboBoxFilterKategorije.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterKategorije_SelectedIndexChanged);
            // 
            // textBoxProcenatPDV
            // 
            this.textBoxProcenatPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProcenatPDV.Location = new System.Drawing.Point(181, 111);
            this.textBoxProcenatPDV.Name = "textBoxProcenatPDV";
            this.textBoxProcenatPDV.Size = new System.Drawing.Size(91, 28);
            this.textBoxProcenatPDV.TabIndex = 43;
            this.textBoxProcenatPDV.Leave += new System.EventHandler(this.textBoxProcenatPDV_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(278, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 29);
            this.label5.TabIndex = 44;
            this.label5.Text = "%";
            // 
            // UserControlStavkaCenovnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxFilterKategorije);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonIzmeniStavku);
            this.Controls.Add(this.buttonIzbrisiStavku);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewStavke);
            this.Name = "UserControlStavkaCenovnika";
            this.Size = new System.Drawing.Size(806, 739);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStavke)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonIzmeniStavku;
        private System.Windows.Forms.Button buttonIzbrisiStavku;
        private System.Windows.Forms.Button buttonDodajStavku;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewStavke;
        private System.Windows.Forms.ComboBox comboBoxValuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNazivStavke;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCenaSaPDV;
        private System.Windows.Forms.TextBox textBoxCenaBezPDV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxKategorija;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSacuvajIzmene;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxFilterKategorije;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProcenatPDV;
        private System.Windows.Forms.Label label5;
    }
}
