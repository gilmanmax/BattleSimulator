using Game.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Classes.BattleActions
{
    public class CyberdemonRocketTrio : BattleAction
    {
        public CyberdemonRocketTrio() : base("Cyberdemon Rockets", 300, 1, ActionType.Attack, Element.Physical, ActionStatType.Physical ) { }
    }
}
