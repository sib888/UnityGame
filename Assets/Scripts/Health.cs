using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public void TakeHit(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
    }
}
