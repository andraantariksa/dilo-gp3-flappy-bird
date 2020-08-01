using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float upForce = 100.0f;
    [SerializeField]
    public bool IsDead { get; private set; } = false;
    [SerializeField] 
    private UnityEvent OnJump = null;
    [SerializeField]
    private UnityEvent OnDead = null;
    [SerializeField]
    private UnityEvent OnFire = null;
    [SerializeField]
    private FireBall fireBall = null;
    
    private Rigidbody2D rigidbody2D = null;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (Input.GetMouseButtonDown(0)) Jump();

            if (Input.GetMouseButtonDown(1)) Fire();
        }
    }

    public void Dead()
    {
        if (IsDead)
        {
            return;
        }

        OnDead.Invoke();
        IsDead = true;
    }

    void Jump()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(new Vector2(0, upForce));
        OnJump.Invoke();
    }

    void Fire()
    {
        FireBall newFireBall = Instantiate(fireBall, transform.position, Quaternion.identity);
        newFireBall.gameObject.SetActive(true);
        OnFire.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)    
    {
        if (other.gameObject.tag == "Obstacle")
        {
            animator.enabled = false;
        }
    }
}
