using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigid;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    GroundController groundController;
    GameManager gameManager;

    void Awake() 
    {
        groundController = FindObjectOfType<GroundController>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update() 
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);

        if(Input.GetMouseButtonDown(0) && myRigid.velocity.y == 0)
        {
            myRigid.velocity = Vector2.up * jumpForce;
            
            if(groundController.isGameStart == false) { groundController.isGameStart = true; }
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("ShortEdge")) { moveSpeed *= -1; }    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Ground")) 
        { 
            Destroy(gameObject);
            gameManager.GameOVer();
        }

        else if(other.gameObject.CompareTag("Star")) 
        {
            Destroy(other.gameObject);
            gameManager.starCount++;
        }

        else if(other.gameObject.CompareTag("Flag")) 
        {
            gameManager.ShowFinishCanvas();
            Time.timeScale = 0f;
        }
    }

}
