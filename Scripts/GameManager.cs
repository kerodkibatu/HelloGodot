using Godot;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance;

    [Export] public AudioStreamPlayer Music;

    public int Score = 0;
    public int TotalCoins = 0;
    public int Balance = 0;
    public float Progress => (float)Balance / TotalCoins;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Instance = GetNode<GameManager>("/root/GameManager");
        Music.Play();
    }
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
    public void RegisterCoin()
    {
        TotalCoins++;
    }
    public void AddCoin()
    {
        Balance++;
        GD.Print($"{Balance} Coin(s) Collected!");
    }
    public void Reset()
    {
        Balance = 0;
        TotalCoins = 0;
    }
}
