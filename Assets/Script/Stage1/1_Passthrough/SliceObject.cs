using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator; 
    public LayerMask sliceableLayer;
    public Material crossSectionMaterial;
    public float cutForce = 2000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if(hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
        
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position,velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target,crossSectionMaterial);
            SetupSlicedComponent(upperHull);
            GameObject loverHull = hull.CreateLowerHull(target,crossSectionMaterial);
            SetupSlicedComponent(loverHull);

            Destroy(target);
        }
    }

    public void SetupSlicedComponent(GameObject SlicedObject)
    {
        Rigidbody rb = SlicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = SlicedObject.AddComponent<MeshCollider>();
        collider.convex= true;
        rb.AddExplosionForce(cutForce,SlicedObject.transform.position,1);

    }
}
