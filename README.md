# SpiceMerchant
A GOAP system case implementation from the modern game algorithm course.

### General:
#### A brief description of what this project is actually demoing
In this system, there is one spice merchant and eight traders doing business following certain rules. The ultimate goal of the player-agent is to store 2 of each spice in the caravan. Spices are acquired by trading different 20 spices between the traders. Each trader accepts a type of spice and returns another type.

* Trader 1: Gives you 2 turmeric units.
* Trader 2: Takes 2 Turmeric units and gives you 1 Saffron unit.
* Trader 3: Takes 2 Saffron units and gives you 1 Cardamom unit.
* Trader 4: Takes 4 Turmeric units and gives you 1 Cinnamon.
* Trader 5: Takes 1 Cardamom and 1 Turmeric and gives you 1 Cloves unit.
* Trader 6: Takes 2 Turmeric, 1 Saffron and 1 Cinnamon and gives 1 Pepper unit.
* Trader 7: Takes 4 Cardamom units and gives you 1 Sumac unit.
* Trader 8: Takes 1 Saffron, 1 Cinnamon and 1 Cloves unit and gives you 1 Sumac unit.

The player-agent begins next to the caravan, and has an inventory that allows carrying at most 4 units of spice at any
one time. The caravan has unlimited capacity, and traders have unlimited supply.

### A quick demonstration:
To set the goal as "having 2 of each spice at the end", we do the following implementation:

  <img src="https://github.com/YuzhouGuo/SpiceMerchant/blob/main/GitHub_Demos/goal_implementation.png">
  
  <img src="https://github.com/YuzhouGuo/SpiceMerchant/blob/main/GitHub_Demos/planFound.png">

  <img src="https://github.com/YuzhouGuo/SpiceMerchant/blob/main/GitHub_Demos/grabTwoTu.png" width="80%" height="80%">

  <img src="https://github.com/YuzhouGuo/SpiceMerchant/blob/main/GitHub_Demos/grabOneSa.png" width="80%" height="80%">

### Source Code:
* Part of the GOAP code skeleton is implemented by @sploreg, I modified some detailed for this specific case.
