using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    internal class GamePlay
    {
        public readonly Bitmap[] icons = {Properties.Resources.empty,   // 0
                                          Properties.Resources.brick,   // 1 
                                          Properties.Resources.box,     // 2
                                          Properties.Resources.target,  // 3  
                                          Properties.Resources.empty,   // 4 
                                          Properties.Resources.box,     // 5
                                          Properties.Resources.down,
                                          Properties.Resources.top,
                                          Properties.Resources.left,
                                          Properties.Resources.right};  

        public Field field = new Field();
        public int Steps { get; set; }
        public int Times { get; set; }  // unit = sec 
        //----------------------------------------------------------------------------------------
        public GamePlay()
        {
            Steps = 0;
            Times = 0;
        }
        //----------------------------------------------------------------------------------------
        public bool CheckGameClear()
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
            Point movePosition = new Point(field.worker.Position.X, field.worker.Position.Y);   // worker의 이동 위치
            Point otherPosition = new Point(field.worker.Position.X, field.worker.Position.Y);  // worker 이동 다음 위치 

            field.worker.MoveDirection = direction;  // worker 의 방향전환
            field.fieldArray[field.worker.Position.X, field.worker.Position.Y] = Constants.Road; // worker 가 있던 위치의 초기화

            switch(direction)    // 이동방향에 따라 worker의 이동 위치 
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

            var obj = checkCanMove(movePosition, direction);            

            if(obj >= 0) // 이동 가능할 경우 
            {
                field.worker.Position = movePosition;
                if(obj == Constants.Box) field.fieldArray[otherPosition.X, otherPosition.Y] = obj + Constants.Road; // worker 가 이동해야할 위치의 박스를 다음위치로 이동한다. 
                field.fieldArray[movePosition.X, movePosition.Y] &= 0x0d ;  // worker 가 이동해야 할 위치를 원래 객체로 변경한다.  
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

            return result;
        }
        //----------------------------------------------------------------------------------------
    }
}
