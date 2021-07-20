-> loop
== loop
<- tree1.branch1
<- tree1.branch2
+ \[Close\]
    -> DONE
- -> loop
== tree1
= branch1
~ temp count = CHOICE_COUNT()
* {limitChoice(count)} Branch 1, first
* {limitChoice(count)} Branch 1, second
* {limitChoice(count)} Branch 1, third
- -> loop
= branch2
~ temp count = CHOICE_COUNT()
* {limitChoice(count)} Branch 2, first
* {limitChoice(count)} Branch 2, second
* {limitChoice(count)} Branch 2, third
- -> loop
== function limitChoice(localCount) ==
~ return localCount == CHOICE_COUNT()
