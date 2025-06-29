using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FortressHealth : MonoBehaviour
{
    public enum Team { Blue, Red }
    public Team team;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnFortressDestroyed();
        }
    }

    private void OnFortressDestroyed()
    {
        if (team == Team.Blue)
        {
            // 蓝色堡垒被摧毁，加载失败场景
            SceneManager.LoadScene("loose");
        }
        else if (team == Team.Red)
        {
            // 红色堡垒被摧毁，加载胜利场景
            SceneManager.LoadScene("victory");
        }
    }

    // 可选：显示血量的UI
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}

