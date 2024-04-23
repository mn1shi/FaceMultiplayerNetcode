using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerPresentation : NetworkBehaviour
{
    private NetworkObject networkObject;

    [SerializeField]
    private List<GameObject> remoteOnly = new List<GameObject>();

    private bool prevIsOwner
    {
        get => internalPrevIsOwner;

        set
        {
            if(value != internalPrevIsOwner)
            {
                internalPrevIsOwner = value;
                OnChangedOwner(internalPrevIsOwner);
            }
        }
    }

    private void OnChangedOwner(bool v)
    {

    }

    private bool internalPrevIsOwner;

    public override void OnNetworkSpawn()
    {

    }

}
