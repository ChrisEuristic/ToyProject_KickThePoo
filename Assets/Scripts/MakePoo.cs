using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePoo : MonoBehaviour
{
    public GameObject poo;
    public float timeDiff = 1;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if(Stage.stagelevel >= 1){
            timer += Time.deltaTime;

            if(timer > timeDiff){
                GameObject newpoo = Instantiate(poo);
                newpoo.GetComponent<Rigidbody2D>().gravityScale = Mathf.Pow(Stage.stagelevel, 0.25f) * 0.5f;
                newpoo.transform.position = new Vector3(Random.Range(-2.4f, 2.4f), 5, 0);
                timeDiff = (1 / Mathf.Pow(Stage.stagelevel, 0.25f)) * Random.Range(0.5f, 1.0f);
                timer = 0;
            }
        }        
    }
}
