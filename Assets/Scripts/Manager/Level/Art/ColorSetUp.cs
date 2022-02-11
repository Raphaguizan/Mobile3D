using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new_colorSetup", menuName ="Game/Level/Color")]
public class ColorSetUp : ScriptableObject
{
    [Header("Objects"), Space]
    public Color floorColor;
    [Space]
    public Color artColor;
    [Header("SkyBox"), Space]
    public Color skyBoxSkyColor;
    [Space]
    public Color skyBoxFloorColor;

    #region constructors
    private void DefaultColors()
    {
        floorColor = Color.white;
        artColor = Color.white;
        skyBoxSkyColor = Color.white;
    }
    public ColorSetUp() 
    {
        DefaultColors();
    }
    public ColorSetUp(Color floor)
    {
        DefaultColors();
        floorColor = floor;
    }
    public ColorSetUp(Color floor, Color art)
    {
        DefaultColors();
        floorColor = floor;
        artColor = art;
    }
    public ColorSetUp(Color floor, Color art, Color sky)
    {
        floorColor = floor;
        artColor = art;
        skyBoxSkyColor = sky;
    }
    #endregion
}
