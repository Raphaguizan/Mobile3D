using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelPiece : MonoBehaviour
{
    public int ArtPointsCount => _artPoints.Count;

    public Transform startPoint;
    public Transform EndPoint;

    [Header("Animation")]
    [SerializeField]
    private GameObject _objects;
    [SerializeField]
    private float _AnimationDuration = .8f;
    [SerializeField]
    private Ease _ease = Ease.OutBack;

    [Header("Art")]
    [SerializeField]
    private GameObject _floor;
    [SerializeField]
    private List<Transform> _artPoints;

    private List<GameObject> _artObjs = new List<GameObject>();

    #region Art
    private void OnEnable()
    {
        _objects.transform.localScale = Vector3.zero;
        _objects.transform.DOScale(Vector3.one, _AnimationDuration).SetEase(_ease);
    }

    public void InsertArt(GameObject artObj)
    {
        if (_artObjs.Count >= _artPoints.Count) return;
        GameObject art = Instantiate(artObj, transform);

        Transform artTransform = _artPoints[_artObjs.Count];
        art.transform.localPosition = artTransform.localPosition;
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
        _floor.GetComponent<Renderer>().material.DOColor(colorSetup.floorColor, _AnimationDuration).SetDelay(.5f).SetEase(_ease);
        foreach(GameObject art in _artObjs)
        {
            foreach (Renderer rend in art.GetComponentsInChildren<Renderer>())
                rend.material.DOColor(colorSetup.artColor, _AnimationDuration).SetDelay(.5f).SetEase(_ease);
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
