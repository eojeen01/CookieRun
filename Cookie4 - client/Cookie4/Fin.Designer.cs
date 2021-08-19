
namespace Cookie4
{
    partial class Fin
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
            this.labelFin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFin
            // 
            this.labelFin.AutoSize = true;
            this.labelFin.BackColor = System.Drawing.Color.Transparent;
            this.labelFin.Font = new System.Drawing.Font("배달의민족 한나체 Air", 112.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelFin.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelFin.Location = new System.Drawing.Point(215, 53);
            this.labelFin.Name = "labelFin";
            this.labelFin.Size = new System.Drawing.Size(608, 188);
            this.labelFin.TabIndex = 0;
            this.labelFin.Text = "Finish!";
            // 
            // Fin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::Cookie4.Properties.Resources.Cookie_background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.labelFin);
            this.DoubleBuffered = true;
            this.Name = "Fin";
            this.Text = "Fin";
            this.Load += new System.EventHandler(this.Fin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFin;
    }
}