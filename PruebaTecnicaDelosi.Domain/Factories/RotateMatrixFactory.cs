using PruebaTecnicaDelosi.Domain.Factories.Interfaces;
using PruebaTecnicaDelosi.Domain.Handlers.Interfaces;
using PruebaTecnicaDelosi.Domain.Models;

namespace PruebaTecnicaDelosi.Domain.Factories;

public class RotateMatrixFactory : IRotateMatrixFactory
{
    private readonly Dictionary<MatrixRotation, IRotateMatrixHandler> _handlers;

    public RotateMatrixFactory(Dictionary<MatrixRotation, IRotateMatrixHandler> handlers)
    {
        _handlers = handlers;
    }

    public IRotateMatrixHandler? CreateHandler(MatrixRotation rotation)
    {
        if (_handlers.TryGetValue(rotation, out var handler))
        {
            return handler;
        }

        return null;
    }
}
