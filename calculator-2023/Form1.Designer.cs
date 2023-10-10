namespace calculator_2023
{
    partial class Calculator2023
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.lblOp = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(0, 30);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(320, 80);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "0";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblResult.TextChanged += new System.EventHandler(this.lblResult_TextChanged);
            this.lblResult.Click += new System.EventHandler(this.lblResult_Click);
            // 
            // lblOp
            // 
            this.lblOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOp.Location = new System.Drawing.Point(0, 0);
            this.lblOp.Name = "lblOp";
            this.lblOp.Size = new System.Drawing.Size(320, 30);
            this.lblOp.TabIndex = 1;
            this.lblOp.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Calculator2023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 477);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblOp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Calculator2023";
            this.ShowIcon = false;
            this.Text = "Calcolatrice";
            this.Load += new System.EventHandler(this.Calculator2023_Load);
            this.TextChanged += new System.EventHandler(this.lblResult_TextChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel lblOp;
    }
}

