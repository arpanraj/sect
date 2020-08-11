using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ShapeCalculations
{
    public static List<GameObject> GetChildShapes(Transform parent)
    {
        int childCount = parent.childCount;
        List<GameObject> childShapes = new List<GameObject>();
        
        for (int i = 0; i < childCount; i++)
        {
            childShapes.Add(parent.GetChild(i).gameObject);
        }
        childShapes = childShapes.OrderBy(x => x.GetComponent<ShapeIdentifier>().id).ToList();
        return childShapes;
    }

    public static List<Vector3> GetRelativePositions(List<GameObject> shapes)
    {
        List<Vector3> relativePositions = new List<Vector3>();
        if (shapes.Count < 2)
            return relativePositions;
        List<Vector3> positions = GetPositions(shapes);
        int shapeIndexLimit = shapes.Count - 1;
        for (int i = 0; i < shapeIndexLimit; i++)
        {
            Transform shaTra = shapes[i].GetComponent<Transform>();
            int j = i + 1;
            for (; j < shapes.Count; j++)
            {
                relativePositions.Add(shaTra.InverseTransformPoint(positions[j]));
            }
        }
        return relativePositions;
    }

    public static List<Vector3> GetPositions(List<GameObject> shapes)
    {
        List<Vector3> positions = new List<Vector3>();
        if (shapes.Count == 0) return positions;
        foreach (GameObject shape in shapes)
        {
            positions.Add(shape.transform.position);
        }
        return positions;
    }

    public static List<List<int>> GetduplicateShapeIndexes(List<GameObject> shapes)
    {
        List<List<int>> indexes = new List<List<int>>();
        if (shapes.Count < 2)
            return indexes;
        List<int> shapeIds = GetShapeIds(shapes);

        int shapeIndexLimit = shapes.Count - 1;
        for (int i = 0; i < shapeIndexLimit; i++)
        {
            int iShapeId = shapeIds[i];
            List<int> dupIds = new List<int>
            {
                i
            };
            bool hasDup = false;
            int j = i + 1;
            for (; j < shapes.Count; j++)
            {
                int jShapeId = shapeIds[j];
                if (iShapeId == jShapeId)
                {
                    dupIds.Add(j);
                    hasDup = true;
                }
            }
            if (hasDup)
            {

                indexes.Add(dupIds);
            }
        }
        return indexes;
    }
    public static List<List<GameObject>> GetObjectFormations(List<List<int>> duplicateShapeIndexes, List<GameObject> shapes)
    {
        List<List<GameObject>> reArrangedLists = new List<List<GameObject>>();
        reArrangedLists.Add(shapes.ToList());
        if (shapes.Count == 0 || duplicateShapeIndexes.Count == 0)
        {
            return reArrangedLists;
        }
        foreach (List<int> dupShaInds in duplicateShapeIndexes)
        {
            int dupShaIndLimit = dupShaInds.Count - 1;

            foreach (List<GameObject> reArrangedList in reArrangedLists.ToList())
            {
                for (int i = 0; i < dupShaIndLimit; i++)
                {
                    int dupShaInd = dupShaInds[i];
                    int j = i + 1;
                    for (; j < dupShaInds.Count; j++)
                    {
                        List<GameObject> reformedShapes = reArrangedList.ToList().Swap(dupShaInds[i], dupShaInds[j]).ToList();
                        reArrangedLists.Add(reformedShapes.ToList());
                    }
                }
            }
        }
        return reArrangedLists;
    }
    public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
        return list;
    }

    public static List<int> GetShapeIds(List<GameObject> shapes)
    {
        List<int> shapeIds = new List<int>();
        if (shapes.Count == 0) return shapeIds;
        foreach (GameObject shape in shapes)
        {
            shapeIds.Add(shape.GetComponent<ShapeIdentifier>().id);
        }
        return shapeIds;
    }
}
