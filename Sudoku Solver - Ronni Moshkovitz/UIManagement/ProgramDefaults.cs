﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.UIManagement
{
    // This class ProgramDefaults, is a Configuration class. It contains all the default messages.
    internal static class ProgramDefaults
    {
        // The wellcome message (shown when the program starts).
        internal const string WELLCOME_MESSAGE = @"
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
──────────────────────────────────────────────────────────────────────────────────────────────────────────────
";
        // The sudoku puzzle rules.
        internal const string SUDOKU_RULES = @"
──────────────────────────────────────────────────────────────────────────────────────────────────────────────
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
──────────────────────────────────────────────────────────────────────────────────────────────────────────────

";
        // An example for sudoku string input.
        internal const string EXAMPLE = @"
──────────────────────────────────────────────────────────────────────────────────────────────────────────────
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
──────────────────────────────────────────────────────────────────────────────────────────────────────────────
";
        // The goodbye message (shown when the user exits the program)
        internal const string GOODBYE_MESSAGE = @"
──────────────────────────────────────────────────────────────────────────────────────────────────────────────
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
──────────────────────────────────────────────────────────────────────────────────────────────────────────────
";
        // Menu for the program's supported commands.
        internal const string MENU = @"
┌────────────────────────────────────────────────────┐
│    Menu:                                           │
│        Choose one of the following options:        │
│          ≡ To view rules: enter - rules            │
│          ≡ To enter board: enter - solve           │
│          ≡ To view example: enter - example        │
│          ≡ To EXIT: enter - exit                   │
└────────────────────────────────────────────────────┘
";
        // Menu for the input source options
        internal const string INPUT_SORCE_OPTIONS = @"
┌────────────────────────────────────────────────────┐
│    Choose input sudoku sorce from the following:   │
│        ≡ To read from file: enter - file           │
│        ≡ To read from console: enter - console     │
└────────────────────────────────────────────────────┘
";
    }
}