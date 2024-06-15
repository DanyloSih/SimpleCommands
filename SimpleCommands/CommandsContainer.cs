namespace SimpleCommands
{
    public class CommandsContainer
	{
		private List<object> _registeredCommands = new List<object>();
		private Dictionary<string, Type> _aliasAndCommandTypeAssociations = new Dictionary<string,Type>();
		
		/// <summary>
		/// Checks if the object matches the conditions of the correct command and then adds it to the list of registered commands.
		/// </summary>
		public void RegisterCommand(object commandObject, string commandAlias)
		{
						
		}
		
		/// <summary>
		/// Removes command object from the registered commands list.
		/// </summary>
		public void UnregisterCommand(object commandObject)
		{
			
		}
		
		public bool IsCommandExist(string commandAlias)
		{
			throw new NotImplementedException();
		}
		
		public Type GetCommandType(string commandAlias)
		{
			throw new NotImplementedException();
		}		
	}
}

