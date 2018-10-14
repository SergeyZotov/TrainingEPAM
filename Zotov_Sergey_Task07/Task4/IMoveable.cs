namespace Task4
{
    interface IMoveable
    {
        int Lives { get; set; }
        double Damage { get; set; }
        int MoveSpeed { set; get; }
        bool TakeDamage(int enemyDamage);
        bool IsDealtDamage(int myDamage);
        bool GetMove(int coordinateX, int coordinateY);

    }
}
