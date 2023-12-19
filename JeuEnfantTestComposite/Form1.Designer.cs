namespace JeuEnfantTestComposite
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
            this.BtnRight = new System.Windows.Forms.Button();
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.RbCercle = new System.Windows.Forms.RadioButton();
            this.RbTriangle = new System.Windows.Forms.RadioButton();
            this.RbRectangle = new System.Windows.Forms.RadioButton();
            this.BtnColor = new System.Windows.Forms.Button();
            this.BtnCreer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRight
            // 
            this.BtnRight.Location = new System.Drawing.Point(669, 145);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(75, 23);
            this.BtnRight.TabIndex = 29;
            this.BtnRight.Text = "Droite";
            this.BtnRight.UseVisualStyleBackColor = true;
            this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Location = new System.Drawing.Point(621, 189);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(75, 23);
            this.BtnDown.TabIndex = 28;
            this.BtnDown.Text = "Bas";
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnLeft
            // 
            this.BtnLeft.Location = new System.Drawing.Point(560, 145);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(75, 23);
            this.BtnLeft.TabIndex = 27;
            this.BtnLeft.Text = "Gauche";
            this.BtnLeft.UseVisualStyleBackColor = true;
            this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // BtnUp
            // 
            this.BtnUp.Location = new System.Drawing.Point(621, 100);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(75, 23);
            this.BtnUp.TabIndex = 26;
            this.BtnUp.Text = "Haut";
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(654, 28);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 25;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // RbCercle
            // 
            this.RbCercle.AutoSize = true;
            this.RbCercle.Location = new System.Drawing.Point(366, 31);
            this.RbCercle.Name = "RbCercle";
            this.RbCercle.Size = new System.Drawing.Size(55, 17);
            this.RbCercle.TabIndex = 24;
            this.RbCercle.TabStop = true;
            this.RbCercle.Text = "Cercle";
            this.RbCercle.UseVisualStyleBackColor = true;
            // 
            // RbTriangle
            // 
            this.RbTriangle.AutoSize = true;
            this.RbTriangle.Location = new System.Drawing.Point(221, 31);
            this.RbTriangle.Name = "RbTriangle";
            this.RbTriangle.Size = new System.Drawing.Size(63, 17);
            this.RbTriangle.TabIndex = 23;
            this.RbTriangle.TabStop = true;
            this.RbTriangle.Text = "Triangle";
            this.RbTriangle.UseVisualStyleBackColor = true;
            // 
            // RbRectangle
            // 
            this.RbRectangle.AutoSize = true;
            this.RbRectangle.Checked = true;
            this.RbRectangle.Location = new System.Drawing.Point(84, 31);
            this.RbRectangle.Name = "RbRectangle";
            this.RbRectangle.Size = new System.Drawing.Size(74, 17);
            this.RbRectangle.TabIndex = 22;
            this.RbRectangle.TabStop = true;
            this.RbRectangle.Text = "Rectangle";
            this.RbRectangle.UseVisualStyleBackColor = true;
            // 
            // BtnColor
            // 
            this.BtnColor.BackColor = System.Drawing.Color.Black;
            this.BtnColor.ForeColor = System.Drawing.Color.White;
            this.BtnColor.Location = new System.Drawing.Point(560, 28);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(75, 23);
            this.BtnColor.TabIndex = 21;
            this.BtnColor.Text = "Colorer";
            this.BtnColor.UseVisualStyleBackColor = false;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // BtnCreer
            // 
            this.BtnCreer.Location = new System.Drawing.Point(466, 28);
            this.BtnCreer.Name = "BtnCreer";
            this.BtnCreer.Size = new System.Drawing.Size(75, 23);
            this.BtnCreer.TabIndex = 20;
            this.BtnCreer.Text = "Creer";
            this.BtnCreer.UseVisualStyleBackColor = true;
            this.BtnCreer.Click += new System.EventHandler(this.BtnCreer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 531);
            this.Controls.Add(this.BtnRight);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnLeft);
            this.Controls.Add(this.BtnUp);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.RbCercle);
            this.Controls.Add(this.RbTriangle);
            this.Controls.Add(this.RbRectangle);
            this.Controls.Add(this.BtnColor);
            this.Controls.Add(this.BtnCreer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Button BtnUp;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.RadioButton RbCercle;
        private System.Windows.Forms.RadioButton RbTriangle;
        private System.Windows.Forms.RadioButton RbRectangle;
        private System.Windows.Forms.Button BtnColor;
        private System.Windows.Forms.Button BtnCreer;
    }
}

