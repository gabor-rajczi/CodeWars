using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars.ValidateSodoku
{
    class Sudoku
    {
        private readonly int[][] _sudokuData;

        public Sudoku(int[][] sudokuData)
        {
            _sudokuData = sudokuData;
        }

        public bool IsValid()
        {
            var rowCount = _sudokuData.Length;

            var littleSquareRowCount = (int)Math.Sqrt(rowCount);
            if (littleSquareRowCount * littleSquareRowCount != rowCount)
                return false;
            
            for (var i = 0; i < rowCount; i++)
            {
                var columnCount = _sudokuData[i].Length;
                if (rowCount != columnCount)
                    return false;
            }

            for (var i = 0; i < littleSquareRowCount; i++)
            {
                for (var j = 0; j < littleSquareRowCount; j++)
                {
                    if (!GetLittleSudoku(i * littleSquareRowCount, j * littleSquareRowCount, littleSquareRowCount).IsValid())
                        return false;
                }
            }

            return true;
        }

        private LittleSudoku GetLittleSudoku(int row, int column, int size)
        {
            
            var a = new List<int[]>();
            for (var r = row; r < row + size; r++)
            {
                var rowContent = _sudokuData[r];
                var newRowContent = rowContent.Skip(column).Take(size).ToArray();
                a.Add(newRowContent);
            }
            return new LittleSudoku(a.ToArray());
        }
    }

    internal class LittleSudoku
    {
        private readonly int[][] _sudokuData;

        public LittleSudoku(int[][] sudokuData)
        {
            _sudokuData = sudokuData;
        }


        public bool IsValid()
        {
            var content = new List<int>();
            foreach (int[] t in _sudokuData)
            {
                content.AddRange(t);
            }
            if (content.Count != content.Distinct().Count())
                return false;
            if (content.Min() < 1)
                return false;
            if(content.Max()> content.Count)
                return false;
            return true;
        }
    }
}