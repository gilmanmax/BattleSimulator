using Game.Models.Enumerators;

namespace Game.Models.Classes.BattleActions
{
    public class BaronFireBall : BattleAction
    {
        public BaronFireBall() : base("Baron's Fireball", 64, 1, ActionType.Attack, Element.Fire, ActionStatType.Magical) { }
    }
}
