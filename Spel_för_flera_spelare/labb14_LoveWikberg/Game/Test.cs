using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg.Game
{
    class Test
    {
        public void Board()
        { 
            Console.WriteLine(" ____  ____");
            Console.WriteLine("|    ||    |");                                        
            Console.WriteLine("|  " + ListsAndArrays.Grid[0].NotTurned + "  ||");
            Console.WriteLine("|____||____||____||____||____||____|");
        }
    }
}
