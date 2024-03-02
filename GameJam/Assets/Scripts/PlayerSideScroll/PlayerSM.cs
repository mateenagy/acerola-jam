using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSM : MonoBehaviour
{
	PlayerState currentState;
	PlayerFactory factory;
	Rigidbody2D rb;

	[Header("Essentials")]
	[SerializeField] float groundCheckRadius = 1f;
	[SerializeField] Vector3 groundCheckOffset;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] LayerMask instantDeathLayer;
	[SerializeField] Transform restartPoint;
	[SerializeField] bool isGrounded = false;
	[Header("Movement")]
	[SerializeField] float speed = 1;
	float inputX;
	bool isMoving = false;

	[Header("Jump")]
	[SerializeField] float jumpHeight = 3f;
	bool isJumping = false;

	[Header("Fall")]
	bool isFall = false;
	[Header("Clone")]
	[SerializeField] GameObject clonePrefab;

	#region GETTERS/SETTERS
	public PlayerState CurrentState { get => currentState; set => currentState = value; }
	public Rigidbody2D Rb { get => rb; set => rb = value; }
	public float Speed { get => speed; set => speed = value; }
	public float InputX { get => inputX; set => inputX = value; }
	public bool IsMoving { get => isMoving; set => isMoving = value; }
	public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
	public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
	public bool IsJumping { get => isJumping; set => isJumping = value; }
	public bool IsFall { get => isFall; set => isFall = value; }
	#endregion

	void Awake()
	{
		factory = new PlayerFactory(this);
		currentState = factory.States[PlayerStates.Ground];
		rb = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		CurrentState.EnterStates();
	}

	void Update()
	{
		InputX = Input.GetAxisRaw("Horizontal");
		IsMoving = InputX > 0 || InputX < 0;
		IsGrounded = CheckGround();
		IsFall = !IsGrounded && Rb.velocity.y < 0;

		if (Input.GetKeyDown(KeyCode.X))
		{
			Instantiate(clonePrefab, transform.position, transform.rotation);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			IsJumping = true;
		}

		if (IsInstaDeath())
		{
			transform.position = restartPoint.position;
		}

		CurrentState.UpdateStates();
	}

	bool CheckGround()
	{
		return Physics2D.OverlapCircle(transform.position + groundCheckOffset, groundCheckRadius, groundLayer);
	}

	bool IsInstaDeath()
	{
		return Physics2D.OverlapCircle(transform.position + groundCheckOffset, groundCheckRadius, instantDeathLayer);
	}

	void FixedUpdate()
	{
		CurrentState.FixedUpdateStates();
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position + groundCheckOffset, groundCheckRadius);
	}
}
