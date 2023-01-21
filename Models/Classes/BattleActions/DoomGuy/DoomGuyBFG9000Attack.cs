using Game.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Classes.BattleActions
{
    public class DoomGuyBFG9000Attack : BattleAction
    {
        public DoomGuyBFG9000Attack() : base("BFG9000!!!!", 1000, 1, ActionType.Attack, Element.None, ActionStatType.Magical ) { }
    }
}
