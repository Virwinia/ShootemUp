
/*
    THIS SCRIPT IS NOT IMPLEMENTED YET
*/



using UnityEngine;

public class APickGear : AbstractPickItem
{
    [SerializeField] GameObject anim;
    public override void DoSomething()
    {
        PlayParticlesInPlayer();
    }

    void PlayParticlesInPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag(StaticValues.TAG_PLAYER);
        GameObject obj = Instantiate(anim, player.transform.position, Quaternion.identity);
        obj.transform.SetParent(player.transform);
    }

    public override bool PowerUpIsPickable()
    {
        throw new System.NotImplementedException();
    }

}
