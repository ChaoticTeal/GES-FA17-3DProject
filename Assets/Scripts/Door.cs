using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IActivatable
{
    [SerializeField]
    protected string nameText;

    [Tooltip("If you set a key, the door will be locked.")]
    [SerializeField]
    protected InventoryObject key;

    [SerializeField]
    protected Switch theSwitch;



    protected Animator animator;
    protected bool isLocked, isOpen, needsSwitch;
    protected List<InventoryObject> playerInventory;
    protected AudioSource audioSource;

    public string NameText
    {
        get
        {
            string toReturn = nameText;

            if (isOpen)
                toReturn = ""; // So it doesn't look like you can open the door anymore.
            else if (isLocked && !HasKey)
                toReturn += " (LOCKED)";
            else if (isLocked && HasKey)
                toReturn += string.Format(" (use {0})", key.NameText);
            else if (needsSwitch)
                toReturn += " (FIND THE SWITCH)";

            return toReturn;
        }
    }

    private bool HasKey
    {
        get
        {
            return playerInventory.Contains(key);
        }
    }

    public virtual void DoActivate()
    {
        if (!isOpen)
        {
            if ((!isLocked && !needsSwitch || HasKey) || (needsSwitch && theSwitch.Active))
            {
                animator.SetBool("isDoorOpen", true);
                audioSource.Play();
                isOpen = true;
            }
        }
    }

    // Use this for initialization
    protected void Start () 
	{
        animator = GetComponent<Animator>();
        playerInventory = FindObjectOfType<InventoryMenu>().PlayerInventory;
        isLocked = key != null;
        needsSwitch = theSwitch != null;
        audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {
        if(needsSwitch)
            if (theSwitch.Active)
                DoActivate();
    }
}