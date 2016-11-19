using UnityEngine;
using System.Collections;
/// <summary>
/// kelas ini berguna untuk mengatur semua pergerakan dari character
/// </summary>
public class CharacterScript : MonoBehaviour
{

    [SerializeField]
    private float jumpForce = 300f;

    private bool isGrounded;
    private bool jump;
    private bool slide;
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxColl;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    /// <summary>
    /// pada method start ini terdapat constructor yang berguna untuk menginisialisasi animator dan rigidbody2d juga BoxCollider2D
    /// </summary>
    public void Start()
    {
        myAnimator = GetComponent<Animator>();
        this.myRigidbody = GetComponent<Rigidbody2D>();
        this.myBoxColl = GetComponent<BoxCollider2D>();

    }

    /// <summary>
    ///    Update is called once per frame
    ///    methods untuk membungkus methods handleInput();
    /// </summary>

    public void Update()
    {
        handleInput();
    }

    public void FixedUpdate()
    {
        isGrounded = groundedChecker();
        handleMovement();
        resetValue();
    }
    /// <summary>
    /// mengatur input dari user
    /// </summary>
    private void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            slide = true;
            this.myBoxColl.size = new Vector2(2.32f, 3f);
            this.myAnimator.SetBool("isSlide", true);
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            slide = false;
            this.myBoxColl.size = new Vector2(2.32f, 4.39f);
            this.myAnimator.SetBool("isSlide", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            jump = true;
            this.myAnimator.SetBool("isJumping", true);
        }
    }
    /// <summary>
    /// dalam method handleMovement berisi command command untuk lompat dan slide
    /// dalam method ini juga berisi command command untuk mengganti animasi
    /// </summary>

    private void handleMovement()
    {
        if (jump && isGrounded)
        {
            GetComponent<AudioSource>().Play();
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        if (jump && !isGrounded)
        {
            isGrounded = true;
            this.myAnimator.SetBool("isJumping", false);
        }
    }
    
    /// <summary>
    ///  method ini berisi command command untuk mengecek apakah character tersebut menginjak tanah atau tidak 
    /// </summary>
    /// <returns>
    /// mengembalikan true jika collider menyentuh tanah dan false jika tidak menyentuh tanah
    /// </returns>
    /// 

    private bool groundedChecker()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] coll = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < coll.Length; i++)
                {
                    if (coll[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    /// <summary>
    /// 
    /// mereset value dari jump dan slide
    /// </summary>
    private void resetValue()
    {
        this.jump = false;
        this.slide = false;

    }

    /// <summary>
    /// method ini berisi instruksi jika character tabrakan dengan obstacle maka obstacle dan character akan difreeze
    /// </summary>
    /// <param name="collider">
    /// merupakan collider dari obstacle
    /// </summary>
    /// mengganti scene dari scene Runner menjadi Scene Game Over
    /// membuat Obstacle menjadi dapat berjalan lagi
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "obs")
        {
            collider.gameObject.GetComponent<ObstacleMovement>().isRun = false;
            Application.LoadLevel("Game Over");
            collider.gameObject.GetComponent<ObstacleMovement>().isRun = true;
        }
    }
}
