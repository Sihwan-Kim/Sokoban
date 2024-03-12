namespace Sokoban
{
    public partial class frmMain:Form
    {
        GamePlay gamePlay;
        public frmMain()
        {
            InitializeComponent();

            gamePlay = new GamePlay();
            makePlayGround(10, 10);
        }
        //----------------------------------------------------------------------------------------
        private void makePlayGround(int x, int y)
        {
            panelGameFiled.RowCount = x;
            panelGameFiled.ColumnCount = y;

            panelGameFiled.Width = x * 32;
            panelGameFiled.Height = y * 32;

            for(int i = 0 ; i < panelGameFiled.ColumnCount ; i++)
            {
                panelGameFiled.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.AutoSize });
            }

            for(int i = 0 ; i < panelGameFiled.RowCount ; i++)
            {
                panelGameFiled.RowStyles.Add(new RowStyle() { SizeType = SizeType.AutoSize });
            }
        }
        //----------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            InitDisplayGame();
            //((PictureBox)panelGameFiled.GetControlFromPosition(0, 0)).Image = Properties.Resources.Box;
        }
        //----------------------------------------------------------------------------------------
        private void InitDisplayGame()
        {
            for(int x = 0 ; x < panelGameFiled.RowCount ; x++)
            {
                for(int y = 0 ; y < panelGameFiled.ColumnCount ; y++)
                {
                    switch(gamePlay.field.fieldArray[x, y])
                    {
                        case 0x00: 
                            panelGameFiled.Controls.Add(new PictureBox() { Image = Properties.Resources.empty, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                            break;
                        case 0x01: 
                            panelGameFiled.Controls.Add(new PictureBox() { Image = Properties.Resources.target, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                            break;
                        case 0x02: 
                            panelGameFiled.Controls.Add(new PictureBox() { Image = Properties.Resources.box, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                            break;
                        case 0x08: 
                            panelGameFiled.Controls.Add(new PictureBox() { Image = Properties.Resources.brick, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                            break;
                    }                    
                }
            }

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)).Image = Properties.Resources.down ;
        }
        //----------------------------------------------------------------------------------------
        private void DirectionClick(object sender, EventArgs e)
        {
            Button direction = (Button)sender;

            switch (direction.Tag.ToString())
            {
                case "6":
                    break;
                case "7":
                    break;
                case "8": 
                    gamePlay.moveWorker(Direction.LEFT);
                    break;
                case "9":
                    gamePlay.moveWorker(Direction.RIGHT);
                    break;
            }
        }
        //----------------------------------------------------------------------------------------

    }
}
