using Godot;
using System;

public class SignalManager : Node
{
	[Signal]
	public delegate void CreateFoundationStarted();
	
	[Signal]
	public delegate void CreateMarketStarted();
	
	[Signal]
	public delegate void CreateFarmStarted();
	
	[Signal]
	public delegate void CreateMineStarted();
	
	[Signal]
	public delegate void CreateTempleStarted();
	
	[Signal]
	public delegate void CreateCarpenterStarted();
	
	[Signal]
	public delegate void CreateBarrackStarted();
	
	[Signal]
	public delegate void CreateHangingGarderStarted();
	
	[Signal]
	public delegate void CreateSmallBedroomStarted();
	
	[Signal]
	public delegate void CreateMediumBedroomStarted();
	
	[Signal]
	public delegate void CreateLargeBedroomStarted();
	
	[Signal]
	public delegate void CreateTheaterStarted();
	
	[Signal]
	public delegate void UpdateFood(float value);
	[Signal]
	public delegate void UpdateWood(int value);
	[Signal]
	public delegate void UpdateStone(int value);
	[Signal]
	public delegate void UpdatePeople(int value);
	[Signal]
	public delegate void UpdateFaith(int value);
	[Signal]
	public delegate void UpdateGold(int value);
	[Signal]
	public delegate void UpdateLivingSpaces(int value);


	
	[Signal]
	public delegate void FoodUpdated(float value);
	[Signal]
	public delegate void WoodUpdated(int value);
	[Signal]
	public delegate void StoneUpdated(int value);
	[Signal]
	public delegate void PeopleUpdated(int value);
	[Signal]
	public delegate void FaithUpdated(int value);
	[Signal]
	public delegate void GoldUpdated(int value);
	[Signal]
	public delegate void LivingSpacesUpdated(int value);
	
}
