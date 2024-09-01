using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1,0,0)*4.0f*Time.deltaTime;
        if (transform.position.x <= ScreenUtils.ScreenLeft)
        {
            Destroy(gameObject);
            BackgroundSpawner.instance.SpawnGround();
        }

    }
}
