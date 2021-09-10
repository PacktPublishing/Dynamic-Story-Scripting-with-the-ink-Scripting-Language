LIST steps = (one), (two), (three)
VAR step = one
VAR end = false

You meet an old man by the side of a dusty road with a wide hat set out in front of him. "Got any change?"
* [Sure]
    -> quest
* [Not today]
    -> quest.stop
    
== quest
{step:
    - one: -> first
    - two: -> second
    - three: -> third
}
-> DONE

= first
You empty some coins from your pocket and the old man nods.  "Thanks, stranger! May the gods bless you!"
-> DONE

= second
You encounter the same old man again a few days later. "Got any more change?"
* [Why not?]
    "Thank you! Thank you!" the old man shouts.
    -> DONE
* [Not this time]
    -> stop

= third
The old man regards you. "You been mighty generous twice now. I won't bother you no more."
-> DONE

= stop
The old man ignores you.
~ end = true
-> DONE

== progress
~ steps -= LIST_MIN(steps)
~ step = LIST_MIN(steps)
-> quest