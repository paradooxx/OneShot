using System;
using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    public static event Action
        OnBulletDestroyed,
        OnEnemyDestroyed;
        
    public static void BulletDestroyed()
    {
        OnBulletDestroyed?.Invoke();
    }

    public static void EnemyDestroyed()
    {
        OnEnemyDestroyed?.Invoke();
    }
}
