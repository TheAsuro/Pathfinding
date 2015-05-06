namespace Pathfinding
{
    partial class WorldDisplay
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
            this.SuspendLayout();
            // 
            // WorldDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImage = global::Pathfinding.Properties.Resources.border;
            this.ClientSize = new System.Drawing.Size(536, 357);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WorldDisplay";
            this.Text = "WorldDisplay";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WorldDisplay_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorldDisplay_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}