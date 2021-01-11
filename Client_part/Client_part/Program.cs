using System;

namespace Client_part
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Init module
            NetworkModule networkModule = new NetworkModule();
            networkModule.Awake();
            networkModule.Start();
            DataModule dataModule = new DataModule();
            dataModule.Awake();

            // Init interface for testing (done automatically in Unity)
            DataModule.ihmMainInterface = new IHMMainInterfaceImpl();
            DataModule.networkInterface = networkModule.GetNetworkInterface();
            DataModule.ihmGameInterface = new IHMGameInterfaceImpl();
            networkModule.dataInterfaceForNetwork = dataModule.GetInterfaceForNetwork();

            dataModule.GetInterfaceForIHMMain().CreateUserSession("test", "test123");
            dataModule.GetInterfaceForIHMMain().ConnectSessionToServer("127.0.0.1", "26950");

            // dataModule.GetInterfaceForIHMMain().LogOutServer();

            Console.WriteLine("Enter any key to quit the application");
            Console.Read();
        }
    }
}
