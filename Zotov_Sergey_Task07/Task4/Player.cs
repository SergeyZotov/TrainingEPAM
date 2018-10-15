namespace Task4
{
    sealed internal class Player : Objects, IMoveable
    {
        public Player player; 

        public Player(string startPositionX = "0", string startPositionY = "0") : 
            base(startPositionX, startPositionY)
        {
            player = new Player();
        }

        public bool GetMove(int coordinateX, int coordinateY) => default;

        public bool Life { private set; get; }

        public bool TakeDamage() => default;

        public int MoveSpeed { get; set; }
    }
}
