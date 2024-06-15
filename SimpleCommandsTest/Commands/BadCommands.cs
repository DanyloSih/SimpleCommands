namespace SimpleCommandsTest.Commands;

public class BadCommand1
{
	private string _someField1;
	public float SomeProperty1 { get; }
	
	public void SomeMethod1(int param1, float param2)
	{
		
	}
}

public class BadCommand2
{
	private string _someField1;
	
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] int param1, 
		[Parameter("myParameterName1")] float param2)
	{
		
	}
}

public class BadCommand3
{
	[Parameter("myField1")]
	private string _someField1;
	
	[Parameter("myProperty1")]
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] int param1, 
		float param2)
	{
		
	}
}

public class BadCommand4
{
	[Parameter("myField1")]
	private string _someField1;
	
	[Parameter("myField1")]
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work.")]
	public void SomeMethod1(
		int param1, 
		float param2)
	{
		
	}
}

public class BadCommand5
{
	[Parameter("myField1")]
	private string _someField1;
	
	[Parameter("myParameterName1")]
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work 1.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] int param1, 
		[Parameter("myParameterName2")] float param2)
	{
		
	}
	
	[CommandConstructor("Do some magic work 1.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] string param1, 
		[Parameter("myParameterName2")] float param2)
	{
		
	}
	
	[CommandConstructor("Do some magic work 2.")]
	public void SomeMethod2(
		[Parameter("myParameterName1")] float param1, 
		[Parameter("myParameterName2")] string param2)
	{
		
	}
}

public class BadCommand6
{
	[Parameter("myField1")]
	private string _someField1;
	
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work 1.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] int param1, 
		[Parameter("myParameterName2")] float param2)
	{
		
	}
	
	[CommandConstructor("Do some magic work 1.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] long param1, 
		[Parameter("myParameterName2")] int param2)
	{
		
	}
	
	[CommandConstructor("Do some magic work 2.")]
	public void SomeMethod2(
		[Parameter("myParameterName1")] double param1, 
		[Parameter("myParameterName2")] byte param2)
	{
		
	}
}