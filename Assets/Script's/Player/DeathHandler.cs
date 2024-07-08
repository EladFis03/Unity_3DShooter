using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        // at the start of the game the Canvas is not visible
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {

        // make the Canvas visible and also the Cursor (mouse) visible
        // stop time
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
