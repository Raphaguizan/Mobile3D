using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPiece : MonoBehaviour
{
    public int ArtPointsCount => artPoints.Count;

    public Transform startPoint;
    public Transform EndPoint;

    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private List<Transform> artPoints;

    private List<GameObject> _artObjs = new List<GameObject>();

    #region Art
    public void InsertArt(GameObject artObj)
    {
        if (_artObjs.Count >= artPoints.Count) return;
        GameObject art = Instantiate(artObj, transform);

        Transform artTransform = artPoints[_artObjs.Count];
        art.transform.position = artTransform.position;
        art.transform.rotation = artTransform.rotation;

        _artObjs.Add(art);
    }

    public void ResetArt()
    {
        for (int i = _artObjs.Count - 1; i >= 0; i--)
        {
            Destroy(_artObjs[i]);
        }
        _artObjs.Clear();
    }
    #endregion

    #region Color
    public void SetColor(ColorSetUp colorSetup)
    {
        floor.GetComponent<Renderer>().material.color = colorSetup.floorColor;
        foreach(GameObject art in _artObjs)
        {
            foreach (Renderer rend in art.GetComponentsInChildren<Renderer>())
                rend.material.color = colorSetup.artColor;
        }
    }

    public void ResetColors()
    {
        ColorSetUp resetSetUp = new ColorSetUp();
        SetColor(resetSetUp);
    }

    private void OnDisable()
    {
        ResetColors();
    }
    #endregion
}
