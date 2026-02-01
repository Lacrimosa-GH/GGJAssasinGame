using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODWalking : MonoBehaviour
{

    private void PlayerWalk(){
        RuntimeManager.PlayOneShot("event:/SFX/sfx_playerWalk");
    }
}
