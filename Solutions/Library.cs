namespace Solutions;

internal static class MatrixOperator<T>
{
    internal static T[] GetMatrixColumn(T[][] matrix, int column)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
            .Select(row => matrix[row][column])
            .ToArray();
    }

    internal static T[] GetMatrixRow(T[][] matrix, int row)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
            .Select(column => matrix[row][column])
            .ToArray();
    }
}

internal static class InputModifier
{
    // To rectify the silly issues with standard input on different machines...
    internal const string NEWLINEHARDCODED = "\n";
    internal static string NewlineSystem = Environment.NewLine;
    internal const string EMPTYLINEHARDCODED = "\n\n";
    internal static string[] EmptylineSystem = { Environment.NewLine, Environment.NewLine };
}
