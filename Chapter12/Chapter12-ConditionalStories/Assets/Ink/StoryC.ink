VAR violence = 0
VAR peace = 0
The king is dead and his sword is next to him on the ground. By picking it up, you could be the next king.
+ [Take up the sword]
~ violence += 10
+ [Ignore the sword]
~ peace += 10
== function check()
~ return violence == 10