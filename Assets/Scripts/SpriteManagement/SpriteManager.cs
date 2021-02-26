using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteManager : singleton<SpriteManager> {
    // Fields
	public SpriteAtlas spriteAtlas;


    // Methods
    protected override void Awake()
    {
        base.Awake();
    }
}
