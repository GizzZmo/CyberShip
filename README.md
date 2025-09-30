# CyberShip

[![CI](https://github.com/GizzZmo/CyberShip/workflows/CI/badge.svg)](https://github.com/GizzZmo/CyberShip/actions/workflows/ci.yml)
[![Documentation CI](https://github.com/GizzZmo/CyberShip/workflows/Documentation%20CI/badge.svg)](https://github.com/GizzZmo/CyberShip/actions/workflows/documentation.yml)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Cyberpunk Space Shooter Game

🚀 **Implementation Complete!** 
The cyberpunk space shooter game logic has been implemented with full C# scripts and asset structure according to the blueprint.

---

## 🎮 Game Features

✅ **Implemented Features:**
- Player ship movement and shooting system
- Enemy AI with movement and shooting
- Projectile collision detection and scoring
- Game state management with lives and score
- Asset structure for cyberpunk-themed content
- Comprehensive Unity setup guide

---

## 📁 Project Structure

```
CyberShip/
├── Assets/
│   ├── Sprites/        # Visual assets for ships, projectiles, UI
│   ├── Sounds/         # Audio effects and music
│   ├── Fonts/          # Cyberpunk-styled fonts
│   └── README.md       # Asset documentation
├── Scripts/
│   ├── PlayerController.cs    # Player movement and shooting
│   ├── Projectile.cs         # Player projectile behavior
│   ├── EnemyController.cs    # Enemy AI and behavior
│   ├── EnemyProjectile.cs    # Enemy projectile behavior
│   └── GameManager.cs        # Game state and enemy spawning
├── Scenes/
│   └── MainScene.unity       # Main game scene
├── SETUP_GUIDE.md           # Complete Unity setup instructions
└── README.md               # This file
```

---

## 🛠️ C# Implementation

The game includes five core scripts implementing the complete game logic:

### PlayerController.cs
- WASD/Arrow key movement
- Space bar shooting
- Configurable movement speed and fire point

### Projectile.cs
- Forward movement with collision detection
- Score system integration
- Automatic cleanup to prevent memory leaks

### EnemyController.cs
- Autonomous enemy movement
- Timed shooting system
- Player detection and targeting

### EnemyProjectile.cs
- Enemy projectile movement toward player
- Player damage system
- Collision detection

### GameManager.cs
- Enemy spawning system
- Score and lives management
- Game over handling
- Singleton pattern for global access

---

## 🎨 Cyberpunk Asset Guidelines

The asset structure follows cyberpunk aesthetics:

**Color Palette:**
- Electric blue (#00FFFF), Neon pink (#FF00FF)
- Dark purple (#330066), Black (#000000)
- Bright green (#00FF00), Orange (#FF6600)

**Visual Style:**
- High contrast with glowing/neon effects
- Retro-futuristic geometric shapes
- Grid patterns and circuit board aesthetics

---

## 🚀 Quick Start

1. **Open in Unity:** Import project into Unity 2021.3 LTS or newer
2. **Follow Setup Guide:** See `SETUP_GUIDE.md` for detailed instructions
3. **Configure Prefabs:** Set up player, enemy, and projectile prefabs
4. **Play:** Test the game with WASD movement and Space to shoot

---

## 🎯 Game Controls

- **Movement:** WASD keys or Arrow keys
- **Shoot:** Space bar or left mouse button
- **Objective:** Destroy enemies to earn points, avoid enemy fire

---

## 📚 Documentation

- **[SETUP_GUIDE.md](SETUP_GUIDE.md)** - Complete Unity setup instructions
- **[API_REFERENCE.md](API_REFERENCE.md)** - Detailed API documentation for all scripts
- **[ARCHITECTURE.md](ARCHITECTURE.md)** - System architecture and design patterns
- **[CONTRIBUTING.md](CONTRIBUTING.md)** - Contribution guidelines
- **[CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md)** - Community code of conduct
- **[Assets/README.md](Assets/README.md)** - Asset creation guidelines
- **[Assets/Sprites/sprite_list.md](Assets/Sprites/sprite_list.md)** - Required sprite assets
- **[Assets/Sounds/sound_list.md](Assets/Sounds/sound_list.md)** - Required audio assets
- **[Assets/Fonts/font_list.md](Assets/Fonts/font_list.md)** - Required font assets

---

## 🔧 Technical Notes

- Built for Unity 2D projects
- Uses Unity's physics system for collision detection
- Implements proper object lifecycle management
- Includes singleton pattern for game state
- Configurable parameters for easy game balancing
- Comprehensive XML documentation for all C# scripts
- Automated CI/CD workflows for code quality and documentation validation

---

## 🚀 CI/CD

This project includes automated workflows:

- **CI Workflow**: Validates code quality, file structure, security, and assets
- **Documentation CI**: Checks markdown files, validates links, and ensures documentation completeness

All workflows run automatically on push and pull requests to main and develop branches.

---

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guidelines](CONTRIBUTING.md) for details on:
- Setting up your development environment
- Coding standards and best practices
- Submitting pull requests
- Reporting issues

Please also read our [Code of Conduct](CODE_OF_CONDUCT.md) before contributing.

---

This implementation provides a complete foundation for a cyberpunk space shooter game with extensible architecture for additional features like power-ups, multiple enemy types, and enhanced visual effects!
