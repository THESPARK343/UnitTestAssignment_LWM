using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace GFXsys
{
    internal class CellularGFX
    {        
        /// <summary>
        /// The Conversions are as follows;;
        /// Keyword|| Effect
        /// 0  :: black 
        /// 1  :: white 
        /// 2  :: blue
        /// 3  :: green
        /// 4  :: yellow
        /// 5  :: red
        /// 6  :: grey
        /// 7  :: dark grey
        /// 8  :: dark yellow
        /// !  :: Next line
        /// these are the rules for the system
        /// Must have a Space between each keyword
        /// Must be entirely lowercase
        /// you basically send a string to the function and it uses the string as a line of consecutive commands to execute
        /// each keyword causes one cell of its respective colour to be printed to console, using a period will send you the the next row
        /// 
        /// for example :
        /// 
        /// string argument = "red white red . white white white . red white red .";
        /// CellularGFX.GridProcGFX(argument);
        /// 
        /// this will output a 3x3 picture of a white plus with red corners
        /// </summary>
        static void CellCLRGFX(string CellCLR)
        {
          
            // Black
            if (CellCLR == "0" || CellCLR == "black")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // White
            if (CellCLR == "1" || CellCLR == "white")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Blue
            if (CellCLR == "2" || CellCLR == "blue")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Green
            if (CellCLR == "3" || CellCLR == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Yellow
            if (CellCLR == "4" || CellCLR == "yellow")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Red
            if (CellCLR == "5" || CellCLR == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Grey
            if (CellCLR == "6" || CellCLR == "grey")
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Dark Grey
            if (CellCLR == "7" || CellCLR == "dgrey")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (CellCLR == "8" || CellCLR == "dyellow")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (CellCLR == "9" || CellCLR == "dgreen")
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (CellCLR == "A")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  ");
                
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("  ");
               
               Console.BackgroundColor = ConsoleColor.DarkGreen;
               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.Write("  ");
            }
            // Next Line
            if (CellCLR =="!")
            {
                Console.Write("\n");
            }
        }
        public static void GridProcGFX(string ValueGFX, int FMR, int Pos1, int Pos2)
        {
            int RnTime = 0;
            string[] CellA = ValueGFX.Split('.');
            while (RnTime < FMR)
            {
                Console.SetCursorPosition(Pos1, Pos2);
                foreach (string Cell in CellA)
                {
                    
                    CellCLRGFX(Cell);
                    RnTime = RnTime + 1;
                }
            }
        }
    }
}
