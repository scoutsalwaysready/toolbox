# Two’s Complement

http://stackoverflow.com/questions/791328/how-does-the-bitwise-complement-operator-work

One other thing maybe to mention is that the flip is called 1s complement, before adding the 1.

Think: knowing that the MSB stores the sign, which number in binary do I need so that for any number, a +(-b) where the same circuit can be used for addition as for negation.

For example:
2 + ? = 0

2: [0]10

Using add and propagate sign:

010+
110
----
[1]000, remove overflow and get 000 -> 0, which is the expected answer for 2-2.

The operation that works for all number is invert all bits + 1, or 1s complement (invert all bits) +1 = two’s complement.



