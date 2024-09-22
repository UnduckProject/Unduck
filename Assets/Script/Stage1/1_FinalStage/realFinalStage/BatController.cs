using UnityEngine;

public class BatController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("attack"))
        {
            Rigidbody attackRb = collision.gameObject.GetComponent<Rigidbody>();
            if (attackRb != null)
            {
                Vector3 bossPosition = GameData.FirstBossTransform;
                Vector3 hitDirection = (bossPosition - collision.transform.position).normalized;
                float hitForce = 80f;
                attackRb.AddForce(hitDirection * hitForce, ForceMode.Impulse);
                collision.gameObject.tag = "playerattack";
            }
        }
    }
}
