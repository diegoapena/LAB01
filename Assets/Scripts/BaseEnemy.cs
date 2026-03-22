using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float range = 10f;
    public float moveSpeed = 3f;
    public bool InArea = false;
    Transform player;

    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    
    void Update()
    {
        if (InArea && player != null)
        {
            // Mover al enemigo hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            InArea = true;
        }
        else if (other.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InArea = false;
            player = null;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (InArea && player != null)
        {
            Gizmos.color = Color.red;

            Vector3 dir = player.position - transform.position;
            Gizmos.DrawRay(transform.position, dir);
        }
    }
}
