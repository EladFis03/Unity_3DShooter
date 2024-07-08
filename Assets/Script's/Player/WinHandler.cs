using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;

    private void Start()
    {
        // at the start of the game the Canvas is not visible
        winCanvas.enabled = false;
    }

    public void HandleWin()
    {

        // make the Canvas visible and also the Cursor (mouse) visible
        // stop time
        winCanvas.enabled = true;
        Time.timeScale = 0;
        // turns off the function to switch weapons 
        FindObjectOfType<WeaponSwitch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
