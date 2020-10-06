using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Trader2Action_TwoSa : GOAPAction
{
	private bool get2Sa = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader2Action_TwoSa () {
		addPrecondition("BagHasSomething", true);
		addPrecondition ("hasTwoTuAndOneSa", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasTwoSa", true);
		cost = 1.5f;
	}
	
	public override void reset ()
	{
		get2Sa = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return get2Sa;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		setInRange(true);
		target = GameObject.Find("T2").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T2").gameObject;

			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));
			navAgent.destination = target.transform.position;

			backpack.Tu -= 2;
			backpack.Sa += 1;
			get2Sa = true;
		}
		return true;
	}

}