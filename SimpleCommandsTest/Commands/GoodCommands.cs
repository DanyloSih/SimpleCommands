namespace SimpleCommandsTest.Commands;

public class GoodCommand1
{
	private string _someField1;
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work.")]
	public void SomeMethod1(int param1, float param2)
	{
		
	}
}

public class GoodCommand2
{
	private string _someField1;
	
	public float SomeProperty1 { get; }
	
	[CommandConstructor("Do some magic work.")]
	public void SomeMethod1(
		[Parameter("myParameterName1")] int param1, 
		float param2)
	{
		
	}
}

public class GoodCommand3
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

public class GoodCommand4
{
	[Parameter("myField1")]
	private string _someField1;
	
	[Parameter("myProperty1")]
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