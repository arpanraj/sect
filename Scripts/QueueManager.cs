using UnityEngine;

public enum QueueType
{
    Simple,
    Circular
}

public abstract class QueueManager : MonoBehaviour
{
    dynamic queue;
    int index = 0;
    private QueueType queueType;
    private int max;

    protected void SetQueue(dynamic queue,QueueType queueType)
    {
        this.queue = queue;
        this.queueType = queueType;
        this.max = queue.Length;
    }
    
    
    protected dynamic current()
    {
        return queue[index];
    }

    protected int GetIndex()
    {
        return index;
    }

    protected void SetIndex(int value)
    {
        index = value;
    }

    protected bool isLast()
    {
        return index == max - 1;
    }

    protected dynamic Next()
    {
        index++;
        if (index == max)
        {
            if (queueType == QueueType.Circular)
            {
                index = 0;
            }
            else
            {
                //Debug.Log("Array Complete");
                index = max - 1;
            }
        }
        return queue[index];
    }

    protected dynamic Previous()
    {
        index--;
        if (index == -1)
        {
            if (queueType == QueueType.Circular)
            {
                index = max - 1;
            }
            else
            {
                //Debug.Log("Array Complete");
                index = 0;
            }
        }
        
        return queue[index];
    }

}
