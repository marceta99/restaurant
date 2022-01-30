
using System.Windows.Forms;

namespace Restaurant.UserControls
{
    partial class UserControlPorudzbine
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
            this.comboBoxFilterStolovi = new System.Windows.Forms.ComboBox();
            this.buttonIzmeniPorudzbinu = new System.Windows.Forms.Button();
            this.buttonIzbrisiPorudzbinu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewSvePorudzbine = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetaljiPorudzbine = new System.Windows.Forms.DataGridView();
            this.buttonNaplati = new System.Windows.Forms.Button();
            this.comboBoxStatusPorudzbine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFiltriraj = new System.Windows.Forms.Button();
            this.groupBoxfilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSvePorudzbine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetaljiPorudzbine)).BeginInit();
            this.groupBoxfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxFilterStolovi
            // 
            this.comboBoxFilterStolovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterStolovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFilterStolovi.FormattingEnabled = true;
            this.comboBoxFilterStolovi.Location = new System.Drawing.Point(196, 55);
            this.comboBoxFilterStolovi.Name = "comboBoxFilterStolovi";
            this.comboBoxFilterStolovi.Size = new System.Drawing.Size(157, 30);
            this.comboBoxFilterStolovi.TabIndex = 46;
            // 
            // buttonIzmeniPorudzbinu
            // 
            this.buttonIzmeniPorudzbinu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzmeniPorudzbinu.Location = new System.Drawing.Point(592, 33);
            this.buttonIzmeniPorudzbinu.Name = "buttonIzmeniPorudzbinu";
            this.buttonIzmeniPorudzbinu.Size = new System.Drawing.Size(129, 83);
            this.buttonIzmeniPorudzbinu.TabIndex = 45;
            this.buttonIzmeniPorudzbinu.Text = "Izmeni Izabranu Porudzbinu";
            this.buttonIzmeniPorudzbinu.UseVisualStyleBackColor = true;
            // 
            // buttonIzbrisiPorudzbinu
            // 
            this.buttonIzbrisiPorudzbinu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzbrisiPorudzbinu.Location = new System.Drawing.Point(727, 34);
            this.buttonIzbrisiPorudzbinu.Name = "buttonIzbrisiPorudzbinu";
            this.buttonIzbrisiPorudzbinu.Size = new System.Drawing.Size(123, 81);
            this.buttonIzbrisiPorudzbinu.TabIndex = 44;
            this.buttonIzbrisiPorudzbinu.Text = "Izbrisi izabranu porudzbinu";
            this.buttonIzbrisiPorudzbinu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Filter po stolovima";
            // 
            // dataGridViewSvePorudzbine
            // 
            this.dataGridViewSvePorudzbine.BackgroundColor = System.Drawing.Color.Tan;
            this.dataGridViewSvePorudzbine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSvePorudzbine.Location = new System.Drawing.Point(207, 141);
            this.dataGridViewSvePorudzbine.Name = "dataGridViewSvePorudzbine";
            this.dataGridViewSvePorudzbine.RowHeadersWidth = 51;
            this.dataGridViewSvePorudzbine.RowTemplate.Height = 24;
            this.dataGridViewSvePorudzbine.Size = new System.Drawing.Size(630, 176);
            this.dataGridViewSvePorudzbine.TabIndex = 42;
            // 
            // dataGridViewDetaljiPorudzbine
            // 
            this.dataGridViewDetaljiPorudzbine.BackgroundColor = System.Drawing.Color.Tan;
            this.dataGridViewDetaljiPorudzbine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetaljiPorudzbine.Location = new System.Drawing.Point(105, 358);
            this.dataGridViewDetaljiPorudzbine.Name = "dataGridViewDetaljiPorudzbine";
            this.dataGridViewDetaljiPorudzbine.RowHeadersWidth = 51;
            this.dataGridViewDetaljiPorudzbine.RowTemplate.Height = 24;
            this.dataGridViewDetaljiPorudzbine.Size = new System.Drawing.Size(862, 215);
            this.dataGridViewDetaljiPorudzbine.TabIndex = 49;
            // 
            // buttonNaplati
            // 
            this.buttonNaplati.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNaplati.Location = new System.Drawing.Point(856, 34);
            this.buttonNaplati.Name = "buttonNaplati";
            this.buttonNaplati.Size = new System.Drawing.Size(111, 83);
            this.buttonNaplati.TabIndex = 50;
            this.buttonNaplati.Text = "Naplati";
            this.buttonNaplati.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatusPorudzbine
            // 
            this.comboBoxStatusPorudzbine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusPorudzbine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatusPorudzbine.FormattingEnabled = true;
            this.comboBoxStatusPorudzbine.Location = new System.Drawing.Point(28, 55);
            this.comboBoxStatusPorudzbine.Name = "comboBoxStatusPorudzbine";
            this.comboBoxStatusPorudzbine.Size = new System.Drawing.Size(137, 30);
            this.comboBoxStatusPorudzbine.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 51;
            this.label1.Text = "Filter po statusu";
            // 
            // buttonFiltriraj
            // 
            this.buttonFiltriraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltriraj.Location = new System.Drawing.Point(105, 34);
            this.buttonFiltriraj.Name = "buttonFiltriraj";
            this.buttonFiltriraj.Size = new System.Drawing.Size(83, 83);
            this.buttonFiltriraj.TabIndex = 53;
            this.buttonFiltriraj.Text = "Filter";
            this.buttonFiltriraj.UseVisualStyleBackColor = true;
            // 
            // groupBoxfilter
            // 
            this.groupBoxfilter.Controls.Add(this.label1);
            this.groupBoxfilter.Controls.Add(this.label3);
            this.groupBoxfilter.Controls.Add(this.comboBoxStatusPorudzbine);
            this.groupBoxfilter.Controls.Add(this.comboBoxFilterStolovi);
            this.groupBoxfilter.Location = new System.Drawing.Point(194, 21);
            this.groupBoxfilter.Name = "groupBoxfilter";
            this.groupBoxfilter.Size = new System.Drawing.Size(373, 98);
            this.groupBoxfilter.TabIndex = 54;
            this.groupBoxfilter.TabStop = false;
            this.groupBoxfilter.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 24);
            this.label2.TabIndex = 53;
            this.label2.Text = "Detalji o izabranoj porudzbini :";
            // 
            // UserControlPorudzbine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxfilter);
            this.Controls.Add(this.buttonFiltriraj);
            this.Controls.Add(this.buttonNaplati);
            this.Controls.Add(this.dataGridViewDetaljiPorudzbine);
            this.Controls.Add(this.buttonIzmeniPorudzbinu);
            this.Controls.Add(this.buttonIzbrisiPorudzbinu);
            this.Controls.Add(this.dataGridViewSvePorudzbine);
            this.Name = "UserControlPorudzbine";
            this.Size = new System.Drawing.Size(1079, 713);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSvePorudzbine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetaljiPorudzbine)).EndInit();
            this.groupBoxfilter.ResumeLayout(false);
            this.groupBoxfilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFilterStolovi;
        private System.Windows.Forms.Button buttonIzmeniPorudzbinu;
        private System.Windows.Forms.Button buttonIzbrisiPorudzbinu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewSvePorudzbine;
        private System.Windows.Forms.DataGridView dataGridViewDetaljiPorudzbine;
        private System.Windows.Forms.Button buttonNaplati;
        private System.Windows.Forms.ComboBox comboBoxStatusPorudzbine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFiltriraj;
        private System.Windows.Forms.GroupBox groupBoxfilter;
        private Label label2;

        public ComboBox ComboBoxFilterStolovi { get => comboBoxFilterStolovi; set => comboBoxFilterStolovi = value; }
        public Button ButtonIzmeniPorudzbinu { get => buttonIzmeniPorudzbinu; set => buttonIzmeniPorudzbinu = value; }
        public Button ButtonIzbrisiPorudzbinu { get => buttonIzbrisiPorudzbinu; set => buttonIzbrisiPorudzbinu = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public DataGridView DataGridViewSvePorudzbine { get => dataGridViewSvePorudzbine; set => dataGridViewSvePorudzbine = value; }
        public DataGridView DataGridViewDetaljiPorudzbine { get => dataGridViewDetaljiPorudzbine; set => dataGridViewDetaljiPorudzbine = value; }
        public Button ButtonNaplati { get => buttonNaplati; set => buttonNaplati = value; }
        public ComboBox ComboBoxStatusPorudzbine { get => comboBoxStatusPorudzbine; set => comboBoxStatusPorudzbine = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Button ButtonFiltriraj { get => buttonFiltriraj; set => buttonFiltriraj = value; }
        public GroupBox GroupBoxfilter { get => groupBoxfilter; set => groupBoxfilter = value; }
    }
}
