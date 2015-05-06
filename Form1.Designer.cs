namespace Pathfinding
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbEnd = new System.Windows.Forms.RadioButton();
            this.rbWall = new System.Windows.Forms.RadioButton();
            this.rbStart = new System.Windows.Forms.RadioButton();
            this.bnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAStar = new System.Windows.Forms.RadioButton();
            this.bnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNone);
            this.groupBox1.Controls.Add(this.rbEnd);
            this.groupBox1.Controls.Add(this.rbWall);
            this.groupBox1.Controls.Add(this.rbStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Block Type";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.BackColor = System.Drawing.Color.Green;
            this.rbNone.Location = new System.Drawing.Point(6, 88);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 3;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = false;
            // 
            // rbEnd
            // 
            this.rbEnd.AutoSize = true;
            this.rbEnd.BackColor = System.Drawing.Color.LightGreen;
            this.rbEnd.Location = new System.Drawing.Point(6, 65);
            this.rbEnd.Name = "rbEnd";
            this.rbEnd.Size = new System.Drawing.Size(44, 17);
            this.rbEnd.TabIndex = 2;
            this.rbEnd.Text = "End";
            this.rbEnd.UseVisualStyleBackColor = false;
            // 
            // rbWall
            // 
            this.rbWall.AutoSize = true;
            this.rbWall.BackColor = System.Drawing.Color.Gray;
            this.rbWall.Location = new System.Drawing.Point(6, 42);
            this.rbWall.Name = "rbWall";
            this.rbWall.Size = new System.Drawing.Size(46, 17);
            this.rbWall.TabIndex = 1;
            this.rbWall.Text = "Wall";
            this.rbWall.UseVisualStyleBackColor = false;
            // 
            // rbStart
            // 
            this.rbStart.AutoSize = true;
            this.rbStart.BackColor = System.Drawing.Color.Orange;
            this.rbStart.Checked = true;
            this.rbStart.Location = new System.Drawing.Point(6, 19);
            this.rbStart.Name = "rbStart";
            this.rbStart.Size = new System.Drawing.Size(47, 17);
            this.rbStart.TabIndex = 0;
            this.rbStart.TabStop = true;
            this.rbStart.Text = "Start";
            this.rbStart.UseVisualStyleBackColor = false;
            // 
            // bnStart
            // 
            this.bnStart.Location = new System.Drawing.Point(12, 12);
            this.bnStart.Name = "bnStart";
            this.bnStart.Size = new System.Drawing.Size(80, 23);
            this.bnStart.TabIndex = 2;
            this.bnStart.Text = "Start";
            this.bnStart.UseVisualStyleBackColor = true;
            this.bnStart.Click += new System.EventHandler(this.bnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAStar);
            this.groupBox2.Location = new System.Drawing.Point(98, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 113);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alogrithm";
            // 
            // rbAStar
            // 
            this.rbAStar.AutoSize = true;
            this.rbAStar.Checked = true;
            this.rbAStar.Location = new System.Drawing.Point(6, 19);
            this.rbAStar.Name = "rbAStar";
            this.rbAStar.Size = new System.Drawing.Size(36, 17);
            this.rbAStar.TabIndex = 0;
            this.rbAStar.TabStop = true;
            this.rbAStar.Text = "A*";
            this.rbAStar.UseVisualStyleBackColor = true;
            // 
            // bnClear
            // 
            this.bnClear.Location = new System.Drawing.Point(98, 12);
            this.bnClear.Name = "bnClear";
            this.bnClear.Size = new System.Drawing.Size(89, 23);
            this.bnClear.TabIndex = 4;
            this.bnClear.Text = "Clear";
            this.bnClear.UseVisualStyleBackColor = true;
            this.bnClear.Click += new System.EventHandler(this.bnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 163);
            this.Controls.Add(this.bnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bnStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Pathfinding";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEnd;
        private System.Windows.Forms.RadioButton rbWall;
        private System.Windows.Forms.RadioButton rbStart;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.Button bnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbAStar;
        private System.Windows.Forms.Button bnClear;
    }
}

