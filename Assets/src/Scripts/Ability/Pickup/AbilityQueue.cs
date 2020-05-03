using System.Collections;
using UnityEngine;

public class AbilityQueue : MonoBehaviour
{
    private Queue queue;
    public bool IsQueueActive = false;

    private void Awake()
    {
        queue = new Queue();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsQueueActive)
        {
            // check that tag matches condition
            CharacterState state = other.GetComponent<CharacterController>().CharacterState;
            if (state == CharacterState.WALKING)
            {
                Debug.Log("ENTER QUEUE");
                EnterQueue(other.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsQueueActive)
        {
            CharacterState state = other.GetComponent<CharacterController>().CharacterState;
            if (state != CharacterState.ABILITY_ACTIVE)
            {
                Debug.Log("Leave QUEUE");
                LeaveQueue();
            }
        }
    }

    public int GetQueueLength()
    {
        return queue.Count;
    }

    private void EnterQueue(GameObject GO)
    {
        GO.GetComponent<CharacterController>().CharacterState = CharacterState.IN_QUEUE;
        queue.Enqueue(GO);
    }

    public GameObject LeaveQueue()
    {
        if (queue.Count > 0)
        {
            GameObject GO = (GameObject)queue.Dequeue();
            GO.GetComponent<CharacterController>().CharacterState = CharacterState.IDLE;
            return GO;
        }
        else
        {
            return null;
        }
    }

}
