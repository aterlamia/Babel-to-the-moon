using Godot;
using System;

public class TopMEnu : Panel
{

	[Export]
	private NodePath _woodLabel;
	[Export]
	private NodePath _foodLabel;
	[Export]
	private NodePath _peopleLabel;
	[Export]
	private NodePath _faithLabel;
	[Export]
	private NodePath _stoneLabel;
	
	[Export]
	private NodePath _goldLabel;
	
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").Connect("StoneUpdated", this, "UpdateStoneLabel");
		GetNode<SignalManager>("/root/SignalManager").Connect("FoodUpdated", this, "UpdateFoodLabel");
		GetNode<SignalManager>("/root/SignalManager").Connect("PeopleUpdated", this, "UpdatePeopleLabel");
		GetNode<SignalManager>("/root/SignalManager").Connect("FaithUpdated", this, "UpdateFaithLabel");
		GetNode<SignalManager>("/root/SignalManager").Connect("WoodUpdated", this, "UpdateWoodLabel");
		GetNode<SignalManager>("/root/SignalManager").Connect("GoldUpdated", this, "UpdateGoldLabel");
	}

	private void UpdateStoneLabel(int value)
	{
		GetNode<Label>(_stoneLabel).Text = $"{value}";
	}
	
	private void UpdateFoodLabel(int value)
	{
		GetNode<Label>(_foodLabel).Text = $"{value}";
	}
	
	private void UpdatePeopleLabel(int value)
	{
		GetNode<Label>(_peopleLabel).Text = $"{value}";	
	}
	
	private void UpdateFaithLabel(int value)
	{
		GetNode<Label>(_faithLabel).Text = $"{value}";	
	}
	
	private void UpdateWoodLabel(int value)
	{
		GetNode<Label>(_woodLabel).Text = $"{value}";
	}
	
	private void UpdateGoldLabel(int value)
	{
		GetNode<Label>(_goldLabel).Text = $"{value}";	
	}
	

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
