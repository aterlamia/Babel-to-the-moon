using Godot;
using System;

public class ResourceManager : Node
{


	private int _people = 0;
	private int _wood = 0;
	private int _stone = 0;
	private int _faith = 0;
	private float _food = 0;
	private int _gold = 0;

	private int _livingSpaces = 2;

	public int People
	{
		get => _people;
		set => _people = value;
	}

	public int Wood
	{
		get => _wood;
		set => _wood = value;
	}

	public int Stone
	{
		get => _stone;
		set => _stone = value;
	}

	public int Faith
	{
		get => _faith;
		set => _faith = value;
	}

	public float Food
	{
		get => _food;
		set => _food = value;
	}

	public int Gold
	{
		get => _gold;
		set => _gold = value;
	}

	public int LivingSpaces
	{
		get => _livingSpaces;
		set => _livingSpaces = value;
	}


	[Export]
	private float _updateTime = 2f;
	[Export]
	private float _foodPerPerson = 0.2f;

	private Timer _timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdateFood", this, "UpdateFood");
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdateWood", this, "UpdateWood");
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdatePeople", this, "UpdatePeople");
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdateFaith", this, "UpdateFaith");
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdateStone", this, "UpdateStone");
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdateGold", this, "UpdateGold");
			GetNode<SignalManager>("/root/SignalManager").Connect("UpdateLivingSpaces", this, "UpdateLivingSpaces");
			
			
			_timer = new Timer();
			_timer.OneShot = false;
			_timer.ProcessMode = Timer.TimerProcessMode.Physics;
			_timer.WaitTime = _updateTime;
			_timer.Connect("timeout", this, "_timer_callback");
			AddChild(_timer);
			_timer.Start();
	}

	private void UpdateGold(int value)
	{
		_gold += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("GoldUpdated", _gold);
	}

	private void UpdateLivingSpaces(int value)
	{
		_livingSpaces += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("LivingSpacesUpdated", _livingSpaces);
	}
	private void UpdateStone(int value)
	{
		_stone += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("StoneUpdated", _stone);
	}
	
	private void UpdateWood(int value)
	{
		_wood += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("WoodUpdated", _wood);
	}
	
	private void UpdatePeople(int value)
	{
		_people += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("PeopleUpdated", _people);
	}
	
	private void UpdateFaith(int value)
	{
		_faith += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("FaithUpdated", _faith);
	}
	
	private void UpdateFood(float value)
	{
		_food += value;
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("FoodUpdated", _food);
	}
	
	
	private void _timer_callback()
	{
		var totalFoodUsed = _foodPerPerson * _people;
		GD.Print(totalFoodUsed);
		UpdateFood(-1 * totalFoodUsed);
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
