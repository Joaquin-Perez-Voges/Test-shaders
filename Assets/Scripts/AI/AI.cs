using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;

    private int i = 0;

    public bool followPlayer;

    private float distanceToPlayer;
    
    public float distanceToFollowPlayer = 10;

    public float distanceToFollowPath = 2;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;

        player = Object.FindAnyObjectByType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer) {
            FollowPlayer();
        }
        
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath(){
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath){
            if (destinations[i] != destinations[destinations.Length-1]){
            
                i++;

            }
            else{
                i = 0;
            }
        }
    }

    public void FollowPlayer(){
        navMeshAgent.destination = player.transform.position;
    }
}
