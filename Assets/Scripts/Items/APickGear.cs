using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APickGear : AbstractPickItem
{
    [SerializeField] GameObject anim;

    public override void DoSomething()
    {
        print("GEAR!!");
        PlayParticlesInPlayer();
        // do something
    }

    void PlayParticlesInPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag(StaticValues.TAG_PLAYER);
        GameObject obj = Instantiate(anim, player.transform.position, Quaternion.identity);
        obj.transform.SetParent(player.transform);
    }

}
