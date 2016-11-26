namespace Dev_LocationMaker
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
            this.displayedMap = new System.Windows.Forms.PictureBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.displayedMap)).BeginInit();
            this.SuspendLayout();
            // 
            // displayedMap
            // 
            this.displayedMap.Image = global::Dev_LocationMaker.Properties.Resources.TestRainbow;
            this.displayedMap.Location = new System.Drawing.Point(12, 41);
            this.displayedMap.Name = "displayedMap";
            this.displayedMap.Size = new System.Drawing.Size(478, 449);
            this.displayedMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.displayedMap.TabIndex = 0;
            this.displayedMap.TabStop = false;
            this.displayedMap.Paint += new System.Windows.Forms.PaintEventHandler(this.displayedMap_Paint);
            this.displayedMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.displayedMap_MouseClick);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(3, 12);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(109, 23);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Change Map";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(364, 12);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(125, 23);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "Clear All Locations";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 501);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.displayedMap);
            this.Name = "Form1";
            this.Text = "Developer Location Maker";
            ((System.ComponentModel.ISupportInitialize)(this.displayedMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox displayedMap;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnClearAll;
    }
}

