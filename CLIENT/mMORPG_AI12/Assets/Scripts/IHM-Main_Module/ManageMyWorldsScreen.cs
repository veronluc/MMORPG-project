using System;
using System.Collections.Generic;
using AI12_DataObjects;
using UnityEngine;


public class ManageMyWorldsScreen : MonoBehaviour
{
    // Properties
    private LocalUser localUser;
    private IHMMainModule ihmMainModule;
    private DataInterfaceForIHMMain dataInterface;
    private GameObject localWorldsManager;

    public void Awake()
    {
        this.ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>();
    }

    public void Start()
    {
        this.localUser = ihmMainModule.localUser;
        this.dataInterface = ihmMainModule.dataInterface;
        localWorldsManager = GameObject.FindGameObjectWithTag("LocalWorlds");
    }

    /// <summary>
    /// Update the current list of local worlds own by the user
    /// <param name="newListWorlds">Worlds currently available</param>
    /// </summary>
    public void UpdateListWorldsDisplay(List<World> localUserWorlds)
    {
        localWorldsManager.GetComponent<UserWorldsManager>().SetUserWorldsList(localUserWorlds);
    }

    /// <summary>
    /// Create a local world
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sizeMap"></param>
    /// <param name="gameMode"></param>
    /// <param name="realDeath"></param>
    /// <param name="difficulty"></param>
    /// <param name="roundTimeSec"></param>
    /// <param name="nbMaxPlayer"></param>
    /// <param name="nbMaxMonsters"></param>
    /// <param name="nbShops"></param>
    /// <param name="hasCity"></param>
    /// <param name="hasPlain"></param>
    /// <param name="hasSwamp"></param>
    /// <param name="hasRiver"></param>
    /// <param name="hasForest"></param>
    /// <param name="hasRockyPlain"></param>
    /// <param name="hasMontain"></param>
    /// <param name="hasSea"></param>
    public void CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty,
        int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp,
        bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea)
    {
        try
        {
            if (!name.Equals("") && roundTimeSec != null && nbMaxPlayer != null && nbMaxMonsters != null && nbShops != null )
            {
                dataInterface.CreateWorld(name, sizeMap, gameMode, realDeath, difficulty,  roundTimeSec,  nbMaxPlayer,  nbMaxMonsters,  nbShops,  hasCity,  hasPlain,  hasSwamp,  hasRiver,  hasForest,  hasRockyPlain,  hasMontain,  hasSea, localUser.user);
            }
            else
            {
                MessagePopupManager.ShowWarningMessage("Un ou plusieurs champs n'a pas été rempli");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception : " + e);
            // handle world creation errors
        }
    }

    /// <summary>
    /// request to load a local world on server and join this world 
    /// </summary>
    /// <param name="player"></param>
    /// <param name="idWorld"></param>
    public void LoadWorld(Player player, string idWorld)
    {
        try
        {
            if (player != null && idWorld != null)
            {
                //TODO : Data doit pouvoir ajouter le playerid dans leur interface 
                //dataInterface.LoadWorld(player, idWorld);
            }
            else
            {
                MessagePopupManager.ShowErrorMessage(
                    "Le monde ou le personnage selectionné n'ont pas été trouvé, veuillez réessayer");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception : " + e);
            // handle load world errors
        }
    }

    /// <summary>
    /// update a local world settings
    /// </summary>
    /// <param name="updatedWorld"></param>
    public void UpdateWorld(World updatedWorld)
    {
        try
        {
            if (updatedWorld != null)
            {
                dataInterface.UpdateWorld(updatedWorld);
            }
            else
            {
                MessagePopupManager.ShowErrorMessage("Le monde modifié n'a pas été trouvé,  veuillez réessayer");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception : " + e);
            // handle update world errors
        }
    }

    /// <summary>
    /// delete a local world 
    /// </summary>
    /// <param name="deletedWorld"></param>
    public void DeleteWorld(World deletedWorld)
    {
        try
        {
            if (deletedWorld != null)
            {
                dataInterface.DeleteWorld(deletedWorld);
            }
            else
            {
                MessagePopupManager.ShowErrorMessage("Le monde supprimé n'a pas été trouvé,  veuillez réessayer");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception : " + e);
            // handle delete world errors
        }
    }
}