using System.Collections.Generic;
using UnityEngine;

public class AINodeManager : MonoBehaviour
{
    #region SingleTon
    public static AINodeManager instance;

    private void Awake()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }
    #endregion

    List<Transform> NodeList = new List<Transform>();

    private void Start()
    {
        foreach (Transform node in GetComponentsInChildren<Transform>())
        {
            NodeList.Add(node);
        }
    }

    public Transform GetClosesedNode(Transform currentPos)
    {
        Transform toReturn = NodeList[0];

        float shortestDistance = Vector3.Distance(NodeList[0].position, currentPos.position);

        foreach (Transform node in NodeList)
        {
            float newDistance = Vector3.Distance(node.position, currentPos.position);

            if (newDistance < shortestDistance)
            {
                //We have a closer node
                shortestDistance = newDistance;
                toReturn = node;
            }
        }

        return toReturn;
    }
}