using Game.Models.Classes.BattleActions;
using Game.Models.Classes.BattleParticipants;
using Game.Models.Enumerators;

namespace Game.Helpers
{
    public static class BattleHelpers
    {
        /// <summary>
        /// Shuffles the list randomly
        /// </summary>
        /// <param name="participants"></param>
        public static IEnumerable<BattleParticipant> ShuffleTheList(this IEnumerable<BattleParticipant> participants)
        {
            Random random = new();
            return participants.OrderBy(_ => random.Next()).ToList();
        }
        /// <summary>
        /// Checks to see if all remaining participants are on the same team.
        /// </summary>
        /// <returns></returns>
        public static bool CheckForEnemyTeams(IEnumerable<BattleParticipant> participants)
        {
            return participants.Select(p => p.TeamName).Distinct().Count() > 1;
        }

        public static BattleParticipant NextToMove(BattleParticipant current, List<BattleParticipant> participants)
        {
            int idx;
            if (participants.Contains(current) == false) { idx = 0; }
            else
            {
               idx = participants.IndexOf(current);
            }
            //if the last participant took their turn, the first is next
            if (idx == participants.Count - 1) { return participants[0]; }
            else
            {
                //the next participant goes!
                return participants[idx+1];
            }
        }

        /// <summary>
        /// Gets the target(s) of an attack.
        /// </summary>
        public static IEnumerable<BattleParticipant> GetTarget(BattleParticipant sender, BattleAction action, IEnumerable<BattleParticipant> participants, IEnumerable<int> SpecificTargetIDs = null)
        {
            List<BattleParticipant> targets = new List<BattleParticipant>();
            int cnt = 0;
            int numToTake = 0;
            //determine how many targets 
            int maxTargets = participants.Count() > action.NumberTargets ? participants.Count() : action.NumberTargets;
            switch (action.ActionType)
            {
                case ActionType.Attack:
                case ActionType.Debuff:
                    participants = participants.Where(p => p.TeamName != sender.TeamName);
                    break;
                case ActionType.Healing:
                case ActionType.Buff:
                    participants = participants.Where(p => p.TeamName == sender.TeamName);
                    break;
            }

            //now get the targets from id

            if (SpecificTargetIDs != null && SpecificTargetIDs.Count() > 0)
            {
                participants = participants.Where(p => SpecificTargetIDs.Contains(p.ID));
            }
            cnt = participants.Count();
            numToTake = action.NumberTargets > cnt ? cnt : action.NumberTargets;
            //order list
            participants.ShuffleTheList();
            return participants.Take(numToTake);
        }
            

    }
}
