using Game.Models.Classes.BattleParticipants;
namespace Game.Helpers
{
    /// <summary>
    /// This can be edited by dev. **TODO: MAKE FILE FRIENDLY**
    /// </summary>
    public static class GameGeneratorHelper
    {
        public static List<BattleParticipant> BattleParticipants = new List<BattleParticipant>();
        public static List<BattleParticipant> GenerateParticipants()
        {
            GenerateParticipants(new Doomguy(), 4);
            GenerateParticipants(new BaronOfHell(), 1);
            return BattleParticipants;
        }
        static void GenerateParticipants(BattleParticipant p, int number)
        {

            for(int i = 0; i < number; i++)
            {
                var cpy = (BattleParticipant)p.Clone();
                cpy.Name += "#" + (i + 1);
                BattleParticipants.Add(cpy);
            }
        }
    }
}
