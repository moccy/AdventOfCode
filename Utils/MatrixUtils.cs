namespace Utils;

public static class MatrixUtils
{
    public static IEnumerable<IEnumerable<T>> Transpose<T>(IEnumerable<IEnumerable<T>> matrix) {
        var enumerators = matrix.Select(e => e.GetEnumerator()).ToArray();
        try
        {
            while (enumerators.All(e => e.MoveNext()))
            {
                yield return enumerators.Select(e => e.Current).ToArray();
            }
        }
        finally
        {
            Array.ForEach(enumerators, e => e.Dispose());
        }
    }
}