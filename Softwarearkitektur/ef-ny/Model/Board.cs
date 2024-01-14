using System;
namespace ef_trello.Model
{
	public class Board
	{
		public Board(Todo Todo)
		{
			this.Todo = Todo;
		}

		public Todo Todo { get; set; }

	}
}

