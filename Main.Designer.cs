namespace Sokoban
{
    partial class frmMain
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
            if(disposing && (components != null))
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            statusStrip1 = new StatusStrip();
            imageList1 = new ImageList(components);
            panelGameFiled = new TableLayoutPanel();
            btnUndo = new Button();
            labelTime = new Label();
            label3 = new Label();
            labelStep = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            labelLevel = new Label();
            btnStart = new Button();
            menuStrip1 = new MenuStrip();
            fileFToolStripMenuItem = new ToolStripMenuItem();
            openOToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitXToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            labelHighTime = new Label();
            label7 = new Label();
            labelHighStep = new Label();
            label9 = new Label();
            label10 = new Label();
            label6 = new Label();
            label8 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 357);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(519, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Button_Down.png");
            imageList1.Images.SetKeyName(1, "Button_Left.png");
            imageList1.Images.SetKeyName(2, "Button_Right.png");
            imageList1.Images.SetKeyName(3, "Button_Top.png");
            // 
            // panelGameFiled
            // 
            panelGameFiled.BackColor = SystemColors.ActiveCaptionText;
            panelGameFiled.ColumnCount = 2;
            panelGameFiled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelGameFiled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelGameFiled.Location = new Point(194, 32);
            panelGameFiled.Name = "panelGameFiled";
            panelGameFiled.RowCount = 2;
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.Size = new Size(320, 320);
            panelGameFiled.TabIndex = 5;
            // 
            // btnUndo
            // 
            btnUndo.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUndo.Location = new Point(46, 275);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(107, 29);
            btnUndo.TabIndex = 19;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // labelTime
            // 
            labelTime.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            labelTime.Location = new Point(77, 131);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(76, 18);
            labelTime.TabIndex = 14;
            labelTime.Text = "00 : 00";
            labelTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label3.Location = new Point(20, 132);
            label3.Name = "label3";
            label3.Size = new Size(45, 16);
            label3.TabIndex = 13;
            label3.Text = "Time :";
            // 
            // labelStep
            // 
            labelStep.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            labelStep.Location = new Point(77, 103);
            labelStep.Name = "labelStep";
            labelStep.Size = new Size(76, 18);
            labelStep.TabIndex = 12;
            labelStep.Text = "0";
            labelStep.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(53, 16);
            label1.TabIndex = 11;
            label1.Text = "Steps :";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(-1, 159);
            label2.Name = "label2";
            label2.Size = new Size(195, 1);
            label2.TabIndex = 20;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(0, 256);
            label4.Name = "label4";
            label4.Size = new Size(195, 1);
            label4.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label5.Location = new Point(12, 32);
            label5.Name = "label5";
            label5.Size = new Size(58, 16);
            label5.TabIndex = 22;
            label5.Text = "Stage : ";
            // 
            // labelLevel
            // 
            labelLevel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            labelLevel.Location = new Point(77, 32);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(76, 18);
            labelLevel.TabIndex = 23;
            labelLevel.Text = "Level-1";
            labelLevel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(46, 310);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(109, 29);
            btnStart.TabIndex = 24;
            btnStart.Text = "Reset";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileFToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(519, 24);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            fileFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openOToolStripMenuItem, toolStripMenuItem1, exitXToolStripMenuItem });
            fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            fileFToolStripMenuItem.Size = new Size(51, 20);
            fileFToolStripMenuItem.Text = "File(F)";
            // 
            // openOToolStripMenuItem
            // 
            openOToolStripMenuItem.Name = "openOToolStripMenuItem";
            openOToolStripMenuItem.Size = new Size(180, 22);
            openOToolStripMenuItem.Text = "Open(O)";
            openOToolStripMenuItem.Click += openOToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // exitXToolStripMenuItem
            // 
            exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            exitXToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            exitXToolStripMenuItem.Size = new Size(180, 22);
            exitXToolStripMenuItem.Text = "Exit(X)";
            exitXToolStripMenuItem.Click += exitXToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 1);
            panel1.TabIndex = 26;
            // 
            // labelHighTime
            // 
            labelHighTime.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            labelHighTime.ForeColor = Color.Red;
            labelHighTime.Location = new Point(77, 228);
            labelHighTime.Name = "labelHighTime";
            labelHighTime.Size = new Size(76, 18);
            labelHighTime.TabIndex = 30;
            labelHighTime.Text = "00 : 00";
            labelHighTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label7.Location = new Point(20, 229);
            label7.Name = "label7";
            label7.Size = new Size(45, 16);
            label7.TabIndex = 29;
            label7.Text = "Time :";
            // 
            // labelHighStep
            // 
            labelHighStep.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            labelHighStep.ForeColor = Color.Red;
            labelHighStep.Location = new Point(77, 200);
            labelHighStep.Name = "labelHighStep";
            labelHighStep.Size = new Size(76, 18);
            labelHighStep.TabIndex = 28;
            labelHighStep.Text = "0";
            labelHighStep.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label9.Location = new Point(12, 200);
            label9.Name = "label9";
            label9.Size = new Size(53, 16);
            label9.TabIndex = 27;
            label9.Text = "Steps :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label10.Location = new Point(12, 171);
            label10.Name = "label10";
            label10.Size = new Size(76, 16);
            label10.TabIndex = 31;
            label10.Text = "High Score";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            label6.Location = new Point(12, 73);
            label6.Name = "label6";
            label6.Size = new Size(99, 16);
            label6.TabIndex = 32;
            label6.Text = "Present Score";
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(2, 61);
            label8.Name = "label8";
            label8.Size = new Size(189, 1);
            label8.TabIndex = 33;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 379);
            Controls.Add(btnStart);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label10);
            Controls.Add(labelHighTime);
            Controls.Add(label7);
            Controls.Add(labelHighStep);
            Controls.Add(label9);
            Controls.Add(panel1);
            Controls.Add(labelLevel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnUndo);
            Controls.Add(labelTime);
            Controls.Add(label3);
            Controls.Add(labelStep);
            Controls.Add(label1);
            Controls.Add(panelGameFiled);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sokoban";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private TableLayoutPanel panelGameFiled;
        private ImageList imageList1;
        private Button btnUndo;
        private Label labelTime;
        private Label label3;
        private Label labelStep;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label labelLevel;
        private Button btnStart;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileFToolStripMenuItem;
        private ToolStripMenuItem openOToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitXToolStripMenuItem;
        private Panel panel1;
        private Label labelHighTime;
        private Label label7;
        private Label labelHighStep;
        private Label label9;
        private Label label10;
        private Label label6;
        private Label label8;
    }
}
