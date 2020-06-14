using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material usualMaterial;
    public Material activeMaterial;


    private Animation anim;
    public bool interactable = false;
    private bool locked = false;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        Debug.Log("update");
        if (interactable)
        {
            var forwardVector = Camera.main.transform.forward;
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, forwardVector, out hit, 5))
            {
                if (hit.collider.gameObject.tag == "Interactable")
                {
                    FeedbackFlashHUD.instance.SetCanInteract(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Debug.Log("Key pressed");
                        PerformAction();
                    }
                }
            } else
            {
                FeedbackFlashHUD.instance.SetCanInteract(false);
            }


        }
    }

    virtual public void PerformAction()
    {
        anim.Play();
        FeedbackFlashHUD.instance.SetCanInteract(false);
    }

    public void PlayAnimation(string animName)
    {
        anim.Play(animName);
    }

    virtual public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collistion enter");
        if (collision.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    virtual public void OnTriggerExit(Collider collision)
    {
        Debug.Log("Collistion exit");
        if (collision.gameObject.tag == "Player")
        {
            interactable = false;
            FeedbackFlashHUD.instance.SetCanInteract(false);
        }
    }
}
