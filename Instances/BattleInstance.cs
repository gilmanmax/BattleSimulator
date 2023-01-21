using Game.Helpers;
using Game.Models.Enumerators;
using Game.Models.Classes.BattleParticipants;

namespace Game.Instances
{
    /// <summary>
    /// A battle instance
    /// </summary>
    public class BattleInstance
    {
        public List<BattleParticipant> Combatants { get; set; }
        /// <summary>
        /// This is the participant whose turn it is
        /// </summary>
        public BattleParticipant ActiveCombatant { get; set; }

        public BattleInstance(List<BattleParticipant> combatants)
        {
            if (combatants == null || combatants.Count == 0)
            {
                throw new Exception("You cannot set up an instance without friends or enemies!");
            }
            //generate the order.
            Combatants = BattleHelpers.ShuffleTheList(combatants).ToList();
            //the first in the list goes first
            ActiveCombatant = Combatants[0];
        }


        public void Battle()
        {
            //while there are still participants
            while (BattleHelpers.CheckForEnemyTeams(Combatants))
            {                
                if (ActiveCombatant.BattleActions.Count() == 0)
                {
                    Console.WriteLine("{0} has no actions and stares, doing nothing.", ActiveCombatant.Name);
                }
                else
                {
                    Random rand = new();
                    var actionIdx = rand.Next(0, ActiveCombatant.BattleActions.Count() - 1);
                    var action = ActiveCombatant.BattleActions.ElementAt(actionIdx);
                    //TODO: IMPLEMENT SPECIFIC TARGET IDS
                    IEnumerable<BattleParticipant> targets = BattleHelpers.GetTarget(ActiveCombatant, action, Combatants).Distinct();

                    //this loop performs one attach vs each target
                    foreach (BattleParticipant target in targets)
                    {
                        bool dies = target.OnActionPerformedAgainst(ActiveCombatant, action);
                        if (dies)
                        {
                            //remove target from combatants list
                            Combatants.Remove(target);
                        }
                    }
                }
                if (BattleHelpers.CheckForEnemyTeams(Combatants) == false)
                {
                    Console.WriteLine("The " + ActiveCombatant.TeamName + " wins!");
                    Console.ReadLine();
                    break;
                }
                //now determine next turn order
                ActiveCombatant = BattleHelpers.NextToMove(ActiveCombatant, Combatants);
            }
        }
    }
}
