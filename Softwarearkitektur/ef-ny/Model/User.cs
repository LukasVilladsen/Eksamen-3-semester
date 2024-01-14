using System;
namespace ef_trello.Model
{
	public class User
	{
		public User(string Name)
		{
			this.Name = Name;
		}

		public string? Name { get; set; }
		public long userId { get; set; }
	}
}

