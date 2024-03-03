using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSM : MonoBehaviour
{
	PlayerState currentState;
	PlayerFactory factory;
	Rigidbody2D rb;
	Animator animator;

	[Header("Essentials")]
	[SerializeField] int availableClone = 3;
	[SerializeField] float groundCheckRadius = 1f;
	[SerializeField] Transform groundCheckTransform;
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
	public UnityEvent _event;

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
	public Animator Animator { get => animator; set => animator = value; }
	#endregion

	void Awake()
	{
		LevelManager.Instance.cloneUsage = availableClone;
		factory = new PlayerFactory(this);
		currentState = factory.States[PlayerStates.Ground];
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
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
		Flip();
		if (Input.GetKeyDown(KeyCode.X) && LevelManager.Instance.cloneUsage > 0)
		{
			LevelManager.Instance.cloneUsage -= 1;
			Instantiate(clonePrefab, new(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
			_event.Invoke();
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
		return Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
	}

	void Flip()
	{
		if (InputX > 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
		if (InputX < 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
		}
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
		Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
	}
}
