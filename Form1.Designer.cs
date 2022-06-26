namespace Laboratory_work2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lenght = new System.Windows.Forms.TextBox();
            this.Time = new System.Windows.Forms.TextBox();
            this.Taustep = new System.Windows.Forms.TextBox();
            this.Hstep = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(828, 673);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(865, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(865, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Длина стержня (L)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(865, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время воздействия (T)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(865, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Шаг по времени (tau)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(865, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Шаг по х (h)";
            // 
            // Lenght
            // 
            this.Lenght.Location = new System.Drawing.Point(1033, 122);
            this.Lenght.Name = "Lenght";
            this.Lenght.Size = new System.Drawing.Size(100, 23);
            this.Lenght.TabIndex = 6;
            // 
            // Time
            // 
            this.Time.Location = new System.Drawing.Point(1033, 172);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(100, 23);
            this.Time.TabIndex = 7;
            // 
            // Taustep
            // 
            this.Taustep.Location = new System.Drawing.Point(1033, 230);
            this.Taustep.Name = "Taustep";
            this.Taustep.Size = new System.Drawing.Size(100, 23);
            this.Taustep.TabIndex = 8;
            // 
            // Hstep
            // 
            this.Hstep.Location = new System.Drawing.Point(1033, 281);
            this.Hstep.Name = "Hstep";
            this.Hstep.Size = new System.Drawing.Size(100, 23);
            this.Hstep.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(865, 333);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(268, 290);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Tag = "";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 100.4444F;
            this.Column1.HeaderText = "Начальная функция";
            this.Column1.Name = "Column1";
            this.Column1.Width = 113;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 99.55555F;
            this.Column2.HeaderText = "Функция В(х)";
            this.Column2.Name = "Column2";
            this.Column2.Width = 112;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 697);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Hstep);
            this.Controls.Add(this.Taustep);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Lenght);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Lenght;
        private TextBox Time;
        private TextBox Taustep;
        private TextBox Hstep;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}