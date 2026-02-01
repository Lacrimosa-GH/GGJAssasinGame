using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODMusic : MonoBehaviour
{
    public static FMODMusic instance;
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
    void Start()
    {
        RuntimeManager.PlayOneShot("event:/MainTheme");
    }

}
