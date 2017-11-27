using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteractiveObject : MonoBehaviour, IActivatable
{
	// Use this for initialization
	void Start ()
    {
        DoActivate();	
	}

    public void DoActivate()
    {
        Debug.Log(this.name + " was activated");
    }
}
