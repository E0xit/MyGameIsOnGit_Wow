using Godot;
using System;

public enum EnemyState { Active, InActive, OnKillState }
public enum Vent { A1, A2, A3, Office, Far, Close, None }
public abstract partial class EnemyBased : Node
{
    [Export] public float movementInterval = 10.0f, killTimer = 15;
    [Export] private OfficeAnimationHandler office;
    public abstract string EnemyName { get; }
    public abstract Office Side { get; }
    public abstract Timer EnemyTimer { get; }

    public Vent location, killPosition;
    public EnemyState enemyState;
    public int state;
    public bool onVent;

    protected abstract int AILevel { get; }
    protected RandomNumberGenerator random = new();
    protected Vent[] Roots = [Vent.A1, Vent.A2, Vent.A3, Vent.Office];
    public override void _Ready()
    {
        EnemyTimer.Timeout += OnMove;
        OnStart();
    }

    public override void _Process(double delta)
    {
        if (location == Vent.Office && (killPosition == Vent.Far || killPosition == Vent.Close))
        {
            onVent = true;
        }
        else onVent = false;
    }
    public void OnMove()
    {
        EnemyTimer.Start(10 - random.RandiRange(0, 3));
        int MovemenOp = random.RandiRange(0, 20);
        if (MovemenOp < AILevel && location != Vent.Office)
        {
            state = Mathf.Clamp(state + 1, 0, Roots.Length - 1);
            location = Roots[state];
        }
        else if (MovemenOp < AILevel && location == Vent.Office && killPosition == Vent.Far)
        {
            killPosition = Vent.Close;
        }
    }
    public void OnStart()
    {
        EnemyTimer.Start(15);
        enemyState = EnemyState.Active;
        if (random.RandiRange(0, 10) < 7)
            killPosition = Vent.Far;
        else killPosition = Vent.Close;

        state = 0;
        location = Roots[state];
        EnemyTimer.Paused = false;
        EnemyTimer.WaitTime = movementInterval;
    }
}
