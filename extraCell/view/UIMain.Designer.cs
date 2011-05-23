using extraCell.view;

namespace extraCell
{
    partial class UIMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filesTab = new System.Windows.Forms.TabControl();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.textColorButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backColorButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(566, 48);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 374);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(566, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.filesTab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 326);
            this.panel1.TabIndex = 3;
            // 
            // filesTab
            // 
            this.filesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTab.Location = new System.Drawing.Point(0, 0);
            this.filesTab.Name = "filesTab";
            this.filesTab.SelectedIndex = 0;
            this.filesTab.Size = new System.Drawing.Size(566, 326);
            this.filesTab.TabIndex = 0;
            this.filesTab.SelectedIndexChanged += new System.EventHandler(this.filesTab_SelectedIndexChanged);
            this.filesTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.filesTab_Selected);
            this.filesTab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filesTab_MouseClick);
            // 
            // textColorButton
            // 
            this.textColorButton.Location = new System.Drawing.Point(283, 6);
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.Size = new System.Drawing.Size(82, 41);
            this.textColorButton.TabIndex = 4;
            this.textColorButton.Text = "Kolor tekstu";
            this.textColorButton.UseVisualStyleBackColor = true;
            this.textColorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // backColorButton
            // 
            this.backColorButton.Location = new System.Drawing.Point(182, 6);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(75, 42);
            this.backColorButton.TabIndex = 5;
            this.backColorButton.Text = "Kolor tła";
            this.backColorButton.UseVisualStyleBackColor = true;
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // UIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 396);
            this.Controls.Add(this.backColorButton);
            this.Controls.Add(this.textColorButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UIMain";
            this.Text = "ExtraCell";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button backColorButton;
        private System.Windows.Forms.TabControl filesTab;
        /*private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn101;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn102;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn103;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn104;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn105;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn106;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn107;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn108;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn109;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn110;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn111;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn112;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn113;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn114;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn115;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn116;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn117;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn118;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn119;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn120;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn121;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn122;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn123;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn124;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn125;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn126;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn127;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn128;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn129;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn130;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn131;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn132;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn133;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn134;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn135;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn136;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn137;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn138;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn139;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn140;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn141;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn142;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn143;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn144;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn145;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn146;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn147;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn148;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn149;
        private ExtraCellTable.DataGridViewTextBoxCustomCellColumn dataGridViewTextBoxCustomCellColumn150;*/
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
   
        
    }
}

