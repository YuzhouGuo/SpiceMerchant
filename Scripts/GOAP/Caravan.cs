using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

/**
 * Holds resources for the Agent.
 */
public class Caravan : MonoBehaviour
{
    public TextMeshPro showNumber;

    public static int Tu = 0; 
    public static int Sa = 0; 
    public static int Ca = 0; 
    public static int Ci = 0; 
    public static int Cl = 0; 
    public static int Pe = 0; 
    public static int Su = 0;

    void Update()
    {
        if (showNumber != null)
        {
            showNumber.text = "In the Caravan: \n" +
                          "\nTu: " + Tu.ToString() +
                          "\nSa: " + Sa.ToString() +
                          "\nCa: " + Ca.ToString() +
                          "\nCi: " + Ci.ToString() +
                          "\nCl: " + Cl.ToString() +
                          "\nPe: " + Pe.ToString() +
                          "\nSu: " + Su.ToString();
        }
    }

    public static void cleanCaravan()
    {
        Tu = 0;
        Sa = 0;
        Ca = 0;
        Ci = 0;
        Cl = 0;
        Pe = 0;
        Su = 0;
    }
}