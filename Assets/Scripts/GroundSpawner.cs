using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private Ground groundRef = null;
    
    private Ground prevGround = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnGround()
    {
        if (!prevGround)
        {
            return;
        }

        Ground newGround = Instantiate(groundRef);
        newGround.gameObject.SetActive(true);
        prevGround.SetNextGround(newGround.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Ground ground = other.GetComponent<Ground>();
        if (!ground)
        {
            return;
        }

        prevGround = ground;
        SpawnGround();
    }
}
