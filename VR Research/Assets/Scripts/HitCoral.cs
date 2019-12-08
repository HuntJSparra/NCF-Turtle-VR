using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCoral : MonoBehaviour
{
    Dictionary<Collider, int> hitPrior;
    private void Start()
    {
        hitPrior = new Dictionary<Collider, int>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash" || other.gameObject.tag == "Soda" || other.gameObject.tag == "Water")
        {
            if (!hitPrior.ContainsKey(other))
            {
                UpdatePoints.removePoint();
                hitPrior.Add(other, 60);
            }
        }
    }
    private void Update()
    {
        foreach (Collider obj in hitPrior.Keys)
        {
            hitPrior[obj] = hitPrior[obj] - 1;
            if(hitPrior[obj] == 0)
            {
                hitPrior.Remove(obj);
            }
        }
    }
}
