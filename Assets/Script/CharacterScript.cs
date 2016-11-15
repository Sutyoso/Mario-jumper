using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

    [SerializeField]
    private float jumpForce = 300f;
        
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
	/*
	 * pada method start ini terdapat constructor yang berguna untuk menginisialisasi animator dan rigidbody2d
	*/
	void Start () {
		myAnimator = GetComponent<Animator> ();
		this.myRigidbody = GetComponent<Rigidbody2D> ();
    }

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
		if (Input.GetKeyDown(KeyCode.S)) {
			slide = true;
		} else if (Input.GetKey(KeyCode.W)) {
			jump = true;
		}
	}
	/*
	 * dalam method handleMovement berisi command command untuk lompat dan slide
	 * dalam method ini juga berisi command command untuk mengganti animasi
	*/

	void handleMovement(){
		if (jump && isGrounded) {
			isGrounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
			this.myAnimator.SetBool ("isJumping", true);
		} else if (jump && !isGrounded) {
			isGrounded = true;
			jump = false;
			this.myAnimator.SetBool ("isJumping", false);
		}
		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			this.myAnimator.SetBool ("isSlide", true);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -jumpForce));
		} else if (!this.myAnimator.GetNextAnimatorStateInfo (0).IsName ("Slide")) {
			this.myAnimator.SetBool ("isSlide", false);
		}
	}
	/*
	 * method ini berisi command command untuk mengecek apakah character tersebut menginjak tanah atau tidak 
	*/

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

	/*
	 * method ini berisi instruksi jika character tabrakan dengan obstacle maka obstacle dan character akan difreeze
	*/
	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.name == "obs")
		{
		
			collider.gameObject.GetComponent<ObstacleMovement> ().isRun = false;
            Application.LoadLevel("Game Over");
            collider.gameObject.GetComponent<ObstacleMovement>().isRun = true;
            //collider.gameObject.GetComponent<char().isRun = false;
            collider.gameObject.GetComponent<ObstacleGenerate>().isRun = true;
            collider.gameObject.GetComponent<ScoreManager>().scoreIncreasing = true;


        }
    }
}
