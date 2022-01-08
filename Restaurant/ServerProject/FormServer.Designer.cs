
namespace ServerProject
{
    partial class FormServer
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
            this.buttonPokreniServer = new System.Windows.Forms.Button();
            this.buttonZaustaviServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPokreniServer
            // 
            this.buttonPokreniServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPokreniServer.Location = new System.Drawing.Point(112, 102);
            this.buttonPokreniServer.Name = "buttonPokreniServer";
            this.buttonPokreniServer.Size = new System.Drawing.Size(172, 67);
            this.buttonPokreniServer.TabIndex = 0;
            this.buttonPokreniServer.Text = "Pokreni Server";
            this.buttonPokreniServer.UseVisualStyleBackColor = true;
            this.buttonPokreniServer.Click += new System.EventHandler(this.buttonPokreniServer_Click);
            // 
            // buttonZaustaviServer
            // 
            this.buttonZaustaviServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZaustaviServer.Location = new System.Drawing.Point(330, 102);
            this.buttonZaustaviServer.Name = "buttonZaustaviServer";
            this.buttonZaustaviServer.Size = new System.Drawing.Size(179, 67);
            this.buttonZaustaviServer.TabIndex = 1;
            this.buttonZaustaviServer.Text = "Zaustavi Server";
            this.buttonZaustaviServer.UseVisualStyleBackColor = true;
            this.buttonZaustaviServer.Click += new System.EventHandler(this.buttonZaustaviServer_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonZaustaviServer);
            this.Controls.Add(this.buttonPokreniServer);
            this.Name = "FormServer";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPokreniServer;
        private System.Windows.Forms.Button buttonZaustaviServer;
    }
}

