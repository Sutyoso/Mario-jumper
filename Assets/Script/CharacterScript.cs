using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	[SerializeField]
	private float jumpForce=300f;

	private bool isGrounded;

	private bool jump;

	private bool slide;

	private Animator myAnimator;

	private Rigidbody2D myRigidbody; 

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		this.myRigidbody = GetComponent<Rigidbody2D> ();
	}


	//void onCollisionEnter2D(Collision2D coll){
	//	if (coll.gameObject.tag == "ground") {
	//		isGrounded = true;
	//	}
	//}

	// Update is called once per frame
	void Update () {
		handleInput ();
	}

	void FixedUpdate(){
		isGrounded = groundedChecker ();

		handleMovement ();

		resetValue ();
	}

	void handleInput(){
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			slide = true;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			jump = true;
		}
	}

	void handleMovement(){
		if (jump && isGrounded) {
			isGrounded = false;
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,jumpForce));
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
			this.myAnimator.SetBool ("isJumping", true);
		} else if (jump && !isGrounded) {
			isGrounded = true;
			jump = false;
			this.myAnimator.SetBool ("isJumping", false);
		}
		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			this.myAnimator.SetBool ("isSlide", true);
		} else if (!this.myAnimator.GetNextAnimatorStateInfo (0).IsName ("Slide")) {
			this.myAnimator.SetBool ("isSlide", false);
		}
	}

	private bool groundedChecker(){
		if (myRigidbody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] coll = Physics2D.OverlapCircleAll (point.position, groundRadius,whatIsGround);

				for (int i = 0; i < coll.Length; i++) {
					if (coll [i].gameObject != gameObject) {
						return true;
					}
				}
			}
		}
		return false;
	}

	void resetValue(){
		this.jump = false;
		this.slide = false;

	}
}
