namespace extraCell.view
{
    partial class SearchForm
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
            this.searchQueryInputBox = new System.Windows.Forms.TextBox();
            this.szukajButton = new System.Windows.Forms.Button();
            this.nastepnyButton = new System.Windows.Forms.Button();
            this.poprzedniButton = new System.Windows.Forms.Button();
            this.opcjeGroupBox = new System.Windows.Forms.GroupBox();
            this.caleWyrazyCheck = new System.Windows.Forms.CheckBox();
            this.wielkoscZnakowCheck = new System.Windows.Forms.CheckBox();
            this.opcjeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchQueryInputBox
            // 
            this.searchQueryInputBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchQueryInputBox.Location = new System.Drawing.Point(12, 12);
            this.searchQueryInputBox.Name = "searchQueryInputBox";
            this.searchQueryInputBox.Size = new System.Drawing.Size(201, 20);
            this.searchQueryInputBox.TabIndex = 0;
            this.searchQueryInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchQueryInputBox_KeyPress);
            // 
            // szukajButton
            // 
            this.szukajButton.Location = new System.Drawing.Point(219, 10);
            this.szukajButton.Name = "szukajButton";
            this.szukajButton.Size = new System.Drawing.Size(75, 23);
            this.szukajButton.TabIndex = 1;
            this.szukajButton.Text = "Szukaj";
            this.szukajButton.UseVisualStyleBackColor = true;
            this.szukajButton.Click += new System.EventHandler(this.szukajButton_Click);
            // 
            // nastepnyButton
            // 
            this.nastepnyButton.Enabled = false;
            this.nastepnyButton.Location = new System.Drawing.Point(219, 48);
            this.nastepnyButton.Name = "nastepnyButton";
            this.nastepnyButton.Size = new System.Drawing.Size(75, 23);
            this.nastepnyButton.TabIndex = 3;
            this.nastepnyButton.Text = "Następny";
            this.nastepnyButton.UseVisualStyleBackColor = true;
            this.nastepnyButton.Click += new System.EventHandler(this.nastepnyButton_Click);
            // 
            // poprzedniButton
            // 
            this.poprzedniButton.Enabled = false;
            this.poprzedniButton.Location = new System.Drawing.Point(219, 77);
            this.poprzedniButton.Name = "poprzedniButton";
            this.poprzedniButton.Size = new System.Drawing.Size(75, 23);
            this.poprzedniButton.TabIndex = 4;
            this.poprzedniButton.Text = "Poprzedni";
            this.poprzedniButton.UseVisualStyleBackColor = true;
            this.poprzedniButton.Click += new System.EventHandler(this.poprzedniButton_Click);
            // 
            // opcjeGroupBox
            // 
            this.opcjeGroupBox.Controls.Add(this.caleWyrazyCheck);
            this.opcjeGroupBox.Controls.Add(this.wielkoscZnakowCheck);
            this.opcjeGroupBox.Location = new System.Drawing.Point(13, 39);
            this.opcjeGroupBox.Name = "opcjeGroupBox";
            this.opcjeGroupBox.Size = new System.Drawing.Size(200, 67);
            this.opcjeGroupBox.TabIndex = 2;
            this.opcjeGroupBox.TabStop = false;
            this.opcjeGroupBox.Text = "Opcje wyszukiwania";
            // 
            // caleWyrazyCheck
            // 
            this.caleWyrazyCheck.AutoSize = true;
            this.caleWyrazyCheck.Location = new System.Drawing.Point(7, 44);
            this.caleWyrazyCheck.Name = "caleWyrazyCheck";
            this.caleWyrazyCheck.Size = new System.Drawing.Size(168, 17);
            this.caleWyrazyCheck.TabIndex = 1;
            this.caleWyrazyCheck.Text = "Uwzględniaj tylko całe wyrazy";
            this.caleWyrazyCheck.UseVisualStyleBackColor = true;
            // 
            // wielkoscZnakowCheck
            // 
            this.wielkoscZnakowCheck.AutoSize = true;
            this.wielkoscZnakowCheck.Location = new System.Drawing.Point(7, 20);
            this.wielkoscZnakowCheck.Name = "wielkoscZnakowCheck";
            this.wielkoscZnakowCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.wielkoscZnakowCheck.Size = new System.Drawing.Size(167, 17);
            this.wielkoscZnakowCheck.TabIndex = 0;
            this.wielkoscZnakowCheck.Text = "Uwzględniaj wielkość znaków";
            this.wielkoscZnakowCheck.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 112);
            this.Controls.Add(this.opcjeGroupBox);
            this.Controls.Add(this.poprzedniButton);
            this.Controls.Add(this.nastepnyButton);
            this.Controls.Add(this.szukajButton);
            this.Controls.Add(this.searchQueryInputBox);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "test";
            this.opcjeGroupBox.ResumeLayout(false);
            this.opcjeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchQueryInputBox;
        private System.Windows.Forms.Button szukajButton;
        private System.Windows.Forms.Button nastepnyButton;
        private System.Windows.Forms.Button poprzedniButton;
        private System.Windows.Forms.GroupBox opcjeGroupBox;
        private System.Windows.Forms.CheckBox caleWyrazyCheck;
        private System.Windows.Forms.CheckBox wielkoscZnakowCheck;
    }
}