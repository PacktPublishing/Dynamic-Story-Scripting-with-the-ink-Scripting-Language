VAR playful = 0
VAR anger = 0
On your daily walk you decide to sit for a few minutes on a nearby bench. You close your eyes to take in the evening sun.
Suddenly, you hear a small sound and look down. A kitten is circling your legs.
-> kitten
== kitten
-> check_kitten ->
+ [Pet the kitten on its head]
    You pet the kitten on its head.
    -> pet_head -> kitten
+ [Pet the kitten on its side]
    You pet the kitten on its side.
    -> pet_side -> kitten
== pet_head
~ playful = playful + 1
->->
== pet_side
~ anger = anger + 1
->->
== check_kitten
{anger >= 2: The kitten seems angry and walks away. -> DONE}
{playful >= 2: One moment, you were petting the kitten and the next your hand has some small cuts on it. You decide to leave the kitten alone. -> DONE}
->->