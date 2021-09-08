VAR percentage = 0
A vast forest stretches out before you and alongside the forest is a winding river.
* (travel_forest) [Enter the forest]
* (travel_river) [Travel by river]
-
~ percentage = RANDOM(1,10)
{
    - percentage <= 3 && travel_forest == 1: 
        <- encounter.brown_wizard
    - percentage > 3 && travel_forest == 1:
        <- encounter.travel
    - travel_river == 1:
        <- encounter.river
}
== encounter
= brown_wizard
As you move through the forest, you encounter a strange man on a sled driven by large rabbits. You talk for a moment before the man moves away from you and deeper into the forest.
-> DONE
= travel
The travel through the forest.
-> DONE
= river
You travel down the river safely.
-> DONE
