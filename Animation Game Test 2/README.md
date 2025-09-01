**Animation Game Test 2**

Created: December 2020
**Language/Tech:** C#, .NET GUI

***************Animation Game Test 2***************
***************Random Picture Generator***************

--------------------------------------------------------------------------
This is a game that makes random pixel pictures. You can choose the colors that the computer will make the picture from, you can resize the picture. Also you can save the picture after the program has generated it, and I have recently added a feature that allows you to magnify the generated picture. You can also add 2 of your own colors to choose from - just type in their RGB's in the grey textboxes

The goal of the game is to try to make the picture look as beautiful as you can. P.s. - during the generation of the picture you can temper with the list of selected colors, and choose how the generation is situated(vertical or horizontal), so you can have more variation to the picture.

Also there is a new feature called "Animation Game Test 3" - it's basically the same thing as this program, but you can have a limitless amount of colors, and you can choose the percent for the randomness of each color, also you can temper with the time interval of the randomness loop(which is in ticks), but to do all this you just have to type a certain code into a textbox for example: 0 0 0/255 255 255|40 60*7000. This code will generate a black and white picture with 40% black and 60% white, and each pixel is going to be chosen for 7000 ticks(a tick is 1/10,000 of a millisecond). So here is the code as it must be: Color's RGB/Second color's RGB/Third color's RGB(and so on, just put backslahes between the RGBs)|30(% for the first color) 60(% for the second color) 10(% for the third)*100(time interval for gen of each pixel - the data will be stored in a separate textbox for more understanding).

Notes:
1. DO NOT make the magnification level to high - because if you punch in 100 there, the program will work for quite some time, maybe crashing your computer (I didn't test that), so remember: the maginfication takes some time to do, so be patient. P.S - if your magnification level is at 5(or any other number), the picture will be magified 5 times.

2. In every game there are some glitches: even in mine: so what we are talking about is that when the program is generating the picture, if you select and/or unslecet any color very fast, and lots of times - you may get black pixels generating - this happens because when you uncheck any color the program first makes that color value to 0(which is black) and then delets the color altogether, so when the color value becomes 0 if at the same moment you have a color being chosen, and it happens to be that same color, you will get a gaping black dot - which is kinda cool.

So,, enjoy!
------------------------------------------

13.12.2020 - 12:39 p.m. ----- edited 25.3.2021 - 6:28 p.m.
