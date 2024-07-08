using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        //starts game by turning off the damage canvas
        impactCanvas.enabled = false;
    }

    // a public mathod thats calls whan hit
    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        impactCanvas.enabled = true;
        // wait for the time the devs makes until canvas diabled again
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
