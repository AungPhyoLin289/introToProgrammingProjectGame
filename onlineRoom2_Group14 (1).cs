using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t*       *       *  ******  *       ******   ******   *     *  ****** ");
            Console.WriteLine("\t\t\t\t *     * *     *   *       *       *       *      *  * * * *  *     ");
            Console.WriteLine("\t\t\t\t  *   *   *   *    ******  *       *       *      *  *  *  *  ****** ");
            Console.WriteLine("\t\t\t\t   * *     * *     *       *       *       *      *  *     *  *     ");
            Console.WriteLine("\t\t\t\t    *       *      ******  ******  ******   ******   *     *  ****** ");
            Console.WriteLine();
            int option;
            bool optionMenuContinue = true;
            do
            {
                Console.WriteLine("There are three games in our project.\n1.\tHangMan Game\n2.\tTictactoe Game\n3.\tRock & Paper & Scissor Game\n4.\tExit");
                Console.WriteLine();
                Console.Write("Which game do you want to play?...");
                option = int.Parse(Console.ReadLine());
               
                switch (option)
                {
                    case 1:
                        {
                            
                            string randomWord = getRandomWord().ToLower();

                            Console.WriteLine("\n\tWelcome to Hangman game (Animal Words).\n");
                            Console.WriteLine("{0}---(FOR TESTING PURPOSE)\n", randomWord);

                            
                            
                            char[] guess = new char[randomWord.Length];

                            //char[] guessAllCharArr;
                            hang0();
                            int incorrectCount = 0;
                            printPlaceHolderDefault(guess);
                            int correctCount = 0, remainingBlanks = randomWord.Length;

                            while (true)
                            {
                                bool isCorrect;
                                isCorrect = checkCharIndiv(userCharIndivInput(), randomWord, guess);
                                updatePlaceHolder(guess);
                                if (guess.SequenceEqual(randomWord))
                                {
                                    Console.WriteLine("You have guessed Correctly!\n\n");
                                    break;
                                }

                                if (isCorrect)
                                {
                                    //Update the placeholder


                                    correctCount++;
                                    if (correctCount == 1)
                                    {
                                        string guessAll;
                                        Console.Write("Want to guess whole word?(yes/no): ");
                                        guessAll = Console.ReadLine();

                                        if (guessAll.ToLower() == "yes")
                                        {
                                            bool guessedAllCorrectly = false;
                                            guessedAllCorrectly = guessWholeWord(randomWord, guess);
                                            if (guessedAllCorrectly)
                                            {
                                                updatePlaceHolder(guess);
                                                Console.WriteLine("Congratulations, you have guessed correctly!!!\n\n");
                                                break;
                                            }
                                            else
                                            {
                                                hang6();
                                                Console.WriteLine("You have lost.\n\n"); break;
                                            }
                                        }


                                    }
                                }
                                else
                                {

                                    incorrectCount++;
                                    if (incorrectCount == 1)
                                        hang1();
                                    else if (incorrectCount == 2)
                                        hang2();
                                    else if (incorrectCount == 3)
                                        hang3();
                                    else if (incorrectCount == 4)
                                        hang4();
                                    else if (incorrectCount == 5)
                                        hang5();
                                    else if (incorrectCount == 6)
                                    {
                                        hang6();
                                        Console.WriteLine("You have lost.");
                                        Console.WriteLine("The Word is....: " + randomWord + ".\n\n");
                                        break;
                                    }


                                }
                            }
                        }
                        break;

                    case 2:
                        {
                            
                            char[] arr = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                            bool gameContinue = true;
                            Console.WriteLine("\t\t\t   Sample Input for Playground\n");
                            Console.WriteLine("\t\t\t     |     |      ");
                            Console.WriteLine("\t\t\t 0   |  1  | 2  ");
                            Console.WriteLine("\t\t\t_____|_____|_____ ");
                            Console.WriteLine("\t\t\t     |     |      ");
                            Console.WriteLine("\t\t\t 3   | 4   | 5  ");
                            Console.WriteLine("\t\t\t_____|_____|_____ ");
                            Console.WriteLine("\t\t\t     |     |      ");
                            Console.WriteLine("\t\t\t 6   | 7   | 8  ");
                            Console.WriteLine("\t\t\t     |     |      ");
                            displayBoard(arr);
                            while (gameContinue)
                            {

                                user1Input(arr);
                                displayBoard(arr);
                                if (process(arr))
                                    break;
                                user2Input(arr);
                                displayBoard(arr);
                                if (process(arr))
                                    break;
                            }
                        }
                        break;
                    case 3:
                        {
                            
                            string result = "";
                            int playerScore = 0, comScore = 0;
                            bool runLoop = true;



                            while (runLoop)
                            {
                                result = process(playerInput(), computerChoice());
                                if (result == "Tie")
                                {
                                    Console.WriteLine("Tie");
                                }
                                else if (result == "player")
                                {
                                    playerScore++;
                                    Console.WriteLine("You win");
                                }
                                else if (result == "computer")
                                {
                                    comScore++;
                                    Console.WriteLine("Computer wins");
                                }
                                if (playerScore == 5)
                                {
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("|You are the champion|");
                                    Console.WriteLine("---------------------");

                                    runLoop = false;
                                }
                                if (comScore == 5)
                                {
                                    Console.WriteLine("---------------");
                                    Console.WriteLine("|You have lost |");
                                    Console.WriteLine("---------------");
                                    runLoop = false;
                                }
                                viewRecord(playerScore, comScore);
                            }




                        }
                        break;
                    case 4:
                        {
                            optionMenuContinue = false;
                            Console.WriteLine("\n\n***************Thank you so much for visiting! See you soon***************");
                        } break;
                    default: optionMenuContinue = true;
                        Console.WriteLine("Please only choose 1, 2, 3 or 4 as shown in the menu."); break;
                }

            }
            while (optionMenuContinue);
        }

        // HANGMAN****************************

        //Getting Random word (Array, function)

        public static string getRandomWord()
        {
            string[] words = { "Ant", "Cat", "Cattle", "Dog", "Donkey",
                "Goat", "Bat", "Bee", "Beetle", "Bird", "Butterfly", "Buzzard",
                "Camel", "Dog", "Donkey", "Goat", "Horse", "Pig", "Rabbit", "Baboon",
                "Bat", "Buffalo", "Camel", "Buzzard", "Lizard", "Chicken", "Cobra",
                "Zebra", "Cockroach ", "Cow", "Crab", "Crocodile", "Deer", "Dolphin",
                "Dinosaur", "Dragon", "Duck", "Elephant ", "Fist", "Fox", "Fly", "Frog",
                "Jellyfish", "Kangaroo", "Leopard", "Lion", "Tiger", "Shark", "Mouse",
                "Rat", "Mosquito ", "Owl", "Octopus", "Panda", "Monkey", "Salmon",
                "Sheep", "Shrimp", "Snake", "Snail", "Starfish", "Squid", "Squirrel",
                "Swallow", "Tortoise", "Turtle", "Whale", "Wolf", "Goldfish", "Pigeon", "mosquito"};
            Random random = new Random();

            int LengthOfArray = words.Length;
            int randomIndex = random.Next(1, LengthOfArray + 1);
            return words[randomIndex];
        }


        //Print the empty underscolls in guess playground (Loop, array)
        public static void printPlaceHolderDefault(char[] guess)
        {
            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] = '_';
                Console.Write(guess[i] + " ");

            }
            Console.WriteLine();
        }

        //update the guess playground as the user guess corectly (Loop, array)
        public static void updatePlaceHolder(char[] guess)
        {
            for (int i = 0; i < guess.Length; i++)
            {
                Console.Write(guess[i] + " ");
            }
            Console.WriteLine();
        }

        //guess the whole word by entering each char in order (InputData to array, array, loop)
        public static bool guessWholeWord(string randomWord, char[] guess)
        {
            Console.WriteLine("The Audacity to take risk is so high");
            char input;
            bool isArrSame;
            for (int i = 0; i < randomWord.Length; i++)
            {
                Console.Write("Enter the " + (i + 1) + " letter of the word: ");
                input = Convert.ToChar(Console.ReadLine().ToLower());
                guess[i] = input;
            }
            isArrSame = guess.SequenceEqual(randomWord);

            return isArrSame;
        }

        //check if the indiv char is there or not (loop, condition, array)
        public static bool checkCharIndiv(char user, string randomWord, char[] guess)
        {
            char randomWordChar; int j = 0;
            for (int i = 0; i < randomWord.Length; i++)
            {
                randomWordChar = randomWord[i];
                if (randomWordChar == user)
                {
                    guess[i] = user;
                    j++;
                }
            }
            if (j != 0)
                return true;
            return false;
        }

        // userInput individual char 
        public static char userCharIndivInput()
        {
            Console.Write("Guess a word: ");
            char character = char.Parse(Console.ReadLine().ToLower());
            return character;
        }



        //Hangman update print
        public static void hang0()
        {
            Console.WriteLine("---------");
            Console.WriteLine("        |");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        //Hangman update print
        public static void hang1()
        {
            Console.WriteLine("----------");
            Console.WriteLine("         |");
            Console.WriteLine("         O");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void hang2()
        {
            Console.WriteLine("----------");
            Console.WriteLine("         |");
            Console.WriteLine("         O");
            Console.Write("       / ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void hang3()
        {
            Console.WriteLine("----------");
            Console.WriteLine("         |");
            Console.WriteLine("         O");
            Console.Write("       / ");
            Console.Write("| ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void hang4()
        {
            Console.WriteLine("----------");
            Console.WriteLine("         |");
            Console.WriteLine("         O");
            Console.Write("       / ");
            Console.Write("| ");
            Console.WriteLine("\\");
            Console.WriteLine();

        }

        public static void hang5()
        {
            Console.WriteLine("----------");
            Console.WriteLine("         |");
            Console.WriteLine("         O");
            Console.Write("       / ");
            Console.Write("| ");
            Console.WriteLine("\\");
            Console.WriteLine("        /");
        }

        public static void hang6()
        {
            Console.WriteLine("----------");
            Console.WriteLine("         |");
            Console.WriteLine("         O");
            Console.Write("       / ");
            Console.Write("| ");
            Console.WriteLine("\\");
            Console.Write("        /");
            Console.WriteLine(" \\");
        }
        //HANGMAN**********************************

        //Tic-tac-toe *****************************
        //Process who win or lose or tie (condition, array)
        public static bool process(char[] arr)
        {
            if ((arr[0] == 'X' && arr[1] == 'X' && arr[2] == 'X') ||
                (arr[0] == 'X' && arr[3] == 'X' && arr[6] == 'X') ||
                (arr[0] == 'X' && arr[4] == 'X' && arr[8] == 'X') ||
                (arr[1] == 'X' && arr[4] == 'X' && arr[7] == 'X') ||
                (arr[2] == 'X' && arr[5] == 'X' && arr[8] == 'X') ||
                (arr[2] == 'X' && arr[4] == 'X' && arr[6] == 'X') ||
                (arr[3] == 'X' && arr[4] == 'X' && arr[5] == 'X') ||
                (arr[6] == 'X' && arr[7] == 'X' && arr[8] == 'X'))
            {
                Console.WriteLine("---------------");
                Console.WriteLine("|Player 1 wins|");
                Console.WriteLine("---------------");
                return true;
            }
            else if ((arr[0] == 'O' && arr[1] == 'O' && arr[2] == 'O') ||
                     (arr[0] == 'O' && arr[3] == 'O' && arr[6] == 'O') ||
                     (arr[0] == 'O' && arr[4] == 'O' && arr[8] == 'O') ||
                     (arr[1] == 'O' && arr[4] == 'O' && arr[7] == 'O') ||
                     (arr[2] == 'O' && arr[5] == 'O' && arr[8] == 'O') ||
                     (arr[2] == 'O' && arr[4] == 'O' && arr[6] == 'O') ||
                     (arr[3] == 'O' && arr[4] == 'O' && arr[5] == 'O') ||
                     (arr[6] == 'O' && arr[7] == 'O' && arr[8] == 'O'))
            {
                Console.WriteLine("---------------");
                Console.WriteLine("|Player 2 wins|");
                Console.WriteLine("---------------");
                return true;
            }
            else if ((arr[0] == 'X' || arr[0] == 'O') &&
                     (arr[1] == 'X' || arr[1] == 'O') &&
                     (arr[2] == 'X' || arr[2] == 'O') &&
                     (arr[3] == 'X' || arr[3] == 'O') &&
                     (arr[4] == 'X' || arr[4] == 'O') &&
                     (arr[5] == 'X' || arr[5] == 'O') &&
                     (arr[6] == 'X' || arr[6] == 'O') &&
                     (arr[7] == 'X' || arr[7] == 'O') &&
                     (arr[8] == 'X' || arr[8] == 'O'))
            {
                Console.WriteLine("\nIt is Tie"); return true;

            }
            return false;



        }

        //Display the board with user filled data (array)
        public static void displayBoard(char[] arr)
        {
            Console.WriteLine("\t\t\t   Playground\n");
            Console.WriteLine("\t\t\t     |     |      ");
            Console.WriteLine("\t\t\t {0}   |  {1}  | {2}  ", arr[0], arr[1], arr[2]);
            Console.WriteLine("\t\t\t_____|_____|_____ ");
            Console.WriteLine("\t\t\t     |     |      ");
            Console.WriteLine("\t\t\t {0}   |  {1}  | {2}  ", arr[3], arr[4], arr[5]);
            Console.WriteLine("\t\t\t_____|_____|_____ ");
            Console.WriteLine("\t\t\t     |     |      ");
            Console.WriteLine("\t\t\t {0}   |  {1}  | {2}  ", arr[6], arr[7], arr[8]);
            Console.WriteLine("\t\t\t     |     |      ");
            Console.WriteLine("\n\t\tPlayer1 symbol: X\t\tPlayer2 symbol: O\n");
        }

        //Place validation (arr, condition)
        public static bool validation(char[] arr, int index, char symbol)
        {
            if (index > 8 || index < 0 )
            {
               Console.WriteLine("Please enter number from 0-8");
                return false;
            }
            else if (arr[index] == 'X' || arr[index] == 'O')
            {
                Console.WriteLine("This place has already been filled!");
                return false;
            }
            arr[index] = symbol;
            return true;
        }

        //player 1 choice (array, condition, loop, function call)
        static void user1Input(char[] arr)
        {
            bool loopContinue = false;
            do
            {
                Console.Write("PLAYER 1's turn to choose: ");
                int user1Num = Convert.ToInt32(Console.ReadLine());
                if (!validation(arr, user1Num, 'X'))
                    loopContinue = true;
                else
                    loopContinue = false;
            }
            while (loopContinue);
        }

        //player 2 choice (array, condition, loop)
        static void user2Input(char[] arr)
        {
            bool loopContinue = false;
            do
            {
                Console.Write("PLAYER 2's turn to choose: ");
                int user2Num = int.Parse(Console.ReadLine());
                if (!validation(arr, user2Num, 'O'))
                    loopContinue = true;
                else
                    loopContinue = false;
            } while (loopContinue);
        }
        //Tic-Tac-Toe************************************

        //RockPaper Scissor*******************************
        public static void viewRecord(int player, int com) 
        {
            Console.WriteLine("\t\tPlayer\t\t\tComputer");
            Console.WriteLine("\t\t  " + player + "  \t\t\t  " + com);
        }


        //Player input (loop)
        public static int playerInput()
        {
            bool inputOkay = false;
            int playerInput;
            do
            {
                Console.WriteLine("1.Rock\n2.Paper\n3.Scissors");
                Console.Write("You select....");
                playerInput = Convert.ToInt32(Console.ReadLine());
                inputOkay = userInputValidation(playerInput);

            } while (inputOkay);
            return playerInput;
        }

        //userInput validation (condition)
        public static bool userInputValidation(int userInput)
        {
            switch (userInput)
            {
                case 1: Console.WriteLine("Your choice is Rock "); return false; break;
                case 2: Console.WriteLine("Your choice is Paper "); return false; break;
                case 3: Console.WriteLine("Your choice is Scissors"); return false; break;
                default: Console.WriteLine("Please choose only 1 to 3"); return true; break;
            }
        }
        //Computer choice random (loop, function)
        public static int computerChoice()
        {
            Random random = new Random();
            int num = random.Next(1, 4);
            switch (num)
            {
                case 1:
                    Console.WriteLine("Computer choice is Rock."); break;
                case 2:
                    Console.WriteLine("Computer choice is Paper."); break;
                case 3:
                    Console.WriteLine("Computer choice is Scissor."); break;
            }
            return num;

        }

        //process who win or lose or tie (condition)
        public static string process(int player, int computer)
        {
            string winningOpp = "";
            if (player == computer)
                winningOpp = "Tie";
            else if ((player == 1 && computer == 3) || (player == 2 && computer == 1) || (player == 3 && computer == 2))
                winningOpp = "player";
            else
                winningOpp = "computer";
            return winningOpp;
        }

        //RockPaperScissor

        
    }
}
