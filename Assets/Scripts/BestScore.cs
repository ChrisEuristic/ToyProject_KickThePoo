using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    GameManager gameMgr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.score > Score.bestscore){
            Score.bestscore = Score.score;
            PlayerPrefs.SetInt("BestScore", Score.bestscore);
            PlayerPrefs.Save();
        }
        else{
            Score.bestscore = PlayerPrefs.GetInt("BestScore");
        }
        GetComponent<Text>().text = "Best Score : " + Score.bestscore.ToString();
    }
}
