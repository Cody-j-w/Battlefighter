using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WipeDebris();
	}

    private IEnumerator WipeDebris()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
