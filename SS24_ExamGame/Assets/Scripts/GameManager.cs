using System.Collections.Generic;
using System.Linq;
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
    private bool firstPlaythrough = false;

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

            if(Random.Range(0f, 1f) > 0.5f) {
                AudioManager.instance.PlayAffirmation(AudioManager.instance.correctAffirmationSounds[Random.Range(0, AudioManager.instance.correctAffirmationSounds.Length)].name);
            }
            
        } 
        else 
        {
            if(Random.Range(0f, 1f) > 0.5f) {
                AudioManager.instance.PlayAffirmation(AudioManager.instance.wrongAffirmationSounds[Random.Range(0, AudioManager.instance.wrongAffirmationSounds.Length)].name);
            }
            
        }

        if(grabbedObjectsList.Count == 6 && !firstPlaythrough)
        {
            OnAllItemsGrabbed.Invoke();
            firstPlaythrough = true;
        }
    }
}
