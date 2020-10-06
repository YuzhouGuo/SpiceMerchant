using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Trader1Action : GOAPAction
{
	private bool giveOut2Tu = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 1; // seconds

	void Start ()
	{
	}
	
	public Trader1Action () {
		addEffect("BagHasSomething", true);
		addEffect ("hasOneTu", true);
		addEffect ("hasTwoTu", true);
		// if(backpack.Tu == 4)
		// 	addEffect("hasFourTu", true);
		cost = 1f;
	}
	
	
	public override void reset ()
	{
		giveOut2Tu = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return giveOut2Tu;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		setInRange(true);
		target = GameObject.Find("T1").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
        if (startTime == 0)
            startTime = Time.time;

        if (Time.time - startTime > workDuration)
        {
            // finished chopping
            navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T1").gameObject;

			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));
			navAgent.destination = target.transform.position;

			backpack.Tu += 2;
			giveOut2Tu = true;
		}
		return true;
	}
}