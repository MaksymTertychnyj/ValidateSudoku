using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateSudoku
{
    public class ValidatorSudoku
    {
        public int[,]? Data { get; set; }
        private int n; 

        public ValidatorSudoku(Array data)
        {
            Data = data as int[,];
            n = (int)Math.Sqrt(Data!.GetLength(0));
        }
        public void ToValidateSudoku()
        {
            if (Data != null)
            {
                ToValidateArrayDimention();
                ToValidateSmallSquaresDimention();
                ToValidateUniqueInRow();
                ToValidateUniqueInColumn();
                ToValidateUniqueInSmallSquares();
            }
            else
            {
                throw new NotValidSudoku("The array can not be null");
            }
        }

        private void ToValidateArrayDimention()
        {
            var nx = Data!.GetLength(0);
            var ny = Data.GetLength(1);
            if (nx == ny && nx > 1 && Math.Sqrt(nx) % 1 == 0)
            {
                return;
            }
            else
            {
                throw new NotValidSudoku("The data structure dimension should be: NxN where N > 1 and √N == integer");
            }
        }

        private void ToValidateSmallSquaresDimention()
        {
            var nx = Math.Sqrt(Data!.GetLength(0));
            var ny = Math.Sqrt(Data.GetLength(1));
            if (nx == ny)
            {
                return;
            }
            else
            {
                throw new NotValidSudoku("Small squares should be √Nx√N");
            }
        }

        private void ToValidateUniqueInRow()
        {
            List<int> rowData = new ();
            for (int i = 0; i< Data!.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    rowData.Add(Data[i, j]);
                }

                if (rowData.Distinct().Count() != rowData.Count())
                {
                    throw new NotValidSudoku($"A number in multi-dimensional array may only appear once in a single row. The error was occured in {i+1}'s row");
                }

                rowData.Clear();
            }
        }

        private void ToValidateUniqueInColumn()
        {
            List<int> columnData = new ();
            for (int j = 0; j< Data!.GetLength(1); j++)
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    columnData.Add(Data[i, j]);
                }

                if (columnData.Distinct().Count() != columnData.Count())
                {
                    throw new NotValidSudoku($"A number in multi-dimensional array may only appear once in a single column. The error was occured in {j + 1}'s column");
                }
                columnData.Clear();
            }
        }

        private void ToValidateUniqueInSmallSquares()
        {
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    var smallSquarElements = GetElementsOfSmallSquar(i, j);
                    if (smallSquarElements.Distinct().Count() != smallSquarElements.Count())
                    {
                        throw new NotValidSudoku("A number in multi-dimensional array may only appear once in the Small square");
                    }
                    smallSquarElements.Clear();
                }
            }
        }

        private List<int> GetElementsOfSmallSquar(int i, int j)
        {
            List<int> squareData = new();

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    squareData.Add(Data![i * n + y, j * n + x]);
                }
            }

            return squareData;
        }
    }
}
