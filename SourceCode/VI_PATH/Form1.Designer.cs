namespace VI_PATH
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Feld = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Feld)).BeginInit();
            this.SuspendLayout();
            // 
            // Feld
            // 
            this.Feld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Feld.ColumnHeadersVisible = false;
            this.Feld.Location = new System.Drawing.Point(249, 12);
            this.Feld.Name = "Feld";
            this.Feld.RowHeadersVisible = false;
            this.Feld.Size = new System.Drawing.Size(608, 336);
            this.Feld.TabIndex = 0;
            this.Feld.SelectionChanged += new System.EventHandler(this.selectionChanged);
            this.Feld.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Feld_MouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "Obstacle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "Finish";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 27);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(536, 407);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 27);
            this.button4.TabIndex = 5;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Edit Mode";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 27);
            this.button5.TabIndex = 7;
            this.button5.Text = "Delete";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 407);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 27);
            this.button6.TabIndex = 8;
            this.button6.Text = "back";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 446);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Feld);
            this.Name = "Form1";
            this.Text = "Dijkstra";
            ((System.ComponentModel.ISupportInitialize)(this.Feld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Feld;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button6;
    }
}

