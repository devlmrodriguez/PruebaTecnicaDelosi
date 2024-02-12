using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PruebaTecnicaDelosi.Domain.Factories.Interfaces;
using PruebaTecnicaDelosi.Domain.Handlers;
using PruebaTecnicaDelosi.Domain.Models;
using PruebaTecnicaDelosi.Domain.Services;
using PruebaTecnicaDelosi.Domain.Services.Interfaces;
using PruebaTecnicaDelosi.Tests.Mocks;
using Xunit;

namespace PruebaTecnicaDelosi.Tests.Tests;

public class ServiceTests
{
    private readonly Mock<IRotateMatrixFactory> _mockFactory;
    private readonly Mock<ILogger<IRotateMatrixService>> _mockLogger;

    public ServiceTests()
    {
        _mockFactory = new Mock<IRotateMatrixFactory>();
        _mockFactory.Setup(x => x.CreateHandler(MatrixRotation.Clockwise)).Returns(new RotateMatrixClockwiseHandler());
        _mockFactory.Setup(x => x.CreateHandler(MatrixRotation.CounterClockwise)).Returns(new RotateMatrixCounterClockwiseHandler());
        _mockFactory.Setup(x => x.CreateHandler(It.IsNotIn(MatrixRotation.Clockwise, MatrixRotation.CounterClockwise))).Returns(() => null);

        _mockLogger = new Mock<ILogger<IRotateMatrixService>>();
    }

    public static TheoryData<MatrixRotation, int[][], int[][]> TestCases => new()
    {
        { MatrixRotation.Clockwise, MatrixMocks.Matrix1, MatrixMocks.RotatedClockwiseMatrix1 },
        { MatrixRotation.Clockwise, MatrixMocks.Matrix2, MatrixMocks.RotatedClockwiseMatrix2 },
        { MatrixRotation.CounterClockwise, MatrixMocks.Matrix1, MatrixMocks.RotatedCounterClockwiseMatrix1 },
        { MatrixRotation.CounterClockwise, MatrixMocks.Matrix2, MatrixMocks.RotatedCounterClockwiseMatrix2 }
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Service_Wit_Known_Rotation_Should_Return_Rotated_Matrix(MatrixRotation rotation, int[][] matrix, int[][] rotatedMatrix)
    {
        IRotateMatrixService service = new RotateMatrixService(_mockFactory.Object, _mockLogger.Object);
        var actualMatrix = service.Rotate(matrix, rotation);

        actualMatrix.Should().BeEquivalentTo(rotatedMatrix, options => options.WithStrictOrdering());
    }

    [Theory]
    [InlineData(100)]
    [InlineData(101)]
    public void Service_With_Unknown_Rotation_Should_Throw_Exception(int unknownRotation)
    {
        MatrixRotation rotation = (MatrixRotation)unknownRotation;
        IRotateMatrixService service = new RotateMatrixService(_mockFactory.Object, _mockLogger.Object);

        Action act = () => service.Rotate(Array.Empty<int[]>(), rotation);
        act.Should().Throw<InvalidOperationException>();
    }
}
