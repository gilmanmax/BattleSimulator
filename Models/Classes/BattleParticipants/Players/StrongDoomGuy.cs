using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Enumerators;
using Game.Models.Classes.BattleActions;

namespace Game.Models.Classes.BattleParticipants
{
    public class StrongerDoomGuy : BattleParticipant
    {
        public StrongerDoomGuy() : base(1000, "Stronger Doomguy.", "Players", new List<ElementAffinity>
        {
            //this is for the armor he has on. lol.
            new ElementAffinity(AffinityType.Resistant,Element.Physical,0.5m),
            new ElementAffinity(AffinityType.Resistant,Element.Fire,0.5m)

        }, new List<BattleAction>
        {
            new DoomGuySuperShotgunBlast(),
            new DoomGuyBFG9000Attack()
        })
        { }
    }
}
