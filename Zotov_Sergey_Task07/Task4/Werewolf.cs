namespace Task4
{
    class Werewolf : Enemies, IAbility
    { 
        public Werewolf(int startPositionX, int startPositionY) :
            base(startPositionX, startPositionY)
        {

        }

        public void CastAbility() => new Wolf((X + randomPosition.Next(0, X)),
               (Y + randomPosition.Next(0, Y)));
    }
}
