using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CaravanSaTwoAction : GOAPAction
{
	private bool Caravan2Sa = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public CaravanSaTwoAction () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasTwoSa", true);
		addEffect("Caravan Sa Two", 2);
		cost = 0f; //since we want this kinda actions to be executed immediately
	}
	
	
	public override void reset ()
	{
		Caravan2Sa = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return Caravan2Sa;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		setInRange(true);
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

			backpack.Sa -= 2;
			Caravan.Sa += 2;
			Caravan2Sa = true;
		}
		return true;
	}

}
