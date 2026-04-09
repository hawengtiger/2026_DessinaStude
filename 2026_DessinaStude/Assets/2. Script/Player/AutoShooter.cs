using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackInterval = 1f;
    public float attackRange = 10f;
    public Transform FirePoint;

    private float attackTimer = 0f;
    private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && playerHealth.isDead) return;

        attackTimer += Time.deltaTime;
        
        if (attackTimer >= attackInterval)
        {
            Transform target = FindNearestEnemy();

            if (target != null)
            {
                Shoot(target);
                attackTimer = 0f;
            }
        }
    }

    Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearest = null;
        float nearestDistnace = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistnace && distance <= attackRange)
            {
                nearestDistnace = distance;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }

    void Shoot(Transform target)
    {
        Vector3 direction = (target.position - FirePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, FirePoint.position, Quaternion.LookRotation(direction));

        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);   
        }
    }


}
