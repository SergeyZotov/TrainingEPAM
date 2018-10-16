namespace Task4
{
    interface IMoveable
    {
        int MoveSpeed { set; get; }
        bool GetMove(int coordinateX, int coordinateY);
        void Move();
    }
}
