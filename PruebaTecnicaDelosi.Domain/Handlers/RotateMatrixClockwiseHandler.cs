using PruebaTecnicaDelosi.Domain.Handlers.Interfaces;

namespace PruebaTecnicaDelosi.Domain.Handlers;

public class RotateMatrixClockwiseHandler : IRotateMatrixHandler
{
    public int[][] Rotate(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        // Transpose the matrix
        int[][] transposedMatrix = new int[cols][];
        for (int i = 0; i < cols; i++)
        {
            transposedMatrix[i] = new int[rows];
            for (int j = 0; j < rows; j++)
            {
                transposedMatrix[i][j] = matrix[j][i];
            }
        }

        // Reverse each row to get clockwise rotation
        for (int i = 0; i < cols; i++)
        {
            Array.Reverse(transposedMatrix[i]);
        }

        return transposedMatrix;
    }
}
