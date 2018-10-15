namespace Task4
{
    internal class ClawsOfDeath : Enemies, IAbility
    {
        private protected int increaseDamageAbility;

        public ClawsOfDeath(string startPositionX, string startPositionY) : 
            base(startPositionX, startPositionY)
        {

        }

        public void CastAbility()
        {
            MoveSpeed += 1;
        }
    }
}
