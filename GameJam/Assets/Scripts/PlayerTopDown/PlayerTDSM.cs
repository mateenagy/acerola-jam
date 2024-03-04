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
	bool canControl = true;
	Transform glitchPos;
	public TrailRenderer trail1;
	public TrailRenderer trail2;
	[SerializeField] UnityEvent _events;

	[Header("Movement")]
	[SerializeField] float speed = 2f;
	[SerializeField] float rotationSpeed = 2f;
	[SerializeField] Transform indicatorTransform;
	[SerializeField] List<Transform> glitches;
	[Header("Sounds")]
	public AudioSource ship;

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
		trail1.enabled = false;
		trail2.enabled = false;
	}

	void Start()
	{
		CurrentState.EnterStates();
		for (int i = 0; i < glitches.Count; i++)
		{
			if (i != LevelManager.Instance.currentLevel)
			{
				glitches[i].gameObject.SetActive(false);
			}
		}

		if (LevelManager.Instance.currentLevel != 0)
		{
			transform.position = glitches[LevelManager.Instance.currentLevel - 1].position;
		}
		trail1.enabled = true;
		trail2.enabled = true;
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
		Vector2 dir = glitches[LevelManager.Instance.currentLevel].position - indicatorTransform.position;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, dir);
		indicatorTransform.rotation = rotation;
	}

	void Update()
	{
		if (!LevelManager.Instance.isStarted || LevelManager.Instance.isDialog)
		{
			indicatorTransform.gameObject.SetActive(false);
			return;
		}
		indicatorTransform.gameObject.SetActive(true);
		if (transform.position.x < -130)
		{
			canControl = false;
			rb.velocity = Vector2.zero;
			transform.DORotate(new(0, 0, -88), 0.5f);
		}
		if (canControl)
		{
			InputX = Input.GetAxisRaw("Horizontal");
			InputY = Input.GetAxisRaw("Vertical");
		}
		else
		{
			InputX = 0;
			InputY = 0;
		}
		IndicatorRotation();

		CurrentState.UpdateStates();
	}

	IEnumerator TakeBack()
	{
		yield return rb.DOMoveX(-120, 1f);
		canControl = true;

	}

	void FixedUpdate()
	{
		if (transform.position.x < -130)
		{
			rb.velocity = Vector2.zero;
			StartCoroutine(TakeBack());
		}
		CurrentState.FixedUpdateStates();
	}
}
