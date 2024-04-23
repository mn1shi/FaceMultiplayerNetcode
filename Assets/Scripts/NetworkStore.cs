using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkStore : NetworkBehaviour
{
    SkinnedMeshRenderer SkinnedMeshRenderer;
    public NetworkVariable<SkinnedMeshRenderer> skin = new NetworkVariable<SkinnedMeshRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        skin.Value = SkinnedMeshRenderer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
