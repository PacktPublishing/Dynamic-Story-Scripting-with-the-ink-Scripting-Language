VAR count = 0
-> loop
== loop
~ count = CHOICE_COUNT()
* {limitChoice(count)} This is the first
* {limitChoice(count)} This is the second
* {limitChoice(count)} This is the third
+ Return
- -> loop
== function limitChoice(localCount) ==
~ return localCount == CHOICE_COUNT()
