-> time_machine(RANDOM(20,80))
== time_machine(loop)
The large machine looms over everything in the room. With flashing lights, odd wires running between parts, and a presence all its own, it seems to be an almost a living, pulsating thing as the scientist runs between sections parts and adjusts various parts.
"I'm so close!" he shouts as he turns a knob and then pulls down a lever. "I just need more time to figure out how to control the loops!"
You regard him and the machine skeptically.
"If you could, just press that last button and everything should be all set for the first demonstration of my time machine! I'm so glad the newspaper sent you to cover this event," he says, adjusting more settings on the grand machine in front of you.
You pause to try to understand the blinking lights as he yells again. "Press the button for me! I just need to make some last-minute changes over here."
On the panel in front of you is a large, green button. You consider it and the scientist rushing around across the room.
+ [Press button]
    ~ loop = loop + 1
    There is a flash of light and the readings on the machine show a message: "This is loop {loop}."
    -> time_machine(loop)
