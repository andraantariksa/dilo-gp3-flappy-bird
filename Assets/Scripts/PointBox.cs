using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBox : MonoBehaviour
{
    [SerializeField]
    private Score score = null;
    [SerializeField]
    private Bird bird = null;
    [SerializeField]
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.IsDead)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Bird birdCollideWith = other.gameObject.GetComponent<Bird>();
        if (birdCollideWith && !birdCollideWith.IsDead)
        {
            score.Add(1);
        }
    }
}
