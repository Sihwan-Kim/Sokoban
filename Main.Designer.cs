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
            statusStrip1 = new StatusStrip();
            panel1 = new Panel();
            button1 = new Button();
            panelGameFiled = new TableLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 371);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(624, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 371);
            panel1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(50, 29);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelGameFiled
            // 
            panelGameFiled.ColumnCount = 2;
            panelGameFiled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelGameFiled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelGameFiled.Dock = DockStyle.Fill;
            panelGameFiled.Location = new Point(193, 0);
            panelGameFiled.Name = "panelGameFiled";
            panelGameFiled.RowCount = 2;
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.Size = new Size(431, 371);
            panelGameFiled.TabIndex = 5;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(624, 393);
            Controls.Add(panelGameFiled);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sokoban";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private Panel panel1;
        private TableLayoutPanel panelGameFiled;
        private Button button1;
    }
}
