using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTDSM : MonoBehaviour
{
	PlayerTDState currentState;
	PlayerTDFactory factory;
	Rigidbody2D rb;
	float inputX;
	float inputY;
	bool isGripped;
	Transform glitchPos;
	[SerializeField] UnityEvent _events;

	[Header("Movement")]
	[SerializeField] float speed = 2f;
	[SerializeField] float rotationSpeed = 2f;
	[SerializeField] Transform indicatorTransform;
	[SerializeField] List<Transform> glitches;

	#region GETTERS / SETTERS        
	public PlayerTDState CurrentState { get => currentState; set => currentState = value; }
	public PlayerTDFactory Factory { get => factory; set => factory = value; }
	public Rigidbody2D Rb { get => rb; set => rb = value; }
	public float InputX { get => inputX; set => inputX = value; }
	public float InputY { get => inputY; set => inputY = value; }
	public float Speed { get => speed; set => speed = value; }
	public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
	public bool IsGripped { get => isGripped; set => isGripped = value; }
	public Transform GlitchPos { get => glitchPos; set => glitchPos = value; }
	public UnityEvent EEvents { get => _events; set => _events = value; }
	#endregion

	void Awake()
	{
		Factory = new PlayerTDFactory(this);
		CurrentState = Factory.States[PlayerTDStates.Move];
		Rb = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		CurrentState.EnterStates();
	}

	public void Gripped(Glitch glitch)
	{
		IsGripped = true;
		GlitchPos = glitch.transform;
	}

	public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
	{
		return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}

	void IndicatorRotation()
	{
		Vector2 dir = glitches[GameManager.currentGlitch].position - indicatorTransform.position;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, dir);
		indicatorTransform.rotation = rotation;
	}

	// void NextGlitch()
	// {
	// 	manager.currentGlitch = (manager.currentGlitch + 1) % glitches.Count;
	// 	// currentGlitch = manager.currentGlitch + 1;
	// }

	void Update()
	{
		InputX = Input.GetAxisRaw("Horizontal");
		InputY = Input.GetAxisRaw("Vertical");
		IndicatorRotation();

		// if (Input.GetKeyDown(KeyCode.K))
		// {
		// 	NextGlitch();
		// }

		CurrentState.UpdateStates();
	}

	void FixedUpdate()
	{
		CurrentState.FixedUpdateStates();
	}
}
