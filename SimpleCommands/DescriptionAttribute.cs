namespace SimpleCommands
{
    public class DescriptionAttribute : Attribute
	{
		private const string DEFAULT_DESCRIPTION = "Doesn't have a description.";
		
		private string? _description;
		
		public bool IsHaveDescription { get; }

		public DescriptionAttribute()
		{
			IsHaveDescription = false;
		}

		public DescriptionAttribute(string description)
		{
			_description = description;
			IsHaveDescription = true;
		}
		
		public string GetDesctiption()
		{
			if (_description != null)
			{
				return _description;
			}
			else
			{
				return DEFAULT_DESCRIPTION;
			}
		}
    }
}

