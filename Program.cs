namespace hangman
{
    class MainClass {
        static void Main() {
            CSHangman cs_hangman = new CSHangman();

            while (true) {
                Console.WriteLine(cs_hangman.Word());
                Console.WriteLine("Guess: ");
                char guess = Console.ReadLine()[0];

                cs_hangman.guess_letter(guess);

                if (cs_hangman.Tries() <= 0) {
                    Console.WriteLine("Hanged!");
                    break;
                }
                else if (cs_hangman.Word().All(character => cs_hangman.UncoveredLetters().Contains(character))) {
                    Console.WriteLine("You won!");
                    break;
                }
            }
        }
    }
    class CSHangman {
        // Instance variables for the class
        private string word = "";
        private List<char> uncovered_letters = new List<char> {};
        private int tries;
        private bool is_hanged;

        private List<string> words = new List<string>
        {
            "CLASS", "METHOD", "PROPERTY", "INTERFACE", "ABSTRACT",
            "OVERRIDE", "PUBLIC", "PRIVATE", "PROTECTED", "STATIC",
            "NEW", "VOID", "INT", "STRING", "CHAR", "DOUBLE", "FLOAT",
            "BOOL", "IF", "ELSE", "SWITCH", "CASE", "DEFAULT", "WHILE",
            "FOR", "FOREACH", "DO", "BREAK", "CONTINUE", "RETURN",
            "THROW", "TRY", "CATCH", "FINALLY", "USING", "NAMESPACE",
            "AS", "IS", "VAR", "THIS", "BASE", "ENUM", "STRUCT", "GET", "SET"
        };

        private Random random = new Random();


        // Constructor
        public CSHangman() {
            // Set up a random variable to calculate a random index
            set_word(words[random.Next(0, words.Count)]);
            set_tries(7);
        }

        // Getters and Setters

        #pragma warning disable IDE1006
        public string Word() {
            return word;
        }

        public void set_word(string value) {
            this.word = value;
        }

        public List<char> UncoveredLetters() {
            return uncovered_letters;
        }

        public void add_uncovered_letter(char value) {
            this.uncovered_letters.Add(value);
        }

        public int Tries() {
            return tries;
        }

        public void set_tries(int value) {
            this.tries = value;
        }

        public bool IsHanged() {
            return is_hanged;
        }

        public void ChangeGameStatus(bool status) {
            is_hanged = status;
        }
    

        #pragma warning restore IDE1006

        // Methods

        public void guess_letter(char letter) {
            letter = char.ToUpper(letter);
            if (Word().Contains(letter)) {
                add_uncovered_letter(letter);
                Console.WriteLine("Correct!");
            }
            else {
                set_tries(Tries() - 1);
                Console.WriteLine("Wrong!");
            }
        }
    }
}