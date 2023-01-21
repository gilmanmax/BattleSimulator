using Game.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Classes.BattleActions
{
    public class DoomGuySuperShotgunBlast : BattleAction
    {
        public DoomGuySuperShotgunBlast() : base("Super Shotgun Blast", 200, 1, ActionType.Attack, Element.Physical, ActionStatType.Physical ) { }
    }
}
