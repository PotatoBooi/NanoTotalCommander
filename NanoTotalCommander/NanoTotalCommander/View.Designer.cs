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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.vControlRight = new NanoTotalCommander.VControl();
            this.vControlLeft = new NanoTotalCommander.VControl();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(299, 169);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(46, 39);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.operationButtonsClicked);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(299, 237);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(46, 39);
            this.buttonMove.TabIndex = 3;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.operationButtonsClicked);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(299, 306);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(46, 39);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.operationButtonsClicked);
            // 
            // vControlRight
            // 
            this.vControlRight.CurrentPath = "";
            this.vControlRight.Drives = new string[0];
            this.vControlRight.FilesList = new string[0];
            this.vControlRight.Location = new System.Drawing.Point(346, -5);
            this.vControlRight.Name = "vControlRight";
            this.vControlRight.Size = new System.Drawing.Size(300, 415);
            this.vControlRight.TabIndex = 1;
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
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.vControlRight);
            this.Controls.Add(this.vControlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "View";
            this.Text = "Nano Total Commander";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VControl vControlLeft;
        private VControl vControlRight;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonCopy;
    }
}

