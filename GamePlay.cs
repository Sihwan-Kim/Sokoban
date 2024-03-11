using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    internal class GamePlay
    {
        public Field field = new Field();
        public int Steps {  get; set; }
        public int Times { get; set; }  // unit = sec 

        public GamePlay()
        {
            Steps = 0;
            Times = 0;
        }
    }
}
