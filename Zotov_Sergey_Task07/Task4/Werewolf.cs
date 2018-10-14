namespace Task4
{
    class Werewolf : Enemies, IAbility
    { 
        public Werewolf(string startPositionX, string startPositionY) :
            base(startPositionX, startPositionY)
        {

        }

        public void CastAbility()
        {
           Wolf wolf = new Wolf((X + 1).ToString(), (Y + 1).ToString());
        }
       

    }
}
