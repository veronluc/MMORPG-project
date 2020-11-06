using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInterfaceForIHMMainImpl : DataInterfaceForIHMMain
{
    public List<string> getListUserWorlds()
    {
        List<string> res = new List<string>();
        res.Add("coucou");
        res.Add("Domaine des dieux");
        res.Add("il est 17h, on est dimanche et je bosse là dessus...");
        return res;
    }
}
