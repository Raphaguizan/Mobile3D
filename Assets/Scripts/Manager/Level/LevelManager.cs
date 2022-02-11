using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public Material skyBoxMaterial;
    public List<LevelBase> levels;
    public float constructDelay = .01f;

    private LevelBase _currentLevel;
    private int levelCount = 0;

    private void Start()
    {
        CreateLevel();
    }

    [ContextMenu("Pass Level")]
    public void PassLevel()
    {
        levelCount++;
        if (levelCount >= levels.Count)
            levelCount = 0;
        CreateLevel();
    }

    public void CreateLevel()
    {
        if (_currentLevel) _currentLevel.CleanPieces();
        _currentLevel = levels[levelCount];
        ChangeSkyColor(_currentLevel.colorType);
        StartCoroutine(DelayToContruct());
    }

    private void ChangeSkyColor(ColorSetUp color)
    {
        skyBoxMaterial.SetColor("_SkyTint", color.skyBoxSkyColor);
        skyBoxMaterial.SetColor("_GroundColor", color.skyBoxFloorColor);
    }


    IEnumerator DelayToContruct()
    {
        for (int i = 0; i < _currentLevel.StartPiecesNumber; i++)
        {
            _currentLevel.GenerateStartPiece(container);
        }
        for (int i = 0; i < _currentLevel.MiddlePiecesNumber; i++)
        {
            yield return new WaitForSeconds(constructDelay);
            _currentLevel.GenerateMiddlePiece(container);
        }
        for (int i = 0; i < _currentLevel.EndPiecesNumber; i++)
        {
            yield return new WaitForSeconds(constructDelay);
            _currentLevel.GenerateFinalPiece(container);
        }
    }
}
