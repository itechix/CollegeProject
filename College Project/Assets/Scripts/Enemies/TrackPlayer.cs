using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {

	// Use this for initialization
	public Transform target; 

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		// Sets the destination of the player
		agent.destination = target.position;
	}
}
