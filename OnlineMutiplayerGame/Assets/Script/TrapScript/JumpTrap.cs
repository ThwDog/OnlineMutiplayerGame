using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            Debug.Log("hit");
            player._Hit();
        }    
    }
}
