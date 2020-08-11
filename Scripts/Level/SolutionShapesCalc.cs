using System.Collections.Generic;
using UnityEngine;

public class SolutionShapesCalc : MonoBehaviour
{
    
#pragma warning disable 0649
    [SerializeField]
    FormationVariable solutionFormations;
#pragma warning restore 0649

    private List<GameObject> shapes;
    private List<List<GameObject>> objectFormations;
    private void Start()
    {
        shapes = ShapeCalculations.GetChildShapes(gameObject.transform);
        List<List<int>> duplicateIndexes = ShapeCalculations.GetduplicateShapeIndexes(shapes);
        objectFormations = ShapeCalculations.GetObjectFormations(duplicateIndexes, shapes);
        SetFormations();
    }
    

    public void SetFormations()
    {
        List<List<Vector3>> formations = new List<List<Vector3>>();
        foreach (List<GameObject> objectFormation in objectFormations)
        {
            formations.Add(ShapeCalculations.GetRelativePositions(objectFormation));
        }
        solutionFormations.Value = formations;
    }


}
