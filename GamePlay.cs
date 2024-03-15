using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    internal class GamePlay
    {
        public delegate void UpdateTimeInform(string time);
        public event UpdateTimeInform? ReturnToTime;

        public Field field = new Field();
        public int Steps { get; set; }
        public int Times { get; set; }  // unit = sec 

        private System.Timers.Timer timer = new System.Timers.Timer();  
        private Stack<UndoInform> undoInforms = new Stack<UndoInform>();    // 이동정보를 저장하기위한 스택(Undo 기능에 사용)

        private Point[] changePosition = new Point[2] ;  // 이동 정보가 변경된 위치 
        //----------------------------------------------------------------------------------------
        public GamePlay()
        {
            Steps = 0;
            Times = 0;

            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }
        //----------------------------------------------------------------------------------------
        public Point getChangePosition(int index)
        {
            return changePosition[index];
        }
        //----------------------------------------------------------------------------------------
        private void timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Times++;            
            ReturnToTime!(string.Format("{0:D2}:{1:D2}", Times/60, Times%60));
        }
        //----------------------------------------------------------------------------------------
        public void Start()
        {
            Times = 0;
            Steps = 0;

            timer.Start();
            undoInforms.Clear();
        }
        //----------------------------------------------------------------------------------------
        public void Stop()
        {
            timer.Stop();
        }
        //----------------------------------------------------------------------------------------
        public bool CheckStageClear()
        {
            bool result = true;

            foreach(var value in field.fieldArray)
            {
                if(value == Constants.Store)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
        //----------------------------------------------------------------------------------------
        public void moveWorker(Direction direction)
        {
            Point movePosition = new Point(field.worker.Position.X, field.worker.Position.Y);   // worker가 이동해야 할 위치 
            Point otherPosition = new Point(field.worker.Position.X, field.worker.Position.Y);  // worker가 이동한 위치의 다음위치 

            field.worker.MoveDirection = direction;  // worker 의 방향전환
 
            switch(direction)    // 이동방향에 따라 worker의 위치와 그 다음위치를 계산한다.
            {
                case Direction.TOP:
                    movePosition.Y--;
                    otherPosition.Y = movePosition.Y - 1;
                    break;
                case Direction.BOTTOM:
                    movePosition.Y++;
                    otherPosition.Y = movePosition.Y + 1;
                    break;
                case Direction.LEFT:                    
                    movePosition.X--;
                    otherPosition.X = movePosition.X - 1;
                    break;
                case Direction.RIGHT:
                    movePosition.X++;
                    otherPosition.X = movePosition.X + 1;
                    break;
            }

            var obj = checkCanMove(movePosition, direction);  // 이동해야할 위치로 이동할 수 있는지 확인한다.(이동위치의 객체를 리턴받는다.)          

            if(obj >= 0) // 이동 가능할 경우 
            {
                field.worker.Position = movePosition;       // worker의 위치를 이동

                if(obj == Constants.Box)
                {
                    field.fieldArray[movePosition.X, movePosition.Y] &= 0x0d ;  // worker가 이동해야 할 위치를 원래 객체로 변경한다.(& 0x0d :박스가 있었다면 제거한다)  
                    field.fieldArray[otherPosition.X, otherPosition.Y] |= obj; // worker가 이동해야할 위치의 박스를 다음위치로 이동한다.               
                }

                undoInforms.Push(new UndoInform(direction, obj == Constants.Box));  // undo 정보를 스텍에 저장

                changePosition[0] = movePosition;
                changePosition[1] = otherPosition;
            }
        }
        //----------------------------------------------------------------------------------------
        public void Undo()
        {
            if(undoInforms.Count > 0)
            { 
                var inform = undoInforms.Pop();

                Point boxPosition = new Point(field.worker.Position.X, field.worker.Position.Y);   // 박스가 원래 있었던 위치 
                Point currentPosition = new Point(field.worker.Position.X, field.worker.Position.Y);   // 박스의 현재 위치 

                switch(inform.direction)    // 이동방향에 따라 worker와 Box 이동 위치 
                {
                    case Direction.TOP:
                        field.worker.Position.Y++;
                        currentPosition.Y--;
                        break;
                    case Direction.BOTTOM:
                        field.worker.Position.Y--;
                        currentPosition.Y++;
                        break;
                    case Direction.LEFT:                    
                        field.worker.Position.X++;
                        currentPosition.X--;
                        break;
                    case Direction.RIGHT:
                        field.worker.Position.X--;
                        currentPosition.X++;
                        break;
                }

                if(inform.pushInform)  // 이전에 박스를 이동했다면 
                {
                    field.fieldArray[currentPosition.X, currentPosition.Y] &= 0x0d;  // 박스가 있던 위치의 초기화
                    field.fieldArray[boxPosition.X, boxPosition.Y] |= Constants.Box; // 원래 박스가 있던 위치에 박스를 옮긴다.
                }

                changePosition[0] = boxPosition;
                changePosition[1] = currentPosition;
                field.worker.MoveDirection = inform.direction;
                Steps--;
            }
        }
        //----------------------------------------------------------------------------------------
        private int checkCanMove(Point Position, Direction Direct)  // 이동하고자 하는 위치의 이동가능 여부 판단
        {
            int result = -1;
            var obj = field.fieldArray[Position.X, Position.Y];     // Worker 가 이동해야 할 위치의 객체는??

            if(obj == Constants.Wall) result = -1;                                  // 벽이 있을 경우 이동하지 못한다. 
            else if(obj == Constants.Road || obj == Constants.Store) result = obj;  // 도로나 창고만 있을 경우 해당위치로 이동할 수 있다. 
            else                                                                    // 박스가 있을 경우 
            {
                switch(Direct)          // Worker 의 이동방향에 따른 박스 다음 위치
                {
                    case Direction.TOP: Position.Y--; break;
                    case Direction.BOTTOM : Position.Y++; break;
                    case Direction.LEFT: Position.X--; break;
                    case Direction.RIGHT: Position.X++; break;
                }

                obj = field.fieldArray[Position.X, Position.Y];

                if(obj == Constants.Road || obj == Constants.Store) result = Constants.Box;  // 박스 건너편이 비어 있으면 이동할 수 있다. 
            }

            if(result > -1) Steps++;

            return result;
        }
        //----------------------------------------------------------------------------------------
    }
}
