using System.Linq;
using Godot;

public enum Office { Monitor, LeftVent, RightVent }
public partial class OfficeAnimationHandler : Node
{
	[Export] private AnimatedSprite2D officeAnimPlayer;
	[Export] private UIHandler officeControlUI;
	public Office currentState;
	public int stateNum;
	private readonly Office[] officeStates = [Office.LeftVent, Office.Monitor, Office.RightVent];
	public override void _Ready()
	{
		officeAnimPlayer.AnimationFinished += AnimFinish;
		stateNum = 1;
		currentState = officeStates[stateNum];
		ChangedOfficeSprite();
	}
	public override void _Process(double delta)
	{
		if (officeControlUI.onHover)
		{
			stateNum = Mathf.Clamp(stateNum + officeControlUI.GetSideValue(), 0, 2);
			MoveAnim();
			officeControlUI.SideVisible(false);
		}
	}
	private void ChangedOfficeSprite()
	{
		switch (currentState)
		{
			case Office.Monitor:
				officeAnimPlayer.Play("OfficeIdle");
				break;
			case Office.LeftVent:
				officeAnimPlayer.Play("LeftVentIdle");
				break;
			case Office.RightVent:
				officeAnimPlayer.Play("RightVentIdle");
				break;
		}
	}
	private void MoveAnim()
	{
		switch (stateNum)
		{
			case 0://Mid to Left
				officeAnimPlayer.Play("LeftTurn");
				break;
			case 1://Mid Return
				if (currentState == Office.LeftVent)
					officeAnimPlayer.Play("LeftTurnBack");
				if (currentState == Office.RightVent)
					officeAnimPlayer.Play("RightTurnBack");
				break;
			case 2://Mid to Right
				officeAnimPlayer.Play("RightTurn");
				break;
		}
	}
	private void AnimFinish()
	{
		currentState = officeStates[stateNum];
		ChangedOfficeSprite();
		officeControlUI.SideVisible(true);
		officeControlUI.SideVisibleIdle();
	}
}
