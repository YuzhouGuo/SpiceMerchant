# SpiceMerchant
A GOAP system case implementation from the modern game algorithm course.

### General:
* The main purpose of this research project is to establish an idea to make a zig-zag path smooth and human-like.
* To have a detailed explanation about this project and how I approach, please visit the report named "Human-Like Path Finding Algorithm Based on Classic A*"
* A much more detailed report about the ideas/algorithm working can be found [here](https://github.com/YuzhouGuo/humanLikePathFinding/blob/master/Human-Like%20Path%20Algorithm%20Based%20on%20A_.pdf).

### A quick demonstration:
Here is an animation from the p5 framework to check out: [Click me!](https://editor.p5js.org/guoyuzhou004@gmail.com/full/1NNJFJHAW)

To show the result of this research/project, we choose a relatively larger map for testing. And here is a brutal presentation of the project:

* Stage one (the classic A* algorithm without any adjustment)

  <img src="https://github.com/YuzhouGuo/humanLikePathFinding/blob/master/stage1.png" width="400" height="400">

* Stage two (based on A*, with wall-avoiding algorithm added, you can see that the path is now trying to get to the middle of the path so that it is more human-like)

  <img src="https://github.com/YuzhouGuo/humanLikePathFinding/blob/master/stage2.png" width="400" height="400">

* Stage three (with advanced wall-avoiding strategy, and Bezier curve applied, visually more smooth)

  <img src="https://github.com/YuzhouGuo/humanLikePathFinding/blob/master/stage3.png" width="400" height="400">

### Source Code:
* The source code for this project is just the sourceCode.js file, with default HTML and CSS code provided by the p5 framework online editor.
