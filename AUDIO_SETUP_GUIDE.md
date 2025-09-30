# AudioManager Prefab Setup Guide

## Overview
This guide explains how to set up the AudioManager prefab with all required audio sources for the CyberShip game.

## Setup Steps

### 1. Create AudioManager GameObject
1. In Unity Hierarchy, right-click and select `Create Empty`
2. Name it "AudioManager"
3. Attach the `AudioManager.cs` script to this GameObject

### 2. Add Audio Source Components
Add **12 AudioSource components** to the AudioManager GameObject:
- One for each sound effect and music track

To add an AudioSource:
1. Select the AudioManager GameObject
2. Click `Add Component` in the Inspector
3. Search for and add "Audio Source"
4. Repeat 12 times (one for each audio field)

### 3. Configure Audio Sources

#### SFX Audio Sources (Sound Effects)
For each of these, set the properties as follows:
- **Play On Awake**: Unchecked (except for mainTheme)
- **Loop**: Unchecked (except for mainTheme and engineThrust)
- **Volume**: 0.5-0.8 (adjust to taste)
- **Spatial Blend**: 0 (2D sound)

1. **laserShot** - Player weapon firing sound
   - Assign: laser_shot.wav audio clip
   
2. **enemyShot** - Enemy weapon sound
   - Assign: enemy_shot.wav audio clip
   
3. **explosion** - Destruction/explosion sound
   - Assign: explosion.wav audio clip
   
4. **engineThrust** - Ship engine sound
   - Assign: engine_thrust.wav audio clip
   - Loop: **Checked**
   
5. **pickup** - Item collection sound
   - Assign: pickup.wav audio clip
   
6. **hitDamage** - Damage taken sound
   - Assign: hit_damage.wav audio clip

#### Music Audio Sources
For music tracks, use these settings:
- **Volume**: 0.3-0.5 (lower than SFX)
- **Loop**: Checked (for mainTheme)
- **Spatial Blend**: 0 (2D sound)

7. **mainTheme** - Main background music
   - Assign: main_theme.mp3 audio clip
   - Play On Awake: **Checked** (or play from GameManager)
   - Loop: **Checked**
   
8. **gameOver** - Game over music
   - Assign: game_over.mp3 audio clip
   
9. **victory** - Victory music
   - Assign: victory.mp3 audio clip

#### UI Audio Sources

10. **menuClick** - Button click sound
    - Assign: menu_click.wav audio clip
    
11. **menuHover** - Menu navigation sound
    - Assign: menu_hover.wav audio clip
    
12. **alert** - Warning/alert sound
    - Assign: alert.wav audio clip

### 4. Link Audio Sources to Script Fields

1. Select the AudioManager GameObject
2. In the Inspector, find the AudioManager script component
3. Drag each AudioSource component to its corresponding field:
   - AudioSource #1 → laserShot
   - AudioSource #2 → enemyShot
   - AudioSource #3 → explosion
   - AudioSource #4 → engineThrust
   - AudioSource #5 → pickup
   - AudioSource #6 → hitDamage
   - AudioSource #7 → mainTheme
   - AudioSource #8 → gameOver
   - AudioSource #9 → victory
   - AudioSource #10 → menuClick
   - AudioSource #11 → menuHover
   - AudioSource #12 → alert

### 5. Create Prefab

1. In the Project window, navigate to `Assets/Prefabs` (create this folder if it doesn't exist)
2. Drag the AudioManager GameObject from the Hierarchy into the Prefabs folder
3. This creates a reusable AudioManager prefab

### 6. Add to Scene

- The AudioManager should be present in every scene
- Simply drag the AudioManager prefab into your scene hierarchy
- It's recommended to use `DontDestroyOnLoad` if you want the audio to persist between scenes

## Usage in Scripts

The AudioManager is already integrated into the following scripts:
- **PlayerController** - Laser shots and engine thrust
- **EnemyController** - Enemy shots and explosion/damage sounds
- **Projectile** - Explosion sounds on enemy hits
- **EnemyProjectile** - Hit damage sound when player is hit
- **GameManager** - Main theme, game over, and victory music
- **UIAudioHandler** - Menu click and hover sounds

## Adding to UI Buttons

For menu buttons with audio feedback:

1. Select your UI Button in the Hierarchy
2. In the Inspector, find the `Button` component
3. Add a `UIAudioHandler` script to the button (or to a parent GameObject)
4. In the Button's `OnClick()` event:
   - Click the `+` button
   - Drag the GameObject with UIAudioHandler to the object field
   - Select `UIAudioHandler → OnMenuClick()`

5. For hover sounds, add an `EventTrigger` component:
   - Add Component → Event Trigger
   - Add New Event Type → Pointer Enter
   - Click `+` in the event
   - Drag the GameObject with UIAudioHandler
   - Select `UIAudioHandler → OnMenuHover()`

## Testing

1. Enter Play mode in Unity
2. Test each sound:
   - Move the player → engine thrust should play
   - Shoot → laser shot should play
   - Enemy shoots → enemy shot should play
   - Hit enemy → explosion should play
   - Take damage → hit damage should play
   - Game over → main theme stops, game over plays
   - Click UI buttons → menu click plays
   - Hover UI buttons → menu hover plays

## Troubleshooting

**Sounds not playing?**
- Check that audio clips are assigned to AudioSource components
- Verify AudioSource components are linked to script fields
- Ensure AudioManager GameObject is in the scene
- Check that "Mute Audio" is not enabled in Unity Game view

**Engine thrust not stopping?**
- Verify the engineThrust AudioSource has the Loop checkbox enabled
- Check that the PlayerController is properly calling Stop() on the AudioSource

**Main theme not playing?**
- Either enable "Play On Awake" on the mainTheme AudioSource
- Or ensure GameManager.Start() is being called

## Audio File Locations

Place your audio files in:
- `Assets/Sounds/SFX/` - For sound effects (.wav files)
- `Assets/Sounds/Music/` - For music tracks (.mp3 files)

## Notes

- Use placeholder sounds initially, then replace with final audio assets
- Consider using an audio mixer for better volume control
- For production, consider using AudioMixerGroups for SFX and Music separation
