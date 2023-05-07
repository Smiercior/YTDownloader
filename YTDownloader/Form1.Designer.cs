
namespace YTDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.wantedListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.foundListBox = new System.Windows.Forms.ListBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.clearFoundBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.plLangBtn = new System.Windows.Forms.Button();
            this.engLangBtn = new System.Windows.Forms.Button();
            this.fileBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.t1SelectName = new System.Windows.Forms.ComboBox();
            this.t2SelectName = new System.Windows.Forms.ComboBox();
            this.t3SelectName = new System.Windows.Forms.ComboBox();
            this.t1StartBtn = new System.Windows.Forms.Button();
            this.t2StartBtn = new System.Windows.Forms.Button();
            this.t3StartBtn = new System.Windows.Forms.Button();
            this.t3StopBtn = new System.Windows.Forms.Button();
            this.t2StopBtn = new System.Windows.Forms.Button();
            this.t1StopBtn = new System.Windows.Forms.Button();
            this.t1PercentLabel = new System.Windows.Forms.Label();
            this.t2PercentLabel = new System.Windows.Forms.Label();
            this.t3PercentLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // wantedListBox
            // 
            this.wantedListBox.BackColor = System.Drawing.Color.Black;
            this.wantedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wantedListBox.ForeColor = System.Drawing.Color.White;
            this.wantedListBox.FormattingEnabled = true;
            this.wantedListBox.ItemHeight = 15;
            this.wantedListBox.Location = new System.Drawing.Point(32, 66);
            this.wantedListBox.Name = "wantedListBox";
            this.wantedListBox.Size = new System.Drawing.Size(152, 270);
            this.wantedListBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wanted";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(32, 342);
            this.textBox1.MaxLength = 40;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(151, 40);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.addBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addBtn.BackgroundImage")));
            this.addBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.addBtn.Location = new System.Drawing.Point(32, 386);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(47, 31);
            this.addBtn.TabIndex = 5;
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.delBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delBtn.BackgroundImage")));
            this.delBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.delBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delBtn.Location = new System.Drawing.Point(83, 386);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(47, 31);
            this.delBtn.TabIndex = 6;
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(283, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Found";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // foundListBox
            // 
            this.foundListBox.BackColor = System.Drawing.Color.Black;
            this.foundListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.foundListBox.ForeColor = System.Drawing.Color.White;
            this.foundListBox.FormattingEnabled = true;
            this.foundListBox.ItemHeight = 15;
            this.foundListBox.Location = new System.Drawing.Point(283, 66);
            this.foundListBox.Name = "foundListBox";
            this.foundListBox.Size = new System.Drawing.Size(216, 315);
            this.foundListBox.TabIndex = 8;
            this.foundListBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.searchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBtn.BackgroundImage")));
            this.searchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.searchBtn.FlatAppearance.BorderSize = 0;
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Location = new System.Drawing.Point(211, 189);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(44, 33);
            this.searchBtn.TabIndex = 9;
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // clearFoundBtn
            // 
            this.clearFoundBtn.BackColor = System.Drawing.Color.Black;
            this.clearFoundBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clearFoundBtn.BackgroundImage")));
            this.clearFoundBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clearFoundBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearFoundBtn.Location = new System.Drawing.Point(460, 344);
            this.clearFoundBtn.Name = "clearFoundBtn";
            this.clearFoundBtn.Size = new System.Drawing.Size(35, 35);
            this.clearFoundBtn.TabIndex = 11;
            this.clearFoundBtn.UseVisualStyleBackColor = false;
            this.clearFoundBtn.Click += new System.EventHandler(this.clearFoundBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::YTDownloader.Resource1.noImage;
            this.pictureBox1.Location = new System.Drawing.Point(546, 291);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 90);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // plLangBtn
            // 
            this.plLangBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.plLangBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.plLangBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plLangBtn.ForeColor = System.Drawing.Color.White;
            this.plLangBtn.Location = new System.Drawing.Point(742, 358);
            this.plLangBtn.Name = "plLangBtn";
            this.plLangBtn.Size = new System.Drawing.Size(58, 23);
            this.plLangBtn.TabIndex = 13;
            this.plLangBtn.Text = "PL";
            this.plLangBtn.UseVisualStyleBackColor = false;
            this.plLangBtn.Click += new System.EventHandler(this.plLangBtn_Click);
            // 
            // engLangBtn
            // 
            this.engLangBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.engLangBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.engLangBtn.ForeColor = System.Drawing.Color.White;
            this.engLangBtn.Location = new System.Drawing.Point(806, 358);
            this.engLangBtn.Name = "engLangBtn";
            this.engLangBtn.Size = new System.Drawing.Size(58, 23);
            this.engLangBtn.TabIndex = 14;
            this.engLangBtn.Text = "ENG";
            this.engLangBtn.UseVisualStyleBackColor = false;
            this.engLangBtn.Click += new System.EventHandler(this.engLangBtn_Click);
            // 
            // fileBtn
            // 
            this.fileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.fileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fileBtn.BackgroundImage")));
            this.fileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.fileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileBtn.Location = new System.Drawing.Point(136, 386);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(47, 32);
            this.fileBtn.TabIndex = 15;
            this.fileBtn.UseVisualStyleBackColor = false;
            this.fileBtn.Click += new System.EventHandler(this.fileBtn_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(546, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Download";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t1SelectName
            // 
            this.t1SelectName.BackColor = System.Drawing.Color.Black;
            this.t1SelectName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.t1SelectName.ForeColor = System.Drawing.Color.White;
            this.t1SelectName.FormattingEnabled = true;
            this.t1SelectName.Location = new System.Drawing.Point(546, 88);
            this.t1SelectName.Name = "t1SelectName";
            this.t1SelectName.Size = new System.Drawing.Size(181, 31);
            this.t1SelectName.TabIndex = 17;
            // 
            // t2SelectName
            // 
            this.t2SelectName.BackColor = System.Drawing.Color.Black;
            this.t2SelectName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.t2SelectName.ForeColor = System.Drawing.Color.White;
            this.t2SelectName.FormattingEnabled = true;
            this.t2SelectName.Location = new System.Drawing.Point(546, 134);
            this.t2SelectName.Name = "t2SelectName";
            this.t2SelectName.Size = new System.Drawing.Size(181, 31);
            this.t2SelectName.TabIndex = 18;
            // 
            // t3SelectName
            // 
            this.t3SelectName.BackColor = System.Drawing.Color.Black;
            this.t3SelectName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.t3SelectName.ForeColor = System.Drawing.Color.White;
            this.t3SelectName.FormattingEnabled = true;
            this.t3SelectName.Location = new System.Drawing.Point(546, 180);
            this.t3SelectName.Name = "t3SelectName";
            this.t3SelectName.Size = new System.Drawing.Size(181, 31);
            this.t3SelectName.TabIndex = 19;
            // 
            // t1StartBtn
            // 
            this.t1StartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.t1StartBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("t1StartBtn.BackgroundImage")));
            this.t1StartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.t1StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t1StartBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.t1StartBtn.Location = new System.Drawing.Point(734, 88);
            this.t1StartBtn.Name = "t1StartBtn";
            this.t1StartBtn.Size = new System.Drawing.Size(47, 31);
            this.t1StartBtn.TabIndex = 20;
            this.t1StartBtn.UseVisualStyleBackColor = false;
            this.t1StartBtn.Click += new System.EventHandler(this.t1StartBtn_Click);
            // 
            // t2StartBtn
            // 
            this.t2StartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.t2StartBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("t2StartBtn.BackgroundImage")));
            this.t2StartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.t2StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t2StartBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.t2StartBtn.Location = new System.Drawing.Point(734, 134);
            this.t2StartBtn.Name = "t2StartBtn";
            this.t2StartBtn.Size = new System.Drawing.Size(47, 31);
            this.t2StartBtn.TabIndex = 21;
            this.t2StartBtn.UseVisualStyleBackColor = false;
            this.t2StartBtn.Click += new System.EventHandler(this.t2StartBtn_Click);
            // 
            // t3StartBtn
            // 
            this.t3StartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.t3StartBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("t3StartBtn.BackgroundImage")));
            this.t3StartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.t3StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t3StartBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.t3StartBtn.Location = new System.Drawing.Point(734, 180);
            this.t3StartBtn.Name = "t3StartBtn";
            this.t3StartBtn.Size = new System.Drawing.Size(47, 31);
            this.t3StartBtn.TabIndex = 22;
            this.t3StartBtn.UseVisualStyleBackColor = false;
            this.t3StartBtn.Click += new System.EventHandler(this.t3StartBtn_Click);
            // 
            // t3StopBtn
            // 
            this.t3StopBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.t3StopBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("t3StopBtn.BackgroundImage")));
            this.t3StopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.t3StopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t3StopBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.t3StopBtn.Location = new System.Drawing.Point(788, 180);
            this.t3StopBtn.Name = "t3StopBtn";
            this.t3StopBtn.Size = new System.Drawing.Size(47, 31);
            this.t3StopBtn.TabIndex = 25;
            this.t3StopBtn.UseVisualStyleBackColor = false;
            this.t3StopBtn.Click += new System.EventHandler(this.t3StopBtn_Click);
            // 
            // t2StopBtn
            // 
            this.t2StopBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.t2StopBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("t2StopBtn.BackgroundImage")));
            this.t2StopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.t2StopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t2StopBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.t2StopBtn.Location = new System.Drawing.Point(788, 134);
            this.t2StopBtn.Name = "t2StopBtn";
            this.t2StopBtn.Size = new System.Drawing.Size(47, 31);
            this.t2StopBtn.TabIndex = 24;
            this.t2StopBtn.UseVisualStyleBackColor = false;
            this.t2StopBtn.Click += new System.EventHandler(this.t2StopBtn_Click);
            // 
            // t1StopBtn
            // 
            this.t1StopBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.t1StopBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("t1StopBtn.BackgroundImage")));
            this.t1StopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.t1StopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t1StopBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.t1StopBtn.Location = new System.Drawing.Point(788, 88);
            this.t1StopBtn.Name = "t1StopBtn";
            this.t1StopBtn.Size = new System.Drawing.Size(47, 31);
            this.t1StopBtn.TabIndex = 23;
            this.t1StopBtn.UseVisualStyleBackColor = false;
            this.t1StopBtn.Click += new System.EventHandler(this.t1StopBtn_Click);
            // 
            // t1PercentLabel
            // 
            this.t1PercentLabel.AutoSize = true;
            this.t1PercentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.t1PercentLabel.Location = new System.Drawing.Point(841, 97);
            this.t1PercentLabel.Name = "t1PercentLabel";
            this.t1PercentLabel.Size = new System.Drawing.Size(23, 15);
            this.t1PercentLabel.TabIndex = 29;
            this.t1PercentLabel.Text = "0%";
            // 
            // t2PercentLabel
            // 
            this.t2PercentLabel.AutoSize = true;
            this.t2PercentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.t2PercentLabel.Location = new System.Drawing.Point(841, 142);
            this.t2PercentLabel.Name = "t2PercentLabel";
            this.t2PercentLabel.Size = new System.Drawing.Size(23, 15);
            this.t2PercentLabel.TabIndex = 30;
            this.t2PercentLabel.Text = "0%";
            // 
            // t3PercentLabel
            // 
            this.t3PercentLabel.AutoSize = true;
            this.t3PercentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.t3PercentLabel.Location = new System.Drawing.Point(841, 189);
            this.t3PercentLabel.Name = "t3PercentLabel";
            this.t3PercentLabel.Size = new System.Drawing.Size(23, 15);
            this.t3PercentLabel.TabIndex = 31;
            this.t3PercentLabel.Text = "0%";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(283, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 45);
            this.label5.TabIndex = 33;
            this.label5.Text = "Log";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.BackColor = System.Drawing.Color.Black;
            this.logRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRichTextBox.ForeColor = System.Drawing.Color.White;
            this.logRichTextBox.Location = new System.Drawing.Point(400, 386);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.Size = new System.Drawing.Size(464, 45);
            this.logRichTextBox.TabIndex = 35;
            this.logRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(887, 441);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t3PercentLabel);
            this.Controls.Add(this.t2PercentLabel);
            this.Controls.Add(this.t1PercentLabel);
            this.Controls.Add(this.t3StopBtn);
            this.Controls.Add(this.t2StopBtn);
            this.Controls.Add(this.t1StopBtn);
            this.Controls.Add(this.t3StartBtn);
            this.Controls.Add(this.t2StartBtn);
            this.Controls.Add(this.t1StartBtn);
            this.Controls.Add(this.t3SelectName);
            this.Controls.Add(this.t2SelectName);
            this.Controls.Add(this.t1SelectName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileBtn);
            this.Controls.Add(this.engLangBtn);
            this.Controls.Add(this.plLangBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clearFoundBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.foundListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wantedListBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "YTDownloader";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox wantedListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox foundListBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button clearFoundBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button plLangBtn;
        private System.Windows.Forms.Button engLangBtn;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox t1SelectName;
        private System.Windows.Forms.ComboBox t2SelectName;
        private System.Windows.Forms.ComboBox t3SelectName;
        private System.Windows.Forms.Button t1StartBtn;
        private System.Windows.Forms.Button t2StartBtn;
        private System.Windows.Forms.Button t3StartBtn;
        private System.Windows.Forms.Button t3StopBtn;
        private System.Windows.Forms.Button t2StopBtn;
        private System.Windows.Forms.Button t1StopBtn;
        private System.Windows.Forms.Label t1PercentLabel;
        private System.Windows.Forms.Label t2PercentLabel;
        private System.Windows.Forms.Label t3PercentLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox logRichTextBox;
    }
}

