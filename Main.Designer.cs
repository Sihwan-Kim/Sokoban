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
            buttonBack = new Button();
            buttonTop = new Button();
            buttonRight = new Button();
            buttonLeft = new Button();
            buttonDown = new Button();
            labelTime = new Label();
            label3 = new Label();
            labelStep = new Label();
            label1 = new Label();
            buttonReset = new Button();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnStart = new Button();
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
            panelGameFiled.Location = new Point(195, 3);
            panelGameFiled.Name = "panelGameFiled";
            panelGameFiled.RowCount = 2;
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelGameFiled.Size = new Size(320, 320);
            panelGameFiled.TabIndex = 5;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBack.Location = new Point(46, 259);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(107, 29);
            buttonBack.TabIndex = 19;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonTop
            // 
            buttonTop.ImageIndex = 3;
            buttonTop.ImageList = imageList1;
            buttonTop.Location = new Point(77, 104);
            buttonTop.Name = "buttonTop";
            buttonTop.Size = new Size(44, 44);
            buttonTop.TabIndex = 18;
            buttonTop.Tag = "0";
            buttonTop.UseVisualStyleBackColor = true;
            buttonTop.Click += DirectionClick;
            // 
            // buttonRight
            // 
            buttonRight.ImageIndex = 2;
            buttonRight.ImageList = imageList1;
            buttonRight.Location = new Point(127, 154);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(44, 44);
            buttonRight.TabIndex = 17;
            buttonRight.Tag = "3";
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += DirectionClick;
            // 
            // buttonLeft
            // 
            buttonLeft.ImageIndex = 1;
            buttonLeft.ImageList = imageList1;
            buttonLeft.Location = new Point(27, 154);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(44, 44);
            buttonLeft.TabIndex = 16;
            buttonLeft.Tag = "2";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += DirectionClick;
            // 
            // buttonDown
            // 
            buttonDown.ImageIndex = 0;
            buttonDown.ImageList = imageList1;
            buttonDown.Location = new Point(77, 154);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(44, 44);
            buttonDown.TabIndex = 15;
            buttonDown.Tag = "1";
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += DirectionClick;
            // 
            // labelTime
            // 
            labelTime.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTime.Location = new Point(77, 64);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(76, 18);
            labelTime.TabIndex = 14;
            labelTime.Text = "00 : 00";
            labelTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 64);
            label3.Name = "label3";
            label3.Size = new Size(53, 18);
            label3.TabIndex = 13;
            label3.Text = "Time :";
            // 
            // labelStep
            // 
            labelStep.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStep.Location = new Point(77, 36);
            labelStep.Name = "labelStep";
            labelStep.Size = new Size(76, 18);
            labelStep.TabIndex = 12;
            labelStep.Text = "0";
            labelStep.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(59, 18);
            label1.TabIndex = 11;
            label1.Text = "Steps :";
            // 
            // buttonReset
            // 
            buttonReset.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonReset.Location = new Point(44, 294);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(109, 29);
            buttonReset.TabIndex = 10;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(-1, 93);
            label2.Name = "label2";
            label2.Size = new Size(195, 1);
            label2.TabIndex = 20;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(0, 211);
            label4.Name = "label4";
            label4.Size = new Size(195, 1);
            label4.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(64, 18);
            label5.TabIndex = 22;
            label5.Text = "Stage : ";
            // 
            // label6
            // 
            label6.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(77, 9);
            label6.Name = "label6";
            label6.Size = new Size(76, 18);
            label6.TabIndex = 23;
            label6.Text = "Level-1";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(44, 224);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(109, 29);
            btnStart.TabIndex = 24;
            btnStart.Text = "Game Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(519, 348);
            Controls.Add(btnStart);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(buttonBack);
            Controls.Add(buttonTop);
            Controls.Add(buttonRight);
            Controls.Add(buttonLeft);
            Controls.Add(buttonDown);
            Controls.Add(labelTime);
            Controls.Add(label3);
            Controls.Add(labelStep);
            Controls.Add(label1);
            Controls.Add(buttonReset);
            Controls.Add(panelGameFiled);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sokoban";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private TableLayoutPanel panelGameFiled;
        private ImageList imageList1;
        private Button buttonBack;
        private Button buttonTop;
        private Button buttonRight;
        private Button buttonLeft;
        private Button buttonDown;
        private Label labelTime;
        private Label label3;
        private Label labelStep;
        private Label label1;
        private Button buttonReset;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnStart;
    }
}
