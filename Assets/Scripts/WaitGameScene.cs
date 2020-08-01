using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitGameScene : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wait(float seconds)
    {
        StartCoroutine(WaitForSeconds(seconds));
    }

    private IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }
}
