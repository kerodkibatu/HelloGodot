using Godot;
using System;

public partial class BouncePad : StaticBody2D
{
    [Export] float BounceForce = -500;
    public override void _Ready()
    {
        GetNode<Area2D>("Area2D").Connect("body_entered", new(this, nameof(OnBodyEntered)));
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public void OnBodyEntered(Node body)
    {
        if (body is Player player)
        {
            player.Velocity = new Vector2(player.Velocity.X,  player.Velocity.Y + BounceForce);
        }
    }
}
