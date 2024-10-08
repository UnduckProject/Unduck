using UnityEngine;

public class LookAtWithYAxisRotation : MonoBehaviour
{
    private Transform target; 
    public Vector3 additionalRotation; 

    private void Start()
    {
        target = GameObject.Find("[BuildingBlock] Camera Rig")?.transform;
        if (target == null)
        {
            Debug.LogWarning("타겟 오브젝트를 찾을 수 없습니다.");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            if (direction.magnitude > 0) 
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Quaternion finalRotation = Quaternion.Euler(0, lookRotation.eulerAngles.y + additionalRotation.y, 0);

                transform.rotation = finalRotation;
            }
        }
    }
}
