using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Result.score = 100;
            SceneManager.LoadScene("End");
            Debug.Log("game clear");
        }
    }
}
