using System;
using System.Threading;

public class MatrixSum
{
    private readonly int[,] _matrix;
    private readonly int[] _rowSums;
    private readonly Barrier _barrier;
    private int _finalSum;

    public MatrixSum(int[,] matrix)
    {
        _matrix = matrix;
        int rowCount = matrix.GetLength(0);
        _rowSums = new int[rowCount];

        
        _barrier = new Barrier(rowCount, (b) =>
        {
            _finalSum = 0;
            foreach (var sum in _rowSums)
            {
                _finalSum += sum;
            }
        });
    }

    public int ComputeTotalSum()
    {
        int rowCount = _matrix.GetLength(0);
        Thread[] threads = new Thread[rowCount];

        for (int i = 0; i < rowCount; i++)
        {
            int rowIndex = i; 
            threads[i] = new Thread(() => ComputeRowSum(rowIndex));
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join(); 
        }

        return _finalSum;
    }

    private void ComputeRowSum(int row)
    {
        int sum = 0;
        int columnCount = _matrix.GetLength(1);

        for (int j = 0; j < columnCount; j++)
        {
            sum += _matrix[row, j];
        }

        _rowSums[row] = sum;

        _barrier.SignalAndWait(); 
    }
}
public class Program
{
    public static void Main()
    {
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 3 }
        };

        var summer = new MatrixSum(matrix);
        int total = summer.ComputeTotalSum();

        Console.WriteLine("The sum of all matrix elements: " + total);
    }
}
