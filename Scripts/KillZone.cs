using Godot;

public partial class KillZone : Area2D
{
    [Export] public AudioStreamPlayer DeathSound;
    [Export] public float DeathTimeout = 1;
    private Timer resetTimer;

    public bool Enabled = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        resetTimer = new Timer
        {
            OneShot = true
        };
        resetTimer.Connect("timeout", new(this, nameof(ResetScene)));
        AddChild(resetTimer);
    }

    private void ResetScene()
    {
        DeathSound.Stop();
        GetTree().ReloadCurrentScene();
        Engine.TimeScale = 1;
        GameManager.Instance.Reset();
    }

    private void OnBodyEntered(Node2D body)
    {
        if (resetTimer.TimeLeft > 0 || !Enabled) return;
        var player = body as Player;
        player.Dead = true;
        DeathSound.Play();
        Engine.TimeScale = 0.5f;
        resetTimer.WaitTime = DeathTimeout;
        resetTimer.Start();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }
}
