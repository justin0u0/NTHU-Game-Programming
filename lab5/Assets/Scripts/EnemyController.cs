using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public GameObject player;
	public Animator animator;

	private NavMeshAgent navMeshAgent;

	// Start is called before the first frame update
	void Start()
	{
		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		animator.SetFloat("speed", 1.0f);
	}

	// Update is called once per frame
	void Update()
	{
		navMeshAgent.SetDestination(player.transform.position);
	}
}
