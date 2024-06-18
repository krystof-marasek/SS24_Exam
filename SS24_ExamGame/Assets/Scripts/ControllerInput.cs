using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControllerInput : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionReference_BackToMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        inputActionReference_BackToMenu.action.performed += BackToMenu;
    }

    private void BackToMenu(InputAction.CallbackContext obj)
    {
        Debug.Log("Back to Menu");
        SceneManager.LoadScene(0);
    }
}
