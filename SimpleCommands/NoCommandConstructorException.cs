namespace SimpleCommands
{
	public class NoCommandConstructorException : Exception
	{
		public object CommandObject { get; }

		public NoCommandConstructorException(object commandObject) : base(
			$"The type \"{commandObject.GetType().Name}\" cannot become a command because " + 
			$"it does not have at least one method marked with the \"{nameof(CommandConstructorAttribute)}\" attribute.")
		{
			CommandObject = commandObject;
		}
	}
}

