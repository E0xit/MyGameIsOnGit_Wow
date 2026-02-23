using Godot;

public partial class UIHandler : Node2D
{
	[Export] private OfficeAnimationHandler officeAnimationHandler;
	[Export] private Panel leftBar, rightBar;
	[Export] private Timer flashDelay;
	public bool onHover;
	public int sidevalue;
	public override void _Ready()
	{
		Visible = true;
		leftBar.MouseEntered += () => StateChange("Left");
		rightBar.MouseEntered += () => StateChange("Right");
		onHover = false;
		sidevalue = 0;	
	}
	public override void _Process(double delta)
	{
	}
	private void StateChange(string side)
	{
		onHover = true;
		sidevalue = side switch { "Left" => -1, "Right" => 1, _ => 0 };
	}
	public void SideVisibleIdle()
	{
		switch (officeAnimationHandler.currentState)
		{
			case Office.Monitor:
				leftBar.Visible = true;
				rightBar.Visible = true;
				break;
			case Office.LeftVent:
				leftBar.Visible = false;
				break;
			case Office.RightVent:
				rightBar.Visible = false;
				break;
		}
	}
	public void SideVisible(bool Bool)
	{
		if (Bool) Visible = true;
		else Visible = false;
	}
	public int GetSideValue()
	{
		onHover = false;
		return sidevalue;
	}

}
