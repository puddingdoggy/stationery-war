using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class ehome : MonoBehaviour
{
    public GameObject enemy;

    void Update()
    {
        if (!enemy)
        {
            SceneManager.LoadScene("loose");
        }
    }
}

