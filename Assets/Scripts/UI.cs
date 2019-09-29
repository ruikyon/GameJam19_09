using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI time, left;
    private float start;

    private void Start()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time.text = ((int)(Time.time - start)).ToString();
        left.text = ((int)Player.instance.HideTime).ToString();
    }
}
