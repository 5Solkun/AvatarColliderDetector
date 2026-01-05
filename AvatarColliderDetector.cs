
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
public class AvatarColliderDetector : UdonSharpBehaviour
{
    [Header("Setting")]
    [SerializeField] private float scanRadius = 3.0f; // 감지 범위
    [SerializeField] private float scanInterval = 1.0f; //스켄텀

    [Header("Force Teleporter")]
    public Transform TeleportPostion;

    [Header("Active When Detect")]
    public GameObject[] ActiveGameObjects;
    public bool DeactiveWhenNotDetected = true;
    

    [Header("Detect Custom Script Event")]
    public UdonSharpBehaviour CustomScript;
    public string CustomScriptEventName;

    private int targetLayer = 10; // PlayerLocal 레이어
    private VRCPlayerApi localPlayer;

    public string[] WhiteList = {"5Sori"};
    void Start()
    {
        localPlayer = Networking.LocalPlayer;
        ScanLoop();
    }

    public void ScanLoop()
    {
        foreach(string White in WhiteList){
            if(localPlayer.displayName == White)
            {return;}
        }
        if (localPlayer != null)
        {
            Vector3 scanPos = localPlayer.GetPosition();
            int layerMask = 1 << targetLayer;
            Collider[] hitColliders = Physics.OverlapSphere(scanPos, scanRadius, layerMask);

            int count = hitColliders.Length;
            if(count>1)
            {
                Detected();
            }
            else
            {
                NotDetected();
            }
        }
        SendCustomEventDelayedSeconds(nameof(ScanLoop), scanInterval);
    }

    public void Detected()
    {
        if(TeleportPostion)
        {
            localPlayer.TeleportTo(TeleportPostion.position, TeleportPostion.rotation);
        }
        foreach(GameObject ActiveGameObject in ActiveGameObjects)
        {
            if(ActiveGameObject)
            {
                ActiveGameObject.SetActive(true);
            }
        }
        if(CustomScript)
        {CustomScript.SendCustomEvent(CustomScriptEventName);}
    }

    public void NotDetected()
    {
        if(!DeactiveWhenNotDetected){return;}
        foreach(GameObject ActiveGameObject in ActiveGameObjects)
        {
            if(ActiveGameObject)
            {
                ActiveGameObject.SetActive(false);
            }
        }
    }
}