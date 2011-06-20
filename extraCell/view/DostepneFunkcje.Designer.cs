namespace extraCell.view
{
    partial class DostepneFunkcje
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
            this.listaFunkcjiBox = new System.Windows.Forms.ListBox();
            this.tabki = new System.Windows.Forms.TabControl();
            this.opisTab = new System.Windows.Forms.TabPage();
            this.przykladyTab = new System.Windows.Forms.TabPage();
            this.przykladyLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.opisLabel = new System.Windows.Forms.Label();
            this.tabki.SuspendLayout();
            this.opisTab.SuspendLayout();
            this.przykladyTab.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaFunkcjiBox
            // 
            this.listaFunkcjiBox.FormattingEnabled = true;
            this.listaFunkcjiBox.Location = new System.Drawing.Point(12, 12);
            this.listaFunkcjiBox.Name = "listaFunkcjiBox";
            this.listaFunkcjiBox.Size = new System.Drawing.Size(157, 199);
            this.listaFunkcjiBox.TabIndex = 0;
            this.listaFunkcjiBox.SelectedIndexChanged += new System.EventHandler(this.listaFunkcjiBox_SelectedIndexChanged);
            // 
            // tabki
            // 
            this.tabki.Controls.Add(this.opisTab);
            this.tabki.Controls.Add(this.przykladyTab);
            this.tabki.Location = new System.Drawing.Point(175, 12);
            this.tabki.Name = "tabki";
            this.tabki.SelectedIndex = 0;
            this.tabki.Size = new System.Drawing.Size(358, 199);
            this.tabki.TabIndex = 1;
            // 
            // opisTab
            // 
            this.opisTab.Controls.Add(this.flowLayoutPanel2);
            this.opisTab.Location = new System.Drawing.Point(4, 22);
            this.opisTab.Name = "opisTab";
            this.opisTab.Padding = new System.Windows.Forms.Padding(3);
            this.opisTab.Size = new System.Drawing.Size(350, 173);
            this.opisTab.TabIndex = 0;
            this.opisTab.Text = "Opis";
            this.opisTab.UseVisualStyleBackColor = true;
            // 
            // przykladyTab
            // 
            this.przykladyTab.Controls.Add(this.flowLayoutPanel1);
            this.przykladyTab.Location = new System.Drawing.Point(4, 22);
            this.przykladyTab.Name = "przykladyTab";
            this.przykladyTab.Padding = new System.Windows.Forms.Padding(3);
            this.przykladyTab.Size = new System.Drawing.Size(350, 173);
            this.przykladyTab.TabIndex = 1;
            this.przykladyTab.Text = "Przykłady";
            this.przykladyTab.UseVisualStyleBackColor = true;
            // 
            // przykladyLabel
            // 
            this.przykladyLabel.AutoSize = true;
            this.przykladyLabel.Location = new System.Drawing.Point(3, 0);
            this.przykladyLabel.Name = "przykladyLabel";
            this.przykladyLabel.Size = new System.Drawing.Size(200, 13);
            this.przykladyLabel.TabIndex = 0;
            this.przykladyLabel.Text = "Wybierz funkcję aby zobaczyć przykłady";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.przykladyLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(338, 161);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.opisLabel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(338, 164);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // opisLabel
            // 
            this.opisLabel.AutoSize = true;
            this.opisLabel.Location = new System.Drawing.Point(3, 0);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size(188, 13);
            this.opisLabel.TabIndex = 0;
            this.opisLabel.Text = "Wybierz funkcję aby wyświetlić pomoc";
            // 
            // DostepneFunkcje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 228);
            this.Controls.Add(this.tabki);
            this.Controls.Add(this.listaFunkcjiBox);
            this.Name = "DostepneFunkcje";
            this.Text = "DostepneFunkcje";
            this.Load += new System.EventHandler(this.DostepneFunkcje_Load);
            this.tabki.ResumeLayout(false);
            this.opisTab.ResumeLayout(false);
            this.przykladyTab.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaFunkcjiBox;
        private System.Windows.Forms.TabControl tabki;
        private System.Windows.Forms.TabPage opisTab;
        private System.Windows.Forms.TabPage przykladyTab;
        private System.Windows.Forms.Label przykladyLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label opisLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}