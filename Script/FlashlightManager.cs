using Godot;
using System;

public partial class FlashlightManager : Node
{
	public Timer delaytimer;
	[Export] private Button flashButton;
	[Export] private UIHandler UI;
	[Export] private OfficeAnimationHandler office;
	[Export] private AnimatedSprite2D ventAnimPlayer;
	[Export] private EnemyBased[] enemies = new EnemyBased[2];
	[Export] private JumpscareHandler jumpscare;
	public override void _Ready()
	{
		delaytimer = GetChildOrNull<Timer>(0);
		flashButton.Pressed += FlashButtonPress;
		ventAnimPlayer.AnimationFinished += FlashEnd;
	}
	public override void _Process(double delta)
	{
		FlashButtonActive();
	}
	private void FlashButtonActive()
	{
		if (office.currentState == Office.Monitor)
		{
			flashButton.Visible = false;
		}
		else flashButton.Visible = true;
	}
	private void FlashButtonPress()
	{
		if (delaytimer.TimeLeft == 0f)
		{
			foreach (EnemyBased enemy in enemies)
			{
				if (enemy.onVent && office.currentState == enemy.Side)
				{
					switch (enemy.killPosition)
					{
						case Vent.Far:
							ventAnimPlayer.Play(enemy.Name + "FoundFar");
							enemy.OnStart();
							break;
						case Vent.Close:
							ventAnimPlayer.Play(enemy.Name + "FoundClose");
							break;
					}
				}
				else if (enemy.EnemyTimer.TimeLeft <= 3f && (enemy.location == Vent.A3 || enemy.killPosition == Vent.Far)) continue;
				else if (office.currentState == enemy.Side) ventAnimPlayer.Play(enemy.Name + "FlashingNone");
			}
			delaytimer.Start(2f);
		}
	}
	private void FlashEnd()
	{
		ventAnimPlayer.Play("PitchBlack");
	}
}
