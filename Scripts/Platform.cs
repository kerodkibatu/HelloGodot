using Godot;
using System;

public partial class Platform : AnimatableBody2D
{
    [Export] RayCast2D _LeftCast;
	[Export] RayCast2D _RightCast;

	[Export] float MoveSpeed = 100;

	Vector2 Velocity;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Velocity = new Vector2(MoveSpeed, 0);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        if (_LeftCast.IsColliding())
		{
            Velocity = new Vector2(MoveSpeed * (float)delta, 0);
        }
        else if(_RightCast.IsColliding())
		{
            Velocity = new Vector2(-MoveSpeed * (float)delta, 0);
        }
        GlobalPosition += Velocity;
    }
}
