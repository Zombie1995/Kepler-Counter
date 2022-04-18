# Kepler-Counter
An application for demonstrating the equality of the areas of two sectors formed by a celestial body in a certain time.
<br>
<br>
![1](Assets/Materials/Logo.png)
<br>
## Area calculation<br>
![2](Images/Sectors.png)
<br>
When a discrete bypass of the trajectory occurs, the program remembers the points bypassed and calculates the areas of the corresponding triangular sectors using the formula:
<br>
![3](Images/AreaFormula.gif)
<br>
## How it actually works
I'm using the following formula to calculate the mutual gravity at each iteration:
![4](Images/GravityFormula.gif)
<br>
Then I add the corresponding acceleration multiplied by the iteration time to the speed:
<br>
![5](Images/DeltaVelocityFormula.gif)
<br>
The movement is calculated according to the following formula:
<br>
![5](Images/MovementFormula.gif)
<br>
## Code
The corresponding scripts are in \Assets\Scripts

