using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public static int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(score < 0)
        {
            scoreText.text = "Game Over";
        }
        else
        {
            scoreText.text = "Game Clear\nscore: " + score;
            GetComponent<Animator>().SetBool("Running", true);
        }
    }
}
