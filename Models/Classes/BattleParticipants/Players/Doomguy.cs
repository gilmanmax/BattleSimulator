using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Enumerators;
using Game.Models.Classes.BattleActions;

namespace Game.Models.Classes.BattleParticipants
{
    public class Doomguy : BattleParticipant
    {
        public Doomguy() : base(100, "The DoomGuy", "Players", new List<ElementAffinity>
        {
            //this is for the armor he has on. lol.
            new ElementAffinity(AffinityType.Resistant,Element.Physical,0.1m)
        }, new List<BattleAction>
        {
            new DoomGuySuperShotgunBlast(),
            new DoomGuySuperShotgunBlast(),
            new DoomGuySuperShotgunBlast(),
            new DoomGuySuperShotgunBlast(),
            new DoomGuyBFG9000Attack()
        })
        { }
    }
}
