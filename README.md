# 100 Prisoners
Some code to calculate a small amount of the 100 Prisoner's Problem

You can find a description here: https://www.youtube.com/watch?v=C5-I0bAuEUE

I tried to solve finding the various combinations of sequences that have loops in them. My solution was brute force and isn't elegant. Probably with more time it could work better. It only practically works for 10 prisoners.

Ironically, I used yield here, which given some restrictions with using yield inside lambda functions doesn't lend itself well to using a parallel for loop. So not very multi-threaded in the end.
