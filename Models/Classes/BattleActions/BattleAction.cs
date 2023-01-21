using Game.Interfaces;
using Game.Models.Enumerators;

namespace Game.Models.Classes.BattleActions
{
    /// <summary>
    /// Represents a battle action
    /// </summary>
    public abstract class BattleAction : IEntity
    {
        /// <summary>
        /// Base Power of Attack
        /// </summary>
        public int BasePower { get; protected set; }
        /// <summary>
        /// Element
        /// </summary>
        public Element Element { get; protected set; }

        public string Name { get; protected set; }
        public ActionType ActionType { get; protected set; }
        public ActionStatType ActionStatType { get; protected set; }
        public int NumberTargets { get; protected set; }
        protected BattleAction(string name, int basePower, int numberTargets, ActionType actionType, Element element, ActionStatType actionStatType)
        {
            Name = name;
            BasePower = basePower;
            ActionType = actionType;
            Element = element;
            ActionStatType = actionStatType;
            NumberTargets = numberTargets;
        }
    }
}
