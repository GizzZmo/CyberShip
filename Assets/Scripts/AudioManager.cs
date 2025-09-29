using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource laserShot;
    public AudioSource enemyShot;
    public AudioSource explosion;
    public AudioSource engineThrust;
    public AudioSource pickup;
    public AudioSource hitDamage;
    public AudioSource mainTheme;
    public AudioSource gameOver;
    public AudioSource victory;
    public AudioSource menuClick;
    public AudioSource menuHover;
    public AudioSource alert;

    public void PlayLaserShot() => laserShot.Play();
    public void PlayEnemyShot() => enemyShot.Play();
    public void PlayExplosion() => explosion.Play();
    public void PlayEngineThrust() => engineThrust.Play();
    public void PlayPickup() => pickup.Play();
    public void PlayHitDamage() => hitDamage.Play();
    public void PlayMainTheme() => mainTheme.Play();
    public void PlayGameOver() => gameOver.Play();
    public void PlayVictory() => victory.Play();
    public void PlayMenuClick() => menuClick.Play();
    public void PlayMenuHover() => menuHover.Play();
    public void PlayAlert() => alert.Play();
}
