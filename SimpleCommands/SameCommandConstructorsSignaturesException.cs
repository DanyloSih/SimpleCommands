using System.Reflection;

namespace SimpleCommands
{
	public class SameCommandConstructorsSignaturesException : Exception
	{
		public SameCommandConstructorsSignaturesException(Type commandObjectType, MethodInfo methodA, MethodInfo methodB) : base(
			$"There is at least two methods with the same signature in command object " + 
			$"with type \"{commandObjectType.Name}\", which is unacceptable. " + 
			$"First method name is: \"{methodA.Name}\", seccond method name is: \"{methodB.Name}\". " + 
			$"Important!!!, the command processor considers all numeric types as one type: " + 
			"(byte = sbyte = short = ushort = int = uint = long = ulong = float = double = decimal)")
		{
			
		}
	}
}

