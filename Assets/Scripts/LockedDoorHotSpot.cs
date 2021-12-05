using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorHotSpot : HotSpots
{
    public AudioSource Audio;
    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            UImanager.instance.OnPlayerClick(HotSpot.TextOnEnter);
            //var player = Player.GetComponent<CharacterControl>();
            //player.Audio.clip = player.AudioClips.PlayerClips[2];
            //player.Audio.Play();
            Audio.Play();
        }
    }
}
