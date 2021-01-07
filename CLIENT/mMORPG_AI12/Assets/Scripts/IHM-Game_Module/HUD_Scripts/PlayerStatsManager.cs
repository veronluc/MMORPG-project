using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour
{
    public Text mana;
    public Text life;
    public Text move;
    public Text playerName;
    private IHMGameModule ihmGameModule;

    private void Start()
    {
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
        mana = GameObject.FindGameObjectWithTag("ManaValue").GetComponent<Text>();
        mana.text = ihmGameModule.player.mana.ToString();
        life = GameObject.FindGameObjectWithTag("LifeValue").GetComponent<Text>();
        life.text = ihmGameModule.player.vitality.ToString();
        move = GameObject.FindGameObjectWithTag("MoveValue").GetComponent<Text>();
        //quelle valeur faut-il mettre ici ?
        move.text = ihmGameModule.player.PM.ToString();
        playerName = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<Text>();
        //valeur à changer
        playerName.text = ihmGameModule.CurrentPlayer.name;
    }
}
