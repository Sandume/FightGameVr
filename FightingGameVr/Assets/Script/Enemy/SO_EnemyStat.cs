using UnityEngine;

[CreateAssetMenu(fileName = "SO_EnemyStat", menuName = "Scriptable Objects/SO_EnemyStat")]
public class SO_EnemyStat : ScriptableObject
{
   public enum Type 
    {
        Soldier,
        Mage,
        Archer
    }

    public int maxHp;
    public float speed;
    public float range;
    public Type type;
    public int dammage;
}
