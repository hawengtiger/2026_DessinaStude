using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;
    public int currentHp;

    public GameObject xpPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log("나 맞았음!");

        if(currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (xpPrefab != null)
        {
            Instantiate(xpPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
