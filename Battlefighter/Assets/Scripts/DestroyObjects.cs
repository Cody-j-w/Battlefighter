﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collision){
        Destroy(collision.gameObject);
    }
}
