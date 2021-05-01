You pause to double-check check the folder again. Yes, you have all of the evidence here.

You nod at your partner and he enters the other room. You take a breath and open the door.

The suspects sits in front of you. As you take a seat, she turns to look at you.

-> interrogation

== interrogation
+ (knife) {knife < 1} [Ask about the knife]
    The suspect shakes their head. "I don't know nothing!"
    -> interrogation
+ (knife_again) {knife == 1 && knife_again < 1} [Ask about the knife again.]
    You take a picture of the knife out of the folder and put it down on the table without saying another word.
    -> interrogation
+ (knife_once_again) {knife_again == 1 && knife_once_again < 1} [Ask about the knife one more time.]
    "Yes. Fine. It's mine," the suspect replies and crosses her arms. Looking at them, you notice the slight cuts on the underside of her arm.
    -> interrogation
+ (cuts) {knife_once_again == 1 && cuts < 1} [Ask about the cuts on her arm.]
    You point to the cuts on her arms. 
    She shrugs. "It was an accident."
    You frown and point at the knife.
    "It's my knife, yes," she says, looking away.
    -> interrogation
+ {cuts == 1} [Take out the picture of the gun next.]
    "This is not yours, though," you say, taking out the picture.
    She does not look back.
    "He attacked you. And not for the first time," you say and point to the older scars still visible. "You finally had enough. You shot him."
    She still looks away, but you can see her shoulders slump. She knows that you know. 
    -> DONE
