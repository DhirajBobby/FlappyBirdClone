using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject PrefabGround;

    [SerializeField]
    GameObject PrefabBackground;

    public static BackgroundSpawner instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SpawnGround()
    {
        GameObject Ground = Instantiate<GameObject>(PrefabGround);
        Ground.transform.position = new Vector2(ScreenUtils.ScreenRight,-5.75f);
    }

    public void SpawnBackground()
    {
        GameObject Background = Instantiate<GameObject>(PrefabBackground);
        Background.transform.position = new Vector2(ScreenUtils.ScreenRight, 0f);
    }
}
