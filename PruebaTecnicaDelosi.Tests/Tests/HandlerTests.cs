using FluentAssertions;
using PruebaTecnicaDelosi.Domain.Handlers;
using PruebaTecnicaDelosi.Domain.Handlers.Interfaces;
using PruebaTecnicaDelosi.Tests.Mocks;
using Xunit;

namespace PruebaTecnicaDelosi.Tests.Tests;

public class HandlerTests
{
    public static TheoryData<int[][], int[][]> TestCases1 => new()
    {
        { MatrixMocks.Matrix1, MatrixMocks.RotatedClockwiseMatrix1 },
        { MatrixMocks.Matrix2, MatrixMocks.RotatedClockwiseMatrix2 }
    };

    [Theory]
    [MemberData(nameof(TestCases1))]
    public void Handler_Should_Rotate_Clockwise(int[][] matrix, int[][] rotatedMatrix)
    {
        IRotateMatrixHandler handler = new RotateMatrixClockwiseHandler();
        var actualMatrix = handler.Rotate(matrix);

        actualMatrix.Should().BeEquivalentTo(rotatedMatrix, options => options.WithStrictOrdering());
    }

    public static TheoryData<int[][], int[][]> TestCases2 => new()
    {
        { MatrixMocks.Matrix1, MatrixMocks.RotatedCounterClockwiseMatrix1 },
        { MatrixMocks.Matrix2, MatrixMocks.RotatedCounterClockwiseMatrix2 }
    };

    [Theory]
    [MemberData(nameof(TestCases2))]
    public void Handler_Should_Rotate_Counter_Clockwise(int[][] matrix, int[][] rotatedMatrix)
    {
        IRotateMatrixHandler handler = new RotateMatrixCounterClockwiseHandler();
        var actualMatrix = handler.Rotate(matrix);

        actualMatrix.Should().BeEquivalentTo(rotatedMatrix, options => options.WithStrictOrdering());
    }
}
