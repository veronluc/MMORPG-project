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
        this.ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
        this.ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>();
        this.dataModule = GameObject.FindGameObjectWithTag("DataModule").GetComponent<DataModule>();
        this.networkModule = GameObject.FindGameObjectWithTag("NetworkModule").GetComponent<NetworkModule>();

        // Dispatch interfaces
        this.ihmMainModule.dataInterface = this.dataModule.GetInterfaceForIHMMain();
        DataModule.ihmMainInterface = this.ihmMainModule.ihmMainInterface;
        DataModule.networkInterface = this.networkModule.GetNetworkInterface();
        DataModule.ihmGameInterface = this.ihmGameModule.ihmGameInterface;
        this.networkModule.dataInterfaceForNetwork = this.dataModule.GetInterfaceForNetwork();
        this.ihmGameModule.dataInterface = this.dataModule.GetInterfaceForIHMGame();
        this.ihmGameModule.GameManager.dataInterface = this.dataModule.GetInterfaceForIHMGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
