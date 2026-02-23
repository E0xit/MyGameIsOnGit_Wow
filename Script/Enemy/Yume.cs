using Godot;
public partial class Yume : EnemyBased
{
    public override string EnemyName => "Yume";
    protected override int AILevel => 15;
    public override Office Side => Office.RightVent;
    public override Timer EnemyTimer => GetChildOrNull<Timer>(0);
}