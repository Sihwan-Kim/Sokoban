using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    internal class GamePlay
    {
        public readonly Bitmap[] icons = {Properties.Resources.Empty,   // 0
                                          Properties.Resources.brick,   // 1 
                                          Properties.Resources.Box,     // 2
                                          Properties.Resources.target,  // 3  
                                          Properties.Resources.Empty,   // 4 
                                          Properties.Resources.Empty,   // 5
                                          Properties.Resources.front};  // 6

        public Field field = new Field();
        public int Steps {  get; set; }
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
                if(value == Constants.VoidTarget)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
