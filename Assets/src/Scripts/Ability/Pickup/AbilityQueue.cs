using System.Collections;
using UnityEngine;

public class AbilityQueue : MonoBehaviour
{
    private Queue queue;
    //private int allowedQueueSize;

    private void Awake()
    {
        queue = new Queue();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter Queue: tag: " + other.tag);
        // check that tag matches condition
        EnterQueue(other.gameObject);
    }

    public int GetQueueLength()
    {
        return queue.Count;
    }

    private void EnterQueue(GameObject GO)
    {
        GO.GetComponent<CharacterController>().SetCharacterState(CharacterState.IN_QUEUE);
        queue.Enqueue(GO);
    }

    public GameObject LeaveQueue()
    {
        if (queue.Count > 0)
        {
            return (GameObject)queue.Dequeue();
        }
        else
        {
            return null;
        }
    }

}
