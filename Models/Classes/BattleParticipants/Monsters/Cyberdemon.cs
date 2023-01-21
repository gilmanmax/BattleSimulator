using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Enumerators;
using Game.Models.Classes.BattleActions;

namespace Game.Models.Classes.BattleParticipants
{
    public class Cyberdemon : BattleParticipant
    {
        public Cyberdemon() : base(4000, "Cyberdemon", "Demons", new List<ElementAffinity>
        {
            new ElementAffinity(AffinityType.Resistant,Element.Fire,0.5m),
            new ElementAffinity(AffinityType.Absorbs,Element.Dark,0.5m),
            new ElementAffinity(AffinityType.Weak,Element.Holy,0.1m),
            new ElementAffinity(AffinityType.Resistant,Element.Earth,0.25m),
            new ElementAffinity(AffinityType.Resistant,Element.Physical,0.25m)
        }, new List<BattleAction>
        {
            new CyberdemonRocketTrio()
        })
        {
        }

    }
}
