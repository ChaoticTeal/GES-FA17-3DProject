using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IActivatable
{
    Animator animator;
    bool isActive;

    public bool Active { get { return isActive; } }

    public string NameText
    {
        get
        {
            return "Switch";
        }
    }

    public void DoActivate()
    {
        isActive = true;
        animator.SetBool("isActive", isActive);
    }

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}
}
