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
            stageFolder = System.Windows.Forms.Application.StartupPath + "stage\\";  // 게임스테이지가 들어있는 폴더 설정 
            makePlayGround(Constants.MapColumnCnt, Constants.MapRowCnt);             // 10x10 형식의 게임스테이지를 만든다. 

            gamePlay = new GamePlay();
            gamePlay.ReturnToTime += new GamePlay.UpdateTimeInform(UpdateTime);

            loadStageNum();     // config 파일에 저장된 스테이지 번호를 불러온다. 

            gameStart();        // 게임을 시작한다. 
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

            gamePlay.loadHighScore(labelLevel.Text);        // 현재 스테이지의 최고 점수를 불러와서 화면에 보여준다.
            labelHighStep.Text = gamePlay.HighSteps.ToString();
            labelHighTime.Text = string.Format("{0:D2}:{1:D2}", gamePlay.HighTimes / 60, gamePlay.HighTimes % 60);
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
            StageNum = 1;            
            gameStart();
        }
        //----------------------------------------------------------------------------------------
        private void gameStart()
        {
            var result = gamePlay.field.loadStage(string.Format("{0}level-{1}.txt", stageFolder, StageNum));

            if(result == false)
            {
                this.KeyPreview = false;
                MessageBox.Show("All games have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                gamePlay.saveHighScore(labelLevel.Text);
                result = MessageBox.Show("This Stage Cleared, Play the next stage?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes) StageNum++;  // 다음 스테이지로 넘어간다. 

                this.KeyPreview = false;
            }

            return result;
        }
        //----------------------------------------------------------------------------------------
        public void saveStageNum()
        {
            Utilities.IniFile iniFile = new Utilities.IniFile("Config.ini");

            iniFile.WriteValue("Sokoban", "Stage Number", StageNum);
        }
        //----------------------------------------------------------------------------------------
        public void loadStageNum()
        {
            Utilities.IniFile iniFile = new Utilities.IniFile("Config.ini");

            StageNum = iniFile.GetInt32("Sokoban", "Stage Number", 1);
        }
        //----------------------------------------------------------------------------------------
        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Would you like to save the current state and exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) saveStageNum();
            
            gamePlay.Stop();
            Close();            
        }
        //----------------------------------------------------------------------------------------
    }
}
