using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimator : MonoBehaviour
{
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hurt()
    {
        myAnimator.SetTrigger("Hurting");

    }
    public void Death()
    {
        myAnimator.SetTrigger("Diying");

    }
    public void Walk()
    {
       // myAnimator.SetBool("Idling", false);

        myAnimator.SetBool("Walking", true);

    }
    public void Idle()
    {
       // myAnimator.SetBool("Idling", true);
        myAnimator.SetBool("Walking", false);


    }
    public void Attacking()
    {
        myAnimator.SetTrigger("Attack1");

    }
}
