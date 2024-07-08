using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        // find how many music players are working now
        // and define it as a value
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        // incase we are having more than one music players
        // we need to destory the last one in order to keep having only one in the scene
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }

        // if this is the first music player to start
        else
        {
            // dont let this one be destroied/reset every time we start the scene
            DontDestroyOnLoad(gameObject);
        }
    }
}
