using Godot;
using System;

public class BuildMenu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private void _on_Market_pressed()
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("CreateMarketStarted");
	}


	private void _on_Foundation_pressed()
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("CreateFoundationStarted");
	}
	
	
private void _on_Farm_pressed()
{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("CreateFarmStarted");
}


private void _on_Temple_pressed()
{
			GetNode<SignalManager>("/root/SignalManager").EmitSignal("CreateMediumBedroomStarted");
}

}


