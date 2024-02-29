using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Movement")]
    [SerializeField] float speed = 2f;
    [SerializeField] float rotationSpeed = 2f;

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

	public void Gripped(Glitch glitch) {
		IsGripped = true;
		GlitchPos = glitch.transform;
	}

    void Update()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        CurrentState.UpdateStates();
    }
}
