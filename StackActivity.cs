using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Pilha STACK = new Pilha();
        STACK.Constructor();
    }
}

class Pilha
{
    
    //CREATE STRINGS
    private int TOP; 
    private const int MAXSIZE = 5; 
    private Stack<string> STACK;
    private bool MESSAGE = false;

    public Pilha()
    {
        TOP = -1;
        STACK = new Stack<string>();
    }

    //CONSTRUCTOR METHOD
    public void Constructor()
    {
        do
        {
            //APPEAR JUST ONCE
            if (!MESSAGE)
            {
                Console.WriteLine("Your stack is empty, start adding items to de top until 50 items.");
                MESSAGE = true; 
            }
            
            //ENTER INITIAL INFO
            Console.Write("\nEnter information: ");
            string INFO = Console.ReadLine();
            Empilhar(INFO);
        } while (TOP < MAXSIZE - 1);

        //WHEN STACK IS FULL
        if (EstaCheia())
        {
            Console.Clear();
            Console.WriteLine("Your stack is full!\n");
            PrintStack();

            
            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1 - Remove item from stack");
                Console.WriteLine("2 - End program");

                //ADD OPTION IF NOT FULL
                if (!EstaCheia())
                {
                    Console.WriteLine("3 - Add item to stack");
                }

                Console.Write("Choose an option: ");
                string OPTION = Console.ReadLine();

                //OPTIONS
                if (OPTION == "1")
                {
                    Console.Write("Enter the value to remove: ");
                    string valueToRemove = Console.ReadLine();
                    RemoveItem(valueToRemove);
                    PrintStack();
                }
                else if (OPTION == "2")
                {
                    Console.WriteLine("Program ended.");
                    break;
                }
                else if (OPTION == "3" && !EstaCheia())
                {
                    Console.Write("Enter information to add: ");
                    string INFO = Console.ReadLine();
                    Empilhar(INFO);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                }
            }
        }
    }


    //PUSH ITEM METHOD
    public void Empilhar(string INFO)
    {
        if (EstaCheia())
        {
            Console.WriteLine("Your stack is full! Can't add anymore.");
            return;
        }

        STACK.Push(INFO);
        TOP++;
        Console.Clear();
        Console.WriteLine($"\nValue '{INFO}' was added to the top.\n");
        PrintStack();
    }


    //POP ITEM METHOD
    public void RemoveItem(string valueToRemove)
    {
        if (EstaVazia())
        {
            Console.WriteLine("Your stack is empty.");
            return;
        }

        //TEMP STACK TO REBUILD AFTER
        Stack<string> tempStack = new Stack<string>(); 
        bool found = false;

        //REMOVE ITEM UNTIL FIND RIGHT VALUE
        while (STACK.Count > 0)
        {
            string ITEM = STACK.Pop();
            TOP--;

            if (ITEM == valueToRemove)
            {
                found = true;
                Console.Clear();
                Console.WriteLine($"Value '{valueToRemove}' removed from the stack.");
                break;
            }
            else
            {
                //SAVE ITEMS IN TEMP STACK
                tempStack.Push(ITEM); 
            }
        }

        //REBUILD W/ TEMP STACK ITEMS
        while (tempStack.Count > 0)
        {
            string ITEM = tempStack.Pop();
            STACK.Push(ITEM);
            TOP++;
        }

        if (!found)
        {
            Console.WriteLine($"Value '{valueToRemove}' not found in the stack.");
        }
    }

    //PRINT STACK METHOD
    public void PrintStack()
    {
        if (EstaVazia())
        {
            Console.WriteLine("Your stack is empty.");
            return;
        }

        Console.WriteLine("Stack content:");
        foreach (var ITEM in STACK)
        {
            Console.Write(ITEM + " ");
        }
        Console.WriteLine();
    }

    //CHECK EMPTY STACK
    public bool EstaVazia()
    {
        return TOP == -1;
    }

    //CHECK FULL STACK
    public bool EstaCheia()
    {
        return TOP == MAXSIZE - 1;
    }
}
