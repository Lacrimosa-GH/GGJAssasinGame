using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
   
    private VisionDetect _visionDetect;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _detectionTime;
    [SerializeField] private float _attackCooldown;
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
        
        if (_attackCooldown <= Time.time)
        {
            //Bullet Spawn
            var projectileClone = Instantiate(_projectilePrefab, 
                _projectileSpawnPoint.position, Quaternion.identity);
            Destroy(projectileClone, 5f);
            // animation
            
           
            
            //Move spawned projectile
            projectileClone.TryGetComponent(out Rigidbody2D rb);
           rb.linearVelocityX = _projectileSpeed * transform.localScale.x;
            // increases the cooldown to match the time.time.
           _attackCooldown = _attackRate + Time.time;      
        }
        

    }


}
