using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DramaDoor : Door
{
    [SerializeField]
    GameObject dramaPanel;

    [SerializeField]
    Transform newPlayerPos;

    [SerializeField]
    GameObject player;

    [SerializeField]
    bool final;

    [SerializeField]
    Text endText;

    public override void DoActivate()
    {
        if(!isOpen)
        {
            animator.SetBool("isDoorOpen", true);
            isOpen = true;
            audioSource.Play();
            StartCoroutine(AnimMoveManager());
        }
    }

    IEnumerator AnimMoveManager()
    {
        FindObjectOfType<InventoryMenu>().canPause = false;
        dramaPanel.GetComponent<Animator>().SetBool("isVisible", true);
        yield return new WaitForSeconds(3f);
        if (newPlayerPos != null && player != null)
            player.transform.position = newPlayerPos.position;
        if (!final)
            dramaPanel.GetComponent<Animator>().SetBool("isVisible", false);
        else
        {
            endText.GetComponent<Animator>().SetBool("isVisible", true);
            yield return new WaitForSeconds(4f);
            endText.GetComponent<Animator>().SetBool("isVisible", false);
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("Title");
        }
        FindObjectOfType<InventoryMenu>().canPause = true;
    }
}