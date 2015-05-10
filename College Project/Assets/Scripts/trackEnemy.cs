using UnityEngine;
using System.Collections;

public class trackEnemy : MonoBehaviour {

	public Transform target; 
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		// Sets the destination of the player
		agent.destination = target.position;
		agent.updateRotation = true;
		transform.LookAt (target);
	}
}