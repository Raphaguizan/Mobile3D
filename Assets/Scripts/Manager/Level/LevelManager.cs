using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    
    [Header("pieces config")]
    public int startPiecesNumber;
    public List<GameObject> startPieces;
    [Space]
    public int middlePiecesNumber;
    public List<GameObject> middlePieces;
    [Space]
    public int endPiecesNumber;
    public List<GameObject> endPieces;

    private LevelPiece _currentPiece;
    private List<LevelPiece> _PiecesUsed = new List<LevelPiece>();

    private void Start()
    {
        CreateLevel();
    }
    private void CleanPieces()
    {
        for (int i = _PiecesUsed.Count -1; i >= 0 ; i--)
        {
            Destroy(_PiecesUsed[i]);
        }
        _PiecesUsed.Clear();
    }

    public void CreateLevel()
    {
        CleanPieces();
        for (int i = 0; i < startPiecesNumber; i++)
        {
            GeneretaPiece(startPieces);
        }
        for (int i = 0; i < middlePiecesNumber; i++)
        {
            GeneretaPiece(middlePieces);
        }
        for (int i = 0; i < endPiecesNumber; i++)
        {
            GeneretaPiece(endPieces);
        }
    }

    public void GeneretaPiece(List<GameObject> list)
    {
        var piece = list[Random.Range(0, list.Count)];

        if (!_currentPiece)
        {
            _currentPiece = Instantiate(piece, container).GetComponent<LevelPiece>();
        }
        else
        {
            _currentPiece = Instantiate(piece, _currentPiece.EndPoint).GetComponent<LevelPiece>();
        }
        _currentPiece.transform.localPosition = Vector3.zero;
    }
}
