VAR has_rake = false

-> tutorial
== tutorial
= awake
You feel a hand on your shoulder and wake up to a young woman frowning down at you.
Jane: "I see you are finally awake! I wish you would stop sleeping under this tree instead of working."
Jane: "Uncle John is going to catch you one of these days and then you will be in trouble."
Jane: "Do you remember what you need to do today?"
* [What was it again?]
    <- tasks
* [I remember.]
    <- remember
- -> rake ->
-> old_shrine
= tasks
Jane: "In case you forgot, you need to clean up all the leaves around the old shrine."
Jane: "And don't forget to take your rake!"
= remember
Jane: "Good! Get out to that old shrine and finish your cleaning!"
= rake
+ [Pick up rake]
    ~ has_rake = true
+ [Skip the rake]
    ~ has_rake = false
- ->->
== old_shrine
{has_rake == false: You realize you do not have your rake.}
+ {has_rake == false} [Retrieve rake]
    -> tutorial.rake ->
    {has_rake == false: -> old_shrine}
- You begin to rake the leaves around the old shrine.
-> DONE