using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class CompletionChecker : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    UnityEvent OnLevelComplete;
    [SerializeField]
    FormationVariable solutionFormations;
    [SerializeField]
    FormationVariable problemFormation;
#pragma warning restore 0649

    public void Check()
    {
        if (solutionFormations.Value == null || problemFormation.Value == null)
        {
            //Debug.Log("Not Assigned Yet");
            return;
        }
        if (solutionFormations.Value.Count == 0 || problemFormation.Value.Count == 0)
        {
            Debug.Log("No shapes");
            return;
        }
        foreach(List<Vector3> solutionFormation in solutionFormations.Value)
        {
            if (problemFormation.Value[0].SequenceEqual(solutionFormation))
            {
                OnLevelComplete.Invoke();
                return;
            }
        }
    }
}
