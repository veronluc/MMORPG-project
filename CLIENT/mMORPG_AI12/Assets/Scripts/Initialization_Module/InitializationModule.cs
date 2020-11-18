using UnityEngine;

public class InitializationModule : MonoBehaviour
{
    IHMMainModule ihmMainModule;
    IHMGameModule ihmGameModule;
    DataModule dataModule;
    NetworkModule networkModule;

    // Start is called before the first frame update
    void Start()
    {
        // Get Modules Script (Module main script)
        this.ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>();
        this.ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
        this.dataModule = GameObject.FindGameObjectWithTag("DataModule").GetComponent<DataModule>();
        this.networkModule = GameObject.FindGameObjectWithTag("NetworkModule").GetComponent<NetworkModule>();

        // Dispatch interfaces
        this.ihmMainModule.dataInterface = this.dataModule.GetInterfaceForIHMMain();
        DataModule.networkInterface = this.networkModule.GetNetworkInterface();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
