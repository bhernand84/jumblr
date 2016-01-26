using jumblr.Factories;
using jumblr.Models;
using jumblr.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var tileFactory = new TileFactory();
            var tile = tileFactory.GetTile();
            bool isActive = true;
            printMenu();
            while (isActive)
            {
                printTile(tile);
                var input = Console.ReadLine();
                if (input.ToUpper() == "Q")
                {
                    isActive = false;
                    break;
                }
                
                try{
                    Direction direction = stringConverter[input.ToUpper()];
                    tile.Rotate(direction);
                }
                catch{
                    Console.WriteLine("unidentified input");
                }
            }
        }

        static void printMenu()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("L = left");
            Console.WriteLine("R = right");
            Console.WriteLine("U = up");
            Console.WriteLine("D = down");
            Console.WriteLine("Q = quit");
            Console.WriteLine("****************************");
        }

        static void printTile(Tile tile)
        {
            Console.WriteLine("     {0}", tile.Letters[(int)TilePosition.Top]);
            Console.WriteLine(" {0} [ {1} ] {2} ", tile.Letters[(int)TilePosition.Left],tile.Letters[(int)TilePosition.Center], tile.Letters[(int)TilePosition.Right]);
            Console.WriteLine("     {0}", tile.Letters[(int)TilePosition.Bottom]);            
        }
        static Dictionary<string, Direction> stringConverter = new Dictionary<string,Direction>(){
            {"L",Direction.Left},
            {"R", Direction.Right},
            {"U", Direction.Up},
            {"D", Direction.Down}
        };
        
    }
}
