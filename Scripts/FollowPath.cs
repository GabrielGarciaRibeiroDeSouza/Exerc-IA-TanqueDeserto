using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5f;
    float accuracy = 1f;
    float rotSpeed = 2f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    void Start()
    {
       wps = wpManager.GetComponent<WPManager>().waypoints;
       g = wpManager.GetComponent<WPManager>().graph;
       currentNode = wps[0];
    }

    //fun��o publica para chamar ao clicar no bot�o
    public void GoToHeli()
    {
        //move para o ponto perto do heliporto
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }
    //fun��o publica para chamar ao clicar no bot�o
    public void GoToRuin()
    {
        //move para o ponto perto das ruinas
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
    }
    //fun��o publica para chamar ao clicar no bot�o
    public void GoToFactory()
    {
        //move para o ponto perto da fabrica
        g.AStar(currentNode, wps[8]);
        currentWP = 0;
    }

    void LateUpdate()
    {
        
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            return;
        }

        //O n� que estar� mais pr�ximo neste momento
        currentNode = g.getPathPoint(currentWP);

        //se estivermos mais pr�ximo bastante do n� o tanque se mover� para o pr�ximo
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        {
            currentWP++;
        }

        if (currentWP < g.getPathLength())
        {
            //pega o tranform do waypoint mais proximo
            goal = g.getPathPoint(currentWP).transform;

            //faz o tank olhar para o waypoit mais proximo
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);

            //faz o calculo de dire��o
            Vector3 direction = lookAtGoal - this.transform.position;

            //faz a rota��o do tank para a dire��o do alvo
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            //move o tank com a velocidade
            this.transform.Translate(0,0, speed * Time.deltaTime);

        }
    }
}
