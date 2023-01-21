using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Enumerators;
using Game.Models.Classes.BattleActions;

namespace Game.Models.Classes.BattleParticipants
{
    public class BaronOfHell : BattleParticipant
    {
        public BaronOfHell(): base(1000, "Baron Of Hell", "Demons", new List<ElementAffinity>
        {
            new ElementAffinity(AffinityType.Resistant,Element.Fire,0.1m),
            new ElementAffinity(AffinityType.Immune,Element.Dark),
            new ElementAffinity(AffinityType.Weak,Element.Holy,0.1m),
            new ElementAffinity(AffinityType.Resistant,Element.Physical,0.05m)
        }, new List<BattleAction>
        {
            new BaronFireBall(),
            new BaronClaw()
        })
        { }

    }
}
