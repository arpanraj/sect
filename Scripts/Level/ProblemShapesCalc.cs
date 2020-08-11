using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ProblemShapesCalc : MonoBehaviour
{
    
#pragma warning disable 0649
    [SerializeField]
    FormationVariable problemFormation;
    [SerializeField]
    UnityEvent OnFormationUpdated;

#pragma warning restore 0649
    private List<GameObject> shapes;

    private void Start()
    {
        shapes = ShapeCalculations.GetChildShapes(gameObject.transform);
    }

    public void UpdateFormations()
    {
        problemFormation.Value =  new List<List<Vector3>>() { ShapeCalculations.GetRelativePositions(shapes) };
        OnFormationUpdated.Invoke();
    }

}
