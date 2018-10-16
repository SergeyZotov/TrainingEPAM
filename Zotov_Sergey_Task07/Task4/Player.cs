namespace Task4
{
    sealed internal class Player : GameObject, IMoveable
    {
        public Player player; 

        public Player(int startPositionX = 0, int startPositionY = 0) : 
            base(startPositionX, startPositionY)
        {
            player = new Player();
        }

        public bool GetMove(int coordinateX, int coordinateY) => default;

        public bool Life { private set; get; }

        public bool TakeDamage() => default;

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public int MoveSpeed { get; set; }


    }
}
