using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score { get; private set; } = 0;
    [SerializeField]
    private UnityEvent OnAddScore = null;
    [SerializeField]
    private Text textScore = null;

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(int value)
    {
        score += value;
        textScore.text = score.ToString();

        if (OnAddScore != null)
        {
            OnAddScore.Invoke();
        }
    }
}
