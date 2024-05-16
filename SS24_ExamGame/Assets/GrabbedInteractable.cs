using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbedInteractable : MonoBehaviour
{
    public Companion Companion;
    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => WasGrabbed());
    }

    public void WasGrabbed()
    {
        Debug.Log("grabbed");
        Companion.moveToNextPos = true;
    }
}
