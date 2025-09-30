# API Reference

This document provides detailed information about all the C# scripts in the CyberShip game.

## Table of Contents
- [PlayerController](#playercontroller)
- [Projectile](#projectile)
- [EnemyController](#enemycontroller)
- [EnemyProjectile](#enemyprojectile)
- [GameManager](#gamemanager)
- [ParallaxLayer](#parallaxlayer)
- [BackgroundScroller](#backgroundscroller)
- [AudioManager](#audiomanager)

---

## PlayerController

Controls player ship movement and shooting mechanics.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `moveSpeed` | `float` | `5f` | Movement speed of the player ship in units per second |
| `projectilePrefab` | `GameObject` | `null` | Prefab for the projectile that will be instantiated when shooting |
| `firePoint` | `Transform` | `null` | Transform point where projectiles spawn from (usually front of ship) |

### Public Methods

None. All functionality is handled internally through Unity's Update method.

### Controls

- **Movement**: WASD or Arrow keys
- **Shoot**: Space bar or Fire1 button (left mouse click)

---

## Projectile

Handles player projectile behavior including movement, collision detection, and scoring.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `speed` | `float` | `10f` | Movement speed of the projectile in units per second |
| `lifetime` | `float` | `5f` | Time in seconds before the projectile is automatically destroyed |
| `scoreValue` | `int` | `10` | Score points awarded when this projectile destroys an enemy |

### Public Methods

None. Handles collision detection automatically through Unity's trigger system.

### Behavior

- Moves forward (upward) continuously
- Destroys enemies on contact and awards score
- Auto-destroys after `lifetime` seconds to prevent memory leaks
- Ignores collisions with player and other player projectiles

---

## EnemyController

Controls enemy AI behavior including movement, shooting, and collision detection.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `moveSpeed` | `float` | `2f` | Movement speed of the enemy in units per second |
| `shootInterval` | `float` | `2f` | Time interval in seconds between enemy shots |
| `enemyProjectilePrefab` | `GameObject` | `null` | Prefab for enemy projectiles |
| `firePoint` | `Transform` | `null` | Transform point where enemy projectiles spawn from |

### Public Methods

None. All behavior is handled internally.

### Behavior

- Moves downward continuously
- Shoots projectiles at regular intervals
- Automatically destroys itself when off-screen (Y < -10)
- Destroys itself when colliding with player

---

## EnemyProjectile

Handles enemy projectile behavior including movement and player damage.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `speed` | `float` | `5f` | Movement speed of the enemy projectile in units per second |
| `lifetime` | `float` | `5f` | Time in seconds before the projectile is automatically destroyed |
| `damage` | `int` | `1` | Amount of damage dealt to player (uses lives system) |

### Public Methods

None. Handles collision detection automatically.

### Behavior

- Moves downward toward the player
- Reduces player lives on contact through GameManager
- Auto-destroys after `lifetime` seconds
- Ignores collisions with enemies and other enemy projectiles

---

## GameManager

Central game manager that controls game state, scoring, lives, and enemy spawning. Uses singleton pattern for global access.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `playerLives` | `int` | `3` | Number of lives the player has remaining |
| `score` | `int` | `0` | Current player score |
| `gameOver` | `bool` | `false` | Indicates whether the game is over |
| `enemyPrefab` | `GameObject` | `null` | Prefab for enemies to be spawned |
| `enemySpawnInterval` | `float` | `2f` | Time interval in seconds between enemy spawns |
| `spawnPoints` | `Transform[]` | `null` | Array of transform points where enemies can spawn |

### Static Fields

| Field | Type | Description |
|-------|------|-------------|
| `Instance` | `GameManager` | Singleton instance accessible globally |

### Public Methods

| Method | Parameters | Returns | Description |
|--------|------------|---------|-------------|
| `AddScore` | `int points` | `void` | Adds points to the player's score |
| `PlayerTakeDamage` | - | `void` | Reduces player lives by one, triggers game over if lives reach zero |
| `GameOver` | - | `void` | Triggers the game over state and pauses the game |
| `RestartGame` | - | `void` | Resets score, lives, and game state to restart the game |

### Usage Example

```csharp
// Add score from another script
if (GameManager.Instance != null)
{
    GameManager.Instance.AddScore(10);
}

// Damage the player
if (GameManager.Instance != null)
{
    GameManager.Instance.PlayerTakeDamage();
}
```

---

## ParallaxLayer

Creates a parallax scrolling effect for background layers.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `scrollSpeed` | `float` | `0.1f` | Scroll speed for this layer (lower = slower) |
| `repeatLength` | `float` | `20f` | Vertical distance after which the layer content repeats |

### Public Methods

None. Automatically handles scrolling.

### Behavior

- Scrolls vertically downward
- Automatically calculates repeat length from SpriteRenderer if available
- Creates infinite scrolling effect by resetting position at intervals

---

## BackgroundScroller

Scrolls background sprites vertically to create a scrolling space effect. Similar to ParallaxLayer but uses Vector2.

### Public Fields

| Field | Type | Default | Description |
|-------|------|---------|-------------|
| `scrollSpeed` | `float` | `0.5f` | Scroll speed for this layer (lower = slower) |
| `repeatLength` | `float` | `20f` | Vertical distance after which the layer content repeats |

### Public Methods

None. Automatically handles scrolling.

### Behavior

- Scrolls vertically downward
- Automatically calculates repeat length from SpriteRenderer if available
- Creates infinite scrolling effect

---

## AudioManager

Centralized audio manager for playing game sounds and music.

### Public Fields

| Field | Type | Description |
|-------|------|-------------|
| `laserShot` | `AudioSource` | Audio source for player laser shot |
| `enemyShot` | `AudioSource` | Audio source for enemy shot |
| `explosion` | `AudioSource` | Audio source for explosion |
| `engineThrust` | `AudioSource` | Audio source for engine thrust |
| `pickup` | `AudioSource` | Audio source for pickup/power-up |
| `hitDamage` | `AudioSource` | Audio source for hit damage |
| `mainTheme` | `AudioSource` | Audio source for main theme music |
| `gameOver` | `AudioSource` | Audio source for game over |
| `victory` | `AudioSource` | Audio source for victory |
| `menuClick` | `AudioSource` | Audio source for menu click |
| `menuHover` | `AudioSource` | Audio source for menu hover |
| `alert` | `AudioSource` | Audio source for alert |

### Public Methods

| Method | Description |
|--------|-------------|
| `PlayLaserShot()` | Plays the player laser shot sound |
| `PlayEnemyShot()` | Plays the enemy shot sound |
| `PlayExplosion()` | Plays the explosion sound |
| `PlayEngineThrust()` | Plays the engine thrust sound |
| `PlayPickup()` | Plays the pickup/power-up sound |
| `PlayHitDamage()` | Plays the hit damage sound |
| `PlayMainTheme()` | Plays the main theme music |
| `PlayGameOver()` | Plays the game over sound |
| `PlayVictory()` | Plays the victory sound |
| `PlayMenuClick()` | Plays the menu click sound |
| `PlayMenuHover()` | Plays the menu hover sound |
| `PlayAlert()` | Plays the alert sound |

### Usage Example

```csharp
// Get reference to AudioManager and play a sound
AudioManager audioManager = FindObjectOfType<AudioManager>();
if (audioManager != null)
{
    audioManager.PlayLaserShot();
}
```

---

## Tags Required

The following Unity tags must be configured for the game to work properly:

- `Player` - For the player ship
- `Enemy` - For enemy ships
- `PlayerProjectile` - For player projectiles
- `EnemyProjectile` - For enemy projectiles

See `SETUP_GUIDE.md` for detailed tag configuration instructions.
