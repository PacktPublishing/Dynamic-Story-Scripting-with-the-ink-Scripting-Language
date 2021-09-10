LIST steps = (one), (two), (three), (four)
VAR step = one
VAR end = false

VAR name = "Wolf's Delight"

VAR stories = 0

You lose a poker hand to a man in a wolf's mask. He asks that you pay in stories.
* [Collect stories]
    -> quest
* [Refuse the deal]
    -> quest.stop
    
== quest
{step:
    - one: -> first
    - two: -> second
    - three: -> third
    - four: -> fourth
}
-> DONE

= first
You collect your first story and tell the man the tale.
~ stories += 1
-> DONE

= second
The man laughs as you finish recounting another story. "Keep the stories coming!"
* [Keep going]
    -> DONE
* [Refuse the deal]
    -> stop

= third
The man in the wolf's mask looks pleased. "You are close to paying off the debt."
~ stories += 1
-> DONE

= fourth
After receiving the last story, the man in the wolf mask nods. "Good job. Debt is paid off."
~ end = true
-> DONE

= stop
Man shakes his head and smiles. "Oh, you will pay me. Maybe not now, but one day soon."
~ end = true
-> DONE

== progress
~ steps -= LIST_MIN(steps)
~ step = LIST_MIN(steps)
-> quest