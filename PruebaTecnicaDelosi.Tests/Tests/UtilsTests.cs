using FluentAssertions;
using PruebaTecnicaDelosi.Domain.Shared;
using PruebaTecnicaDelosi.Tests.Mocks;
using Xunit;

namespace PruebaTecnicaDelosi.Tests.Tests;

public class UtilsTests
{
    public static TheoryData<int[][], string> TestCases => new()
    {
        { MatrixMocks.EmptyMatrix, MatrixMocks.StringEmptyMatrix },
        { MatrixMocks.UnitMatrix, MatrixMocks.StringUnitMatrix },
        { MatrixMocks.Matrix1, MatrixMocks.StringMatrix1 },
        { MatrixMocks.Matrix2, MatrixMocks.StringMatrix2 }
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Should_Convert_Matrix_Array_To_String(int[][] matrix, string stringMatrix)
    {
        var actualResult = Utils.ArrayToString(matrix);
        actualResult.Should().Be(stringMatrix);
    }
}
