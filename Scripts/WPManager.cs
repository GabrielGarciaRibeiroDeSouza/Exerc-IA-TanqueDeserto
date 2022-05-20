using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Link
{
    public enum direction { UNI, BI}
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();
    
    void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }
            foreach (Link _link in links)
            {
                graph.AddEdge(_link.node1, _link.node2);
                if (_link.dir == Link.direction.BI)
                {
                    graph.AddEdge(_link.node2, _link.node1);
                }
            }
        }
    }

   
    void Update()
    {
        graph.debugDraw();
    }
}
