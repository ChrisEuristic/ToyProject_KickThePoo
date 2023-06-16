using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Timers;

public class HeadHittedPoo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            PlayerMove.energy -= 0.3f;

            Rigidbody2D pooRigid;
            Animator pooAnim;
            GameObject poo;

            poo = other.gameObject;
            Destroy(poo, 0.5f);
            pooRigid = other.gameObject.GetComponent<Rigidbody2D>();

            pooAnim = other.gameObject.GetComponent<Animator>();
            other.gameObject.GetComponent<AudioSource>().Play();

            pooRigid.bodyType = RigidbodyType2D.Static;

            pooAnim.SetBool("isCollision", true);
        }
    }
}
