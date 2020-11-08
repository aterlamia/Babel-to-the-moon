using Godot;
using Bable;
using Godot.Collections;


public class RoomSpawner : Node
{
	private Room _currentRoom = null;

	private RoomMap _map;
	[Export] private Dictionary<Rooms, PackedScene> _roomTypes = new Dictionary<Rooms, PackedScene>()
	{
		{Rooms.Farm, null},
		{Rooms.Foundation, null},
		{Rooms.SmallBedroom, null},
		{Rooms.MediumBedroom, null},
		{Rooms.LargeBedroom, null},
		{Rooms.Market, null},
		{Rooms.Carpenter, null},
		{Rooms.Miner, null},
		{Rooms.Temple, null}
	};
	
	public override void _Ready()
	{
		_map = new RoomMap();
		GetNode<SignalManager>("/root/SignalManager").Connect("CreateMarketStarted", this, "CreateMarket");
		GetNode<SignalManager>("/root/SignalManager").Connect("CreateFoundationStarted", this, "CreateFoundation");
		GetNode<SignalManager>("/root/SignalManager").Connect("CreateSmallBedroomStarted", this, "CreateSmallRoom");
		GetNode<SignalManager>("/root/SignalManager").Connect("CreateMediumBedroomStarted", this, "CreateMediumRoom");
		GetNode<SignalManager>("/root/SignalManager").Connect("CreateFarmStarted", this, "CreateFarm");
	}

	private void CreateFarm()
	{
		var instance = (Room) _roomTypes[Rooms.Farm].Instance();
		instance.Translation = new Vector3(0, 0, 0);
		GetParent().AddChild(instance);

		_currentRoom = instance;
	}
	

	private void CreateMarket()
	{
		var instance = (Room) _roomTypes[Rooms.Farm].Instance();
		instance.Translation = new Vector3(0, 0, 0);
		GetParent().AddChild(instance);

		_currentRoom = instance;
	}
	
	private void CreateFoundation()
	{
		var instance = (Room) _roomTypes[Rooms.SmallBedroom].Instance();
		instance.Translation = new Vector3(0, 0, 0);
		GetParent().AddChild(instance);

		_currentRoom = instance;
	}
	
	private void CreateSmallRoom()
	{
		var instance = (Room) _roomTypes[Rooms.SmallBedroom].Instance();
		instance.Translation = new Vector3(0, 0, 0);
		GetParent().AddChild(instance);

		_currentRoom = instance;
	}
	
		
	private void CreateMediumRoom()
	{
		var instance = (Room) _roomTypes[Rooms.MediumBedroom].Instance();
		instance.Translation = new Vector3(0, 0, 0);
		GetParent().AddChild(instance);

		_currentRoom = instance;
	}


	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent is InputEventMouseButton mouseEvent && _currentRoom != null)
		{

			if (mouseEvent.Pressed)
			{

				var roomPos = new Vector2(_currentRoom.Translation.x, _currentRoom.Translation.y);
				if (_map.IsOccupied(roomPos, _currentRoom.getWidth()) == false)
				{
					_map.SetOccupied(roomPos, _currentRoom.getWidth()); 
					_currentRoom.Build();
					_currentRoom = null;
				}
				
			}
		}
	}
	
	float SnapValue(float value, float step) {
		return Mathf.Round(value / step) * step;
	}
	
	public override void _Process(float delta)
	{
		if (_currentRoom != null)
		{
			var mousePosition = GetParent().GetViewport().GetMousePosition();
			var camera = GetViewport().GetCamera();

			var newPos = camera.ProjectPosition(mousePosition, camera.Translation.z);


			newPos.z = 0;
			newPos.x = SnapValue(newPos.x, 1.5f);
			newPos.y = Mathf.Max(SnapValue(newPos.y, 3), 0);
			_currentRoom.Translation = newPos;

			if (_map.IsOccupied(new Vector2(newPos.x, newPos.y), _currentRoom.getWidth()))
			{
				_currentRoom.GetNode<MeshInstance>("Forcefield").Show();
			}
			else
			{
				_currentRoom.GetNode<MeshInstance>("Forcefield").Hide();	
			}
		}
	}
}
