using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JoyMeter : MonoBehaviour
{
    [SerializeField] private GameObject progress;
    private Coroutine increaseJoyCoroutine;
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private int targetItems = 6;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator IncreaseJoy()
    {
        Image joy = progress.GetComponent<Image>();
        float increment = (100f / targetItems) / 100f;
        float targetFill = Mathf.Clamp(joy.fillAmount + increment, 0, 1);
        float startFill = joy.fillAmount; 
        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            joy.fillAmount = Mathf.Lerp(startFill, targetFill, elapsed / animationDuration);
            yield return null;
        }
        joy.fillAmount = targetFill;
    }
}
