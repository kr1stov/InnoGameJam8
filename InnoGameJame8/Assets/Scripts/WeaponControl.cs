using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

    [SerializeField]
    Transform rightHand;

    [SerializeField]
    Transform leftHand;

    [SerializeField]
    GameObject weapon;

    GameObject weaponLeft;
    GameObject weaponRight;

    // Use this for initialization
	void Start () {
        AttachWeapons();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AttachWeapons()
    {
        this.weaponLeft = Instantiate(this.weapon, this.leftHand.position, Quaternion.identity) as GameObject;
        this.weaponLeft.transform.parent = this.leftHand;

        this.weaponRight = Instantiate(this.weapon, this.rightHand.position, Quaternion.identity) as GameObject;
        this.weaponRight.transform.parent = this.rightHand;
    }


}
