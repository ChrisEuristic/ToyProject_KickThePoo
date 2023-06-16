using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCarrotSound : MonoBehaviour
{
    public void EatCarrotSoundFunction(){
        if(Score.organic != 0){
            Score.organic--;
            GetComponent<AudioSource>().Play();
        }
        
    }
}
