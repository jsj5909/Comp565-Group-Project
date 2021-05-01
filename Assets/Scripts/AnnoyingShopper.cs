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
    [SerializeField] float maxTimeToWaypoint = 7;

    [SerializeField] GameObject[] waypoints;

    NavMeshAgent navigation;

    Animator animator;

    Vector3 currentWaypoint = Vector3.zero;

    int currentWaypointIndex = -1;
    int previousWaypointIndex = -1;

    bool moving = false;
    float timeToReachWaypoint = -1;



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

        timeToReachWaypoint += Time.time + maxTimeToWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moving)
        {
          /*  if(Time.time > timeToReachWaypoint)
            {
                PickNextWaypoint();
                timeToReachWaypoint += Time.time + maxTimeToWaypoint;
            }
          */ 
            
            //Debug.LogError("Moving...");
          //  if(navigation.isPathStale)
          //  {
          //      PickNextWaypoint();
          //  }

            // navigation.SetDestination(currentWaypoint);
            navigation.destination = currentWaypoint;

        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.gameObject.tag == "Waypoint")
        {
            if ((currentWaypoint - other.transform.position).magnitude > 0.1)
            {
               // Debug.LogError("distance = " + (currentWaypoint - other.transform.position).magnitude.ToString());
                
                return;
            }
            
            moving = false;
            navigation.isStopped = true;

           // Debug.LogError("distance = " + (currentWaypoint - other.transform.position).magnitude.ToString());

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
          //  Debug.Log("currentWaypoint:  " + currentWaypointIndex.ToString());

            return waypoints[currentWaypointIndex].transform.position;
        }

        //when a destination is reached and its time to move again then pick a new random waypoint for destination.
        //don't pick the second one twice in a row

        int nextWaypointIndex = Random.Range(0, waypoints.Length);
        while (currentWaypointIndex == nextWaypointIndex)
        {
            nextWaypointIndex = Random.Range(0, waypoints.Length);

            // Debug.LogError("Next Waypoint: " + nextWaypoint.ToString());
        }

        previousWaypointIndex = currentWaypointIndex;
        currentWaypointIndex = nextWaypointIndex;

       // Debug.LogError("PWP = " + previousWaypointIndex + " CWP = " + currentWaypointIndex);

        return waypoints[nextWaypointIndex].transform.position;
  
    }
}
