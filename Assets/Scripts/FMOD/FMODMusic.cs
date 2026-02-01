using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODMusic : MonoBehaviour
{
    void Start()
    {
        RuntimeManager.PlayOneShot("event:/MainTheme");
    }

}
