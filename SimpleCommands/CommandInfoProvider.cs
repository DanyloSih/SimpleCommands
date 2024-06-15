using System.Reflection;

namespace SimpleCommands
{
	public static class CommandInfoProvider
	{
		public static void CheckIsCommandObjectCorrect(object commandObject)
		{
			if (commandObject == null)
			{
				throw new ArgumentNullException("Command object cannot be null!");
			}
			
			Type commandObjectType = commandObject.GetType();
			
			List<MethodInfo> availableMethods = GetAvailableConstructors(commandObjectType);
			
			if(TryGetCommandConstructorsWithSameSignatures(availableMethods, out var constructorsWithSameSignatures))
			{
				throw new SameCommandConstructorsSignaturesException(
					commandObjectType, constructorsWithSameSignatures.Item1, constructorsWithSameSignatures.Item2);
			}
			
			if (availableMethods.Count == 0)
			{
				throw new NoCommandConstructorException(commandObject);
			}
			
			List<ParameterAttribute> nonConstructorParameters = GetNonConstructorParameters(commandObjectType);

			foreach (var methodInfo in availableMethods)
			{
				List<ParameterAttribute> allParameters = GetConstructorParameters(methodInfo);
				allParameters.AddRange(nonConstructorParameters);
				
				if(TryGetDuplicatedParametersName(allParameters, out var parameterName))
				{
					throw new SameParameterNamesException(commandObjectType, parameterName);
				}				
			}
		}
		
		public static bool TryGetCommandConstructorsWithSameSignatures(
			IEnumerable<MethodInfo> commandConstructionMethods, 
			out (MethodInfo, MethodInfo) constructorsWithSameSignatures)
		{
			foreach (var methodA in commandConstructionMethods)
			{
				foreach (var methodB in commandConstructionMethods)
				{
					if(methodA == methodB)
					{
						continue;
					}		
					
					ParameterInfo[] methodAParameters = methodA.GetParameters();
					ParameterInfo[] methodBParameters = methodB.GetParameters();
					
					if(methodAParameters.Length != methodBParameters.Length)
					{
						continue;
					}
					
					int sameParametersCounter = 0;
					
					for (int i = 0; i < methodAParameters.Length; i++)
					{
						if(methodAParameters[i].ParameterType.Equals(methodBParameters[i].ParameterType))
						{
							sameParametersCounter++;
						}
					}
					
					if(sameParametersCounter == methodAParameters.Length)
					{
						constructorsWithSameSignatures = new (methodA, methodB);
						return true;
					}
				}
			}
			
			constructorsWithSameSignatures = new();
			return false;
		}
		
		public static bool TryGetDuplicatedParametersName(IEnumerable<ParameterAttribute> parameters, out string duplicatedName)
		{
			foreach (ParameterAttribute parameterA in parameters)
			{
				
				foreach (ParameterAttribute parameterB in parameters)
				{
					if(parameterA == parameterB)
					{
						continue;
					}		
					
					if(parameterA.ParameterName.Equals(parameterB.ParameterName))
					{
						duplicatedName = parameterA.ParameterName;
						return true;
					}
				}
			}
			
			duplicatedName = string.Empty;
			return false;	
		}
		
		public static List<ParameterAttribute> GetNonConstructorParameters(Type commandObjectType)
		{
			List<Attribute> attributes = new List<Attribute>();
			
			FieldInfo[] fieldInfos = commandObjectType.GetFields(
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

			PropertyInfo[] propertyInfos = commandObjectType.GetProperties(
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);

			foreach (var fieldInfo in fieldInfos)
			{
				attributes.AddRange(fieldInfo.GetCustomAttributes());
			}
			
			foreach (var propertyInfo in propertyInfos)
			{
				attributes.AddRange(propertyInfo.GetCustomAttributes());
			}
			
			return GetFilteredAttributes<ParameterAttribute>(attributes);
		}
				
		public static List<ParameterAttribute> GetConstructorParameters(MethodInfo commandConstructorMethod)
		{
			List<ParameterAttribute> result = new List<ParameterAttribute>();
			ParameterInfo[] parameters = commandConstructorMethod.GetParameters();

			for (int i = 0; i < parameters.Length; i++)
			{
				var parameterAttributes = GetFilteredAttributes<ParameterAttribute>(parameters[i].GetCustomAttributes());
				if(parameterAttributes.Count > 0)
				{
					result.Add(parameterAttributes[0]);
				}
			}
			
			return result;
		}
		
		public static List<MethodInfo> GetAvailableConstructors(Type commandObjectType)
		{
			MethodInfo[] methods = commandObjectType.GetMethods(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
				
			List<MethodInfo> availableConstructors = new List<MethodInfo>();
			
			for (int i = 0; i < methods.Length; i++)
			{
				var attributes = methods[i].GetCustomAttributes();
					
				if (GetFilteredAttributes<CommandConstructorAttribute>(attributes).Count > 0)
				{
					availableConstructors.Add(methods[i]);
				}
			}
			
			return availableConstructors;
		}
		
		private static List<T> GetFilteredAttributes<T>(IEnumerable<Attribute> attributes)
			where T: Attribute
		{
			List<T> result = new List<T>();
			foreach (var attribute in attributes)
			{
				if(typeof(T).IsAssignableFrom(attribute.GetType()))
				{
					result.Add((T)attribute);
				}
			}
			
			return result;
		}
	}
}

