using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject firstPerson; // position for first person camera
    [SerializeField] Vector3 thirdPersonView = new Vector3(0, 5, -7);
    private bool isThirdPersonView;

    private Quaternion initRotation;

    public Players type = Players.Player1;
    private KeyCode firstPersonKey;
    
    // Start is called before the first frame update || Awake is called when the script is loaded
    void Start()
    {
        isThirdPersonView = true;
        initRotation = transform.rotation;

        if (type == Players.Player1)
            firstPersonKey = KeyCode.Tab;
        else
            firstPersonKey = KeyCode.RightControl;
    }

    // LateUpdate is called after update || Fixed Update is called before the update
    void LateUpdate()
    {
        // Tab key is the input responsible for switching camera
        bool isTabPress = Input.GetKeyDown(firstPersonKey);
        if (isTabPress)
            isThirdPersonView = !isThirdPersonView;
            
        if (isThirdPersonView)
            ManageThirdPersonView();
        else
            ManageFirstPersonView();


    }

    void ManageThirdPersonView()
    {
        transform.position = player.transform.position + thirdPersonView;
        transform.rotation = initRotation;
    }

    void ManageFirstPersonView()
    {
        transform.position = firstPerson.transform.position;
        transform.rotation = firstPerson.transform.rotation;
    }
    
}
