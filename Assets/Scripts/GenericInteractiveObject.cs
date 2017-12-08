using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteractiveObject : MonoBehaviour, IActivatable
{
    public string NameText
    {
        get
        {
            return "";
        }
    }

    // Use this for initialization
    void Start ()
    {

	}

    public void DoActivate()
    {
        Debug.Log(this.name + " was activated");
    }
}
