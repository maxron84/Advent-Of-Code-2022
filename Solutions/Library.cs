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
