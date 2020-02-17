using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * STOP COROUTINE FOR PLASTIC BAG TEXT WHEN INSTANTIATING BAG
 */

public class TurtleWaypoints : MonoBehaviour
{
    public float speed;

    public Vector3[] waypoints;
    private WaypointSystem ws;

    public Transform headMarker;
    public Transform plasticBag;
    private Vector3 bagPos;

    public Text textBubble;
    [TextArea]
    public string jellybeanDefaultText;
    [TextArea]
    public string jellybeanJellyfishText;
    [TextArea]
    public string jellybeanPlasticBagText;


    void OnValidate()
    {
        transform.position = waypoints[0];
        bagPos = plasticBag.position;
        textBubble.text = jellybeanDefaultText;
    }

    // Start is called before the first frame update
    void Start()
    {
        ws = new WaypointSystem(transform, waypoints);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

        ws.update();
        transform.rotation = ws.currentRotation();


        if (Input.GetKeyDown("p") && !plasticBag.gameObject.activeSelf)
        {
            plasticBag.position = bagPos;
            plasticBag.gameObject.SetActive(true);
            goForPlasticBag();
        }
    }


    void goForPlasticBag()
    {
        textBubble.text = jellybeanJellyfishText;
        ws.takeDetour(new ManualTransformWaypoint(plasticBag));
        StartCoroutine(grabBag());
    }

    IEnumerator grabBag()
    {
        do
        {
            yield return new WaitForSeconds(0.25f);
        } while (Vector3.Distance(headMarker.position, plasticBag.position) > 1f);

        plasticBag.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(holdBag());

        ws.takeDetour(new ManualTransformWaypoint(Camera.main.transform));
        speed /= 10;
        //ws.stopDetour();
    }

    IEnumerator holdBag()
    {
        Rigidbody rb = plasticBag.GetComponent<Rigidbody>();
        Animator a = GetComponent<Animator>();
        a.SetBool("Eating", true);

        Vector3 originalLocalPosition = headMarker.localPosition;
        while (headMarker.localPosition.y >= 0.009)
        {
            headMarker.Translate(-0.1f * Vector3.forward * Time.deltaTime);
            rb.MovePosition(Vector3.Lerp(plasticBag.position, headMarker.position, 0.1f));
            yield return new WaitForSeconds(Time.deltaTime);
        }

        headMarker.localPosition = originalLocalPosition;
        plasticBag.gameObject.SetActive(false);

        a.SetBool("Eating", false);
        a.SetTrigger("Thrash");

        ws.stopDetour();
        speed *= 10;
        StartCoroutine(plasticBagText());
    }

    IEnumerator plasticBagText()
    {
        textBubble.text = jellybeanPlasticBagText;
        yield return new WaitForSeconds(5.5f);
        textBubble.text = jellybeanDefaultText;
    }
}
