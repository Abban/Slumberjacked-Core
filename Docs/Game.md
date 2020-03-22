# Game

## Scene Loader
Scenes are loaded additively

## Board
The board is the repository for all objects in a level. It contains:

* A registry of actor positions.
* Positions of static objects such as walls or pits or water

## Actors

### What are they?

Anything on the board that is interactable is an Actor.

### How they work

Everything moves one unit at a time

* __Movement:__ An actor might have the ability to move or be moved by another actor.
* __Interacting:__ If an actor tries to move to a space already occupied by another actor an interact action happens.
* __FSM:__ Actors use an FSM to manage their movement states
* __Behaviours:__ Actors have behaviours that perform the things that happen on interactions