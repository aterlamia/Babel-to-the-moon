using Godot;
using System;
using Bable.Jobs;

public class Room : Spatial
{

	[Export]
	int _size = 1;

	[Export]
	string _name = "Not set";
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void Build()
	{
		var job = GetNode<IJob>("Job");

		if (job != null)
		{
			job.Start();
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	public int getWidth()
	{
		return _size;
	}
}
