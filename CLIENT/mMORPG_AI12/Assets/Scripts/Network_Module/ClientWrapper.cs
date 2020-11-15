using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientWrapper : MonoBehaviour
{
    public Client client { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        client = new Client();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
