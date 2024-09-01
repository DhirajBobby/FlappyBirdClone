using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1, 0, 0) * 1.0f * Time.deltaTime;
        if (transform.position.x <= ScreenUtils.ScreenLeft)
        {
            Destroy(gameObject);
            BackgroundSpawner.instance.SpawnBackground();
        }
    }
}
