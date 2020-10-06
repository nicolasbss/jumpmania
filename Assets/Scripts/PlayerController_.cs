using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController_ : MonoBehaviour
{   

    

    private float topScore = 0.0f;
    private float topHeight = 0.0f;
    public Text scoreText;

    private Rigidbody2D rb2d;
    private float moveInputx;
    public GameObject moedaPrefab;
    
    private BoxCollider2D boxCollider;

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.layer == LayerMask.NameToLayer("Coins")) {
           SoundManager.PlaySound("coin");
           Destroy(other.gameObject);
           topScore = topScore + 10;         
        }
    }

    private float speed = 10f;

    public bool doubleJumped; // informa se foi feito um pulo duplo
    public bool isDucking;
 	public bool isGrounded;		// Se está no chão
 	public bool isJumping;		// Se está pulando
    public bool isFalling;      // Se estiver caindo
   

    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {  
        
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update(){
        if(rb2d.velocity.y > 0 && transform.position.y > topHeight)
        {   
            topHeight = transform.position.y;
            topScore += 1;
        }

        scoreText.text = "SCORE: " + Mathf.Round(topScore).ToString();

        if(transform.position.y < -5)
        {   
            SoundManager.PlaySound("gameOver");
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        moveInputx = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInputx * speed, rb2d.velocity.y);
        isGrounded = false;
        if(moveInputx < 0) {     
 
            
            
            transform.localRotation = Quaternion.Euler(0, 180, 0);
          
	    }
	    else if(moveInputx > 0)
        {
            
          
            transform.localRotation = Quaternion.Euler(0, 0, 0);
           

        }

        if(rb2d.velocity.y < 0)
        {
           isFalling = true;
           isJumping = false;
        }
        else if (rb2d.velocity.y >= 0)
        {
           isFalling = false;
           isJumping = true;
        }
        animator.SetFloat("movementX", moveInputx); // +Normalizado
        animator.SetFloat("movementY", rb2d.velocity.y);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFalling", isFalling);
       

    }
}
