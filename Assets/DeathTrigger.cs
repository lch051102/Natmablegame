using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        switch (collidedObject.tag)
        {
            case "DeathTrigger":
                // Player hit the death trigger - kill 'em!
                // 여기에 플레이어가 죽도록 구현!
                break;
        }
    }
}
