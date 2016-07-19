using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private Rigidbody2D rigidbody2D;

	public float move;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis("Horizontal");
	}

	private void Update()
	{
		if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
		rigidbody2D.velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();


		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		/*if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}*/
	}

	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}