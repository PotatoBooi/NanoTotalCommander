namespace NanoTotalCommander
{
    partial class View
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.vControlLeft = new NanoTotalCommander.VControl();
            this.SuspendLayout();
            // 
            // vControlLeft
            // 
            this.vControlLeft.CurrentPath = "";
            this.vControlLeft.Drives = new string[0];
            this.vControlLeft.FilesList = new string[0];
            this.vControlLeft.Location = new System.Drawing.Point(-1, -5);
            this.vControlLeft.Name = "vControlLeft";
            this.vControlLeft.Size = new System.Drawing.Size(300, 415);
            this.vControlLeft.TabIndex = 0;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 411);
            this.Controls.Add(this.vControlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "View";
            this.Text = "Nano Total Commander";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VControl vControlLeft;
    }
}

