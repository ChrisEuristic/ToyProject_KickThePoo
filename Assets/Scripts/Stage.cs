using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public static int stagelevel = 0, nextStageScore = 10;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stagelevel == 0){
            GetComponent<Text>().text = "Ready";
            timer += Time.deltaTime;

            if(timer > 5){
                stagelevel = 1;
                GetComponent<AudioSource>().Play();
            }
        }
        else if(Score.score >= nextStageScore){
            nextStageScore += 10 * Mathf.RoundToInt(Mathf.Pow((float)stagelevel, 0.25f));
            stagelevel++;
            GetComponent<AudioSource>().Play();
        }
        else
            GetComponent<Text>().text = "Stage  " + stagelevel.ToString();
    }
}
