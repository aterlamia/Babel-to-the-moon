using Godot;
using System;

public class Tower : Spatial
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("UpdateGold", 500 );
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("UpdatePeople", 2);
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("UpdateFood", 10);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
