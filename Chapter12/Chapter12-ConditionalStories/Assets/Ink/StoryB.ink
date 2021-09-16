VAR violence = 0
VAR peace = 0
The forest is quiet as you approach the unicorn.
+ [Attack the unicorn]
~ violence += 10
+ [Leave the area]
~ peace += 10

== function check()
~ return peace <= 0