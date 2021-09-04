VAR money = 100
VAR inventory = 0

== function buy(cost) ==
{money >= cost:
    ~ money = money - cost
    ~ inventory = inventory + 1
}

== function sell(price) ==
{inventory >= 1:
    ~ inventory = inventory - 1
    ~ money = money + price
}

== function status() ==
Money: {money}
Inventory {inventory}
