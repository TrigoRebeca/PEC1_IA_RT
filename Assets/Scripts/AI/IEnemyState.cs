using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState 
{
    void UpdateState();
    void GoToAttackState();
    void GoToPatrolState();
    void GoToAlertState();
    void OnTriggerEnter(Collider col);
    void OnTriggerStay(Collider col);
    void OnTriggerExit(Collider col);
    void Impact();



}
