using Godot;
using System;

public partial class GameUI : Control
{
	[Export] public ProgressBar Progress;
	[Export] public Label ScoreLabel;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        ScoreLabel.Text = $"{GameManager.Instance.Balance}";
		Progress.Value = GameManager.Instance.Progress * 100;
    }
}
