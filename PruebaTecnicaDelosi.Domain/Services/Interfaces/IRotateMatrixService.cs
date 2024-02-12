using PruebaTecnicaDelosi.Domain.Models;

namespace PruebaTecnicaDelosi.Domain.Services.Interfaces;

public interface IRotateMatrixService
{
    int[][] Rotate(int[][] matrix, MatrixRotation rotation);
}
