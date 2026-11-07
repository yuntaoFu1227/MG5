# MG5
## Devlog
1. I think NavMesh is better when a character needs to find a path in an environment with obstacles. For example, in a forest exploration game, NacMesh can help the character avoid obstacles. On the other hand, I use physics for a car racing game because cars need control of speed, acceleration and collisions. NavMesh is not suitable for controlling cars in the racing game.
2. The for loop starts at the first bird and checks every bird in the array. Vector3.Distance calculates the distance between each bird and the player. In my project, the interaction distance is 3, so any birds within 3 units of the player will call RunAway(). And birds outside that distance will not trigger that method.
## Open-Source Assets
- [Quirky animal 3D models](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235)
- [Mountain fantasy environment models](https://www.fab.com/listings/60487a72-3f20-4bb2-aa78-247ed1582656)