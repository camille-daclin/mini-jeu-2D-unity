# 🎮 Jeu 2D Unity – Test de Turing en réseau

> Projet universitaire – Licence 3 Informatique, Université Lyon 1  
> Responsable : Alexandre Meyer | C# / Unity

---

## 📌 Description

Jeu vidéo 2D développé sous Unity, se jouant en réseau. Un joueur contrôle le personnage principal (Mario-like) tandis qu'un second joueur — humain ou IA — contrôle les ennemis. À la fin de la partie, le joueur doit deviner s'il a affronté un humain ou une machine : c'est le **test de Turing appliqué au jeu vidéo**.

---

## 🎯 Objectifs du projet

- Développer un jeu 2D complet sous Unity en C#
- Implémenter un **mode réseau** (deux joueurs dans des salles séparées)
- Concevoir une **IA** capable de piloter les ennemis de façon crédible
- Intégrer un **test de Turing** en fin de partie

---

## 🚧 État d'avancement

Le projet est en cours de développement.

**Fonctionnalités terminées ✅**
- Déplacements du joueur (gauche/droite, saut, échelle)
- Système de vie et de dégâts
- Gestion des checkpoints
- Système de pièces et d'inventaire
- Interface de jeu (barre de vie, compteurs)
- Ennemis avec waypoints (patrouille basique)
- Gestion des scènes (GameOver, chargement)

**En cours / À venir 🔄**
- Mode réseau multijoueur
- IA avancée pour les ennemis (comportements crédibles)
- Test de Turing en fin de partie
- Équilibrage et niveau(x) supplémentaire(s)

---

## 🛠️ Technologies

- **Unity** 6.3 LTS
- **C#**
- **Unity Netcode** *(prévu pour le réseau)*

---

## 🗂️ Structure du projet

```
Assets/
├── Animation/       # Animations des personnages
├── Code/            # Scripts C# (Player, Ennemi, GameManager...)
├── Prefabs/         # Objets réutilisables
├── Scenes/          # Scènes du jeu
├── Tiles/           # Tuiles pour les niveaux
└── Settings/        # Paramètres du projet
```

---

## 👩‍💻 Auteure

**Camille Daclin** – Étudiante en Licence 3 Informatique, Université Lyon 1  
[github.com/camille-daclin](https://github.com/camille-daclin)
