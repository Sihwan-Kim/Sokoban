namespace Sokoban
{
    public partial class frmMain:Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            panelGameFiled.RowCount = 10;
            panelGameFiled.ColumnCount = 10;

            panelGameFiled.Width = 10 * 32;
            panelGameFiled.Height = 10 * 32;

            for(int i = 0 ; i < panelGameFiled.ColumnCount ; i++)
            {
                panelGameFiled.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.AutoSize });
            }

            for(int i = 0 ; i < panelGameFiled.RowCount ; i++)
            {
                panelGameFiled.RowStyles.Add(new RowStyle() { SizeType = SizeType.AutoSize });
            }

            for(int y = 0; y<panelGameFiled.RowCount; y++) 
            {
                for(int x = 0; x<panelGameFiled.ColumnCount; x++) 
                {
                    panelGameFiled.Controls.Add(new PictureBox() { Image = Properties.Resources.Box, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                }
            }

            //((PictureBox)panelGameFiled.GetControlFromPosition(0, 0)).Image = Properties.Resources.Box;
        }
        //----------------------------------------------------------------------------------------

    }
}
