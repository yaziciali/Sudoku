
namespace Sudoku
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
            this.components = new System.ComponentModel.Container();
            this.KontrolTusu = new System.Windows.Forms.Button();
            this.TemizleTusu = new System.Windows.Forms.Button();
            this.YeniOyunTusu1 = new System.Windows.Forms.Button();
            this.YeniOyunTusu2 = new System.Windows.Forms.Button();
            this.Pano1 = new Sudoku.Pano();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // KontrolTusu
            // 
            this.KontrolTusu.Location = new System.Drawing.Point(232, 516);
            this.KontrolTusu.Name = "KontrolTusu";
            this.KontrolTusu.Size = new System.Drawing.Size(94, 29);
            this.KontrolTusu.TabIndex = 1;
            this.KontrolTusu.Text = "Kontrol Et";
            this.KontrolTusu.UseVisualStyleBackColor = true;
            this.KontrolTusu.Click += new System.EventHandler(this.KontrolTusu_Click);
            // 
            // TemizleTusu
            // 
            this.TemizleTusu.Location = new System.Drawing.Point(449, 516);
            this.TemizleTusu.Name = "TemizleTusu";
            this.TemizleTusu.Size = new System.Drawing.Size(94, 29);
            this.TemizleTusu.TabIndex = 2;
            this.TemizleTusu.Text = "Temizle";
            this.TemizleTusu.UseVisualStyleBackColor = true;
            this.TemizleTusu.Click += new System.EventHandler(this.TemizleTusu_Click);
            // 
            // YeniOyunTusu1
            // 
            this.YeniOyunTusu1.Location = new System.Drawing.Point(22, 27);
            this.YeniOyunTusu1.Name = "YeniOyunTusu1";
            this.YeniOyunTusu1.Size = new System.Drawing.Size(94, 62);
            this.YeniOyunTusu1.TabIndex = 3;
            this.YeniOyunTusu1.Text = "Yeni Oyun Kolay";
            this.YeniOyunTusu1.UseVisualStyleBackColor = true;
            this.YeniOyunTusu1.Click += new System.EventHandler(this.YeniOyunTusu1_Click);
            // 
            // YeniOyunTusu2
            // 
            this.YeniOyunTusu2.Location = new System.Drawing.Point(22, 401);
            this.YeniOyunTusu2.Name = "YeniOyunTusu2";
            this.YeniOyunTusu2.Size = new System.Drawing.Size(94, 67);
            this.YeniOyunTusu2.TabIndex = 4;
            this.YeniOyunTusu2.Text = "Yeni Oyun Zor";
            this.YeniOyunTusu2.UseVisualStyleBackColor = true;
            this.YeniOyunTusu2.Click += new System.EventHandler(this.YeniOyunTusu2_Click);
            // 
            // Pano1
            // 
            this.Pano1.Location = new System.Drawing.Point(148, 27);
            this.Pano1.Name = "Pano1";
            this.Pano1.Size = new System.Drawing.Size(471, 468);
            this.Pano1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 563);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pano1);
            this.Controls.Add(this.YeniOyunTusu2);
            this.Controls.Add(this.YeniOyunTusu1);
            this.Controls.Add(this.TemizleTusu);
            this.Controls.Add(this.KontrolTusu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button KontrolTusu;
        private System.Windows.Forms.Button TemizleTusu;
        private System.Windows.Forms.Button YeniOyunTusu1;
        private System.Windows.Forms.Button YeniOyunTusu2;
        private Pano Pano1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

