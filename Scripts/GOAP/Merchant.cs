using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Merchant : Character
{
	NavMeshAgent navAgent;
	BackpackComponent backpack;
	/**
	 * Try to make two of each spices.
	 * The ForgeTooldAction will be able to fulfill this goal.
	 */
	void Start ()
	{
		navAgent = GetComponent<NavMeshAgent>();
		backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));
	}

	public override HashSet<KeyValuePair<string,object>> createGoalState () 
	{
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();

        goal.Add(new KeyValuePair<string, object>("Caravan Tu Two", 2));
		goal.Add(new KeyValuePair<string, object>("Caravan Sa Two", 2));
		// goal.Add(new KeyValuePair<string, object>("Caravan Ca Two", 2));
		// goal.Add(new KeyValuePair<string, object>("Caravan Ci Two", 2));
        // goal.Add(new KeyValuePair<string, object>("Caravan Cl Two", 2));
        // goal.Add(new KeyValuePair<string, object>("Caravan Pe Two", 2));
        // goal.Add(new KeyValuePair<string, object>("Caravan Su Two", 2));
		return goal;
	}

	public override HashSet<KeyValuePair<string,object>> getWorldState () 
	{
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();

		worldData.Add(new KeyValuePair<string, object>("BagHasSomething", backpack.getTotalNumber() > 0));
		worldData.Add(new KeyValuePair<string, object>("hasOneTu", backpack.Tu >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoTu", backpack.Tu >= 2));
		worldData.Add(new KeyValuePair<string, object>("hasFourTu", backpack.Tu == 4)); //since we can only have max 4 items in bag
		worldData.Add(new KeyValuePair<string, object>("hasTwoTuAndOneSa", backpack.Tu >= 2 && backpack.Sa >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasOneSa", backpack.Sa >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoSa", backpack.Sa >= 2));
		worldData.Add(new KeyValuePair<string, object>("hasOneCa", backpack.Ca >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoCa", backpack.Ca >= 2));
		worldData.Add(new KeyValuePair<string, object>("hasFourCa", backpack.Ca == 4));
		worldData.Add(new KeyValuePair<string, object>("hasOneCi", backpack.Ci >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoCi", backpack.Ci >= 2));
		worldData.Add(new KeyValuePair<string, object>("hasOneCl", backpack.Cl >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoCl", backpack.Cl >= 2));
		worldData.Add(new KeyValuePair<string, object>("hasOneSu", backpack.Su >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoSu", backpack.Su >= 2));
		worldData.Add(new KeyValuePair<string, object>("hasOnePe", backpack.Pe >= 1));
		worldData.Add(new KeyValuePair<string, object>("hasTwoSu", backpack.Su >= 2));

        worldData.Add(new KeyValuePair<string, object>("Caravan Tu Two", Caravan.Tu >= 2));
		worldData.Add(new KeyValuePair<string, object>("Caravan Sa Two", Caravan.Su >= 2));
		worldData.Add(new KeyValuePair<string, object>("Caravan Ca Two", Caravan.Ca >= 2));
		worldData.Add(new KeyValuePair<string, object>("Caravan Ci Two", Caravan.Ci >= 2));
        worldData.Add(new KeyValuePair<string, object>("Caravan Cl Two", Caravan.Cl >= 2));
        worldData.Add(new KeyValuePair<string, object>("Caravan Pe Two", Caravan.Pe >= 2));
        worldData.Add(new KeyValuePair<string, object>("Caravan Su Two", Caravan.Su >= 2));

		return worldData;
	}
}
