using Microsoft.Extensions.Logging;
using PruebaTecnicaDelosi.Domain.Factories.Interfaces;
using PruebaTecnicaDelosi.Domain.Models;
using PruebaTecnicaDelosi.Domain.Services.Interfaces;
using PruebaTecnicaDelosi.Domain.Shared;

namespace PruebaTecnicaDelosi.Domain.Services;

public class RotateMatrixService : IRotateMatrixService
{
    private readonly IRotateMatrixFactory _factory;
    private readonly ILogger<IRotateMatrixService> _logger;

    public RotateMatrixService(IRotateMatrixFactory factory, ILogger<IRotateMatrixService> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public int[][] Rotate(int[][] matrix, MatrixRotation rotation)
    {
        _logger.LogInformation("Rotating {Rotation}: {Matrix}", rotation, Utils.ArrayToString(matrix));
        var rotationHandler = _factory.CreateHandler(rotation) ?? throw new InvalidOperationException("Invalid rotation");
        var rotatedMatrix = rotationHandler.Rotate(matrix);
        _logger.LogInformation("Result: {RotatedMatrix}", Utils.ArrayToString(rotatedMatrix));
        return rotatedMatrix;
    }
}
