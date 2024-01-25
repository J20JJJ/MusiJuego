using UnityEngine;

public class muerte : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nota") || other.gameObject.CompareTag("+1"))
        {
            Debug.Log("Entra");
            Destroy(other.gameObject);
        }
    }

}