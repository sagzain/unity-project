public interface IKillable
{
    int Health { get; set; }
    void TakeDamage(int amount);
    void Death();
}
