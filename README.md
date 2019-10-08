### INFO 5340 / CS 5650: Virtual and Augmented Reality - Fall 2019

# Assignment 1

Read: [Assignment Instructions](https://docs.google.com/document/d/1La3bKARSi58KifaHSFowvJsRRt2wocoFOD25dy8ox_Q/edit?usp=sharing "Detailed Assignment Instructions")

**Remember that you also have to submit information through Canvas before the submission deadline**

<hr>

### Student Name:

\<Sunny Ladkani\>


### Student NetID:

\<sl2883\>

<hr>

### Solution

In addition to your code in this repository, please submit screen recordings showing your solutions in action for each part of the assignment. Host the videos on your Cornell Google Drive account and provide a link as instructed below. They have to be accessible to other Cornell accounts, streamable and downloadable (mp4/mov).

**Screen Recording: Part 1**

Filename: (a1-2019-part1-sl2883.mov)[https://drive.google.com/open?id=1Ei1hBNBczt0QxPxf-Hb5tIN0kJjicRQV]

  
**Screen Recording: Part 2**

Filename: (a1-2019-part2-sl2883.mov) [https://drive.google.com/open?id=1s4SAHexsQJFvT9_NmqghG4tk6hd9gMox]


**Screen Recording: Part 3**

Filename: (a1-2019-part3-sl2883.mov) [https://drive.google.com/open?id=1NzOAZLSEz5ZrgTunUi4dh4K0-epRp9gV]


**Screen Recording: Part 4**

Filename: (a1-2019-part4-sl2883.mov) [https://drive.google.com/open?id=1VB6K556njlapoklZkd5ad1lfyjKzRlLS]

**Screen Recording: Part 5**

Filename: (a1-2019-part5-sl2883.mov) [https://drive.google.com/open?id=1TbBb1YP8naSBq5ZXDQXOV-8Ju_4oPXSF]

<hr>

### Writeup

**Work Summary**

[Write a short summary of your approach to this assignment and list the main challenges you faced]
Approach ->
Because I've no idea of unity platform and C# language, I started with reading about basic tutorial on unity and c#. My approach was to follow the assignment steps linearly. Whenever there was an issue, I spent most time understanding the flow if events and learning about the details of the unity framework. 

Challenges ->
1. Figuring out key unity functions and identifying which settings need to be on/off for different events
2. Figuring out how to move platforms without the player falling
3. The script wasn't refreshed at times, stuggled with that.
4. Overall learning of C# and unity interface

**Final Five**

[If you implemented the Final Five part, tell us about your solution, what you did and why]
The final part was about helping the user to play the game. As I was building the game, the biggest challenge I faced was to look at the different views of the game. Because the game is about moving objects from one place to the other, it's important to understand where in 3D are they positioned. To solve this, and ensure that the user knows how to play the game at all time, I added a "Hint" object in the game space. Clicking on the Hint lets user learn the basics of the game. The hints also tell user that by using "X, Y, Z & N" keyboard shortcuts, the user can switch between the different cameras available to view and play the game. The hint goes aways when the user clicks on the "Hint" object again.
