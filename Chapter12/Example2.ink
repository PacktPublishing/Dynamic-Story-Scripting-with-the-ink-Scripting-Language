VAR percentage = 0
~ percentage = RANDOM(1,10)
{
    - percentage <= 3: 
        <- encounter.brown_wizard
    - else:
        <- encounter.travel
}
== encounter
= brown_wizard
As you move through the forest, you encounter a strange man on a sled driven by large rabbits. You talk for a moment before the man moves away from you and deeper into the forest.
-> DONE
= travel
The travel through the forest.
-> DONE
