VAR reputation = 10
-> villager_1
== villager_1
Villager: Heroes! You have returned from fighting the monsters in the forest! Did... you find any sign of my husband? He has been missing for several days.
+ \(Lie\) We have not found him yet.
    <- adjust_reputation(-10)
+ We found what was left of him. I'm sorry to report he is dead.
    <- adjust_reputation(10)
+ I used his leg to fight off some spiders! Oh. Right... he's, you know, dead.
    <- adjust_reputation(-15)
- -> DONE
== adjust_reputation(amount)
~ reputation = reputation + amount
-> report_reputation ->
== report_reputation
Current reputation: {reputation}