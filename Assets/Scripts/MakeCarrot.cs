using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCarrot : MonoBehaviour
{
    public GameObject carrot;
    public float timeDiff = 15;
    float timer = 0, bonusCarrotTimer = 0;
    public static bool isBeingCarrot = false;
    void Start()
    {
    }

    void Update()
    {
        if(Stage.stagelevel == 0){
            bonusCarrotTimer += Time.deltaTime;
            if(bonusCarrotTimer >= 0.5f){
                GameObject newcarrot = Instantiate(carrot);
                Destroy(newcarrot, 5.0f);
                newcarrot.transform.position = new Vector3(Random.Range(-2.4f, 2.4f), 5, 0);
                bonusCarrotTimer = 0;
            }
        }
        if(!isBeingCarrot){
            timer += Time.deltaTime;
        }
        
        if(timer > 4){
            GameObject newcarrot = Instantiate(carrot);
            newcarrot.transform.position = new Vector3(Random.Range(-2.4f, 2.4f), 5, 0);
            isBeingCarrot = true;
            timer = 0;
        }
    }
}
