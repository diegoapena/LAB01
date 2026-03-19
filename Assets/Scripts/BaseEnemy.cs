using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float range = 10f;
    public bool InArea = false;
    Transform player;
    

    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

   
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            InArea = true;
            print("Player Entered");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InArea = false;
            player = null;
            print("Player Exit");
            
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
