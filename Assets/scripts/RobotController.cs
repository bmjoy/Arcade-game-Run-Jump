using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float maxSpeed = 3f;
	float speed;
	//a boolean value to represent whether we are facing left or not
	bool facingLeft = false;
	//a value to represent our Animator
	Animator anim;
        //to check ground and to have a jumpforce we can change in the editor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	public float jumpForce = 300f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		controleScene.resume = true;
		//set anim to our animator
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent <Animator>();

	}
	
	
	void FixedUpdate () {
		if (controleScene.resume) {
			//set our vSpeed
			anim.enabled=true;
			anim.SetFloat ("vSpeed", rb.velocity.y);
			//set our grounded bool
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			//set ground in our Animator to match grounded
			anim.SetBool ("Ground", grounded);
		} else {
			anim.enabled=false;
		}
	}

	void Update(){
		if (controleScene.resume) {
			MovePlayer (speed);
			//inputManager ();
		}
		
	}
	void MovePlayer(float playerSpeed){
		rb.velocity = new Vector3 (playerSpeed, rb.velocity.y);	
		anim.SetFloat ("Speed",Mathf.Abs (playerSpeed));
	}
	//flip if needed
	void Flip(bool left){
		if (left != facingLeft) {
			facingLeft = !facingLeft;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	public void btnRightDown(){
		Flip (false);
		//rb.velocity = new Vector3 (4, rb.velocity.y);	
		speed = maxSpeed;
	}
	public void btnLeftDown(){
		Flip (true);
		speed = -maxSpeed;
	}
	public void btnRightUp(){
		speed = 0;
	}
	public void btnLeftUp(){
		speed = 0;
	}
	public void btnJump(){
		if(grounded ){
			anim.SetBool("Ground",false);
			rb.AddForce (new Vector2(0,jumpForce));
		}
	}
	void inputManager(){
		//if we are on the ground and the space bar was pressed, change our ground state and add an upward force
		if(grounded && Input.GetKeyDown (KeyCode.UpArrow)){
			anim.SetBool("Ground",false);
			rb.AddForce (new Vector2(0,jumpForce));
		}

		float move = Input.GetAxis ("Horizontal");//Gives us of one if we are moving via the arrow keys
		//move our Players rigidbody
		rb.velocity = new Vector3 (move * maxSpeed, rb.velocity.y);	
		//set our speed
		anim.SetFloat ("Speed",Mathf.Abs (move));
		//if we are moving left but not facing left flip, and vice versa
		if (move < 0 && !facingLeft) {

			Flip (true);
		} else if (move > 0 && facingLeft) {
			Flip (false);
		}
	}
}