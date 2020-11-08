using Godot;
using Godot.Collections;

namespace Bable
{
	public class RoomMap
	{
		private Dictionary<Vector2, bool> _occupied;

		public Dictionary<Vector2, bool> Occupied
		{
			get => _occupied;
			set => _occupied = value;
		}

		public RoomMap()
		{
			_occupied = new Dictionary<Vector2, bool>();
		}


		public void SetOccupied(Vector2 pos, int width)
		{
			var mapPos = new Vector2((pos.x / 1.5f), pos.y / 3f);
			for (var i = 0; i < width; i++)
			{
				
				if (_occupied.ContainsKey(mapPos + new Vector2(i, 0)))
				{
					_occupied[mapPos + new Vector2(i , 0)] = true;
				}
				else
				{
					_occupied.Add(mapPos + new Vector2(i, 0), true);
				}
			}
		}

		public bool IsOccupied(Vector2 pos, int width)
		{
			var mapPos = new Vector2((pos.x / 1.5f), pos.y / 3f);
			
			for (var i = 0; i < width; i++)
			{
				if (_occupied.ContainsKey(mapPos + new Vector2(i, 0)))
				{
					return true;
				}
			}

			return false;
		}
	}
}
