using PruebaTecnicaDelosi.Domain.Handlers.Interfaces;
using PruebaTecnicaDelosi.Domain.Models;

namespace PruebaTecnicaDelosi.Domain.Factories.Interfaces;

public interface IRotateMatrixFactory
{
    IRotateMatrixHandler? CreateHandler(MatrixRotation rotation);
}
