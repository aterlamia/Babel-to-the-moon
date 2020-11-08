using Godot;
using System;
using Bable.Jobs;

public class FarmJob : Node, IJob
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	[Export]
	private float _speed = 2f;

	[Export]
	private int _amount = 1;


	private Timer _timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = new Timer();
		_timer.OneShot = false;
		_timer.ProcessMode = Timer.TimerProcessMode.Physics;
		_timer.WaitTime = _speed;
		_timer.Connect("timeout", this, "_timer_callback");
		AddChild(_timer);
	}

	public void Start()
	{
		_timer.Start();
	}
	
	public void Pauze()
	{
		_timer.Paused = true;
	}
	
	public void Stop()
	{
		_timer.Stop();
	}
	
	
	private void _timer_callback()
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("UpdateFood", _amount );
	}
}
