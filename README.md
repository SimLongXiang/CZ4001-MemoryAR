# MemoryAR - A Memory Training AR Game

![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/Screenshot_20190414-194900.jpg)

MemoryAR  is a single player marker-based memory training game for the young. Created using Unity and Vuforia as the ARtoolkit, the application aims to train and improve a user’s brain memory through a series of flashing images, and user is required to remember the order of those images. In this first version, poker cards are used as the marker for the game.

![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/Screenshot_20190414-194932.jpg)
![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/Screenshot_20190414-194945.jpg)
![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/Screenshot_20190414-195024.jpg)


# Game Construct of MemoryAR 
The game mechanics of MemoryAR consists of several functions and each of them calls another function upon the completion of their individual task. This creates a procedural loop as the game progresses. 

![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/MemoryAR%20Game%20Mechanics.JPG)

There are 3 main code features that make this application possible:

# 1.	Invoke() and Invokerepeating() functions
Invoke() and Invokerepeating() functions allow the calling of other functions after a set period of seconds. In addition, Invokerepeating() acts as a replacement for the while() function, with a terminating function, CancelInvoke(). With that in mind, MemoryAR uses Invokerepeating() to implement the flashing of the images, controlling the speed that it flashes. Also, it uses Invoke() to call other functions, making the procedural aspect of the code happen through coordination of timing each function runs between each other.

![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/ARInvokerepeating.JPG)

# 2.	Manipulating AR detection
During the process of flashing the sequence of images, AR recognition and detection needs to be paused to avoid user accidentally scanned the image target, causing runtime error as the checking of cards happens after the flashing image process. Thus, a static method PauseVuforia(bool what) house the stopping and starting function of AR recognition, namely imageTracker.Stop() and imageTracker.Start(). This implementation allows the stopping and starting functions to be called by passing in a Boolean value to indicate the status of AR detection.

![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/ARrecognition.JPG)

# 3.	Getting image target’s name
In order to check if the scanned card is correct, the application has to be able to determine what the scanned card is. Vuforia has a DefaultTrackableEventHandler script that generates the image target name. Thus, extracting this variable will allow the main game script to perform correctness check using If-Else() function.

![alt text](https://github.com/SimLongXiang/CZ4001-MemoryAR/blob/master/MemoryARScreenShot/DefaultTrackingHandlerEvent.JPG)

# Future Development
The creation of MemoryAR opens a wide range of function for the masses. In the education sector, MemoryAR can be a visual teaching tool, such as introducing new words and getting them exposed to those word through memory training. This can be achieved by replacing the flashing images with words, and assigning each card used to a word for the game to work. Also, each card can render a 3D model that represents the word assigned. In short, the idea of a dynamic marker (markers that renders different object on different setting) unlocks the possibility of learning words through visual.
In other sectors, MemoryAR can be used as:
  -	an aid to help elderly with failing memory, 
  -	Color-blind testing,
  -	Learning assessment tool (flashing questions and asking user to scan correct answers)
  -	Spelling Bee competition (flashing letters in a word in random order, and scanning card to determine correct letter order)
In conclusion, the creation of MemoryAR is to help create or improve solution for existing problems. The capability of AR technology is one that should be heavily explored and implemented to make the world better.


