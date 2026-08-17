# Memory Architect

A first-person exploration and puzzle game built in Unity 6. The player moves through a
hallway and a set of memory rooms, inspects the objects in them, and opens doors to
progress deeper into the building.

## Status

Playable prototype. Movement, mouse look, and the door interaction system work end to end.
Three scenes are built out: the hallway and two rooms. Puzzle logic beyond the doors is
still in progress.

## Requirements

- **Unity 6000.3.10f1** (the project is pinned to this editor version)
- Universal Render Pipeline 17.3.0
- Unity Input System 1.18.0

## Running the project

1. Clone the repository.
2. Open Unity Hub, choose **Add project from disk**, and select the `Memory Architect`
   folder.
3. Open the project with Unity 6000.3.10f1. The first import takes a while — the
   `Library` folder is rebuilt from scratch and there are around 1.6 GB of models and
   4K textures.
4. Open `Assets/Scenes/mainhol.unity` and press Play.

## Controls

| Action     | Binding          |
| ---------- | ---------------- |
| Move       | WASD             |
| Look       | Mouse            |
| Run        | Shift            |
| Jump       | Space            |
| Interact   | E                |

## Project layout

```
Memory Architect/
├── Assets/
│   ├── Material/        Materials for props, walls and floors
│   ├── Models/          Imported 3D props (furniture, lighting, decor)
│   ├── Prefabs/         Reusable objects, e.g. the door system
│   ├── Scenes/          mainhol, Room_1, Room_2
│   ├── Script/          Gameplay C# scripts
│   ├── Settings/        URP renderer and quality assets
│   ├── TextMesh Pro/    UI text package assets
│   └── Texture/         Wall, floor, plaster and wallpaper textures
├── Packages/            Unity package manifest
└── ProjectSettings/     Editor and build configuration
```

## Scripts

| Script                | Responsibility                                                      |
| --------------------- | ------------------------------------------------------------------- |
| `PlayerMovement.cs`   | Character controller movement, running, jumping, gravity             |
| `MouseLook.cs`        | First-person camera, pitch clamped to ±80°                           |
| `PlayerControls.cs`   | Generated Input System bindings                                      |
| `Door.cs`             | Raycasts ahead of the camera and fires the interact action           |
| `DoorInteraction.cs`  | Hinge rotation, open/close state, and the on-screen interact prompt   |

## Team

Memory Architect is a team project. This repository is Daniela Munteanu's copy of the
game, but the work in it is not hers alone:

- **Daniela Munteanu** — hallway scene, room 1 and room 3 design, door opening and player
  controller, environment art
- **Nedelcu Radu** — initial Unity project structure and `.gitignore`, numeric-code safe
  interaction
- **Morar Mircea Mihnea** — repository setup, branch integration

The original team repository lives on GitLab under the `memory-architect` group.

## Third-party assets

The `Assets/Models` and `Assets/Texture` folders contain third-party models and PBR
texture sets from sources such as Sketchfab, Poly Haven, and ambientCG. Each retains the
license of its original author. Check the individual asset folders before reusing anything
from this repository in another project.
