namespace Task4
{
    sealed internal class Player : Objects, IMoveable
    {
        private int damage;
        private int lives;

        public Player player = new Player();

        public Player(string startPositionX = "0", string startPositionY = "0") : 
            base(startPositionX, startPositionY)
        {

        }

        public bool GetMove(int coordinateX, int coordinateY)
        {
            return default;
        }

        public double Damage
        {
            set;
            get;
        }

        public int Lives
        {
            set;
            get;
        }

        public bool TakeDamage(int enemyDamage)
        {
            return default;
        }

        public bool IsDealtDamage(int myDamage)
        {
            return default;
        }

        public int MoveSpeed
        {
            set;
            get;
        }
    }
}
