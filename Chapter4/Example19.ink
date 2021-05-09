VAR money = 30
VAR apples = 0
VAR oranges = 0
You approach the marketplace and consider what is on sale. 
-> market

== market
You have {money} gold.
You have purchased {apples} apples.
You have purchased {oranges} oranges.

+ {money > 10} [Buy Apple for 10 gold]
    ~ decreaseMoney(10)
    ~ increaseApples()
    -> market
+ {money > 15} [Buy Oranges for 15 gold]
    ~ decreaseMoney(15)
    ~ increaseOranges()
    -> market
* [Leave market]
    -> DONE

== function decreaseMoney(amount)
~ money = money - amount

== function increaseApples()
~ apples = apples + 1

== function increaseOranges()
~ oranges = oranges + 1
