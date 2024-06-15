namespace SimpleCommands
{
	/// <summary>
	/// Allows command processor to use the marked method as a command constructor.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class CommandConstructorAttribute : DescriptionAttribute
	{
		public CommandConstructorAttribute()
		{
		}

		public CommandConstructorAttribute(string description) : base(description)
		{
		}
    }
}

