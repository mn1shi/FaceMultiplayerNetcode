using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(NetworkObject))]
public class FacialExpressionControl : NetworkBehaviour
{
    //[SerializeField]
    //private NetworkVariable<SkinnedMeshRenderer> networkMesh = new NetworkVariable<SkinnedMeshRenderer>();

    [SerializeField]
    private NetworkVariable<float> jawOpen = new NetworkVariable<float>();

    private float oldJawOpen = 0;

    [SerializeField]
    private SkinnedMeshRenderer avatarMesh;

    // Start is called before the first frame update
    void Start()
    {
        // if no player controll 

    }

    // Update is called once per frame
    void Update()
    {
        if (IsClient && IsOwner)
        {
            ClientFacialInput();
        }

        ClientFacialMove();
    }

    private void ClientFacialInput()
    {
        float inputJawOpen = avatarMesh.GetBlendShapeWeight(4);
        if (oldJawOpen != inputJawOpen)
        {
            oldJawOpen = inputJawOpen;
            UpdateClientFacialExpressionServerRpc(inputJawOpen);
        }
        //OVRFaceExpressions.FaceExpression.JawDrop

        //OVRFaceExpressions.WeightProvider.GetWeight(OVRFaceExpressions.FaceExpression.JawDrop);

        // foreach (SkinnedMeshRenderer s in skinned)//not sure whether work or not
        //{
        //    s.SetBlendShapeWeight(41, _mouthSize * 100);
        //    s.SetBlendShapeWeight(17, _mouthSize * 50);
        //    s.SetBlendShapeWeight(6, _mouthSize * 20);
        //}

    }

    private void ClientFacialMove()
    {
        if(jawOpen.Value != 0)
        {
            avatarMesh.SetBlendShapeWeight(4, jawOpen.Value);
            //UpdateClientFacialExpression(jawOpen.Value);
        }

    }

    [ServerRpc]
    public void UpdateClientFacialExpressionServerRpc(float newJawOpen)
    {
        jawOpen.Value = newJawOpen;
    }

}
