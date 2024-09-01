using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D BirdRigidBody;
    const float JumpUnit = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        BirdRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        transform.eulerAngles = new Vector3(0, 0, BirdRigidBody.velocity.y*2.0f);
    } 
    
    //make bird jump
    void Jump()
    {
        if(GameManager.Instance.gameState == GameState.Playing)
        {
            BirdRigidBody.velocity = Vector2.up * JumpUnit;
            AudioManager.instance.PlaySound(AudioClipName.BirdJump);
        }
    }

    //Detect collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Death"))
        {
            BirdRigidBody.bodyType = RigidbodyType2D.Static;
            GameManager.Instance.GameOver();
            AudioManager.instance.PlaySound(AudioClipName.BirdDie);

        }
        else if(other.CompareTag("Point"))
        {
            GameManager.Instance.AddScore();
            AudioManager.instance.PlaySound(AudioClipName.ScorePoint);
        }
    }
}
