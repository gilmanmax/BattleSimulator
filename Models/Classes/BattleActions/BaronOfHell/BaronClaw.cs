using Game.Models.Enumerators;

namespace Game.Models.Classes.BattleActions
{
    public class BaronClaw: BattleAction
    {
        public BaronClaw() : base("Baron's Claw", 80, 1, ActionType.Attack, Element.Physical, ActionStatType.Physical) { }
    }
}
