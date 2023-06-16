using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score, bestscore, organic, carrot, kickthepoo;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score : " + score.ToString();
    }
}
