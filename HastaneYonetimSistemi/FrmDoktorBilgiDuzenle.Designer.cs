namespace HastaneYonetimSistemi
{
    partial class FrmDoktorBilgiDuzenle
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
            this.labelDoktorTC = new System.Windows.Forms.Label();
            this.textBoxSoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBrans = new System.Windows.Forms.ComboBox();
            this.buttonDuzenlemeKaydet = new System.Windows.Forms.Button();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxTCNO = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelDoktorTC
            // 
            this.labelDoktorTC.AutoSize = true;
            this.labelDoktorTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDoktorTC.Location = new System.Drawing.Point(102, 101);
            this.labelDoktorTC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDoktorTC.Name = "labelDoktorTC";
            this.labelDoktorTC.Size = new System.Drawing.Size(40, 24);
            this.labelDoktorTC.TabIndex = 36;
            this.labelDoktorTC.Text = "TC:";
            // 
            // textBoxSoyad
            // 
            this.textBoxSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSoyad.Location = new System.Drawing.Point(203, 198);
            this.textBoxSoyad.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSoyad.Name = "textBoxSoyad";
            this.textBoxSoyad.Size = new System.Drawing.Size(210, 29);
            this.textBoxSoyad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(75, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Soyad:";
            // 
            // textBoxAd
            // 
            this.textBoxAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxAd.Location = new System.Drawing.Point(203, 153);
            this.textBoxAd.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(210, 29);
            this.textBoxAd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(103, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Ad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(79, 251);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "Branş:";
            // 
            // comboBoxBrans
            // 
            this.comboBoxBrans.FormattingEnabled = true;
            this.comboBoxBrans.Location = new System.Drawing.Point(202, 248);
            this.comboBoxBrans.Name = "comboBoxBrans";
            this.comboBoxBrans.Size = new System.Drawing.Size(211, 32);
            this.comboBoxBrans.TabIndex = 4;
            // 
            // buttonDuzenlemeKaydet
            // 
            this.buttonDuzenlemeKaydet.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonDuzenlemeKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDuzenlemeKaydet.Location = new System.Drawing.Point(291, 345);
            this.buttonDuzenlemeKaydet.Name = "buttonDuzenlemeKaydet";
            this.buttonDuzenlemeKaydet.Size = new System.Drawing.Size(123, 40);
            this.buttonDuzenlemeKaydet.TabIndex = 42;
            this.buttonDuzenlemeKaydet.Text = "Guncelle";
            this.buttonDuzenlemeKaydet.UseVisualStyleBackColor = false;
            this.buttonDuzenlemeKaydet.Click += new System.EventHandler(this.buttonDuzenlemeKaydet_Click);
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSifre.Location = new System.Drawing.Point(202, 297);
            this.textBoxSifre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(211, 29);
            this.textBoxSifre.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(90, 300);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 24);
            this.label7.TabIndex = 40;
            this.label7.Text = "Şifre:";
            // 
            // maskedTextBoxTCNO
            // 
            this.maskedTextBoxTCNO.Enabled = false;
            this.maskedTextBoxTCNO.Location = new System.Drawing.Point(203, 101);
            this.maskedTextBoxTCNO.Mask = "00000000000";
            this.maskedTextBoxTCNO.Name = "maskedTextBoxTCNO";
            this.maskedTextBoxTCNO.Size = new System.Drawing.Size(211, 29);
            this.maskedTextBoxTCNO.TabIndex = 1;
            this.maskedTextBoxTCNO.ValidatingType = typeof(int);
            // 
            // FrmDoktorBilgiDuzenle
            // 
            this.AcceptButton = this.buttonDuzenlemeKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(594, 504);
            this.Controls.Add(this.maskedTextBoxTCNO);
            this.Controls.Add(this.buttonDuzenlemeKaydet);
            this.Controls.Add(this.textBoxSifre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxBrans);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelDoktorTC);
            this.Controls.Add(this.textBoxSoyad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAd);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmDoktorBilgiDuzenle";
            this.Text = "Doktor Bilgi Düzenle";
            this.Load += new System.EventHandler(this.FrmDoktorBilgiDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDoktorTC;
        private System.Windows.Forms.TextBox textBoxSoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBrans;
        private System.Windows.Forms.Button buttonDuzenlemeKaydet;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTCNO;
    }
}