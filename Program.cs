
using Game.Helpers;
using Game.Instances;
namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting battle simulator!");
            BattleInstance instance = new BattleInstance(GameGeneratorHelper.GenerateParticipants());
            instance.Battle();
        }
    }
  
}