using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float MovementSpeed = 4.0f;
    float LeftEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        LeftEnd = ScreenUtils.ScreenLeft;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(-1, 0, 0) * MovementSpeed * Time.deltaTime;
        if (gameObject.transform.position.x <= LeftEnd - 2)
        {
            Destroy(gameObject);
        }
    }
}
