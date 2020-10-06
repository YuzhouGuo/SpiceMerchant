using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CaravanTuTwoAction : GOAPAction
{
	private bool Caravan2Tu = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 1; // seconds

	void Start ()
	{
	}
	
	public CaravanTuTwoAction () {
		//addPrecondition("TuInCaravanNotTwoYet", true);
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasTwoTu", true);
		addEffect("Caravan Tu Two", 2);
		//addEffect("TuInCaravanNotTwoYet", false);
		cost = 0f; //since we want this kinda actions to be executed immediately
	}
	
	
	public override void reset ()
	{
		Caravan2Tu = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return Caravan2Tu;
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

			backpack.Tu -= 2;
			Caravan.Tu += 2;
			Caravan2Tu = true;
		}
		return true;
	}

}
