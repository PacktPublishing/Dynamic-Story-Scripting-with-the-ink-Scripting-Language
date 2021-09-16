VAR violence = 0
VAR peace = 0
The great dragon of the north stands before you with its claw extended.
+ [Attack the dragon]
~ violence += 10
+ [Accept its claw in greeting]
~ peace += 10

== function check()
~ return violence > 10