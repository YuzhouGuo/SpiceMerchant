using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * A general character class.
 * You should subclass this for specific Labourer classes and implement
 * the createGoalState() method that will populate the goal for the GOAP
 * planner.
 */
public abstract class Character : MonoBehaviour, IGoap
{
	public float moveSpeed = 1;

	void Start ()
	{
		// if (backpack == null)
		// 	backpack = gameObject.AddComponent ("BackpackComponent" ) as BackpackComponent;
		// if (backpack.tool == null) {
		// 	GameObject prefab = Resources.Load<GameObject> (backpack.toolType);
		// 	GameObject tool = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
		// 	backpack.tool = tool;
		// 	tool.transform.parent = transform; // attach the tool
		// }
	}


	void Update ()
	{

	}

	/**
	 * Key-Value data that will feed the GOAP actions and system while planning.
	 */
	public abstract HashSet<KeyValuePair<string,object>> getWorldState ();

	/**
	 * Implement in subclasses
	 */
	public abstract HashSet<KeyValuePair<string,object>> createGoalState ();


	public void planFailed (HashSet<KeyValuePair<string, object>> failedGoal)
	{
		// Not handling this here since we are making sure our goals will always succeed.
		// But normally you want to make sure the world state has changed before running
		// the same goal again, or else it will just fail.
	}

	public void planFound (HashSet<KeyValuePair<string, object>> goal, Queue<GOAPAction> actions)
	{
		// Yay we found a plan for our goal
		Debug.Log ("<color=green>Plan found</color> "+GoapAgent.prettyPrint(actions));
	}

	public void actionsFinished ()
	{
		// Everything is done, we completed our actions for this gool. Hooray!
		Debug.Log ("<color=blue>Actions completed</color>");
	}

	public void planAborted (GOAPAction aborter)
	{
		// An action bailed out of the plan. State has been reset to plan again.
		// Take note of what happened and make sure if you run the same goal again
		// that it can succeed.
		Debug.Log ("<color=red>Plan Aborted</color> "+GoapAgent.prettyPrint(aborter));
	}

	public bool moveAgent(GOAPAction nextAction) {
		// move towards the NextAction's target
		float step = moveSpeed * Time.deltaTime;
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
		
		if (gameObject.transform.position.Equals(nextAction.target.transform.position) ) {
			// we are at the target location, we are done
			nextAction.setInRange(true);
			return true;
		} else
			return false;
	}
}