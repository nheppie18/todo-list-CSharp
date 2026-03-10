namespace TodoListProject
{
    // Represents a single to-do item
    class TodoItem
    {
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public TodoItem(string description)
        {
            Description = description;
            IsDone = false;
        }

        // Mark an item in the list as done
        public void MarkAsDone()
        {
            IsDone = true;
        }

        // Used to display and item and if it is complete or not.
        public override string ToString()
        {
            return $"{(IsDone ? "[x]" : "[ ]")} {Description}";
        }
    }

    // Manages the list of to-do items
    class TodoList
    {
        private List<TodoItem> items = new List<TodoItem>();

        // Add an Item to the list
        public void AddItem(string description)
        {
            items.Add(new TodoItem(description));
        }

        // Remove an item from the list
        public void RemoveItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        // Mark an item in the list as done
        public void MarkDone(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items[index].MarkAsDone();
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        // View all items in the list
        public void ShowItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your to-do list is empty.");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            TodoList todoList = new TodoList();
            bool done = false;

            while (!done)
            {
                // Get user input on what action they want to make
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Mark task as done");
                Console.WriteLine("4. Remove a task");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":   // Add a task
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        todoList.AddItem(description);
                        break;

                    case "2":   // View all tasks
                        Console.WriteLine("Your tasks:");
                        todoList.ShowItems();
                        break;

                    case "3":   // Mark a task as complete
                        Console.Write("Enter task number to mark as done: ");
                        if (int.TryParse(Console.ReadLine(), out int completeItem))
                        {
                            todoList.MarkDone(completeItem - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "4":   // Remove a task
                        Console.Write("Enter task number to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeItem))
                        {
                            todoList.RemoveItem(removeItem - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "5":   // Quit
                        done = true;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:    // Error catching
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
