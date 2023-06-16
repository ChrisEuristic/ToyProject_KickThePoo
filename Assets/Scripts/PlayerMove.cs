using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public static Rigidbody2D playerRigid;
    public static SpriteRenderer spriteRenderer;
    public static Animator playerAnim;
    public static float energy = 0.1f;

    float halfWidth = Screen.width;
    float movement, moveSpeed = 5, deadTimer;
    GameObject energyBar;
    
    void Awake() {
        playerRigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        energyBar = GameObject.Find("ScoreCanvas/Slider");
    }

    void Update(){
        if(energy <= 0){
            deadTimer += Time.deltaTime;

            if(deadTimer > 1){
                SceneManager.LoadScene("GameOverScene");
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(Input.mousePosition.x < Screen.width * 0.5f & Input.mousePosition.y < Screen.height * 0.9f)
            {
                spriteRenderer.flipX = false;
                playerRigid.velocity = new Vector2(0.5f * playerRigid.velocity.normalized.x, playerRigid.velocity.y);
                energy -= 1 * Time.deltaTime;
            }
            else if(Input.mousePosition.x < Screen.width * 0.25f){
                spriteRenderer.flipX = false;
                playerRigid.velocity = new Vector2(0.5f * playerRigid.velocity.normalized.x, playerRigid.velocity.y);
                energy -= 1 * Time.deltaTime;
            }
            else if(Input.mousePosition.x >= Screen.width * 0.5f & Input.mousePosition.y < Screen.height * 0.9f){
                spriteRenderer.flipX = true;
                playerRigid.velocity = new Vector2(0.5f * playerRigid.velocity.normalized.x, playerRigid.velocity.y);
                energy -= 1 * Time.deltaTime;
            }
            else if(Input.mousePosition.x > Screen.width * 0.75f){
                spriteRenderer.flipX = true;
                playerRigid.velocity = new Vector2(0.5f * playerRigid.velocity.normalized.x, playerRigid.velocity.y);
                energy -= 1 * Time.deltaTime;
            }
        }

        if(Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x < Screen.width * 0.5f & Input.mousePosition.y < Screen.height * 0.9f)
            {
                float h = -7000 * Time.deltaTime;
                playerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
                
            }
            else
            {
                float h = 7000 * Time.deltaTime;
                playerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            playerRigid.velocity = Vector2.zero;
        }

        //Walking Animation
        if(playerRigid.velocity.normalized.x == 0)
            playerAnim.SetBool("isWalking", false);
        else
            playerAnim.SetBool("isWalking", true);

        // Tracking Energy Bar
        energyBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
    }

    void FixedUpdate() {
        if(playerRigid.velocity.x > maxSpeed){                                    // Right Max Speed
            playerRigid.velocity = new Vector2(maxSpeed, playerRigid.velocity.y);
        }
        else if(playerRigid.velocity.x < maxSpeed * (-1)){                        // Left Max Speed
            playerRigid.velocity = new Vector2(maxSpeed * (-1), playerRigid.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Carrot"){
            if(CarrotScript.carrotstatus == 0){
                Debug.Log("일반 당근을 먹음");
                GetComponent<AudioSource>().Play();
                Score.carrot++;
                Score.score += Mathf.RoundToInt(Mathf.Pow((float)Stage.stagelevel, 0.25f)) * 2;
                energy += 0.15f;
                if(energy >= 1){
                    energy = 1;
                }
                CarrotScript.carrotstatus = 0;
                MakeCarrot.isBeingCarrot = false;
                Destroy(collision.gameObject);
            }
            else if(CarrotScript.carrotstatus == 1){
                Debug.Log("유기농 당근을 먹음");
                GetComponent<AudioSource>().Play();
                Score.organic++;
                Score.score += Mathf.RoundToInt(Mathf.Pow((float)Stage.stagelevel, 2f) / 10) + 10;
                energy = 1;
                CarrotScript.carrotstatus = 0;
                MakeCarrot.isBeingCarrot = false;
                Destroy(collision.gameObject);
            }
            else if(CarrotScript.carrotstatus == 2){
                Debug.Log("썩은 당근을 먹음");
                GetComponent<AudioSource>().Play();
                energy = 0;
                CarrotScript.carrotstatus = 0;
                MakeCarrot.isBeingCarrot = false;
                Destroy(collision.gameObject);
            }
        }
    }
}
