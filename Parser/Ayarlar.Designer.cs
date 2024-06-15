namespace Parser
{
    partial class Ayarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayarlar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaranacak = new System.Windows.Forms.TextBox();
            this.btnTaranacakDizin = new System.Windows.Forms.Button();
            this.btnkayitDizin = new System.Windows.Forms.Button();
            this.txtkayitYeri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.sayac = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sayac)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarama yapılacak dizin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dosyaların kayıt edileceği dizin";
            // 
            // txtTaranacak
            // 
            this.txtTaranacak.Location = new System.Drawing.Point(181, 10);
            this.txtTaranacak.Name = "txtTaranacak";
            this.txtTaranacak.Size = new System.Drawing.Size(212, 20);
            this.txtTaranacak.TabIndex = 2;
            // 
            // btnTaranacakDizin
            // 
            this.btnTaranacakDizin.Location = new System.Drawing.Point(409, 8);
            this.btnTaranacakDizin.Name = "btnTaranacakDizin";
            this.btnTaranacakDizin.Size = new System.Drawing.Size(75, 23);
            this.btnTaranacakDizin.TabIndex = 3;
            this.btnTaranacakDizin.Text = "...";
            this.btnTaranacakDizin.UseVisualStyleBackColor = true;
            this.btnTaranacakDizin.Click += new System.EventHandler(this.btnTaranacakDizin_Click);
            // 
            // btnkayitDizin
            // 
            this.btnkayitDizin.Location = new System.Drawing.Point(409, 39);
            this.btnkayitDizin.Name = "btnkayitDizin";
            this.btnkayitDizin.Size = new System.Drawing.Size(75, 23);
            this.btnkayitDizin.TabIndex = 5;
            this.btnkayitDizin.Text = "...";
            this.btnkayitDizin.UseVisualStyleBackColor = true;
            this.btnkayitDizin.Click += new System.EventHandler(this.btnkayitDizin_Click);
            // 
            // txtkayitYeri
            // 
            this.txtkayitYeri.Location = new System.Drawing.Point(181, 41);
            this.txtkayitYeri.Name = "txtkayitYeri";
            this.txtkayitYeri.Size = new System.Drawing.Size(212, 20);
            this.txtkayitYeri.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ziplenecek dosya sayısı";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(466, 116);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // sayac
            // 
            this.sayac.Location = new System.Drawing.Point(181, 75);
            this.sayac.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.sayac.Name = "sayac";
            this.sayac.Size = new System.Drawing.Size(60, 20);
            this.sayac.TabIndex = 9;
            this.sayac.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 151);
            this.Controls.Add(this.sayac);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnkayitDizin);
            this.Controls.Add(this.txtkayitYeri);
            this.Controls.Add(this.btnTaranacakDizin);
            this.Controls.Add(this.txtTaranacak);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(569, 190);
            this.MinimumSize = new System.Drawing.Size(569, 190);
            this.Name = "Ayarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sayac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaranacak;
        private System.Windows.Forms.Button btnTaranacakDizin;
        private System.Windows.Forms.Button btnkayitDizin;
        private System.Windows.Forms.TextBox txtkayitYeri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.NumericUpDown sayac;
    }
}