using UnityEngine;

public class xpPickup : MonoBehaviour
{
    public int xpAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();
        
        if (playerLevel != null)
        {
            playerLevel.AddXp(xpAmount);
        }

        Destroy(gameObject);
    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
