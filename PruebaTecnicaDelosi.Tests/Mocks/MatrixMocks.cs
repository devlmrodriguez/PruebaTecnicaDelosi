namespace PruebaTecnicaDelosi.Tests.Mocks;

public class MatrixMocks
{
    public static readonly int[][] EmptyMatrix = Array.Empty<int[]>();

    public static readonly int[][] UnitMatrix =
    {
        new[] { 0 }
    };

    public static readonly int[][] Matrix1 =
    {
        new[] { 1, 2 },
        new[] { 3, 4 },
    };

    public static readonly int[][] Matrix2 =
    {
        new[] { 1, 2, 3 },
        new[] { 4, 5, 6 },
        new[] { 7, 8, 9 },
    };

    public static readonly int[][] RotatedClockwiseMatrix1 =
    {
        new[] { 3, 1 },
        new[] { 4, 2 }
    };

    public static readonly int[][] RotatedClockwiseMatrix2 =
    {
        new[] { 7, 4, 1 },
        new[] { 8, 5, 2 },
        new[] { 9, 6, 3 }
    };

    public static readonly int[][] RotatedCounterClockwiseMatrix1 =
    {
        new[] { 2, 4 },
        new[] { 1, 3 }
    };

    public static readonly int[][] RotatedCounterClockwiseMatrix2 =
    {
        new[] { 3, 6, 9 },
        new[] { 2, 5, 8 },
        new[] { 1, 4, 7 }
    };

    public static readonly string StringEmptyMatrix = "[]";

    public static readonly string StringUnitMatrix = "[[0]]";

    public static readonly string StringMatrix1 = "[[1, 2], [3, 4]]";

    public static readonly string StringMatrix2 = "[[1, 2, 3], [4, 5, 6], [7, 8, 9]]";
}
