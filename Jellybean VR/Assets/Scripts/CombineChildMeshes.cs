using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineChildMeshes : MonoBehaviour
{
    public void Start()
    {
        Combine();
    }

    public void Combine()
    {
        List<MeshFilter> children = new List<MeshFilter>(GetComponentsInChildren<MeshFilter>());

        while (children.Count > 0)
        {
            //List<MeshFilter> meshFilters = new List<MeshFilter>();
            List<CombineInstance> combineInstances = new List<CombineInstance>();
            Material matTarget = children[0].gameObject.GetComponent<MeshRenderer>().sharedMaterial; // Type of mesh being combined this pass
            GameObject compositeMesh = new GameObject("Composite Mesh");
            compositeMesh.transform.position = transform.position;
            compositeMesh.transform.parent = transform;
            compositeMesh.AddComponent<MeshRenderer>();
            compositeMesh.AddComponent<MeshFilter>();

            List<MeshFilter> childrenToRemove = new List<MeshFilter>();
            foreach (MeshFilter child in children)
            {
                //Debug.Log(child.gameObject.name);
                //Debug.Log(child.gameObject.GetComponent<MeshRenderer>().sharedMaterial);
            
                if (child.gameObject.GetComponent<MeshRenderer>().sharedMaterial == matTarget)
                {
                    //Debug.Log("Adding Mesh");
                    //meshFilters.Add(child);

                    CombineInstance newCI = new CombineInstance();
                    newCI.mesh = child.sharedMesh;
                    newCI.transform = compositeMesh.transform.worldToLocalMatrix * child.transform.localToWorldMatrix;
                    combineInstances.Add(newCI);
                    child.gameObject.SetActive(false);

                    childrenToRemove.Add(child);
                }
            }

            foreach (MeshFilter child in childrenToRemove)
                children.Remove(child);

            CombineInstance[] cis = new CombineInstance[combineInstances.Count];
            combineInstances.CopyTo(cis);
            // Debug.Log(cis.Length);

            compositeMesh.GetComponent<MeshFilter>().mesh = new Mesh();
            compositeMesh.GetComponent<MeshFilter>().mesh.CombineMeshes(cis, true, true, true);
            gameObject.SetActive(true);
            compositeMesh.GetComponent<Renderer>().sharedMaterial = matTarget;
        }
    }
}
