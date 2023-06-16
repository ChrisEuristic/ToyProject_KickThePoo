using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveScore()
    {
        if(!PlayerPrefs.HasKey("BestScore")){
            PlayerPrefs.SetInt("BestScore", Score.bestscore);
            Debug.Log("Best Score 없어서 추가함.");
        }
        else{
            Score.bestscore = PlayerPrefs.GetInt("BestScore");
            Debug.Log("Best Score 있음.");
        }
            
    }
}
