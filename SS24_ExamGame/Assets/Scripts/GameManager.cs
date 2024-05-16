using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    [Header("Minigame")]
    private List<GameObject> grabbedObjectsList = new List<GameObject>();

    [Header("UI")]
    public TextMeshPro counter;

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

        grabbedObjectsList.Add(grabbedObject);
        counter.text = grabbedObjectsList.Count.ToString();
    }
}

