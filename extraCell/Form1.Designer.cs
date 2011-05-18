using extraCell.view;

namespace extraCell
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NowyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otworzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZapiszStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.drukujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjscieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopiujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wytnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wklejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czcionkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.komorkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szukajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noweOknoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozmiescToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filesTab = new System.Windows.Forms.TabControl();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.formulaInputBox = new System.Windows.Forms.TextBox();
            this.obliczButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.edycjaToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.szukajToolStripMenuItem,
            this.oknaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NowyStripMenuItem,
            this.otworzToolStripMenuItem,
            this.ZapiszStripMenuItem,
            this.zamknijToolStripMenuItem,
            this.toolStripSeparator1,
            this.drukujToolStripMenuItem,
            this.toolStripSeparator2,
            this.ustawieniaToolStripMenuItem,
            this.wyjscieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // NowyStripMenuItem
            // 
            this.NowyStripMenuItem.Name = "NowyStripMenuItem";
            this.NowyStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NowyStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.NowyStripMenuItem.Text = "Nowy";
            this.NowyStripMenuItem.Click += new System.EventHandler(this.NowyStripMenuItem_Click);
            // 
            // otworzToolStripMenuItem
            // 
            this.otworzToolStripMenuItem.Name = "otworzToolStripMenuItem";
            this.otworzToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.otworzToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.otworzToolStripMenuItem.Text = "Otwórz";
            this.otworzToolStripMenuItem.Click += new System.EventHandler(this.otworzToolStripMenuItem_Click);
            // 
            // ZapiszStripMenuItem
            // 
            this.ZapiszStripMenuItem.Name = "ZapiszStripMenuItem";
            this.ZapiszStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.ZapiszStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZapiszStripMenuItem.Text = "Zapisz";
            this.ZapiszStripMenuItem.Click += new System.EventHandler(this.ZapiszStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // drukujToolStripMenuItem
            // 
            this.drukujToolStripMenuItem.Name = "drukujToolStripMenuItem";
            this.drukujToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.drukujToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.drukujToolStripMenuItem.Text = "Drukuj";
            this.drukujToolStripMenuItem.Click += new System.EventHandler(this.drukujToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // wyjscieToolStripMenuItem
            // 
            this.wyjscieToolStripMenuItem.Name = "wyjscieToolStripMenuItem";
            this.wyjscieToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.wyjscieToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.wyjscieToolStripMenuItem.Text = "Wyjście";
            this.wyjscieToolStripMenuItem.Click += new System.EventHandler(this.wyjscieToolStripMenuItem_Click);
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopiujToolStripMenuItem,
            this.wytnijToolStripMenuItem,
            this.wklejToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // kopiujToolStripMenuItem
            // 
            this.kopiujToolStripMenuItem.Name = "kopiujToolStripMenuItem";
            this.kopiujToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.kopiujToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.kopiujToolStripMenuItem.Text = "Kopiuj";
            this.kopiujToolStripMenuItem.Click += new System.EventHandler(this.kopiujToolStripMenuItem_Click);
            // 
            // wytnijToolStripMenuItem
            // 
            this.wytnijToolStripMenuItem.Name = "wytnijToolStripMenuItem";
            this.wytnijToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.wytnijToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.wytnijToolStripMenuItem.Text = "Wytnij";
            this.wytnijToolStripMenuItem.Click += new System.EventHandler(this.wytnijToolStripMenuItem_Click);
            // 
            // wklejToolStripMenuItem
            // 
            this.wklejToolStripMenuItem.Name = "wklejToolStripMenuItem";
            this.wklejToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.wklejToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.wklejToolStripMenuItem.Text = "Wklej";
            this.wklejToolStripMenuItem.Click += new System.EventHandler(this.wklejToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czcionkaToolStripMenuItem,
            this.komorkaToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // czcionkaToolStripMenuItem
            // 
            this.czcionkaToolStripMenuItem.Name = "czcionkaToolStripMenuItem";
            this.czcionkaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.czcionkaToolStripMenuItem.Text = "Czcionka";
            this.czcionkaToolStripMenuItem.Click += new System.EventHandler(this.czcionkaToolStripMenuItem_Click);
            // 
            // komorkaToolStripMenuItem
            // 
            this.komorkaToolStripMenuItem.Name = "komorkaToolStripMenuItem";
            this.komorkaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.komorkaToolStripMenuItem.Text = "Komórka";
            // 
            // szukajToolStripMenuItem
            // 
            this.szukajToolStripMenuItem.Name = "szukajToolStripMenuItem";
            this.szukajToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.szukajToolStripMenuItem.Text = "Szukaj";
            // 
            // oknaToolStripMenuItem
            // 
            this.oknaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noweOknoToolStripMenuItem,
            this.rozmiescToolStripMenuItem,
            this.toolStripSeparator3});
            this.oknaToolStripMenuItem.Name = "oknaToolStripMenuItem";
            this.oknaToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.oknaToolStripMenuItem.Text = "Okna";
            // 
            // noweOknoToolStripMenuItem
            // 
            this.noweOknoToolStripMenuItem.Name = "noweOknoToolStripMenuItem";
            this.noweOknoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.noweOknoToolStripMenuItem.Text = "Nowe Okno";
            this.noweOknoToolStripMenuItem.Click += new System.EventHandler(this.noweOknoToolStripMenuItem_Click);
            // 
            // rozmiescToolStripMenuItem
            // 
            this.rozmiescToolStripMenuItem.Name = "rozmiescToolStripMenuItem";
            this.rozmiescToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.rozmiescToolStripMenuItem.Text = "Rozmieść";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
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
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 302);
            this.panel1.TabIndex = 3;
            // 
            // filesTab
            // 
            this.filesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTab.Location = new System.Drawing.Point(0, 0);
            this.filesTab.Name = "filesTab";
            this.filesTab.SelectedIndex = 0;
            this.filesTab.Size = new System.Drawing.Size(566, 302);
            this.filesTab.TabIndex = 0;
            this.filesTab.SelectedIndexChanged += new System.EventHandler(this.filesTab_SelectedIndexChanged);
            this.filesTab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filesTab_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kolor tekstu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Kolor tła";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // formulaInputBox
            // 
            this.formulaInputBox.Location = new System.Drawing.Point(181, 45);
            this.formulaInputBox.Name = "formulaInputBox";
            this.formulaInputBox.Size = new System.Drawing.Size(292, 20);
            this.formulaInputBox.TabIndex = 6;
            this.formulaInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formulaInputBox_KeyPress);
            // 
            // obliczButton
            // 
            this.obliczButton.Location = new System.Drawing.Point(479, 45);
            this.obliczButton.Name = "obliczButton";
            this.obliczButton.Size = new System.Drawing.Size(75, 23);
            this.obliczButton.TabIndex = 7;
            this.obliczButton.Text = "Oblicz";
            this.obliczButton.UseVisualStyleBackColor = true;
            this.obliczButton.Click += new System.EventHandler(this.obliczButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 396);
            this.Controls.Add(this.obliczButton);
            this.Controls.Add(this.formulaInputBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ExtraCell";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otworzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem drukujToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem wyjscieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopiujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wytnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wklejToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czcionkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem komorkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szukajToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem oknaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noweOknoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozmiescToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem NowyStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZapiszStripMenuItem;
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
        private System.Windows.Forms.TextBox formulaInputBox;
        private System.Windows.Forms.Button obliczButton;
   
        
    }
}

