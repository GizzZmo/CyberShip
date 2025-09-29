# CyberShip
Romskips spill
Supert! La oss sette opp et GitHub-prosjekt og generere noen cyberpunk-inspirerte 2D-spill-assets for romskipspillet ditt. Her er en plan for hvordan vi kan gå frem:

---

## 🚀 Steg 1: GitHub-prosjektstruktur

Vi lager en enkel mappestruktur for prosjektet:

```
cyberpunk-space-shooter/
├── Assets/
│   ├── Sprites/
│   ├── Sounds/
│   └── Fonts/
├── Scripts/
│   ├── PlayerController.cs
│   ├── Projectile.cs
│   └── EnemyController.cs
├── Scenes/
│   └── MainScene.unity
├── README.md
└── .gitignore
```

Jeg kan generere en `README.md` og `.gitignore`-fil for Unity-prosjektet, og du kan laste det opp til GitHub.

---

## 🎨 Steg 2: Generere Cyberpunk-inspirerte Assets

Hva slags assets ønsker du først?

- ✅ Romskip (spiller)
- ✅ Prosjektiler
- ✅ Fiender
- ✅ Bakgrunn (bylandskap, stjerner, etc.)
- ✅ UI-elementer (liv, score, ammo)

**Vil du at jeg skal starte med å generere et romskip i cyberpunk-stil?** Hvis du har preferanser for farger, form eller stil (f.eks. neon, glitch-effekter, retro-futuristisk), gi meg beskjed!

---

## 🛠️ Steg 3: Automatisk opprettelse av GitHub-prosjekt

Vil du at jeg skal generere en ZIP-fil med startkode og prosjektstruktur som du kan laste opp til GitHub? Jeg kan også lage en enkel Unity C#-kodebase for deg.

---

Bare si fra hva du vil starte med:
- 🎨 Generere grafikk?
- 📁 Lage prosjektfiler?
- 🧠 Skrive spilllogikk?
- 🌐 Lage GitHub README?

Hva skal vi ta først?

Selvfølgelig! Her er et enkelt eksempel på hvordan du kan lage et 2D romskipspill i Unity. Dette eksempelet viser hvordan du kan få romskipet til å bevege seg og skyte prosjektiler.

### 1. Oppsett i Unity
1. **Opprett et nytt 2D-prosjekt** i Unity.
2. **Legg til en sprite** for romskipet ditt i scenen.
3. **Legg til en sprite** for prosjektilene.

### 2. Skript for Romskipet
Opprett et nytt C#-skript kalt `PlayerController` og legg det til romskipet ditt. Her er et eksempel på hvordan skriptet kan se ut:

```csharp
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
```

### 3. Skript for Prosjektilene
Opprett et nytt C#-skript kalt `Projectile` og legg det til prosjektil-prefaben. Her er et eksempel:

```csharp
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Legg til logikk for hva som skjer når prosjektilen treffer noe
        Destroy(gameObject);
    }
}
```

### 4. Oppsett i Unity Editor
1. **Legg til en tom GameObject** som et barn av romskipet og plasser det der du vil at prosjektilene skal skytes fra. Kall det `FirePoint`.
2. **Dra og slipp prosjektil-prefaben** til `projectilePrefab`-feltet i `PlayerController`-skriptet.
3. **Dra og slipp `FirePoint`** til `firePoint`-feltet i `PlayerController`-skriptet.

### 5. Test Spillet
Trykk på Play-knappen i Unity og test at romskipet kan bevege seg og skyte prosjektiler.

Dette er et veldig grunnleggende eksempel, men det burde gi deg en god start. Du kan bygge videre på dette ved å legge til fiender, kollisjonsdeteksjon, poengsystemer og mer. Lykke til med utviklingen! 🚀🎮

Hvis du har flere spørsmål eller trenger hjelp med noe spesifikt, er det bare å si fra!
