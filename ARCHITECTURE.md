# CyberShip Architecture

This document provides an overview of the system architecture and design patterns used in the CyberShip game.

## Table of Contents
- [Overview](#overview)
- [Architecture Diagram](#architecture-diagram)
- [Design Patterns](#design-patterns)
- [Game Flow](#game-flow)
- [Component Interactions](#component-interactions)
- [Asset Structure](#asset-structure)

## Overview

CyberShip is a cyberpunk-themed 2D space shooter built with Unity. The architecture follows object-oriented principles with a focus on modularity, reusability, and clean separation of concerns.

### Key Principles

- **Component-Based Design**: Uses Unity's component system for modular functionality
- **Singleton Pattern**: GameManager provides global game state access
- **Event-Driven**: Collision-based interactions trigger game events
- **Separation of Concerns**: Each script has a single, well-defined responsibility

## Architecture Diagram

```
┌─────────────────────────────────────────────────────────────┐
│                        Game Scene                            │
│                                                              │
│  ┌─────────────┐                                            │
│  │ GameManager │ (Singleton)                                │
│  │  - Score    │                                            │
│  │  - Lives    │                                            │
│  │  - Spawning │                                            │
│  └──────┬──────┘                                            │
│         │                                                    │
│         │ manages                                            │
│         ▼                                                    │
│  ┌─────────────────────────────────────────────────────┐   │
│  │                  Game Objects                        │   │
│  │                                                       │   │
│  │  ┌──────────────┐        ┌──────────────┐          │   │
│  │  │   Player     │        │    Enemy     │          │   │
│  │  │  Controller  │        │  Controller  │          │   │
│  │  └──────┬───────┘        └──────┬───────┘          │   │
│  │         │ spawns                │ spawns            │   │
│  │         ▼                       ▼                   │   │
│  │  ┌──────────────┐        ┌──────────────┐          │   │
│  │  │   Player     │        │    Enemy     │          │   │
│  │  │  Projectile  │        │  Projectile  │          │   │
│  │  └──────────────┘        └──────────────┘          │   │
│  └─────────────────────────────────────────────────────┘   │
│                                                              │
│  ┌─────────────────────────────────────────────────────┐   │
│  │              Background & Effects                    │   │
│  │                                                       │   │
│  │  ┌──────────────┐        ┌──────────────┐          │   │
│  │  │  Parallax    │        │  Background  │          │   │
│  │  │   Layer      │        │   Scroller   │          │   │
│  │  └──────────────┘        └──────────────┘          │   │
│  └─────────────────────────────────────────────────────┘   │
│                                                              │
│  ┌─────────────┐                                            │
│  │AudioManager │                                            │
│  │  - SFX      │                                            │
│  │  - Music    │                                            │
│  └─────────────┘                                            │
└─────────────────────────────────────────────────────────────┘
```

## Design Patterns

### 1. Singleton Pattern
**Used in**: `GameManager`

The GameManager uses the Singleton pattern to ensure only one instance exists and provides global access to game state.

```csharp
public static GameManager Instance;

void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}
```

**Benefits**:
- Centralized game state management
- Easy access from any script
- Persists across scenes

### 2. Component Pattern
**Used in**: All game objects

Each script is a self-contained component that can be attached to Unity GameObjects.

**Benefits**:
- Modularity and reusability
- Easy to test and maintain
- Follows Unity's architecture

### 3. Object Pooling (Recommended for Production)
**Currently**: Objects are instantiated and destroyed
**Recommendation**: Implement object pooling for projectiles to improve performance

### 4. Observer Pattern (Implicit)
**Used in**: Collision detection system

Unity's collision system acts as an implicit observer pattern where objects react to collision events.

## Game Flow

### 1. Initialization
```
Game Start
    ↓
GameManager.Awake() - Initialize singleton
    ↓
GameManager.Start() - Set spawn timing
    ↓
Player spawns in scene
    ↓
Background scrolling begins
```

### 2. Main Game Loop
```
Every Frame (Update):
    ↓
Player Input → PlayerController
    ├─ Movement (WASD/Arrows)
    └─ Shooting (Space/Click) → Spawn Projectile
    ↓
Enemy Behavior → EnemyController
    ├─ Move downward
    └─ Shoot at intervals → Spawn Enemy Projectile
    ↓
GameManager
    └─ Spawn enemies at intervals
    ↓
Collision Detection
    ├─ Player Projectile + Enemy → Destroy enemy, add score
    ├─ Enemy Projectile + Player → Reduce lives
    └─ Enemy + Player → Destroy enemy
    ↓
Check Game State
    └─ If lives <= 0 → Game Over
```

### 3. Game Over
```
Player Lives = 0
    ↓
GameManager.GameOver()
    ├─ Set gameOver flag
    ├─ Stop spawning
    └─ Pause game (Time.timeScale = 0)
    ↓
Display Final Score
    ↓
Option to Restart
    └─ GameManager.RestartGame()
```

## Component Interactions

### Score System
```
Player Projectile hits Enemy
    ↓
Projectile.OnTriggerEnter2D()
    ↓
GameManager.Instance.AddScore(scoreValue)
    ↓
GameManager updates score
    ↓
(Optional) Update UI
```

### Damage System
```
Enemy Projectile hits Player
    ↓
EnemyProjectile.OnTriggerEnter2D()
    ↓
GameManager.Instance.PlayerTakeDamage()
    ↓
GameManager decrements lives
    ↓
If lives <= 0: GameManager.GameOver()
```

### Spawning System
```
GameManager.Update()
    ↓
Check if spawn time reached
    ↓
Select random spawn point
    ↓
Instantiate enemy at spawn point
    ↓
Schedule next spawn
```

## Asset Structure

### Directory Organization
```
CyberShip/
├── Assets/
│   ├── Sprites/          # Visual assets
│   │   ├── Player/
│   │   ├── Projectiles/
│   │   ├── Enemies/
│   │   └── Backgrounds/
│   ├── Sounds/           # Audio assets
│   │   ├── SFX/
│   │   └── Music/
│   ├── Fonts/            # Typography
│   ├── Scripts/          # Additional scripts
│   └── README.md
├── Scripts/              # Core game scripts
│   ├── PlayerController.cs
│   ├── Projectile.cs
│   ├── EnemyController.cs
│   ├── EnemyProjectile.cs
│   ├── GameManager.cs
│   ├── ParallaxLayer.cs
│   └── BackgroundScroller.cs
└── Scenes/
    └── MainScene.unity
```

### Prefab Architecture

**Player Prefab**:
- PlayerController component
- SpriteRenderer
- Rigidbody2D (Gravity = 0)
- Collider2D
- FirePoint child object

**Enemy Prefab**:
- EnemyController component
- SpriteRenderer
- Rigidbody2D (Gravity = 0)
- Collider2D
- FirePoint child object

**Projectile Prefabs**:
- Projectile/EnemyProjectile component
- SpriteRenderer
- Rigidbody2D (Trigger = true)
- Collider2D (Trigger = true)

## Performance Considerations

### Current Implementation
- ✅ Automatic cleanup of off-screen objects
- ✅ Timed destruction of projectiles
- ✅ Efficient collision detection using triggers
- ✅ Minimal Update() operations

### Recommended Optimizations
- ⚠️ Implement object pooling for projectiles
- ⚠️ Use spatial partitioning for large numbers of enemies
- ⚠️ Optimize sprite atlases for reduced draw calls
- ⚠️ Consider using Unity's Job System for heavy computations

## Extensibility

The architecture is designed to be easily extensible:

### Adding New Enemy Types
1. Create new enemy prefab
2. Optionally create specialized EnemyController subclass
3. Configure in GameManager's enemy spawn system

### Adding Power-ups
1. Create PowerUp script similar to Projectile
2. Add collision detection for player
3. Integrate with GameManager for effects

### Adding UI
1. Create UI scripts that reference GameManager.Instance
2. Subscribe to score/lives changes
3. Update UI elements accordingly

### Adding Different Weapons
1. Create new Projectile variants
2. Modify PlayerController to switch between weapons
3. Add weapon selection system

## Testing Strategy

### Unit Testing
- Test individual component behaviors in isolation
- Mock dependencies (e.g., GameManager.Instance)
- Validate state changes

### Integration Testing
- Test component interactions
- Verify collision detection
- Validate score and lives systems

### Playtest Focus Areas
- Game balance (spawn rates, difficulty)
- Player controls responsiveness
- Performance with many objects on screen
- Edge cases (off-screen behavior, null references)

## Dependencies

### Unity Systems
- Unity 2D Physics (Collider2D, Rigidbody2D)
- Unity Input System (Input.GetAxis, Input.GetButton)
- Unity GameObject lifecycle (Instantiate, Destroy)
- Unity Time system (Time.deltaTime, Time.timeScale)

### External Dependencies
None - Pure Unity implementation

## Future Architecture Considerations

### Scalability
- Consider implementing a state machine for game states
- Add event system for decoupled communication
- Implement save/load system for persistence
- Add networking layer for multiplayer support

### Maintainability
- Add comprehensive unit tests
- Implement continuous integration
- Create editor tools for level design
- Add profiling and analytics
