namespace BaiduPanLGET
{
    partial class Main
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
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlText = new System.Windows.Forms.TextBox();
            this.ResultBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dlText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.md5Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filenameText = new System.Windows.Forms.TextBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.getButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 25);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(38, 13);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL : ";
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(56, 22);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(404, 20);
            this.urlText.TabIndex = 1;
            // 
            // ResultBox
            // 
            this.ResultBox.Controls.Add(this.label3);
            this.ResultBox.Controls.Add(this.button1);
            this.ResultBox.Controls.Add(this.dlText);
            this.ResultBox.Controls.Add(this.label2);
            this.ResultBox.Controls.Add(this.md5Text);
            this.ResultBox.Controls.Add(this.label1);
            this.ResultBox.Controls.Add(this.filenameText);
            this.ResultBox.Controls.Add(this.filenameLabel);
            this.ResultBox.Location = new System.Drawing.Point(15, 61);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(455, 120);
            this.ResultBox.TabIndex = 2;
            this.ResultBox.TabStop = false;
            this.ResultBox.Text = "Result";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dlText
            // 
            this.dlText.Location = new System.Drawing.Point(100, 66);
            this.dlText.Name = "dlText";
            this.dlText.ReadOnly = true;
            this.dlText.Size = new System.Drawing.Size(260, 20);
            this.dlText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Download Link : ";
            // 
            // md5Text
            // 
            this.md5Text.Location = new System.Drawing.Point(100, 43);
            this.md5Text.Name = "md5Text";
            this.md5Text.ReadOnly = true;
            this.md5Text.Size = new System.Drawing.Size(260, 20);
            this.md5Text.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MD5 : ";
            // 
            // filenameText
            // 
            this.filenameText.Location = new System.Drawing.Point(100, 17);
            this.filenameText.Name = "filenameText";
            this.filenameText.ReadOnly = true;
            this.filenameText.Size = new System.Drawing.Size(260, 20);
            this.filenameText.TabIndex = 1;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(7, 20);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(63, 13);
            this.filenameLabel.TabIndex = 0;
            this.filenameLabel.Text = "File Name : ";
            // 
            // getButton
            // 
            this.getButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.getButton.Location = new System.Drawing.Point(0, 187);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(472, 23);
            this.getButton.TabIndex = 3;
            this.getButton.Text = "Get Link!";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Processing............";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 210);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.urlText);
            this.Controls.Add(this.urlLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "BaiduPanLGET";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResultBox.ResumeLayout(false);
            this.ResultBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.GroupBox ResultBox;
        private System.Windows.Forms.TextBox filenameText;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.TextBox dlText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox md5Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
    }
}

