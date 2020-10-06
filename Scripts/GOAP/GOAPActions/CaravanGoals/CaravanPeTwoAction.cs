using System;
using UnityEngine;
using UnityEngine.AI;

public class CaravanPeTwoAction : GOAPAction
{
	private bool Caravan2Pe = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public CaravanPeTwoAction () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasTwoPe", true);
		addEffect("Caravan Pe Two", 2);
		cost = 0f; //since we want this kinda actions to be executed immediately
	}
	
	
	public override void reset ()
	{
		Caravan2Pe = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return Caravan2Pe;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("Caravan").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("Caravan").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Pe -= 2;
			Caravan.Pe += 2;
			Caravan2Pe = true;
		}
		return true;
	}
	
}
