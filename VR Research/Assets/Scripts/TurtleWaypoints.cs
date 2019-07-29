using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleWaypoints : MonoBehaviour
{
    public float speed;

    public Vector3[] waypoints;
    private WaypointSystem ws;

    public Transform headMarker;
    public Transform plasticBag;


    void OnValidate()
    {
        transform.position = waypoints[0];
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
            plasticBag.position = new Vector3(Camera.main.transform.position.x, plasticBag.position.y, Camera.main.transform.position.z);
            plasticBag.gameObject.SetActive(true);
            goForPlasticBag();
        }
    }


    void goForPlasticBag()
    {
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

        ws.stopDetour();
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
    }
}
