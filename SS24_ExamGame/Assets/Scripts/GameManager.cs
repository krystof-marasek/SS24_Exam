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

    [Header("UI")]
    public TextMeshPro counter;
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
            counter.text = grabbedObjectsList.Count.ToString();
            StartCoroutine(joyMeter.IncreaseJoy());
        }

        if(grabbedObjectsList.Count == 3)
        {
            OnAllItemsGrabbed.Invoke();
        }
    }
}
