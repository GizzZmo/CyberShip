# Contributing to CyberShip

Thank you for your interest in contributing to CyberShip! This document provides guidelines and instructions for contributing to the project.

## Table of Contents
- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [How to Contribute](#how-to-contribute)
- [Development Workflow](#development-workflow)
- [Coding Standards](#coding-standards)
- [Commit Guidelines](#commit-guidelines)
- [Pull Request Process](#pull-request-process)
- [Testing Guidelines](#testing-guidelines)
- [Documentation](#documentation)

## Code of Conduct

By participating in this project, you agree to abide by our [Code of Conduct](CODE_OF_CONDUCT.md). Please read it before contributing.

## Getting Started

### Prerequisites
- Unity 2021.3 LTS or newer
- Git for version control
- A GitHub account
- Basic knowledge of C# and Unity

### Setting Up Your Development Environment

1. **Fork the repository**
   ```bash
   # Click the "Fork" button on GitHub
   ```

2. **Clone your fork**
   ```bash
   git clone https://github.com/YOUR_USERNAME/CyberShip.git
   cd CyberShip
   ```

3. **Add upstream remote**
   ```bash
   git remote add upstream https://github.com/GizzZmo/CyberShip.git
   ```

4. **Open in Unity**
   - Open Unity Hub
   - Click "Add" and select the CyberShip folder
   - Open the project

5. **Follow the setup guide**
   - Read `SETUP_GUIDE.md` for detailed instructions
   - Configure tags and layers as specified

## How to Contribute

### Types of Contributions

We welcome various types of contributions:

- 🐛 **Bug Fixes**: Fix bugs and issues
- ✨ **New Features**: Add new gameplay features or mechanics
- 📚 **Documentation**: Improve or add documentation
- 🎨 **Assets**: Create sprites, sounds, or other game assets
- 🧪 **Tests**: Add or improve tests
- 🔧 **Refactoring**: Improve code quality and structure
- 💡 **Ideas**: Suggest new features or improvements

### Finding Issues to Work On

- Check the [Issues](https://github.com/GizzZmo/CyberShip/issues) page
- Look for issues tagged with `good first issue` or `help wanted`
- Comment on an issue to let others know you're working on it

## Development Workflow

### 1. Create a Branch

Always create a new branch for your work:

```bash
git checkout -b feature/your-feature-name
# or
git checkout -b fix/bug-description
```

Branch naming conventions:
- `feature/` - New features
- `fix/` - Bug fixes
- `docs/` - Documentation changes
- `refactor/` - Code refactoring
- `test/` - Adding or updating tests

### 2. Make Your Changes

- Write clean, readable code
- Follow the coding standards (see below)
- Add comments for complex logic
- Update documentation as needed

### 3. Test Your Changes

- Test in Unity Editor
- Verify all existing features still work
- Test edge cases
- Check for console errors or warnings

### 4. Commit Your Changes

```bash
git add .
git commit -m "type: brief description"
```

See [Commit Guidelines](#commit-guidelines) below.

### 5. Push to Your Fork

```bash
git push origin your-branch-name
```

### 6. Create a Pull Request

- Go to the original repository on GitHub
- Click "New Pull Request"
- Select your branch
- Fill out the PR template
- Submit the pull request

## Coding Standards

### C# Style Guide

Follow these C# coding standards:

#### Naming Conventions

```csharp
// Classes, Structs, Enums - PascalCase
public class PlayerController { }
public struct GameState { }
public enum WeaponType { }

// Public fields and properties - PascalCase
public float MoveSpeed = 5f;
public int Score { get; set; }

// Private fields - camelCase with no prefix
private float nextShootTime;
private Transform player;

// Constants - PascalCase or UPPER_CASE
public const float MaxSpeed = 10f;
private const int MAX_ENEMIES = 50;

// Methods - PascalCase
public void ShootProjectile() { }
private void UpdatePosition() { }

// Parameters - camelCase
public void AddScore(int scoreValue) { }
```

#### Code Organization

```csharp
using UnityEngine;

/// <summary>
/// Class description here
/// </summary>
public class MyScript : MonoBehaviour
{
    // Public serialized fields (shown in Inspector)
    [Header("Settings")]
    public float speed = 5f;
    
    // Public properties
    public int Score { get; private set; }
    
    // Private fields
    private float timer;
    private bool isActive;
    
    // Unity lifecycle methods
    void Awake() { }
    void Start() { }
    void Update() { }
    void OnDestroy() { }
    
    // Public methods
    public void DoSomething() { }
    
    // Private methods
    private void HelperMethod() { }
}
```

#### Documentation Comments

Use XML documentation comments for all public members:

```csharp
/// <summary>
/// Moves the player based on input.
/// </summary>
/// <param name="direction">The direction vector to move in.</param>
/// <returns>True if movement was successful.</returns>
public bool Move(Vector2 direction)
{
    // Implementation
}
```

#### Best Practices

- ✅ Keep methods short and focused (single responsibility)
- ✅ Use meaningful variable and method names
- ✅ Avoid magic numbers - use constants or serialized fields
- ✅ Handle null checks appropriately
- ✅ Cache component references in Start() or Awake()
- ✅ Use `SerializeField` for private fields that need Inspector access
- ✅ Avoid using `Find()` methods in Update()
- ❌ Don't use `goto` statements
- ❌ Avoid deeply nested code (max 3-4 levels)

### Unity-Specific Guidelines

#### Inspector Organization

Use headers and tooltips:

```csharp
[Header("Movement Settings")]
[Tooltip("Maximum movement speed in units per second")]
public float maxSpeed = 10f;

[Header("Combat Settings")]
[Tooltip("Damage dealt per shot")]
public int damage = 10;
```

#### Prefabs and Tags

- Use prefabs for reusable objects
- Configure tags and layers properly
- Don't rely on object names for game logic

#### Performance

- Use object pooling for frequently instantiated objects
- Avoid expensive operations in Update()
- Cache component references
- Use `CompareTag()` instead of `tag ==`

## Commit Guidelines

### Commit Message Format

```
type: brief description

Optional detailed description

Fixes #issue_number
```

### Types

- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, missing semicolons, etc.)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

### Examples

```bash
feat: add power-up system for temporary shields

fix: prevent projectiles from destroying player

docs: update API reference with new methods

refactor: optimize enemy spawning logic
```

## Pull Request Process

### Before Submitting

- [ ] Code follows the style guidelines
- [ ] All tests pass
- [ ] Documentation is updated
- [ ] No console errors or warnings
- [ ] Changes are tested in Unity
- [ ] Commit messages follow the format

### PR Template

When creating a pull request, include:

1. **Description**: What does this PR do?
2. **Motivation**: Why is this change needed?
3. **Testing**: How was this tested?
4. **Screenshots**: For visual changes
5. **Related Issues**: Link to related issues

### Review Process

1. Maintainers will review your PR
2. Address any requested changes
3. Once approved, your PR will be merged
4. Your contribution will be credited

## Testing Guidelines

### Manual Testing Checklist

- [ ] Test in Unity Editor play mode
- [ ] Verify no console errors or warnings
- [ ] Test all affected features
- [ ] Test edge cases
- [ ] Check performance (frame rate)
- [ ] Verify proper cleanup (no memory leaks)

### Automated Testing

If adding automated tests (future):
- Place tests in `Tests/` folder
- Use Unity Test Framework
- Test both play mode and edit mode scenarios
- Aim for high code coverage

## Documentation

### When to Update Documentation

Update documentation when you:
- Add new public APIs
- Change existing behavior
- Add new features
- Fix significant bugs
- Modify setup or configuration

### Documentation Files

- `README.md` - Project overview and quick start
- `API_REFERENCE.md` - Detailed API documentation
- `ARCHITECTURE.md` - System architecture and design
- `SETUP_GUIDE.md` - Unity setup instructions
- Code comments - For complex logic

### Documentation Style

- Use clear, concise language
- Include code examples where helpful
- Add diagrams for complex concepts
- Keep information up-to-date
- Use proper Markdown formatting

## Asset Contributions

### Creating Game Assets

If contributing sprites, sounds, or other assets:

1. **Follow the cyberpunk theme**
   - Use neon colors (cyan, magenta, purple)
   - Dark backgrounds with bright accents
   - Geometric, futuristic designs

2. **Technical requirements**
   - Sprites: PNG with transparency, power-of-2 dimensions
   - Sounds: High-quality, compressed formats
   - Fonts: Include license information

3. **Organization**
   - Place in appropriate `Assets/` subfolder
   - Update relevant documentation
   - Include source files if available

4. **Licensing**
   - Ensure you have rights to contribute the asset
   - Specify the license
   - Credit original creators if applicable

## Getting Help

### Resources

- [Unity Documentation](https://docs.unity3d.com/)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- Project documentation in this repository

### Communication

- **Issues**: For bugs and feature requests
- **Discussions**: For questions and general discussion
- **Pull Requests**: For code review and feedback

### Questions?

If you have questions:
1. Check existing documentation
2. Search closed issues
3. Open a new issue with the `question` label

## Recognition

Contributors will be recognized in:
- Project README
- Release notes
- Contributors page (if created)

Thank you for contributing to CyberShip! 🚀
