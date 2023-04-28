# ECS-KATA

Your mission is to create a pure ECS based solution to the following problem. My definition of pure ECS is the following:

- Components can only store data, or functions to mutate the underlying state, or pure accessors.
- Systems should follow the SRP and only do one thing. Such as update the position of an entity.
- Entities are just an ID, and a collection of components.
- ECS code lives inside the Scripts/ECS folder and must not reference any Unity code.
- The ECS provides code contracts that should be implemented on the Unity side.

## The Problem

The cube monster is hungry but it has no ability to hunt for food.

The world has no ability to grow and create more food, to keep the hungry monster alive.

Write a pure ECS solution to this problem, spawn food, and make the monster hunt for the food.

If you manage to complete this quickly, then bonus points for any one of these: 
* The monster performs a spin action of excitement when it eats food.
* The monster gets fatter and slower for each pieces of food it eats.

## Notes

"World" is the name of the inital scene. Prefabs "Character" and "Collectable" are already created.

There are two example systems that you can use as a starting point. They are located in the Scripts/ECS/Systems folder.

The initial instantiates 1000 entities with two component types and then unity reflects the state of this in the view using IVisibilitySystem. 

VisibilitySystem.cs - This handles instantiating objects from a pool, then showing and hiding them.
LiveAndDieSystem.cs - This is an example of a system that mutates the state of a component using Arch queries.

## References

You can find documentation to Arch ECS here:

https://github.com/genaray/Arch

