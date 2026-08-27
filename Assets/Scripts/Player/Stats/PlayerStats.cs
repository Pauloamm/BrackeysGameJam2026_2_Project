using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float moveSpeed = 6;
    public int maxHealth = 5;
    public int maxShields = 1;
}
