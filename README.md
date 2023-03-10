# Sudoku Solver - Ronni Moshkovitz

#### This project is an OMEGA Sudoku solver. It gets a string representation of a Sudoku board and solves it rapidly.

The code is written in C# (.NET 7.0), and the sudoku solving is implemented using Dr. Donald Knuth’s Dancing Links Algorithm.

## README Menu:
**[The Sudoku Rules](README.md#sudoku-puzzle-rules)**

**[The Program](README.md#the-program)**

**[The Code](README.md#the-code-behind-the-sudoku-solver)**

**[The Solving Algorithm](README.md#the-solving-algorithm--dancing-links)**


## Sudoku Puzzle Rules
A sudoku puzzle is a logic-based value placement puzzle.
The goal is to solve the puzzle by filling an NxN grid with values from 1 to N in such a way that each house (row, column, or box) contains all of the values from 1 to N without repetition. The puzzle typically starts with some values already filled in as clues, and the player must use logic to determine the correct placement of the remaining numbers.

**The houses:**

In the Sudoku puzzle each cell has 3 houses.
There are 3 types of houses:

≡ Row:

<img width="235" alt="image" src="https://user-images.githubusercontent.com/117098162/212574748-f006ecb7-f205-4153-a7e7-8fa05b9c1903.png">


≡ Column:

<img width="32" alt="image" src="https://user-images.githubusercontent.com/117098162/212574914-15a8fd00-841a-45f9-81f5-5c06a8691d1a.png">


≡ Box: (subgrid of **sqrt(N)xsqrt(N)** cells)

<img width="82" alt="image" src="https://user-images.githubusercontent.com/117098162/212574949-5580146e-8c10-491e-8489-e5a2a2b08608.png">

These are all the houses of the cell in index (0,0) on the board from the next example.


#### Example for a Sudoku string
The string: 100000027000304015500170683430962001900007256006810000040600030012043500058001000
Represents the board:

<img width="267" alt="image" src="https://user-images.githubusercontent.com/117098162/212572696-565f9895-a69d-4b47-be3f-5df3f7ea8ee3.png">
* A sudoku with size 9x9

## The program
This program solves Sudoku boards in different sizes. It currently supports boards in sizes 1x1 to 25x25.
To enter a board, you can choose from two different sources. You can either choose Console; and enter a Sudoku string directly into the console, or you can choose Text file; and enter a path to a txt file with a Sudoku string in it.
The rest of the user communication is done through the console.

### Using the soduko solver program
#### Running the program
To run the sudoku solver program you first have to clone the repository to your local computer. Then open the ``Sudoku Solver - Ronni Moshkovitz.sln`` file in Visual Studio 2022, and run it. **make sure you are using .NET 7.0**.


#### Program usage
Starting the program will show the following:
```
     __        __   _ _                            _          _   _          
     \ \      / /__| | | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
      \ \ /\ / / _ \ | |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
       \ V  V /  __/ | | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
        \_/\_/ \___|_|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|
        ___  __  __ _____ ____    _      ____  _   _ ____   ___  _  ___   _   
       / _ \|  \/  | ____/ ___|  / \    / ___|| | | |  _ \ / _ \| |/ / | | |  
      | | | | |\/| |  _|| |  _  / _ \   \___ \| | | | | | | | | | ' /| | | |  
      | |_| | |  | | |__| |_| |/ ___ \   ___) | |_| | |_| | |_| | . \| |_| |  
       \___/|_|  |_|_____\____/_/   \_\ |____/ \___/|____/ \___/|_|\_\\___/   
                      ____   ___  _ __     _______ ____                                      
                     / ___| / _ \| |\ \   / / ____|  _ \                                     
                     \___ \| | | | | \ \ / /|  _| | |_) |                                    
                      ___) | |_| | |__\ V / | |___|  _ <                                     
                     |____/ \___/|_____\_/  |_____|_| \_\    

This solver gets a sudoku string that represent all the cells of the sudoku board, and solves it for you!.
```
along with the rules and an example.

Every round before starting a new action, the next menu will appear:
```
≡ To view rules: enter - rules

≡ To enter board: enter - solve

≡ To view example: enter - example 

≡ To EXIT: enter - exit
```

**Choosing rules:** will display the sudoku rules
```
    In the Sudoku puzzle each cell has 3 houses.
    There are 3 types of houses:
     ≡ Row:
        ┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐
        │ 1 │ 0 │ 0 ││ 0 │ 0 │ 0 ││ 0 │ 2 │ 7 │
        └───┴───┴───┘└───┴───┴───┘└───┴───┴───┘
     ≡ Column: 
        ┌───┐
        │ 1 │
        ├───┤
        │ 0 │
        ├───┤
        │ 5 │
        └───┘
        ┌───┐
        │ 4 │
        ├───┤
        │ 9 │
        ├───┤
        │ 0 │
        └───┘
        ┌───┐
        │ 0 │
        ├───┤
        │ 0 │
        ├───┤
        │ 0 │ 
        └───┘
     ≡ Box:
        ┌───┬───┬───┐
        │ 1 │ 0 │ 0 │
        ├───┼───┼───┤
        │ 0 │ 0 │ 0 │
        ├───┼───┼───┤
        │ 5 │ 0 │ 0 │
        └───┴───┴───┘
    The main goal is to fill in all the empty cells and compleate the board.

    BUT, There is only one rule for the sudoku puzzle.
    Eeach value can only appear ONCE in a house.
```
**Choosing example:** will show the following example
```
Exemple:
    The string:
    100000027000304015500170683430962001900007256006810000040600030012043500058001000
    Represents the board:
        ┌───────────────────────────────────────┐
        │┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
        ││ 1 │ 0 │ 0 ││ 0 │ 0 │ 0 ││ 0 │ 2 │ 7 ││
        │├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
        ││ 0 │ 0 │ 0 ││ 3 │ 0 │ 4 ││ 0 │ 1 │ 5 ││
        │├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
        ││ 5 │ 0 │ 0 ││ 1 │ 7 │ 0 ││ 6 │ 8 │ 3 ││
        │└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
        │┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
        ││ 4 │ 3 │ 0 ││ 9 │ 6 │ 2 ││ 0 │ 0 │ 1 ││
        │├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
        ││ 9 │ 0 │ 0 ││ 0 │ 0 │ 7 ││ 2 │ 5 │ 6 ││
        │├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
        ││ 0 │ 0 │ 6 ││ 8 │ 1 │ 0 ││ 0 │ 0 │ 0 ││
        │└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
        │┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
        ││ 0 │ 4 │ 0 ││ 6 │ 0 │ 0 ││ 0 │ 3 │ 0 ││
        │├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
        ││ 0 │ 1 │ 2 ││ 0 │ 4 │ 3 ││ 5 │ 0 │ 0 ││
        │├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
        ││ 0 │ 5 │ 8 ││ 0 │ 0 │ 1 ││ 0 │ 0 │ 0 ││
        │└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
        └───────────────────────────────────────┘
    * You can choose your desired board size.
```
**Choosing solve:** will ask you for an input source
```
┌────────────────────────────────────────────────────┐
│    Choose input sudoku sorce from the following:   │
│        ≡ To read from file: enter - file           │
│        ≡ To read from console: enter - console     │
└────────────────────────────────────────────────────┘
```
After choosing file, the program will ask for a file path to a txt file with a Sudoku string in it.

After choosing console, the program will ask for a Sudoku string.

**After entering the Sudoku string:** the solver will display the given Sudoku in a clean Sudoku display, and then solve it. After that the program will present the solved Sudoku's display, the solved Sudoku string, and the time that it took to solve the Sudoku ( in milisecounds).

output example for the string 100000027000304015500170683430962001900007256006810000040600030012043500058001000:
```
┌───────────────────────────────────────┐
│┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
││ 1 │ 0 │ 0 ││ 0 │ 0 │ 0 ││ 0 │ 2 │ 7 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 0 │ 0 │ 0 ││ 3 │ 0 │ 4 ││ 0 │ 1 │ 5 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 5 │ 0 │ 0 ││ 1 │ 7 │ 0 ││ 6 │ 8 │ 3 ││
│└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
│┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
││ 4 │ 3 │ 0 ││ 9 │ 6 │ 2 ││ 0 │ 0 │ 1 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 9 │ 0 │ 0 ││ 0 │ 0 │ 7 ││ 2 │ 5 │ 6 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 0 │ 0 │ 6 ││ 8 │ 1 │ 0 ││ 0 │ 0 │ 0 ││
│└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
│┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
││ 0 │ 4 │ 0 ││ 6 │ 0 │ 0 ││ 0 │ 3 │ 0 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 0 │ 1 │ 2 ││ 0 │ 4 │ 3 ││ 5 │ 0 │ 0 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 0 │ 5 │ 8 ││ 0 │ 0 │ 1 ││ 0 │ 0 │ 0 ││
│└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
└───────────────────────────────────────┘

Solved:
┌───────────────────────────────────────┐
│┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
││ 1 │ 9 │ 3 ││ 5 │ 8 │ 6 ││ 4 │ 2 │ 7 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 8 │ 6 │ 7 ││ 3 │ 2 │ 4 ││ 9 │ 1 │ 5 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 5 │ 2 │ 4 ││ 1 │ 7 │ 9 ││ 6 │ 8 │ 3 ││
│└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
│┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
││ 4 │ 3 │ 5 ││ 9 │ 6 │ 2 ││ 8 │ 7 │ 1 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 9 │ 8 │ 1 ││ 4 │ 3 │ 7 ││ 2 │ 5 │ 6 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 2 │ 7 │ 6 ││ 8 │ 1 │ 5 ││ 3 │ 4 │ 9 ││
│└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
│┌───┬───┬───┐┌───┬───┬───┐┌───┬───┬───┐│
││ 7 │ 4 │ 9 ││ 6 │ 5 │ 8 ││ 1 │ 3 │ 2 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 6 │ 1 │ 2 ││ 7 │ 4 │ 3 ││ 5 │ 9 │ 8 ││
│├───┼───┼───┤├───┼───┼───┤├───┼───┼───┤│
││ 3 │ 5 │ 8 ││ 2 │ 9 │ 1 ││ 7 │ 6 │ 4 ││
│└───┴───┴───┘└───┴───┴───┘└───┴───┴───┘│
└───────────────────────────────────────┘

Took: 1.1451 milisecounds

Solved Sudoku string: 193586427867324915524179683435962871981437256276815349749658132612743598358291764
```
**Choosing exit:** will show the following and then terminate the program
```
      _____ _              _                      __                   _             _   _    _     
     |_   _| |_  __ _ _ _ | |__  _  _ ___ _  _   / _|___ _ _   _  _ __(_)_ _  __ _  | |_| |_ (_)___ 
       | | | ' \/ _` | ' \| / / | || / _ \ || | |  _/ _ \ '_| | || (_-< | ' \/ _` | |  _| ' \| (_-< 
       |_| |_||_\__,_|_||_|_\_\  \_, \___/\_,_| |_| \___/_|    \_,_/__/_|_||_\__, |  \__|_||_|_/__/ 
                   ___ _   _ ___ |__/_  _  ___   _   ___  ___  _ __   _____ _|___/                  
                  / __| | | |   \ / _ \| |/ / | | | / __|/ _ \| |\ \ / / __| _ \ |                  
                  \__ \ |_| | |) | (_) | ' <| |_| | \__ \ (_) | |_\ V /| _||   /_|                  
                  |___/\___/|___/ \___/|_|\_\\___/  |___/\___/|____\_/ |___|_|_(_)  
                    
                                                         _     _   _                 
              ___ ___ ___   _  _ ___ _  _   _ _  _____ _| |_  | |_(_)_ __  ___       
             (_-</ -_) -_) | || / _ \ || | | ' \/ -_) \ /  _| |  _| | '  \/ -_)_ _ _ 
             /__/\___\___|  \_, \___/\_,_| |_||_\___/_\_\\__|  \__|_|_|_|_\___(_|_|_)
                            |__/ 

Created by: Ronni Moshkovitz
```

## The code behind the Sudoku solver
#### This project is divided into 6 parts; each is in charge of one aspect of the overall program:
- BoardProcessing
- BoardSolving
- ReadingAndWriting
- SudokuHandling
- UIManagement

- Exceptions

### BoardProcessing:

This package includes all the processing related classes. These classes validate the Sudoku string, validate it, parse it into a board, and check that the board doesn't contradict the Sudoku rules.


**Classes:**

- Board
- BoardTranslator
- StringValidator
- SudokuParser
- BoardValidator
- BoardProcessor


**Board:**

This class represent a Sudoku board. On this board all empty cells contain the value zero. All cells with values contain a value between 1 to the board's side length.

**BoardTranslator:**

This class is a Utility class. It is in charge of converting the cell's value from int to its matching char, and so the other way.

**StringValidator:**

This class defines an object that validates Sudoku string representations.

**SudokuParser:**

This class defines an object that is in charge of converting the input Sudoku string to a 2D array of int values and deparsing an array to a string (the other way around).

**BoardValidator:**

This class is in charge of validating a given board. It makes sure that the board doesn't contradict the sudoku rules.

**BoardProcessor:**

This class is an object that processes a board from an input string that represents the Sudoku board to a board object.

### BoardSolving:

This package includes all the Sudoku solving related classes. These classes preform all the steps in the solving of the Sudoku.

**Classes:**

- CoverMatrix
- DancingNode
- ColumnNode
- DLXLayout
- DancingLinks
- SolutionHandler
- SudokuSolver

**CoverMatrix:**

This class defines an object that creates an exact cover matrix for a given board.

**DancingNode:**

This class defines a node for a four-way-linked DLX layout.

**ColumnNode:**

This class defines a column node for a four-way-linked DLX layout.

**DLXLayout:**

This class converts an exact cover matrix into a four-way-linked list representation of the exact cover problem. In this representation each node is linked vertically and horizontally to create a layout where only the constraints (the 1ns) appear.

**DancingLinks:**

This class defines an object that solves an exact cover problem, represented by a four-way-linked list (dancing links layout), based on Donald E. Knuth's algorithm X.

**SolutionHandler:**

This class converts an exact cover solution to a Sudoku solution.

**SudokuSolver:**

This class represents a Sudoku solver that gets a Sudoku board and solves it.

### ReadingAndWriting:

This package includes all the classes and interfaces that are in charge of reading and writing (getting input and setting output). These classes preform all the input and output supported by this program.

**Classes:**

- IReader
- IWriter
- TextFileAccess
- TextFileReader
- TextFileWriter
- ConsoleReader
- ConsoleWriter

**IReader:**

This interface supports reading input.

**IWriter:**

This interface supports writing output.

**TextFileAccess:**

This class is an abstract class that represent file access object.

**TextFileReader:**

This class inherits TextFileAccess and implements the IReader interface. It reads input from the file.

**TextFileWriter:**

This class inherits TextFileAccess and implements the IWriter interface. It writes output to the file.

**ConsoleReader:**

This class implements the IReader interface. It reads input from the console.

**ConsoleWriter:**

This class implements the IWriter interface. It writes output to the console.

### SudokuHandling:

This package includes all the classes that gather the Sudoku handling process. Its main class gathers the board processing and the board solving, along with the timing of the solution and the display of the board as a Sudoku board.

**Classes:**

- BoardDisplay
- Timer
- SudokuHandler

**BoardDisplay:**

This class creates a Sudoku display for its board.

**Timer:**

This class represents a stopwatch object.

**SudokuHandler:**

This class is in charge of handling all the Sudoku related operations.

### UIManagement:

This package includes all the classes that manage the UI and interact with the user. It directs all the user's requests and act accordingly.

**Classes:**

- UserCommunication
- MenuSelections
- MenuActions
- ProgramDefaults

**UserCommunication:**

This class is a static class. It is in charge of all the input and output exchange with the user.

**MenuSelections:**

This class is in charge of directing the program according to a given selection string.

**MenuActions:**

This class is a static class. It contains the actions for the menu selections.

**ProgramDefaults:**

This class is a Configuration class. It contains all the default messages.

### Exceptions:

This package includes all the program's exceptions.

**Exceptions:**

- IllegalBoardException
- IllegalHouseException
- IllegalRowException
- IllegalColumnException
- IllegalBoxException

- InvalidSudokuStringException
- UnsupportedValueException
- InvalidLengthException
- StringTooLongException
- InvalidSideException
- EmptyStringException

- TextFilePathException
- EmptyPathException
- WrongFormatException

**IllegalBoardException:**
This Exception is an exception for cases in which the given board is illegal (contradicts the Sudoku rules).

**IllegalHouseException:**
 This Exception is an exception for cases in which the given board is illegal due to multiple appearances of the same value in the same house.

**IllegalRowException:**
This Exception is an exception for cases in which the given board is illegal due to multiple appearances of the same value in the same row.

**IllegalColumnException:**
This Exception is an exception for cases in which the given board is illegal due to multiple appearances of the same value in the same column.

**IllegalBoxException:**
This Exception is an exception for cases in which the given board is illegal due to multiple appearances of the same value in the same box.

**InvalidSudokuStringException:**
This Exception is an exception for when the given Sudoku string is invalid.

**UnsupportedValueException:**
 This Exception is an exception for cases in which the given Sudoku string is invalid due to an appearance of a character (value) that is out of the range of the Sudoku board's values.

**InvalidLengthException:**
This Exception is an exception for cases in which the given Sudoku string is invalid due to invalid length of the string.

**StringTooLongException:**
This Exception is an exception for cases in which the given Sudoku string is invalid due to too long Sudoku string.

**InvalidSideException:**
This Exception is an exception for cases in which the given Sudoku string is invalid due to missing characters (values) to complete a Sudoku board.

**EmptyStringException:**
This Exception is an exception for cases in which the given Sudoku string is empty.

**TextFilePathException:**
This Exception is an exception for cases in which the given file path is invalid for text file access.

**EmptyPathException:**
This Exception is an exception for cases in which the given file path is empty.

**WrongFormatException:**
This Exception is an exception for cases in which the given file path is invalid due to wrong file format (not \*.txt).

## The solving algorithm – Dancing Links
###### After extensive search and considerations, I decided to solve the Sudoku puzzle using Dr. Donald Knuth’s Dancing Links Algorithm, along with the algorithm X.  In this approach, the Sudoku puzzle is converted into an Exact Cover problem. The algorithm solves the Exact Cover problem, and the solution gets converted back to a Sudoku board.

### Exact Cover Problem
An exact cover problem can be represented as a sparse matrix where the rows represent the possibilities, and the columns represent constraints. Each cell in the matrix contains either a 0 or a 1.
Looking at the matrix representation, every row has a 1 in every column that it satisfies, and a 0 in every column that is not satisfied by this row. To solve an exact cover problem, a set of rows such that every column contains exactly one 1, has to be selected. This set represents the chosen solution parts, out of all the problems possible option.
Here is an example representation of a sparse matrix of an exact cover problem:

![image](https://user-images.githubusercontent.com/117098162/212575858-3ddb2b0e-990b-4150-812f-ed45783b72d6.png)

### Converting Sudoku into an Exact Cover Problem:
In the Sudoku puzzle each cell has an amount of options equals to the amount of cells in each house.
Each value can only appear once in a house, meaning: 
•	Each value can only appear once in a row
•	Each value can only appear once in a column
•	Each value can only appear once in a box
These 4 constraints help us to build the exact cover problem for the Sudoku.

In the Sudoku exact cover problem, each row represents a single option for a specific cell. This row contains the option’s constraints as will be described later.
Here is an example for the first option for the first cell in a 9x9 Sudoku board:

![image](https://user-images.githubusercontent.com/117098162/212576031-824c5f57-10c4-4873-9b7e-544e3fd4472c.png)

#### Setting the Constraints:
•	Cell Constraint: This constraint represents the cell’s serial number. Since a cell can only contain one value, all the options for the same cell will have a constraint (1) in the same column. This way two values for the same row will never be selected. Only one of the cell’s options can be part of the final result. The first cells in the matrix (0 to the amount of cells), will contain this constraint.
•	House constraints: The next three constraints follow the same idea. Since only one appearance of each value can appear in a single house, each house is assigned a house size amount of cells in the matrix cover matrix’ row for a certain option. This constraint is according to the house size + the option value.
Thus, all the options with the same value in the same house, can’t be chosen for the same set, meaning; the answer can't contain two cell options with the same value in the same house, because both will have a 1 in the same column.

For example:
In a 9x9 Sudoku:
The first 81 (9*9) exact cover matrix cells in a row will be cell constraints.
The second 81 exact cover matrix cells in a row will be rows constraints, while the 9 first ones will be row number 0th constraint (the first row).
Same goes for column and box constraints.
The third 81 exact cover matrix cells in a row will be columns constraints.
The last 81 exact cover matrix cells in a row will be boxes constraints.
The location of the house constraint will be determined according to its type, house number, and the value to insert.

**To demonstrate, here is an example for a single row in a cover matrix (EC), divided to the different constraint ranges:**

For a row constraint of the cell in index (0,3), in a 4x4 Sudoku.
Suppose the option for the cell is the value 2:
The row will look like this:

Cell constraint – 4th cell overall

| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 |
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
| **0** | **0** | **0** | **1** | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |

Row constraint – row 0, value 2 (second option)

| 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29 | 30 | 31 |
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
| **0** | **1** | **0** | **0** | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |

Column constraint – column 3, value 2 (second option)

| 32 | 33 | 34 | 35 | 36 | 37 | 38 | 39 | 40 | 41 | 42 | 43 | 44 | 45 | 46 | 47 |
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
| 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | **0** | **1** | **0** |**0** |

*we skipped 12 cells that belong to columns 0-2

Box constraint – box 1, value 2 (second option) 

| 48 | 49 | 50 | 51 | 52 | 53 | 54 | 55 | 56 | 57 | 58 | 59 | 60 | 61 | 62 | 63 |
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
| 0 | 0 | 0 | 0 | **0** | **1** | **0** | **0** | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |

*we skipped 4 cells that belong to column 0

### Solving the problem
##### Algorithm x:
Algorithm X is an algorithm that was created by Dr. Donald Knuth and can be used to find
all the solutions for a given Exact Cover problem. It is a nondeterministic, recursive algorithm that uses depth-first search for backtracking. 
The algorithm is based on a very simple technique. It uses a four-way-linked list representation of the exact cover problem, where each node points to the node above, below, to the right, and to the left of it, in a two directional way (and a circular way). This way, a removal of a node from the list and an insertion back to the list are simple and quick. This is the key to the dancing links technique, this makes the backtracking efficient.

##### Dancing Links:
Dancing Links, or DLX for short, is the technique suggested by Donald Knuth for
implementing Algorithm X. 
It uses the following structure: We build a grid like layout built out from nodes (a circular four-way-linked list). This grid contains an exact cover problem, where only the 1s are present, and each column has a special node at the top, that represents the column itself (there is also an extra node that acts as the header node of the list).
**Here is an example of the node representation along with the matrix representation to the same problem:**

![image](https://user-images.githubusercontent.com/117098162/212577272-59ada03c-0281-448a-b1dd-ede24eb7e402.png)

The solving algorithm works in a backtracking form. It chooses a row and tries to find a solution with it. After choosing the row it "covers" all the nodes that are related to it. Meaning, if a certain row is selected, all the other options in that row are selected as well, and all the columns that have a node in that row get satisfied. Then, all the rows with 1s (nodes) in the same columns are removed (unlinked), and all the columns that got satisfied by the choice of that row are removed as well (covered).
The removing process works by simply linking and unlinking the nodes to their neighboring nodes.
This process repeats itself over and over again.
If the algorithm reaches a dead end, it backtracks and uncovers (reconnects) the last covered nodes.

The solving process can end in one of two ways:
1. All the columns are removed but the header node. In this case a solution was found, all columns are satisfied.
2. Tried all possible rows and all lead to a dead end, there is no solution to the problem.

### Complete the sudoku
After solving the Sudoku Exact Cover Problem, we get a set of options that represent one solution to the exact cover problem.
This solution includes all the cells on the board and their values (including both empty and filled cells). To solve the Sudoku, we will translate each row from the solution set back to the cell index, and the cell value. We will then place each cell result on the Sudoku board, until the Sudoku is fully
solved.


