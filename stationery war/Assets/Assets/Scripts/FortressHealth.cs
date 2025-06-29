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
            // ��ɫ���ݱ��ݻ٣�����ʧ�ܳ���
            SceneManager.LoadScene("loose");
        }
        else if (team == Team.Red)
        {
            // ��ɫ���ݱ��ݻ٣�����ʤ������
            SceneManager.LoadScene("victory");
        }
    }

    // ��ѡ����ʾѪ����UI
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}

