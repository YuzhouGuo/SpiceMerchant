using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Trader2Action_ReadyForTwoSa : GOAPAction
{
	private bool doTrader1Again = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader2Action_ReadyForTwoSa () {
        addPrecondition("BagHasSomething", true);
        addPrecondition("hasOneSa", true);
		addEffect ("BagHasSomething", true);
		addEffect ("hasTwoTuAndOneSa", true);
		cost = 1.5f;
	}
	
	public override void reset ()
	{
		doTrader1Again = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return doTrader1Again;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		setInRange(true);
		target = GameObject.Find("T1").gameObject; // Find T1 for another 2 Tu
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T1").gameObject;

			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));
			navAgent.destination = target.transform.position;

			backpack.Tu += 2;
			doTrader1Again = true;
		}
		return true;
	}
}