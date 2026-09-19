using UnityEngine;


//Let us create this script into an object/asset
//Parameters (FileName, MenuName)
[CreateAssetMenu(fileName = "NewWeapon", menuName = "GameData/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string weight;
    public string weaponSpeed;
    public float hitBoxSize;
    public float hitBoxPos;
    public int basedamage;
    public Sprite weaponSprite;
    public bool Canshoot;
}
