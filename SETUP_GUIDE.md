# Unity Setup Guide for Cyberpunk Space Shooter

This guide explains how to set up the cyberpunk space shooter game in Unity using the provided scripts and assets.

## Prerequisites
- Unity 2021.3 LTS or newer
- Basic understanding of Unity Editor

## Setup Steps

### 1. Project Setup
1. Create a new 2D Unity project
2. Import all scripts from the `Scripts/` folder
3. Copy the `Assets/` folder structure to your Unity project

### 2. Scene Setup

#### Player Setup
1. Create a new GameObject and name it "Player"
2. Add a Sprite Renderer component
3. Add a Rigidbody2D component (set Gravity Scale to 0)
4. Add a Collider2D component (Box Collider 2D or Circle Collider 2D)
5. Set the Player tag to "Player"
6. Attach the `PlayerController` script
7. Create a child GameObject called "FirePoint" positioned where projectiles should spawn

#### Projectile Setup
1. Create a GameObject called "PlayerProjectile"
2. Add Sprite Renderer with projectile sprite
3. Add Rigidbody2D (Gravity Scale = 0, Is Trigger = true)
4. Add Collider2D (Is Trigger = true)
5. Set tag to "PlayerProjectile"
6. Attach the `Projectile` script
7. Save as prefab and assign to PlayerController's projectilePrefab field

#### Enemy Setup
1. Create a GameObject called "Enemy"
2. Add Sprite Renderer with enemy sprite
3. Add Rigidbody2D (Gravity Scale = 0)
4. Add Collider2D
5. Set tag to "Enemy"
6. Attach the `EnemyController` script
7. Create child "FirePoint" for enemy projectiles
8. Save as prefab

#### Enemy Projectile Setup
1. Create GameObject called "EnemyProjectile"
2. Add Sprite Renderer with enemy projectile sprite
3. Add Rigidbody2D (Gravity Scale = 0, Is Trigger = true)
4. Add Collider2D (Is Trigger = true)
5. Set tag to "EnemyProjectile"
6. Attach the `EnemyProjectile` script
7. Save as prefab and assign to EnemyController's enemyProjectilePrefab field

#### Game Manager Setup
1. Create empty GameObject called "GameManager"
2. Attach the `GameManager` script
3. Assign enemy prefab to enemyPrefab field
4. Create spawn points (empty GameObjects) positioned above the screen
5. Assign spawn points to the spawnPoints array

### 3. Input Setup
Configure Input Manager for player controls:
- Horizontal: A/D keys or Left/Right arrows
- Vertical: W/S keys or Up/Down arrows
- Fire1: Space bar or left mouse button

### 4. Tags Configuration
Create these tags in the Unity Tag Manager:
- Player
- Enemy
- PlayerProjectile
- EnemyProjectile

### 5. Layer Setup (Optional)
For better collision management, create layers:
- Player
- Enemy
- PlayerProjectiles
- EnemyProjectiles

## Script Configuration

### PlayerController Parameters
- `moveSpeed`: How fast the player moves (default: 5)
- `projectilePrefab`: Reference to player projectile prefab
- `firePoint`: Transform where projectiles spawn

### Projectile Parameters
- `speed`: Projectile movement speed (default: 10)
- `lifetime`: How long projectile exists (default: 5 seconds)
- `scoreValue`: Points awarded for enemy destruction (default: 10)

### EnemyController Parameters
- `moveSpeed`: Enemy movement speed (default: 2)
- `shootInterval`: Time between enemy shots (default: 2 seconds)
- `enemyProjectilePrefab`: Reference to enemy projectile prefab
- `firePoint`: Transform where enemy projectiles spawn

### GameManager Parameters
- `playerLives`: Starting player lives (default: 3)
- `enemySpawnInterval`: Time between enemy spawns (default: 2 seconds)
- `enemyPrefab`: Reference to enemy prefab
- `spawnPoints`: Array of spawn point transforms

## Testing
1. Play the scene
2. Use WASD or arrow keys to move
3. Press Space or click to shoot
4. Enemies should spawn and shoot back
5. Check console for score and lives updates

## Troubleshooting

### Common Issues
- **Player won't move**: Check Input Manager configuration
- **Projectiles don't spawn**: Verify prefab assignments and FirePoint positions
- **No collisions**: Ensure proper tags and collider setup
- **Enemies don't spawn**: Check GameManager spawn points and prefab assignments

### Performance Tips
- Use object pooling for projectiles in production
- Limit number of active enemies and projectiles
- Optimize sprite sizes and compression settings

## Next Steps
- Add UI for score and lives display
- Implement power-ups and different weapon types
- Add background scrolling and parallax effects
- Create multiple enemy types and boss battles
- Add sound effects and music
- Implement save/load functionality