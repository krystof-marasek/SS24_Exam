using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Minigame")]
    private List<GameObject> grabbedObjectsList = new List<GameObject>();
    public UnityEvent OnAllItemsGrabbed;
    public Companion cat;

    [Header("UI")]
    public JoyMeter joyMeter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ObjectGrabbed (GameObject grabbedObject)
    {
        if(grabbedObjectsList.Contains(grabbedObject))
        {
            return;
        }

        if(grabbedObject.CompareTag("CorrectASMRobject"))
        {
            grabbedObjectsList.Add(grabbedObject);
            StartCoroutine(joyMeter.IncreaseJoy());
            cat.grabbedRightObject = true;
        }

        if(grabbedObjectsList.Count == 6)
        {
            OnAllItemsGrabbed.Invoke();
        }
    }
}
