using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController_ : MonoBehaviour
{   

    private Rigidbody2D rb2d;
    private float moveInputx;
    public GameObject moedaPrefab;
    
    public AudioClip coin;
    private BoxCollider2D boxCollider;

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.layer == LayerMask.NameToLayer("Coins")) {
           AudioSource.PlayClipAtPoint(coin, this.gameObject.transform.position);
           Destroy(other.gameObject);
          
        }
    }

    private float speed = 10f;

    public bool doubleJumped; // informa se foi feito um pulo duplo
    public bool isDucking;
 	public bool isGrounded;		// Se está no chão
 	public bool isJumping;		// Se está pulando
    public bool isFalling;      // Se estiver caindo
    public bool isFacingRight;      // Se está olhando para a direita

    private Animator animator;


    private float topScore = 0.0f;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {  
        
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update(){
        if(rb2d.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }

        scoreText.text = "SCORE: " + Mathf.Round(topScore).ToString();

        if(transform.position.y < -5)
        {
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        moveInputx = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInputx * speed, rb2d.velocity.y);
        Debug.Log(moveInputx);
        if(moveInputx < 0) {
            isFacingRight = false;
	    }
	    else if(moveInputx > 0)
        {
            isFacingRight = true;
        }

        if(rb2d.velocity.y < 0)
        {
           isFalling = true;
        }
        else
        {
           isFalling = false;
        }
        animator.SetFloat("movementX", moveInputx); // +Normalizado
    
        animator.SetBool("isFalling", isFalling);

    }
}
