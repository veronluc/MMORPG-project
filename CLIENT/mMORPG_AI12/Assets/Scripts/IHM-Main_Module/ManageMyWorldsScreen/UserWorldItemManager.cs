using AI12_DataObjects;
using TMPro;
using UnityEngine;

public class UserWorldItemManager : MonoBehaviour
{
    public TextMeshProUGUI worldName;
    public TextMeshProUGUI worldSize;
    public TextMeshProUGUI worldType;

    void Start()
    {
    }

    /// <summary>
    /// Set some world info. to this gameObject (to show it on the screen)
    /// </summary>
    /// <param name="world">The world that will be displayed in this gameObject</param>
    public void SetWorldInfoToGameObject(World world)
    {
        this.worldName.text = world.name;

        this.worldSize.text = world.sizeMap.ToString();

        this.worldType.text = world.gameMode.ToString().ToUpper();
    }
    
    /// <summary>
    /// Only for Test purpose
    /// </summary>
    public void SetRandomInfoToGameObject()
    {
        this.worldName.text = "A wonderful world name";

        this.worldSize.text = "SMALL";

        this.worldType.text = "PVP";
    }
    
}