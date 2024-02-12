namespace PruebaTecnicaDelosi.Domain.Shared;

public static class Utils
{
    public static string ArrayToString(int[][] array)
    {
        return "[" + string.Join(", ", array.Select(row => "[" + string.Join(", ", row) + "]")) + "]";
    }
}
