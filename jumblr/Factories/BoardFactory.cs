using jumblr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Factories
{
    public class BoardFactory
    {
        public Board Get(int size)
        {
            return new Board(size);
        }
    }
}
