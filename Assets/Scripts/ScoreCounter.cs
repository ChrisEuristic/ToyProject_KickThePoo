using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Enemy"){
            Destroy(col.gameObject, 0);
            
            Score.score++;
            Score.kickthepoo++;
        }
    }
}
