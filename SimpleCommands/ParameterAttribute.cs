namespace SimpleCommands
{
	/// <summary>
	/// If you add this attribute to a class member, <br/>
	/// this will mean that this variable can be used by command processor.
	/// </summary>
	/// <typeparam name="T">Available types: all basic types, custom classes and structs, enums, arrays, lists, dictionaries. <br/>
	/// All other types will cause exception.</typeparam>
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public class ParameterAttribute : Attribute
	{
		/// <summary>
		/// Name of marked class member for command processor. <br/>
		/// May differ from the actual class member name. 
		/// </summary>
		public string ParameterName { get; }
		/// <summary>
		/// Determines the order in which parameter names will be used in command processor. <br/> 
		/// The less the value, the earlier the parameter will be displayed. <br/>
		/// If the index of several elements is the same, their order will be determined based <br/> 
		/// on their position in the class, priority is given to the top left elements. <br/>
		/// </summary>
		public int OrderID { get; }
		/// <summary>
		/// Determines for the command processor whether it is mandatory to specify a value for this class member.
		/// </summary>
		public bool IsOptional { get; }

		/// <summary>
		/// <inheritdoc cref="ParameterAttribute"/>
		/// </summary>
		/// <param name="parameterName"><inheritdoc cref="ParameterName" path="/summary"/></param>
		/// <param name="isOptional"><inheritdoc cref="IsOptional" path="/summary"/></param>
		/// <param name="orderID"><inheritdoc cref="OrderID" path="/summary"/></param>
		public ParameterAttribute(string parameterName, bool isOptional = false, int orderID = 0)
		{
			ParameterName = parameterName!;
			OrderID = orderID;
			IsOptional = isOptional;
		}
	}
}

