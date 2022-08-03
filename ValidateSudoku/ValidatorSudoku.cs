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

        public ValidatorSudoku(Array data)
        {
            Data = data as int[,];
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
                throw new NotValidateSudokuException("The array can not be null");
            }
        }

        private void ToValidateArrayDimention()
        {
            var nx = Data!.GetLength(0);
            var ny = Data.GetLength(1);
            if (nx == ny && nx > 1 && Math.Sqrt(nx) % 1 == 0)
            {
            }
            else
            {
                throw new NotValidateSudokuException("The data structure dimension should be: NxN where N > 1 and √N == integer");
            }
        }

        private void ToValidateSmallSquaresDimention()
        {
            var nx = Math.Sqrt(Data!.GetLength(0));
            var ny = Math.Sqrt(Data.GetLength(1));
            if (nx == ny)
            {
            }
            else
            {
                throw new NotValidateSudokuException("Small squares should be √Nx√N");
            }
        }

        private void ToValidateUniqueInRow()
        {
            List<int> rowData = new List<int>();
            for (int i = 0; i< Data!.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    rowData.Add(Data[i, j]);
                }

                if (rowData.Distinct().Count() != rowData.Count())
                    throw new NotValidateSudokuException($"A number in multi-dimensional array may only appear once in a single row. The error was occured in {i+1}'s row");
                rowData.Clear();
            }
        }

        private void ToValidateUniqueInColumn()
        {
            List<int> columnData = new List<int>();
            for (int j = 0; j< Data!.GetLength(1); j++)
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    columnData.Add(Data[i, j]);
                }

                if (columnData.Distinct().Count() != columnData.Count())
                    throw new NotValidateSudokuException($"A number in multi-dimensional array may only appear once in a single column. The error was occured in {j + 1}'s column");
                columnData.Clear();
            }
        }

        private void ToValidateUniqueInSmallSquares()
        {
            List<int> squareData = new List<int>();
            int n = (int)Math.Sqrt(Data!.GetLength(0));
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        for (int x = 0; x < n; x++)
                        {
                            squareData.Add(Data[i*n+y, j*n+x]);
                        }
                    }

                    if (squareData.Distinct().Count() != squareData.Count())
                        throw new NotValidateSudokuException("A number in multi-dimensional array may only appear once in the Small square");
                    squareData.Clear();
                }
            }
        }
    }
}
