using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem
{
        private Transform transform; // object using the system

        private Waypoint[] waypoints;
        private int currentIndex;
        private Waypoint currentWaypoint;

        private Quaternion startRotation;
        private float initialDistance; // Initial distance to waypoint
        private float t; // Time.deltaTime/initialDistance // Used for banking (what fraction of the distance should have been covered so far?)
        private float lastTilt;

        public WaypointSystem(Transform ownerTransform, Vector3[] waypointsList)
        {
            transform = ownerTransform;

            waypoints = new Waypoint[waypointsList.Length];
            for (int i=0; i<waypoints.Length; i++) {
                waypoints[i] = new VectorWaypoint(waypointsList[i]);
            }
            currentIndex = 0;
            currentWaypoint = waypoints[currentIndex];

            lastTilt = 0;
        }


        public void update()
        {
            if (currentWaypoint.checkCompletion(transform)) {
                nextWP();
            }
        }


        public Quaternion currentRotation()
        {
            transform.eulerAngles -= new Vector3(0, 0, transform.eulerAngles.z);

            t += 0.1f*Time.deltaTime/initialDistance;
            Quaternion endRotation = Quaternion.LookRotation(this.currentWP()-transform.position);
            // Quaternion preTiltRotation = Quaternion.Lerp(startRotation, endRotation, t);
            Quaternion preTiltRotation = Quaternion.RotateTowards(transform.rotation, endRotation, t);

            float delta = transform.rotation.eulerAngles.y - preTiltRotation.eulerAngles.y;
            float newTilt = Mathf.Sign(delta)*Mathf.Min(80, Mathf.Abs(350*delta));
            float tilt = Mathf.Lerp(lastTilt, newTilt, Time.deltaTime);
            Quaternion tiltRotation = Quaternion.Euler(0, 0, tilt);
            lastTilt = tilt;

            return preTiltRotation * tiltRotation;
        }

        public Vector3 currentWP()
        {
            return currentWaypoint.getPosition();
        }

        public Vector3 nextWP()
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
            currentWaypoint = waypoints[currentIndex];

            Debug.Log("Loading next waypoint: "+this.currentWP(), transform);

            startRotation = transform.rotation;
            initialDistance = Vector3.Distance(transform.position, this.currentWP());
            t = 0;

            return currentWP();
        }


        public void takeDetour(Waypoint detourWP) {
            Debug.Log("Taking detour", transform);

            this.currentWaypoint = detourWP;
        }

        public void stopDetour() {
            Debug.Log("Exiting detour", transform);
            
            nextWP();
        }
    }