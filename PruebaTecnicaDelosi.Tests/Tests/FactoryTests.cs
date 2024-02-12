using FluentAssertions;
using PruebaTecnicaDelosi.Domain.Factories;
using PruebaTecnicaDelosi.Domain.Factories.Interfaces;
using PruebaTecnicaDelosi.Domain.Handlers;
using PruebaTecnicaDelosi.Domain.Handlers.Interfaces;
using PruebaTecnicaDelosi.Domain.Models;
using Xunit;

namespace PruebaTecnicaDelosi.Tests.Tests;

public class FactoryTests
{
    private readonly Dictionary<MatrixRotation, IRotateMatrixHandler> _handlers;

    public FactoryTests()
    {
        _handlers = new Dictionary<MatrixRotation, IRotateMatrixHandler>
        {
            { MatrixRotation.Clockwise,  new RotateMatrixClockwiseHandler() },
            { MatrixRotation.CounterClockwise, new RotateMatrixCounterClockwiseHandler() }
        };
    }

    [Theory]
    [InlineData(MatrixRotation.Clockwise, typeof(RotateMatrixClockwiseHandler))]
    [InlineData(MatrixRotation.CounterClockwise, typeof(RotateMatrixCounterClockwiseHandler))]
    public void Factory_With_Known_Rotation_Should_Create_Handler(MatrixRotation rotation, Type handlerType)
    {
        IRotateMatrixFactory factory = new RotateMatrixFactory(_handlers);
        var handler = factory.CreateHandler(rotation);
        handler.Should().BeOfType(handlerType);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(101)]
    public void Factory_With_Unknown_Rotation_Should_Not_Create_Handler(int unknownRotation)
    {
        MatrixRotation rotation = (MatrixRotation)unknownRotation;
        IRotateMatrixFactory factory = new RotateMatrixFactory(_handlers);
        var handler = factory.CreateHandler(rotation);
        handler.Should().BeNull();
    }
}
