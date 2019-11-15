﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public Player player;
    static Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();
    static Dictionary<string, EnemyRange> rangeEnemies = new Dictionary<string, EnemyRange>();
    public GameObject gameoverUI;

    #region Singleton
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public static void RegisterPlayer(Player p)
    {
        player = p;
        player.transform.name = p.player_name;
    }

    public static void RegisterEnemy(string enemy_id, Enemy enemy)
    {
        enemies.Add(enemy_id, enemy);
        enemy.transform.name = enemy_id;
    }

    public static void RegisterRangeEnemy(string enemy_id, EnemyRange enemy)
    {
        rangeEnemies.Add(enemy_id, enemy);
        enemy.transform.name = enemy_id;
    }

    public static Enemy GetEnemy(string enemy_id)
    { 
        return enemies[enemy_id];
    }

    public static EnemyRange GetRangeEnemy(string enemy_id)
    {
        return rangeEnemies[enemy_id];
    }

    public static Player GetPlayer()
    {
        return player;
    }

    public static void UnregisterEnemy(string enemy_id)
    {
        Debug.Log("Unregistering: " + enemy_id);
        enemies.Remove(enemy_id);
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        gameoverUI.SetActive(true);
        Invoke("Restart", 3f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameObject player_object;
}
