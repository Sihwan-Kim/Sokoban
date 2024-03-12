namespace Sokoban
{
    public partial class frmMain:Form
    {
        public readonly Bitmap[] icons = { Properties.Resources.empty,
                                           Properties.Resources.target,
                                           Properties.Resources.box,
                                           Properties.Resources.box,
                                           Properties.Resources.brick }; 

        public readonly Bitmap[] worker = { Properties.Resources.top,
                                            Properties.Resources.down,
                                            Properties.Resources.left,
                                            Properties.Resources.right };  

        private GamePlay gamePlay;
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
        }
        //----------------------------------------------------------------------------------------
        private void InitDisplayGame()
        {
            for(int x = 0 ; x < panelGameFiled.RowCount ; x++)
            {
                for(int y = 0 ; y < panelGameFiled.ColumnCount ; y++)
                {
                    panelGameFiled.Controls.Add(new PictureBox() { Image = icons[gamePlay.field.fieldArray[x, y]], SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);            
                }
            }

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)).Image = Properties.Resources.down ;
        }
        //----------------------------------------------------------------------------------------
        private void DirectionClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Point rootPosition = gamePlay.field.worker.Position;  // worker가 처음 있던 위치 저장 
            Direction direction = (Direction)int.Parse(button.Tag.ToString());

            gamePlay.moveWorker(direction);
            FieldUpdate(rootPosition, direction);

            if(gamePlay.CheckGameClear())
            {
                MessageBox.Show("This State Cleared", "Information", MessageBoxButtons.OK);
            }
        }
        //----------------------------------------------------------------------------------------
        private void FieldUpdate(Point RootPosition, Direction Direct)
        {
            Point pos1 = RootPosition;
            Point pos2 = RootPosition;

            switch(Direct)
            {
                case Direction.TOP: 
                    pos1.Y -= 1;
                    pos2.Y -= 2;
                    break;
                case Direction.BOTTOM: 
                    pos1.Y += 1;
                    pos2.Y += 2;
                    break;
               case Direction.LEFT: 
                    pos1.X -= 1;
                    pos2.X -= 2;
                    break;
               case Direction.RIGHT: 
                    pos1.X += 1;
                    pos2.X += 2;
                    break;
            }

            int item1 = gamePlay.field.fieldArray[RootPosition.X, RootPosition.Y];
            int item2 = gamePlay.field.fieldArray[pos1.X, pos1.Y];
            int item3 = gamePlay.field.fieldArray[pos2.X, pos2.Y];

            ((PictureBox)panelGameFiled.GetControlFromPosition(RootPosition.X, RootPosition.Y)).Image = icons[item1] ;
            ((PictureBox)panelGameFiled.GetControlFromPosition(pos1.X, pos1.Y)).Image = icons[item2] ;
            ((PictureBox)panelGameFiled.GetControlFromPosition(pos2.X, pos2.Y)).Image = icons[item3] ;

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)).Image = worker[(int)Direct] ;
        }
        //----------------------------------------------------------------------------------------

    }
}
