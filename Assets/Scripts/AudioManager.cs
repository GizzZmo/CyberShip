using UnityEngine;

/// <summary>
/// Centralized audio manager for playing game sounds and music.
/// Provides easy access to all audio sources in the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>Audio source for player laser shot sound.</summary>
    public AudioSource laserShot;
    
    /// <summary>Audio source for enemy shot sound.</summary>
    public AudioSource enemyShot;
    
    /// <summary>Audio source for explosion sound.</summary>
    public AudioSource explosion;
    
    /// <summary>Audio source for engine thrust sound.</summary>
    public AudioSource engineThrust;
    
    /// <summary>Audio source for pickup/power-up sound.</summary>
    public AudioSource pickup;
    
    /// <summary>Audio source for hit damage sound.</summary>
    public AudioSource hitDamage;
    
    /// <summary>Audio source for main theme music.</summary>
    public AudioSource mainTheme;
    
    /// <summary>Audio source for game over sound.</summary>
    public AudioSource gameOver;
    
    /// <summary>Audio source for victory sound.</summary>
    public AudioSource victory;
    
    /// <summary>Audio source for menu click sound.</summary>
    public AudioSource menuClick;
    
    /// <summary>Audio source for menu hover sound.</summary>
    public AudioSource menuHover;
    
    /// <summary>Audio source for alert sound.</summary>
    public AudioSource alert;

    /// <summary>Plays the player laser shot sound.</summary>
    public void PlayLaserShot() => laserShot.Play();
    
    /// <summary>Plays the enemy shot sound.</summary>
    public void PlayEnemyShot() => enemyShot.Play();
    
    /// <summary>Plays the explosion sound.</summary>
    public void PlayExplosion() => explosion.Play();
    
    /// <summary>Plays the engine thrust sound.</summary>
    public void PlayEngineThrust() => engineThrust.Play();
    
    /// <summary>Plays the pickup/power-up sound.</summary>
    public void PlayPickup() => pickup.Play();
    
    /// <summary>Plays the hit damage sound.</summary>
    public void PlayHitDamage() => hitDamage.Play();
    
    /// <summary>Plays the main theme music.</summary>
    public void PlayMainTheme() => mainTheme.Play();
    
    /// <summary>Plays the game over sound.</summary>
    public void PlayGameOver() => gameOver.Play();
    
    /// <summary>Plays the victory sound.</summary>
    public void PlayVictory() => victory.Play();
    
    /// <summary>Plays the menu click sound.</summary>
    public void PlayMenuClick() => menuClick.Play();
    
    /// <summary>Plays the menu hover sound.</summary>
    public void PlayMenuHover() => menuHover.Play();
    
    /// <summary>Plays the alert sound.</summary>
    public void PlayAlert() => alert.Play();
}
