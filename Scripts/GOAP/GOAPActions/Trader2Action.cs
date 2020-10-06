using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Trader2Action : GOAPAction
{
	private bool take2TuGive1Sa = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader2Action () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasTwoTu", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasOneSa", true);
		cost = 2f;
	}
	
	public override void reset ()
	{
		take2TuGive1Sa = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take2TuGive1Sa;
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
			take2TuGive1Sa = true;
		}
		return true;
	}
}