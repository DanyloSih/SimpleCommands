namespace SimpleCommands.Extensions
{
    public static class DoubleExtensions
	{
		public static object ToNumericType(this double value, Type numericType)
		{
			return Convert.ChangeType(value, numericType);
		}
	}
}