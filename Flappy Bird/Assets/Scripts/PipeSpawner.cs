using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject PrefabPipeDown;
    [SerializeField]
    GameObject PrefabPipeUp;
    [SerializeField]
    GameObject PrefabPipeCentre;
    Timer PipeSpawnTimer;

    const float MinPipePosition = 0.0f;
    const float MaxPipePosition = 4f;
    const float PipeGap = 10f;
    const float PipeSpawnInterval = 2.0f;


    float rightEnd;
    float bottomEnd;

    private void Awake()
    {
        ScreenUtils.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        rightEnd = ScreenUtils.ScreenRight;
        bottomEnd = ScreenUtils.ScreenBottom;
        SpawnPipe();
        PipeSpawnTimer = gameObject.AddComponent<Timer>();
        PipeSpawnTimer.Duration = PipeSpawnInterval;
        PipeSpawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (PipeSpawnTimer.Finished)
        {
            SpawnPipe();
            PipeSpawnTimer.Duration = PipeSpawnInterval;
            PipeSpawnTimer.Run();
        }
    }
    
    //Spawn pipe on the rigth with random height 
    void SpawnPipe()
    {
        GameObject Pipedown = Instantiate<GameObject>(PrefabPipeDown);
        Pipedown.transform.position = new Vector2(rightEnd + 2,
            (bottomEnd - 1.5f) + Random.Range(MinPipePosition, MaxPipePosition));
        GameObject Pipeup = Instantiate<GameObject>(PrefabPipeUp);
        Pipeup.transform.position = new Vector2(rightEnd + 2,
            Pipedown.transform.position.y + PipeGap);
        GameObject PipeCentre = Instantiate<GameObject>(PrefabPipeCentre);
        PipeCentre.transform.position = new Vector2(rightEnd + 2,
            Pipedown.transform.position.y + 5.5f);
    }
}
