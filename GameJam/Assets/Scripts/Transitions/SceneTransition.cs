using System.Collections;
using UnityEngine;

public abstract class SceneTransition : MonoBehaviour
{
	public abstract IEnumerator TransitionEnter();
	public abstract IEnumerator TransitionLeave();
}
