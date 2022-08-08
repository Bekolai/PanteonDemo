using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutRepeat : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        callRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callAnimation()
    {
        animator.SetTrigger("Hit");
    }
    public void callRandom()
    {
        float RandomTime = Random.Range(1.5f, 3f);
        Invoke("callAnimation", RandomTime);
    }
}
