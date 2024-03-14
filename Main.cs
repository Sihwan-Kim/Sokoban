using Windows.Devices.Display.Core;
using Windows.Gaming.Input;

namespace Sokoban
{
    public partial class frmMain:Form
    {
        private int StageNum = 1;
        private readonly string stageFolder;

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
            gamePlay.ReturnToTime += new GamePlay.UpdateTimeInform(UpdateTime);

            makePlayGround(10, 10);

            stageFolder = System.Windows.Forms.Application.StartupPath + "stage\\" ;            
        }
        //----------------------------------------------------------------------------------------
        private void UpdateTime(string TimeInform)
        {
            this.Invoke(new Action(() => { labelTime.Text = TimeInform; }));
        }
        //----------------------------------------------------------------------------------------
        private void makePlayGround(int X, int Y)
        {
            panelGameFiled.RowCount = X;
            panelGameFiled.ColumnCount = Y;

            panelGameFiled.Width = X * 32;
            panelGameFiled.Height = Y * 32;

            for(int i = 0 ; i < panelGameFiled.ColumnCount ; i++)
            {
                panelGameFiled.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.AutoSize });
            }

            for(int i = 0 ; i < panelGameFiled.RowCount ; i++)
            {
                panelGameFiled.RowStyles.Add(new RowStyle() { SizeType = SizeType.AutoSize });
            }

            for(int y = 0 ; y < panelGameFiled.RowCount ; y++)
            {
                for(int x = 0 ; x < panelGameFiled.ColumnCount ; x++)
                {
                    panelGameFiled.Controls.Add(new PictureBox() { Image = icons[gamePlay.field.fieldArray[x, y]], SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                }
            }
        }
        //----------------------------------------------------------------------------------------
        private void displayStage()
        {
            for(int y = 0 ; y < panelGameFiled.RowCount ; y++)
            {
                for(int x = 0 ; x < panelGameFiled.ColumnCount ; x++)
                {
                    ((PictureBox)panelGameFiled.GetControlFromPosition(x, y)!).Image = icons[gamePlay.field.fieldArray[x, y]];
                }
            }

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)!).Image = Properties.Resources.down;
        }
        //----------------------------------------------------------------------------------------
        private void FieldUpdate(Point RootPosition)
        {
            Point pos1 = RootPosition;
            Point pos2 = RootPosition;

            switch(gamePlay.field.worker.MoveDirection)
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

            ((PictureBox)panelGameFiled.GetControlFromPosition(RootPosition.X, RootPosition.Y)!).Image = icons[item1];
            ((PictureBox)panelGameFiled.GetControlFromPosition(pos1.X, pos1.Y)!).Image = icons[item2];

            if(pos2.X >= 0 && pos2.X < 10 && pos2.Y >= 0 && pos2.Y < 10)
            {
                int item3 = gamePlay.field.fieldArray[pos2.X, pos2.Y];
                ((PictureBox)panelGameFiled.GetControlFromPosition(pos2.X, pos2.Y)!).Image = icons[item3];
            }

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)!).Image = worker[(int)gamePlay.field.worker.MoveDirection];

            labelStep.Text = gamePlay.Steps.ToString();
            labelTime.Text = gamePlay.Times.ToString();
        }
        //----------------------------------------------------------------------------------------
        private void DirectionClick(object sender, EventArgs e)
        {
            Button? button = sender as Button;

            if(button is not null)
            {
                WorkerMove((Direction)int.Parse(button.Tag!.ToString()!));
            }
        }
        //----------------------------------------------------------------------------------------
        private void buttonReset_Click(object sender, EventArgs e)
        {
        }
        //----------------------------------------------------------------------------------------
        private void buttonBack_Click(object sender, EventArgs e)
        {

        }
        //----------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Up: WorkerMove(Direction.TOP); break;
                case Keys.Down: WorkerMove(Direction.BOTTOM); break;
                case Keys.Left: WorkerMove(Direction.LEFT); break;
                case Keys.Right: WorkerMove(Direction.RIGHT); break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //----------------------------------------------------------------------------------------
        private void WorkerMove(Direction direction)
        {
            Point rootPosition = gamePlay.field.worker.Position;  // worker가 처음 있던 위치 저장 

            gamePlay.moveWorker(direction);
            FieldUpdate(rootPosition);

            if(gamePlay.CheckStageClear())
            {
                gamePlay.Stop();
                MessageBox.Show("This Stage Cleared", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StageNum++;  // 다음 스테이지로 넘어간다. 
            }
        }
        //----------------------------------------------------------------------------------------
        private void btnStart_Click(object sender, EventArgs e)
        {
            gamePlay.field.loadStage(string.Format("{0}level-{1}.txt",stageFolder, StageNum));
            displayStage();
            gamePlay.Start();
        }
        //----------------------------------------------------------------------------------------
    }
}
