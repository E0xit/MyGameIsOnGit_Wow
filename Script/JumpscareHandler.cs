using Godot;
using System;

public partial class JumpscareHandler : AnimatedSprite2D
{
	[Export] private CanvasLayer UI;
	[Export] private Timer timer;
	public override void _Ready()
	{
		AnimationChanged += OnJumpscare;
		AnimationFinished += AfterKill;
		timer.Timeout += ToGameOver;
	}
	public void OnJumpscare()
	{
		UI.Visible = false;
	}
	public void AfterKill()
	{
		timer.Start();
	}
	public void ToGameOver()
	{
		//Nope
	}
	public void PlayJumpscare(string name)
	{
		Play(name);
		timer.Start();
	}
}
