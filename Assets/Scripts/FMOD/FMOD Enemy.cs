using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEnemy : MonoBehaviour
{
    
    private void EnemyWalk(){
        RuntimeManager.PlayOneShot("event:/SFX/sfx_enemyWalk", gameObject.transform.position);
    }

    private void WalkingTalking(){
        RuntimeManager.PlayOneShot("event:/SFX/sfx_policeTalk", gameObject.transform.position);

    }
}
