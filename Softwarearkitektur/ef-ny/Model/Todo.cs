using System;
namespace ef_trello.Model
{
	public class Todo
	{
		public Todo(string Title,  User User)
		{

            this.User = User;
			this.Title = Title;
		}

        public Todo(string Title)
        {
            this.Title = Title;
            
            
        }

        public long TodoId { get; set; }
        public string? Title { get; set; }
		public User? User { get; set; }
		
	}
}

