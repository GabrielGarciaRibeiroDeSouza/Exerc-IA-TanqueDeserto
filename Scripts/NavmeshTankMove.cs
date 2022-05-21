using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshTankMove : MonoBehaviour
{
    //variavel publica para adicionar o agente
    public NavMeshAgent agent;
 
    void Update()
    {
        //se clicar o botão esquerdo mouse
        if (Input.GetMouseButtonDown(0))
        {
            //variavel para armazenar a posição do mouse
            RaycastHit hit;

            //cria um raycast na posição do mouse
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {       
                //define o destino do agente igual a posição do "hit.point"(um vetor3) 
                agent.SetDestination(hit.point);
            }
        }
    }
}
