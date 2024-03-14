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
                                           Properties.Resources.inbox,
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

            makePlayGround(10, 10);                                                  // 10x10 형식의 게임스테이지를 만든다. 
            stageFolder = System.Windows.Forms.Application.StartupPath + "stage\\";  // 게임스테이지가 들어있는 폴더 설정 
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

            panelGameFiled.Width = X * Constants.IconSize;
            panelGameFiled.Height = Y * Constants.IconSize;

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
                    panelGameFiled.Controls.Add(new PictureBox() { Image = Properties.Resources.empty, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                }
            }
        }
        //----------------------------------------------------------------------------------------
        private void displayInitStage()
        {
            for(int y = 0 ; y < panelGameFiled.RowCount ; y++)
            {
                for(int x = 0 ; x < panelGameFiled.ColumnCount ; x++)
                {
                    ((PictureBox)panelGameFiled.GetControlFromPosition(x, y)!).Image = icons[gamePlay.field.fieldArray[x, y]];
                }
            }

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)!).Image = Properties.Resources.down;

            labelLevel.Text = string.Format("Level-{0}", StageNum);
            labelStep.Text = "0";
        }
        //----------------------------------------------------------------------------------------
        private void FieldUpdate(Point RootPosition, bool Undo)
        {
            /*********************************************************
             * 일반적인 이동에서는 최대 3개 픽셀에 변화가 생긴다.
             * Undo 상황에서는 최대 2개 픽셀에 변화가 생긴다. 
             *********************************************************/
            Point pos1 = gamePlay.getChangePosition(0);
            Point pos2 = gamePlay.getChangePosition(1);

            int item1 = gamePlay.field.fieldArray[pos1.X, pos1.Y];
            int item2 = gamePlay.field.fieldArray[pos2.X, pos2.Y];

            ((PictureBox)panelGameFiled.GetControlFromPosition(pos1.X, pos1.Y)!).Image = icons[item1];
            ((PictureBox)panelGameFiled.GetControlFromPosition(pos2.X, pos2.Y)!).Image = icons[item2];

            if(!Undo)
            {
                int item3 = gamePlay.field.fieldArray[RootPosition.X, RootPosition.Y];
                ((PictureBox)panelGameFiled.GetControlFromPosition(RootPosition.X, RootPosition.Y)!).Image = icons[item3];
            }

            ((PictureBox)panelGameFiled.GetControlFromPosition(gamePlay.field.worker.Position.X, gamePlay.field.worker.Position.Y)!).Image = worker[(int)gamePlay.field.worker.MoveDirection];

            labelStep.Text = gamePlay.Steps.ToString();
        }
        //----------------------------------------------------------------------------------------
        private void DirectionClick(object sender, EventArgs e)
        {
            Button? button = sender as Button;

            if(KeyPreview && button is not null)
            {
                var result = WorkerMove((Direction)int.Parse(button.Tag!.ToString()!));

                if(result == DialogResult.Yes) gameStart();
            }
        }
        //----------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)  // 방향키에 대항 이벤트 처리
        {
            if(KeyPreview)
            {
                DialogResult result = DialogResult.No;

                switch(keyData)
                {
                    case Keys.Up: result = WorkerMove(Direction.TOP); break;
                    case Keys.Down: result = WorkerMove(Direction.BOTTOM); break;
                    case Keys.Left: result = WorkerMove(Direction.LEFT); break;
                    case Keys.Right: result = WorkerMove(Direction.RIGHT); break;
                }

                if(result == DialogResult.Yes) gameStart();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //----------------------------------------------------------------------------------------
        private void btnStart_Click(object sender, EventArgs e)
        {
            gameStart();
        }
        //----------------------------------------------------------------------------------------
        private void gameStart()
        {
            var result = gamePlay.field.loadStage(string.Format("{0}level-{1}.txt", stageFolder, StageNum));

            if(result == false) this.KeyPreview = false;
            else
            {
                displayInitStage();
                gamePlay.Start();
                this.KeyPreview = true;
            }
        }
        //----------------------------------------------------------------------------------------
        private void btnUndo_Click(object sender, EventArgs e)
        {
            gamePlay.Undo();
            FieldUpdate(gamePlay.field.worker.Position, true);
        }
        //----------------------------------------------------------------------------------------
        private DialogResult WorkerMove(Direction direction)
        {
            DialogResult result = DialogResult.No;
            Point rootPosition = gamePlay.field.worker.Position;  // worker가 처음 있던 위치 저장 

            gamePlay.moveWorker(direction);
            FieldUpdate(rootPosition, false);  // 화면을 갱신한다. 

            if(gamePlay.CheckStageClear())  // 게임이 완료 되었다.
            {
                gamePlay.Stop();
                result = MessageBox.Show("This Stage Cleared, Play the next stage?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes) StageNum++;  // 다음 스테이지로 넘어간다. 

                this.KeyPreview = false;
            }

            return result;
        }
        //----------------------------------------------------------------------------------------
        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamePlay.Stop();
            Close();
        }
        //----------------------------------------------------------------------------------------
    }
}
