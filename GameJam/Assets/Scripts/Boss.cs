using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.DOMoveX(player.transform.position.x, 4f);
    }
}
