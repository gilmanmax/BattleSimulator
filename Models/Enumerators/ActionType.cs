using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Enumerators
{
    /// <summary>
    /// Determines whether the action is an damaging attack, healing, a status effect, or other.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Use this if attack damages.
        /// </summary>
        Attack,
        /// <summary>
        /// Healing spells
        /// </summary>
        Healing,
        /// <summary>
        /// Buffs like bless go here
        /// </summary>
        Buff,
        /// <summary>
        /// Poison, Sleep all go here
        /// </summary>
        Debuff,
        /// <summary>
        /// Other might include fleeing, doing nothing etc.
        /// </summary>
        Other
    }
}
