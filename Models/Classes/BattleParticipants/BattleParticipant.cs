using Game.Interfaces;
using Game.Models.Classes.BattleActions;
using Game.Models.Enumerators;

namespace Game.Models.Classes.BattleParticipants
{
    public abstract class BattleParticipant : IDestroyable, ICloneable
    {
        public int ID { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public string Name { get; set; }
        public int TurnOrder { get; set; }
        /// <summary>
        /// Used to determine what team the participant is in. Same names may not attack each other, different numbers are enemies.
        /// </summary>
        public string TeamName { get; set; }

        public IEnumerable<ElementAffinity> ElementalAffinities { get; set; }

        public IEnumerable<BattleAction> BattleActions { get; protected set; }

        /// <summary>
        /// Use this if any affinities exist.
        /// </summary>
        public BattleParticipant(int maxHP, string name, string teamName, IEnumerable<ElementAffinity> affinities, IEnumerable<BattleAction> battleActions)
        {
            MaxHP = maxHP;
            HP = maxHP;
            Name = name;
            ElementalAffinities = affinities;
            BattleActions = battleActions;
            TeamName = teamName;
        }
        /// <summary>
        /// Use this constructor if neutral to all elements.
        /// </summary>
        public BattleParticipant(int maxHP, string name, string teamName, List<BattleAction> battleActions)
        {
            MaxHP = maxHP;
            HP = maxHP;
            Name = name;
            BattleActions = battleActions;
            ElementalAffinities = new List<ElementAffinity>();
            TeamName = teamName;
        }

        /// <summary>
        /// Runs when at attack is made against participant.
        /// </summary>
        /// <param name="action"></param>
        /// <returns>True if the participant dies.</returns>
        public bool OnActionPerformedAgainst(BattleParticipant sender, BattleAction action)
        {

            if (action.ActionType == ActionType.Attack)
            {
                ///check for affinities
                var affinity = ElementalAffinities.FirstOrDefault(p => p.Element == action.Element);
                if (affinity == null)
                {
                    Console.WriteLine("{0} was attacked by {1} with {2} for {3} damage!", Name, sender.Name, action.Name, action.BasePower);
                    HP -= action.BasePower;
                }
                else if (affinity.AffinityType == AffinityType.Absorbs)
                {
                    int healAmt = OnHeal(action.BasePower, affinity.AffinityStrength);
                    Console.WriteLine("{0} was attacked by {1} with {2} and absorbs the attack for {4} HP!", Name, sender.Name, action.Name, healAmt);
                }
                //since Affinity Strength 0<x<1, use multiply for resistance
                else if (affinity.AffinityType == AffinityType.Resistant)
                {
                    
                    var totalDmg = Convert.ToInt32(action.BasePower * (1-affinity.AffinityStrength));
                    Console.WriteLine("{0} was attacked by {1} with {2}!! {0} resists the attack and takes {3} damage!", Name, sender.Name, action.Name, totalDmg);
                    HP -= totalDmg;
                }
                else if (affinity.AffinityType == AffinityType.Immune)
                {
                    Console.WriteLine("{0} was attacked by {1} with {2} but {0} is completely immune!", Name, sender.Name, action.Name);
                }
                //since Affinity Strength 0<x<1, use divide for weakness.
                else if (affinity.AffinityType == AffinityType.Weak)
                {
                    var totalDmg = Convert.ToInt32(action.BasePower / (1-affinity.AffinityStrength));
                    Console.WriteLine("{0} was attacked by {1} with {2}!! {0} is weak against the attack and takes {3} damage!", Name, sender.Name, action.Name, totalDmg);
                    HP -= totalDmg;
                }
            }
            else if (action.ActionType == ActionType.Healing)
            {
                int healAmt = OnHeal(action.BasePower);
                Console.WriteLine("{0} was healed by {1} with {2} for {3} HP!", Name, sender.Name, action.Name, healAmt);
                HP += healAmt;
            }
            else if (action.ActionType == ActionType.Buff || action.ActionType == ActionType.Other || action.ActionType == ActionType.Debuff)
            {
                throw new NotImplementedException("Sorry, these are not implemented yet.");
            }
            if (HP < 0)
            {
                OnDestroy();
                return true;
            }
            else
            {
                return false;
            }
        }
        public int OnHeal(int healAmt, decimal affinityStrength = 1)
        {
            var hpAfterAction = HP + Convert.ToInt32(healAmt * affinityStrength);
            var hpAfterHealing = hpAfterAction > MaxHP ? MaxHP : hpAfterAction;
            var actualAmtHealed = hpAfterHealing - HP;
            HP = hpAfterHealing;
            return actualAmtHealed;
        }
        public virtual void OnDestroy()
        {
            Console.WriteLine(Name + " dies!");
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
