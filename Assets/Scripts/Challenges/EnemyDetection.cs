using Unity.VisualScripting;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class EnemyDetection : MonoBehaviour
{
   
    private VisionDetect _visionDetect;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _detectionTime;
     public float attackCooldown;
    [SerializeField] private float _attackRate;

    private Animator _animator;

    private void Start()
    {
        _visionDetect = GetComponentInChildren<VisionDetect>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        updateAttack(_visionDetect.playerInView);
    }

    private void updateAttack(bool playerDetected)
    {
        //null check
        if (!playerDetected) return;
        
        if (attackCooldown <= Time.time)
        {
            _animator.Play("Shoot");
            RuntimeManager.PlayOneShot("event:/SFX/sfx_gunShot", gameObject.transform.position);
            //Bullet Spawn
            var projectileClone = Instantiate(_projectilePrefab, 
                _projectileSpawnPoint.position, Quaternion.identity);
            Destroy(projectileClone, 5f);
            
            
            
            //Move spawned projectile
            projectileClone.TryGetComponent(out Rigidbody2D rb);
           rb.linearVelocityX = _projectileSpeed * transform.localScale.x;
            // increases the cooldown to match the time.time.
           attackCooldown = _attackRate + Time.time;      
        }
        

    }


}
