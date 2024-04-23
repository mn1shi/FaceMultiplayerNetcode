using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Relay;
using TMPro;

public class NetworkConnect : MonoBehaviour
{
    //public Relay relay;
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI playersInGameText;

    public void Create()
    {
        NetworkManager.Singleton.StartHost();
        print("Hosted");
        //relay.AllocateRelay();
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
        print("Joined as Client");
        //relay.JoinRelay("");
    }

    private void Update()
    {
        playersInGameText.text = $"Players in game: {PlayerManager.Instance.PlayersInGame}";
    }
}
