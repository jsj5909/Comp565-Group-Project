using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//The annoying shopper slowly meanders through the store stopping at random waypoints
//when stopped, colliding with them will cause the player to lose items from the cart
//They player can bump them when they are moving


public class AnnoyingShopper : MonoBehaviour
{
    [SerializeField] float minSecondsBetweenMoves = 3;
    [SerializeField] float maxSecondsBetweenMoves = 5;

    [SerializeField] bool constantRoute = false;

    [SerializeField] GameObject[] waypoints;

    NavMeshAgent navigation;

    Animator animator;

    Vector3 currentWaypoint = Vector3.zero;

    int currentWaypointIndex = 0;

    bool moving = false;



    // Start is called before the first frame update
    void Start()
    {
        //grab the navmesh component
        navigation = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        //initialize the first waypoint
        currentWaypoint = PickNextWaypoint();

        moving = true;
        animator.SetInteger("AnimationID", 1);
        navigation.SetDestination(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moving)
        {
            //Debug.LogError("Moving...");
            navigation.SetDestination(currentWaypoint);

        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.gameObject.tag == "Waypoint")
        {
            moving = false;
            navigation.isStopped = true;
            
            currentWaypoint = PickNextWaypoint();
            StartCoroutine(WaitBeforeMoving());
        }
    }

    private IEnumerator WaitBeforeMoving()
    {
        float seconds = Random.Range(minSecondsBetweenMoves, maxSecondsBetweenMoves);
        //Debug.LogError("Waiting... " + seconds.ToString());
        animator.SetInteger("AnimationID", 0);
        yield return new WaitForSeconds(seconds);

        moving = true;
        navigation.isStopped = false;
        animator.SetInteger("AnimationID", 1);
    }


    private Vector3 PickNextWaypoint()
    {
        if(constantRoute)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
                currentWaypointIndex = 0;

            //Debug.Log("currentWaypoint:  " + waypoints[currentWaypointIndex].gameObject.name.ToString());
            Debug.Log("currentWaypoint:  " + currentWaypointIndex.ToString());

            return waypoints[currentWaypointIndex].transform.position;
        }
        
        //when a destination is reached and its time to move again then pick a new random waypoint for destination.
        int nextWaypoint = Random.Range(0, waypoints.Length);

       // Debug.LogError("Next Waypoint: " + nextWaypoint.ToString());


        return waypoints[nextWaypoint].transform.position;
  
    }
}
