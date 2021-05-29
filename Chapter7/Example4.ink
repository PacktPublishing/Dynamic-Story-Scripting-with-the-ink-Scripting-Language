You read all the books and talked your parents into going to the zoo. You just had to know. 
You enter the area containing the snakes and walk up to the glass.
-> snake_house
== snake_house
+ (tap){tap < 2}[Tap the glass and say something {tap > 0: again}]
    {tap <= 1: You tap on the glass in front of you. The snake turns slightly toward the noise and sticks out its tongue.}
    {tap > 1: No, you finally decide. You cannot talk to snakes.}
    -> snake_house
+ [Ignore the snake]
    You regard the coiled snake and then walk out.
    {tap > 1: What were you thinking? Talking to snakes is fictional.}
    -> DONE
