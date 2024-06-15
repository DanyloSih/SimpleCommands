namespace SimpleCommands
{
    public class SameParameterNamesException : Exception
	{
		public Type CommandObjectType { get; }
		public string ParametersName { get; }

		public SameParameterNamesException(Type commandObjectType, string parametersName) : base(
			$"There is at least two parameters with the same name: \"{parametersName}\" in command object " + 
			$"with type \"{commandObjectType.Name}\", which is unacceptable.")
		{
			CommandObjectType = commandObjectType;
			ParametersName = parametersName;
		}
	}
}

