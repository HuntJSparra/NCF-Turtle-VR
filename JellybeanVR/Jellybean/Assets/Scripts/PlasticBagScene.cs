using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagScene : MonoBehaviour
{
    public static PlasticBagScene instance;

    public GameObject bag; // Bag in the scene (that disappears and is visually replaced by turtleBag)
    public GameObject turtleBag; // Bag that the turtle is holding (but starts hidden)
    public GameObject turtle;

    public AudioSource splashingSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TieBagToTurtle()
    {
        //bag.transform.parent = turtle.transform;
        bag.GetComponent<MeshRenderer>().enabled = false;
        turtleBag.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(Thrash());
    }

    IEnumerator Thrash()
    {
        //yield return new WaitForSeconds(1f);

        turtle.GetComponent<Animator>().SetBool("Thrashing", true);
        splashingSource.Play();

        yield return new WaitForSeconds(10f);

        turtle.GetComponent<Animator>().SetBool("Thrashing", false);
        splashingSource.Stop();

        yield return new WaitForSeconds(8f);

        SceneTransition.instance.ChangeScene("Menu");
    }
}
