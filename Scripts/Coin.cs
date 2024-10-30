using Godot;
using System;

public partial class Coin : Area2D
{
    [Export] AudioStreamPlayer2D _PickupSound;
    bool Collected = false;
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        _PickupSound.Finished += OnSoundFinished;
        GameManager.Instance.RegisterCoin();
    }

    private void OnSoundFinished()
    {
        QueueFree();
    }

    private void OnBodyEntered(Node body)
    {
        if (Collected) return;
        if (body is Player)
            CollectCoin();
    }
    public void CollectCoin()
    {
        Visible = false;
        Collected = true;
        GameManager.Instance.AddCoin();
        _PickupSound.Play();
    }
}
