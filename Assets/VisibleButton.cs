using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleButton : MonoBehaviour
{
    float timer = 0;
    public Button button;
    public Image image_rabbie;
    public Image image_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer <= 1f){
            button.image.color = new Color(1f, 1f, 1f, timer);
            image_rabbie.color = new Color(1f, 1f, 1f, timer);
            image_text.color = new Color(1f, 1f, 1f, timer);
        }
    }
}
