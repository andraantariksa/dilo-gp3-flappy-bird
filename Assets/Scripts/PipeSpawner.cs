using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private Bird bird = null;
    [SerializeField]
    private Pipe pipeAbove = null;
    [SerializeField]
    private Pipe pipeBelow = null;
    [SerializeField]
    private float spawnIntervalMax = 4.0f;
    [SerializeField]
    private float spawnIntervalMin = 1.0f;
    [SerializeField]
    private float maxMinOffset = 1.0f;
    [SerializeField]
    private float holeSizeMax = 1.5f;
    [SerializeField]
    private float holeSizeMin = 0.8f;
    [SerializeField]
    private PointBox pointBox = null;

    private Coroutine coroutineSpawn = null;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPipe()
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);

        Pipe newPipeAbove = Instantiate(pipeAbove, transform.position, Quaternion.Euler(0, 0, 180));
        newPipeAbove.gameObject.SetActive(true);

        Pipe newPipeBelow = Instantiate(pipeBelow, transform.position, Quaternion.identity);
        newPipeBelow.gameObject.SetActive(true);

        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeAbove.transform.position += Vector3.up * y;
        newPipeBelow.transform.position += Vector3.up * y;

        newPipeAbove.transform.position += Vector3.up * (holeSize / 2.0f);
        newPipeBelow.transform.position += Vector3.down * (holeSize / 2.0f);

        PointBox newPointBox = Instantiate(pointBox, transform.position, Quaternion.identity);
        newPointBox.gameObject.SetActive(true);
        newPointBox.transform.position += Vector3.up * y;
    }

    public void SpawnPipe(Pipe pipe)
    {
        Pipe newPipe = Instantiate(pipe, transform.position, Quaternion.Euler(0, 0, 180));
        newPipe.gameObject.SetActive(true);
    }

    public void StartSpawn()
    {
        if (coroutineSpawn == null)
        {
            coroutineSpawn = StartCoroutine(SpawnPipeWhileBirdIsAlive());
        }
    }

    public void StopSpawn()
    {
        if (coroutineSpawn != null)
        {
            StopCoroutine(coroutineSpawn);
        }
    }

    private IEnumerator SpawnPipeWhileBirdIsAlive()
    {
        while (true)
        {
            if (bird.IsDead)
            {
                StopSpawn();
            }
            else
            {
                SpawnPipe();
            }

            float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
