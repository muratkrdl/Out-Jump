using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    public bool isGameStart = false;

    void Update() 
    {
        if(isGameStart) { transform.Translate(0f, moveSpeed * Time.deltaTime, 0f); }    
    }

}
