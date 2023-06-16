using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickThePoo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            
            Animator rabbieAnim;

            rabbieAnim = this.GetComponentInParent<Animator>();
            rabbieAnim.SetBool("isKick", true);

        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            
            Animator rabbieAnim;

            rabbieAnim = this.GetComponentInParent<Animator>();
            rabbieAnim.SetBool("isKick", false);
        }
    }
}
