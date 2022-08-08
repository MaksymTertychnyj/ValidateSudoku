using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateSudoku
{
    public class NotValidSudoku
        : Exception
    {
        public NotValidSudoku(string message)
            : base(message)
        {
        }
    }
}
