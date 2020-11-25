using System;
using System.Collections.Generic;
using AI12_DataObjects;
using UnityEngine;


public class ManageMyWorldsScreen : MonoBehaviour
{
    // Properties
    private User currentUser; 
    private IHMMainModule ihmMainModule;
    private DataInterfaceForIHMMain dataInterface;
    private GameObject localWordlsManager; 

    public void Awake()
    {
        this.ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>();
        this.dataInterface = ihmMainModule.dataInterface;
    }

    public void Start()
    {
        this.currentUser = ihmMainModule.getCurrentUser(); 
        this.dataInterface = ihmMainModule.dataInterface;
        localWordlsManager = GameObject.FindGameObjectWithTag("LocalWorlds");

        UpdateListWorldsDisplay();
    }

    /// <summary>
    /// Update the current list of local worlds own by the user
    /// <param name="newListWorlds">Worlds currently available</param>
    /// </summary>
    public void UpdateListWorldsDisplay()
    {
        //TODO : DATA need to update their User object to add a List<wolrd> worlds 
        //TODO : IMH MAIN Need to creat IHM and component LocalWorlds Manager
        //localWordlsManager.GetComponent<LocalWorldsManager>().SetWorldList(this.currentUser.worlds);
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
    public void createWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea)
    {
        try
        {
            if (name != null && sizeMap != null && gameMode != null && realDeath != null && difficulty != null &&
                roundTimeSec != null && nbMaxPlayer != null && nbMaxMonsters != null && nbShops != null &&
                hasCity != null && hasPlain != null && hasSwamp != null && hasRiver != null && hasForest != null &&
                hasRockyPlain != null && hasMontain != null && hasSea != null)
            {
                //TODO : voir avec data ce qu'il leur faut lors de la création y'a des choses qu'on ne peut pas fournir 
                //dataInterface.CreateWorld(name, sizeMap, gameMode, realDeath, difficulty,  roundTimeSec,  nbMaxPlayer,  nbMaxMonsters,  nbShops,  hasCity,  hasPlain,  hasSwamp,  hasRiver,  hasForest,  hasRockyPlain,  hasMontain,  hasSea);

                //TODO: quand le monde est créé on l'add à la liste des monde du user et on update le display
                //Est-ce qu'on le met quand dans notre local ou faut que data une fois créer et user update il nous renvoie le user ? 
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
    public void LoadWorld(Player player, string idWorld) {
        try
        {
            if (player != null && idWorld != null)
            {
                //TODO : data doit mettre à jour sont interface de load world
                //dataInterface.LoadWorld(player, idWorld);
            }
            else
            {
                MessagePopupManager.ShowErrorMessage("Le monde ou le personnage selectionné n'ont pas été trouvé, veillez réesayer");
            }

        }
        catch (Exception e)
        {
            Debug.Log("Exception : " + e);
            // handle load world errors
        }
    }

    /// <summary>
    /// update a world local world settings
    /// </summary>
    /// <param name="updatedWorld"></param>
    public void updateWorld(World updatedWorld)
    {
        try
        {
            if (updatedWorld != null)
            {
                //TODO : data doit mettre à jour son interface 
                //dataInterface.updateWorld(updatedWorld);
            }
            else
            {
                MessagePopupManager.ShowErrorMessage("Le monde modifié n'a pas été trouvé,  veillez réesayer");
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
    public void deleteWorld(World deletedWorld)
    {
        try
        {
            //TODO : data doit mettre à jour son interface 
            if (deletedWorld != null)
            {
                //TODO : data doit mettre à jour son interface 
                //dataInterface.deleteWorld(deletedWorld);
            }
            else
            {
                MessagePopupManager.ShowErrorMessage("Le monde supprimé n'a pas été trouvé,  veillez réesayer");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception : " + e);
            // handle delete world errors
        }
    }
}
