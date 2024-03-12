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
            panel1 = new Panel();
            buttonBack = new Button();
            buttonTop = new Button();
            imageList1 = new ImageList(components);
            buttonRight = new Button();
            buttonLeft = new Button();
            buttonDown = new Button();
            label2 = new Label();
            label3 = new Label();
            labelStep = new Label();
            label1 = new Label();
            buttonReset = new Button();
            panelGameFiled = new TableLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 326);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(519, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(buttonBack);
            panel1.Controls.Add(buttonTop);
            panel1.Controls.Add(buttonRight);
            panel1.Controls.Add(buttonLeft);
            panel1.Controls.Add(buttonDown);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(labelStep);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonReset);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 326);
            panel1.TabIndex = 4;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBack.Location = new Point(14, 278);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(75, 29);
            buttonBack.TabIndex = 9;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonTop
            // 
            buttonTop.ImageIndex = 3;
            buttonTop.ImageList = imageList1;
            buttonTop.Location = new Point(73, 110);
            buttonTop.Name = "buttonTop";
            buttonTop.Size = new Size(44, 44);
            buttonTop.TabIndex = 8;
            buttonTop.Tag = "6";
            buttonTop.UseVisualStyleBackColor = true;
            buttonTop.Click += DirectionClick;
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
            // buttonRight
            // 
            buttonRight.ImageIndex = 2;
            buttonRight.ImageList = imageList1;
            buttonRight.Location = new Point(123, 160);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(44, 44);
            buttonRight.TabIndex = 7;
            buttonRight.Tag = "9";
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += DirectionClick;
            // 
            // buttonLeft
            // 
            buttonLeft.ImageIndex = 1;
            buttonLeft.ImageList = imageList1;
            buttonLeft.Location = new Point(23, 160);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(44, 44);
            buttonLeft.TabIndex = 6;
            buttonLeft.Tag = "8";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += DirectionClick;
            // 
            // buttonDown
            // 
            buttonDown.ImageIndex = 0;
            buttonDown.ImageList = imageList1;
            buttonDown.Location = new Point(73, 160);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(44, 44);
            buttonDown.TabIndex = 5;
            buttonDown.Tag = "7";
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += DirectionClick;
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(73, 69);
            label2.Name = "label2";
            label2.Size = new Size(99, 18);
            label2.TabIndex = 4;
            label2.Text = "00 : 00 : 00";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 69);
            label3.Name = "label3";
            label3.Size = new Size(53, 18);
            label3.TabIndex = 3;
            label3.Text = "Time :";
            // 
            // labelStep
            // 
            labelStep.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStep.Location = new Point(73, 41);
            labelStep.Name = "labelStep";
            labelStep.Size = new Size(99, 18);
            labelStep.TabIndex = 2;
            labelStep.Text = "0";
            labelStep.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 41);
            label1.Name = "label1";
            label1.Size = new Size(59, 18);
            label1.TabIndex = 1;
            label1.Text = "Steps :";
            // 
            // buttonReset
            // 
            buttonReset.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonReset.Location = new Point(97, 278);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(75, 29);
            buttonReset.TabIndex = 0;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += button1_Click;
            // 
            // panelGameFiled
            // 
            panelGameFiled.BackColor = SystemColors.ActiveCaptionText;
            panelGameFiled.ColumnCount = 2;
            panelGameFiled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelGameFiled.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelGameFiled.Location = new Point(195, 3);
            panelGameFiled.Name = "panelGameFiled";
            panelGameFiled.RowCount = 2;
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.Size = new Size(320, 320);
            panelGameFiled.TabIndex = 5;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(519, 348);
            Controls.Add(panelGameFiled);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sokoban";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private Panel panel1;
        private TableLayoutPanel panelGameFiled;
        private Button buttonReset;
        private Label label1;
        private Label labelStep;
        private Label label2;
        private Label label3;
        private Button buttonTop;
        private ImageList imageList1;
        private Button buttonRight;
        private Button buttonLeft;
        private Button buttonDown;
        private Button buttonBack;
    }
}
