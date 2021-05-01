-> interrogation

You pause to check the folder again. 

and sit down in front of the suspect.

== interrogation
+ (knife) {knife < 1} [Ask about the knife]
    The suspect shakes their head. "I don't know nothing!"
    -> interrogation
+ {knife >= 1} [Ask about the knife again.]
    
+ (blood_pattern) {knife >= 2} [Ask about the blood pattern]
    -> interrogation
+ {blood_pattern >= 1} [Ask about the trail of blood]
    -> interrogation
