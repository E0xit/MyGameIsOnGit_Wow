using Godot;
using System.Linq;

public partial class DebugUi : Node2D
{
	[Export] private OfficeAnimationHandler officeAnim;
	[Export] private FlashlightManager flashlight;
	[Export] private EnemyBased[] enemies = new EnemyBased[2];
	private Label[] debugui;
	public override void _Ready()
	{
		debugui = [.. GetChildren(true).OfType<Label>()];
	}
	public override void _Process(double delta)
	{
		debugui[0].Text = "officeState = " + officeAnim.currentState;
		debugui[1].Text = "stateNum = " + officeAnim.stateNum;
		debugui[2].Text = "YumeState = " + enemies[0].state;
		debugui[3].Text = "YumeLocation = " + enemies[0].location;
		debugui[4].Text = "YumeMoveInterval = " + enemies[0].EnemyTimer.TimeLeft;
		debugui[5].Text = "YumeKillLocation = " + enemies[0].killPosition;
		debugui[6].Text = "FlashDelay = " + flashlight.delaytimer.TimeLeft;
	}
}
