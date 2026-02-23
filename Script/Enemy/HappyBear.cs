using Godot;
public partial class HappyBear : EnemyBased
{
    public override string EnemyName => "HappyBear";
    protected override int AILevel => 15;
    public override Office Side => Office.LeftVent;
    public override Timer EnemyTimer => GetChildOrNull<Timer>(0);
}