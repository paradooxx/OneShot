using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletGameObject;
    private GameObject[] enemyGameObject;

    private void Awake()
    {
       enemyGameObject = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void CheckBulletStatus()
    {
        if(bulletGameObject == null)
        {
            GameLoseStatus();
        }
    }

    private void CheckEnemyStatus()
    {
        if(enemyGameObject.Length == 0)
        {
            GameWinStatus();
        }
    }

    private void GameWinStatus()
    {
        throw new NotImplementedException();
    }

    private void GameLoseStatus()
    {
        throw new NotImplementedException();
    }
}
