using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New_Level", menuName ="Game/Level/Level")]
public class LevelBase : ScriptableObject
{
    //properties
    public int StartPiecesNumber => startPiecesNumber;
    public int MiddlePiecesNumber => middlePiecesNumber;
    public int EndPiecesNumber => endPiecesNumber;

    //publics 
    [Header("Types")]
    public ColorSetUp colorType;
    public ArtListSetUp artType;

    //serializables
    [Header("Pieces Configuration"), SerializeField]
    private int startPiecesNumber;
    [SerializeField]
    private List<LevelPiece> startPieces;

    [SerializeField, Space]
    private int middlePiecesNumber;
    [SerializeField]
    private List<LevelPiece> middlePieces;

    [SerializeField, Space]
    private int endPiecesNumber;
    [SerializeField]
    private List<LevelPiece> endPieces;

    //privates
    private LevelPiece _currentPiece;
    private List<GameObject> _PiecesUsed = new List<GameObject>();

    public void CleanPieces()
    {
        for (int i = _PiecesUsed.Count - 1; i >= 0; i--)
        {
            Destroy(_PiecesUsed[i]);
        }
        _PiecesUsed.Clear();
    }

    private void GeneretaPiece(List<LevelPiece> list, Transform container)
    {
        Transform spawnParent = container;
        if (_currentPiece)
            spawnParent = _currentPiece.EndPoint;

        var piece = list[Random.Range(0, list.Count)];

        _currentPiece = Instantiate(piece.gameObject, spawnParent).GetComponent<LevelPiece>();
        _PiecesUsed.Add(_currentPiece.gameObject);
        _currentPiece.transform.localPosition = Vector3.zero;
        _currentPiece.transform.SetParent(container);
        ConfigureArtPiece();
    }

    private void ConfigureArtPiece()
    {
        for (int i = 0; i < _currentPiece.ArtPointsCount; i++)
        {
            _currentPiece.InsertArt(artType.artList[Random.Range(0, artType.artList.Count)]);
        }
        _currentPiece.SetColor(colorType);
    }

    public void GenerateStartPiece(Transform container)
    {
        GeneretaPiece(startPieces, container);
    }
    public void GenerateMiddlePiece(Transform container)
    {
        GeneretaPiece(middlePieces, container);
    }
    public void GenerateFinalPiece(Transform container)
    {
        GeneretaPiece(endPieces, container);
    }

}
