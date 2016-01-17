using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{

    private Animator animator;
    private Dialogue dialogue;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetInteger("AnimationState", 0);
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.IsSomeoneTalking())
        {
            animator.SetInteger("AnimationState", 1);
        }
        else
        {
            animator.SetInteger("AnimationState", 0);
        }
    }
}