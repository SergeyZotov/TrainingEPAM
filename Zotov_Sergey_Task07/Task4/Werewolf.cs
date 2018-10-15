namespace Task4
{
    class Werewolf : Enemies, IAbility
    { 
        public Werewolf(string startPositionX, string startPositionY) :
            base(startPositionX, startPositionY)
        {

        }

        public void CastAbility() => new Wolf((X + randomPosition.Next(0, X)).ToString(),
               (Y + randomPosition.Next(0, Y)).ToString());
    }
}
