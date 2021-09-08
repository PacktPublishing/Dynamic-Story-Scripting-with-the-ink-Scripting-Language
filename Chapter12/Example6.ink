VAR location_pick = 0

-> location -> marker -> DONE

== location
First, we saw the <>
{shuffle:
    - tower
        ~ location_pick = "tower"
    - ruin
        ~ location_pick = "ruin"
    - temple
        ~ location_pick = "temple"
}<>.
->->

== marker
Next, we saw the <>
{
    - location_pick == "tower":
       {shuffle:
            - grave
            - memorial stone
        }
    - else:
        {shuffle:
            - farmstead
            - ancient tree
        }
}<>.
->->
