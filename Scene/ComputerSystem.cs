using Godot;

public enum Mode { MusicBox, AudioLure, ChargeLight, RobotJammer }
public partial class ComputerSystem : Control
{
	[Export] private Label modeDisplay, status;
	[Export] private Button next, previous;
	private Mode currentMode;
	private Mode[] modes = [Mode.MusicBox, Mode.AudioLure, Mode.ChargeLight, Mode.RobotJammer];
	private int modeIndex;
	public override void _Ready()
	{
		next.Pressed += () => ModeChange("next");
		previous.Pressed += () => ModeChange("previous");
		modeIndex = 0;
		currentMode = modes[modeIndex];

		ModeDisplayChange();
	}

	private void ModeChange(string context)
	{
		switch (context)
		{
			case "next":
				modeIndex = (modeIndex + 1) % modes.Length;
				break;
			case "previous":
				modeIndex = (modeIndex - 1 + modes.Length) % modes.Length;
				break;
		}
		currentMode = modes[modeIndex];
		ModeDisplayChange();
	}
	private void ModeDisplayChange()
	{
		switch (currentMode)
		{
			case Mode.MusicBox:
				modeDisplay.Text = "music box";
				break;
			case Mode.AudioLure:
				modeDisplay.Text = "audio lure";
				break;
			case Mode.ChargeLight:
				modeDisplay.Text = "charge light";
				break;
			case Mode.RobotJammer:
				modeDisplay.Text = "robot jammer";
				break;
		}
	}

}
