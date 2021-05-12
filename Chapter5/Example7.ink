VAR strength = 16
VAR intelligence = 16
-> save_or_doom
== save_or_doom
The villain holds the ancient artifact and is moments away from enslaving the world with its limitless power as part of a complex ritual.
* {strength > 15} [Use strength]
    <- use_strength
* {intelligence > 15} [Use intelligence]
    <- use_intelligence
- -> DONE
= use_strength
You throw your hand axe as hard as you can. It strikes the artifact, shattering it into multiple pieces and ending the ritual.
= use_intelligence
You quickly calculate the size of the artifact based on its materials and cast the spell to banish it to another dimension. In a blink, the ritual ends!