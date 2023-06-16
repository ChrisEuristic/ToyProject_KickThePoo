using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotScript : MonoBehaviour
{
    Animator carrotAnim;
    public float transformCarrotTimeDiff;
    float timer = 0, carrotOverTime = 11;
    public static int carrotstatus = 0;

    void Awake() {
        carrotAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        transformCarrotTimeDiff = Stage.stagelevel + 5;

        if(MakeCarrot.isBeingCarrot){
            timer += Time.deltaTime;
        }

        if(timer > transformCarrotTimeDiff & carrotstatus == 0){
            carrotstatus = 1;
            Debug.Log("유기농 당근이 됨");
            carrotAnim.SetInteger("CarrotStatus", 1);
            GetComponent<AudioSource>().Play();
        }
        if(timer > transformCarrotTimeDiff + (carrotOverTime - Mathf.Sqrt(Stage.stagelevel)) & carrotstatus == 1){
            carrotstatus = 2;
            Debug.Log("당근이 썩음");
            carrotAnim.SetInteger("CarrotStatus", 2);
        }
        if(timer > transformCarrotTimeDiff + (carrotOverTime - Mathf.Sqrt(Stage.stagelevel)) + 10 & carrotstatus == 2){
            carrotstatus = 0;
            MakeCarrot.isBeingCarrot = false;
            Debug.Log("당근이 사라짐");
            carrotAnim.SetInteger("CarrotStatus", 0);
            Destroy(this.gameObject);
            timer = 0;
        }
    }
}
