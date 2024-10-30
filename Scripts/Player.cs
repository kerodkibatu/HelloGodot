using Godot;
using GodotPlugins.Game;
using System;
using System.Diagnostics;

public partial class Player : CharacterBody2D
{
    [Export] AnimatedSprite2D Sprite;
    // Constants for the player's movement.
    [Export] int CoyoteTime = 300;
    public const float Speed = 130.0f;
    public const float JumpVelocity = -300.0f;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public bool canJump = true;

    Stopwatch coyoteTimer = Stopwatch.StartNew();
    public bool Dead = false;
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (coyoteTimer.ElapsedMilliseconds > CoyoteTime)
        {
            canJump = false;
        }

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity.Y += gravity * (float)delta;
            coyoteTimer.Restart();
        }
        else
        {
            canJump = true;
        }

        if (Input.IsActionJustPressed("jump") && canJump && !Dead)
        {
            velocity.Y = JumpVelocity;
            canJump = false;
        }

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("left", "right", "up", "down");
        if (direction != Vector2.Zero && !Dead)
        {
            velocity.X = direction.X * Speed;
            if (direction.X < 0)
                Sprite.FlipH = true;
            else if (direction.X > 0)
                Sprite.FlipH = false;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }
        if(Dead)
            Sprite.Animation = "die";
        else if (!IsOnFloor())
            Sprite.Animation = "jump";
        else if (direction.X != 0)
            Sprite.Animation = "run";
        else
            Sprite.Animation = "idle";


        Velocity = velocity;
        MoveAndSlide();
    }
}
