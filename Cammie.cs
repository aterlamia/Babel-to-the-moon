using Godot;
using System;

public class Cammie : Camera
{
	private float currentZoom = 100;

	private float zoomStep = 1.5f;

	private Vector3 lastCameraPosition;

	private Vector3 cameraTargetOffset;

	private bool _moveCamera = false;

	private Vector2 _previousPosition;

	private Vector2 mouseCurrentPosition;

	private float _cameraSpeed = 0.8f;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton)
		{
			var mouseEvent = (InputEventMouseButton) @event;
			if ((ButtonList) mouseEvent.ButtonIndex == ButtonList.Right && mouseEvent.IsPressed())
			{
				_previousPosition = mouseEvent.Position;
				_moveCamera = true;
			}
			else
			{
				_moveCamera = false;
			}
		
		}
		else if (@event is InputEventMouseMotion)
		{
			if (_moveCamera)
			{
				var mouseEvent = (InputEventMouseMotion) @event;
				mouseCurrentPosition = mouseEvent.Position;
			}
		}

		if (Input.IsActionJustReleased("zoomout"))
		{
			currentZoom += zoomStep;
		}
		else if (Input.IsActionJustReleased("zoomin"))
		{
			currentZoom -= zoomStep;
		}
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	public override void _PhysicsProcess(float delta)
	{
		// Take the middle of the screen and always zoom there
		var hitPos = new Vector3(0, 0, 0); //(GetViewport().Size / 2);
		//
		
		if (_moveCamera)
		{
			
			var mousePosition = GetParent().GetViewport().GetMousePosition();
			var camera = GetViewport().GetCamera();

			var dragStart =camera.ProjectPosition(_previousPosition, camera.Translation.z);
			var dragEnd = camera.ProjectPosition(mousePosition, camera.Translation.z);
			
		
			var offset = (dragStart - dragEnd);
			var newpos = Translation + offset ;
		
			 Translation = Translation.LinearInterpolate((Vector3) newpos, delta * _cameraSpeed);
		}



		// if (currentZoom !=  Translation.z)
		// {
			var off = Translation;
			off.z = currentZoom;

			Translation = off;
			// }
			//
			// //
			// // if (currentZoom > 0 ||currentZoom < (10f))
			// // {
			// // 	// cameraTargetOffset += dir * currentZoom;
			// // 	Size = currentZoom;
			// // }
			//
			//  lastCameraPosition = Translation;
			//  var off = new Vector3(0, 0, zoomStep);
			//  Translation = Translation.LinearInterpolate(Translation + off, delta * 5f);
			// // cameraTargetOffset -= Translation - lastCameraPosition;
	}
}
