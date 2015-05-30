using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

    [SerializeField]
    Transform rightHand;

    [SerializeField]
    Transform leftHand;

    [SerializeField]
    GameObject weaponPrefab;

    private GameObject weaponLeft;
    private GameObject weaponRight;

    // Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++ )
        { 
            AttachWeapons();
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AttachWeapons()
    {
        AttachWeaponToHand(out this.weaponLeft, this.leftHand);
        AttachWeaponToHand(out this.weaponRight, this.rightHand);
    }

    public void AttachWeaponToHand(out GameObject weapon, Transform slot)
    {
        weapon = Instantiate(this.weaponPrefab, slot.position, slot.rotation) as GameObject;
        //this.weaponRight.transform.parent = this.rightHand;
        weapon.GetComponent<SpringJoint>().connectedBody = slot.GetComponent<Rigidbody>();
    }


}
