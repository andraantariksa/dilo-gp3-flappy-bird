using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private Bird bird;
    [SerializeField]
    private Pipe pipeAbove;
    [SerializeField]
    private Pipe pipeBelow;
    [SerializeField]
    private float spawnInterval = 2.0f;
    [SerializeField]
    private float maxMinOffset = 1.0f;
    [SerializeField]
    private float holeSize = 1.0f;

    private Coroutine coroutineSpawn;

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
        Pipe newPipeAbove = Instantiate(pipeAbove, transform.position, Quaternion.Euler(0, 0, 180));
        newPipeAbove.gameObject.SetActive(true);

        Pipe newPipeBelow = Instantiate(pipeBelow, transform.position, Quaternion.identity);
        newPipeBelow.gameObject.SetActive(true);

        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeAbove.transform.position += Vector3.up * y;
        newPipeBelow.transform.position += Vector3.up * y;

        newPipeAbove.transform.position += Vector3.up * (holeSize / 2.0f);
        newPipeBelow.transform.position += Vector3.down * (holeSize / 2.0f);    }

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
            
            SpawnPipe();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
