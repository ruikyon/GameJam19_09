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
            Result.score = (int)(Player.instance.HideTime * 100 - UI.GetTime()*10);
            if (Result.score <= 0) Result.score = 100;
            SceneManager.LoadScene("End");
            Debug.Log("game clear");
        }
    }
}
