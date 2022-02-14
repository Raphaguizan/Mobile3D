using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using DG.Tweening;

public class LevelManager : Singleton<LevelManager>
{
    public static Action PassLevelCallback;

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

    // Pode passar o level durante o jogo pelo contex menu (os tres pontinhos do componente) no inspector.
    [ContextMenu("Pass Level")]
    public void PassLevel()
    {
        levelCount++;
        if (levelCount >= levels.Count)
            levelCount = 0;
        PassLevelCallback.Invoke();
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
        StartCoroutine(SkySmoothColorChange(color));
    }

    IEnumerator SkySmoothColorChange(ColorSetUp color)
    {
        float lerpColor = 0;
        Color CurrentSkyColor = skyBoxMaterial.GetColor("_SkyTint");
        Color CurrentFloorColor = skyBoxMaterial.GetColor("_GroundColor");

        while (lerpColor < 1)
        {
            Color skyLerp = Color.Lerp(CurrentSkyColor, color.skyBoxSkyColor, lerpColor);
            Color floorLerp = Color.Lerp(CurrentFloorColor, color.skyBoxFloorColor, lerpColor);

            lerpColor += Time.deltaTime;
            skyBoxMaterial.SetColor("_SkyTint", skyLerp);
            skyBoxMaterial.SetColor("_GroundColor", floorLerp);
            yield return null;
        }
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
