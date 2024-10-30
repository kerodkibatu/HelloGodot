using Godot;
using System;

public partial class Enemy : Node2D
{
	[Export] Area2D KnockoutZone;
    [Export] KillZone KillZone;
    [Export] RayCast2D LeftCast;
    [Export] RayCast2D RightCast;
    [Export] AnimatedSprite2D Sprite;
    [Export] AudioStreamPlayer2D KnockSFX;
    [Export] float Speed = 30;

	int Direction = 1;
	bool IsDead = false;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(KnockoutZone.HasOverlappingBodies() && !KillZone.HasOverlappingBodies())
		{
			KillZone.Enabled = false;
			Sprite.Animation = "knocked";
			GameManager.Instance.Score += 10;
			IsDead = true;
			KnockSFX.Play();
		}

		if (IsDead) return;
		if(LeftCast.IsColliding())
			Direction = 1;
		else if(RightCast.IsColliding())
			Direction = -1;

		Position += new Vector2(Direction * Speed * (float)delta,0);
	}
}
