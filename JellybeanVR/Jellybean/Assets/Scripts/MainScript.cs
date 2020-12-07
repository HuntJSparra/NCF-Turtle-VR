using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public float thrashingTime;

    [HideInInspector]
    public static MainScript instance;

    [SerializeField]
    private GameObject jellybean;

    public static int trashRemaining;
    private bool startedBagScenario = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        trashRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startedBagScenario && (trashRemaining <= 0))
        {
            jellybean.GetComponent<Animator>().SetTrigger("Start Eating");
            startedBagScenario = true;
            Debug.Log("All trash collected!");
        }
    }

    // Triggered by the animation for EatingBag starting (EatingBagState.cs behavior)
    public void EnterEatingAnimation()
    {
        jellybean.transform.GetChild(2).GetComponent<Renderer>().enabled = true;
    }

    // Triggered by the animation for EatingBag ending (EatingBagState.cs behavior)
    public void ExitEatingAnimation()
    {
        jellybean.transform.GetChild(2).GetComponent<Renderer>().enabled = false;
        jellybean.GetComponent<Animator>().SetBool("Thrashing", true);
        StartCoroutine(StopThrashing());
    }

    IEnumerator StopThrashing()
    {
        yield return new WaitForSeconds(thrashingTime);
        jellybean.GetComponent<Animator>().SetBool("Thrashing", false);
    }
}
