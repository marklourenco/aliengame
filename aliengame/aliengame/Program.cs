// Mark Jeremy Lourenco Rojas
// Chin Tang

namespace SpaceExplorer
{
    // Base class for entities with health
    abstract class Entity
    {
        public int Health { get; protected set; }

        public Entity(int health)
        {
            Health = health;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public bool IsAlive() => Health > 0;
    }

    // Spaceship class
    class Spaceship
    {
        private int fuel;
        private int shieldStrength;
        private int cargoCapacity;
        private int cargoHold;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Spaceship(int fuel, int shieldStrength, int cargoCapacity, int startX, int startY)
        {
            this.fuel = fuel;
            this.shieldStrength = shieldStrength;
            this.cargoCapacity = cargoCapacity;
            this.cargoHold = 0;
            X = startX;
            Y = startY;
        }

        public virtual int getFuel()
        {
            return fuel;
        }

        public virtual void TakeDamage(int damage)
        {
            shieldStrength -= damage;
            if (shieldStrength < 0) shieldStrength = 0;
        }

        public bool IsAlive() => shieldStrength > 0;

        public bool Move(string direction)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Out of fuel!");
                return false;
            }

            switch (direction.ToLower())
            {
                case "up":
                    Y++;
                    break;
                case "down":
                    Y--;
                    break;
                case "left":
                    X--;
                    break;
                case "right":
                    X++;
                    break;
                default:
                    Console.WriteLine("Invalid direction.");
                    return false;
            }

            fuel--;
            return true;
        }

        public void CollectResource(Resource resource)
        {
            if (cargoHold + resource.Amount <= cargoCapacity)
            {
                cargoHold += resource.Amount;
                Console.WriteLine($"Collected {resource.Amount} {resource.Type}.");
            }
            else
            {
                Console.WriteLine("Cargo hold full!");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Spaceship Position: ({X}, {Y})");
            Console.WriteLine($"Fuel: {fuel}");
            Console.WriteLine($"Shield Strength: {shieldStrength}");
            Console.WriteLine($"Cargo Hold: {cargoHold}/{cargoCapacity}");
        }
    }

    // Alien class
    class Alien : Entity
    {
        public string Name { get; private set; }
        public int AttackPower { get; private set; }

        public Alien(string name, int health, int attackPower)
            : base(health)
        {
            Name = name;
            AttackPower = attackPower;
        }

        public void Attack(Spaceship spaceship)
        {
            if (IsAlive())
            {
                Console.WriteLine($"{Name} attacks the spaceship!");
                spaceship.TakeDamage(AttackPower);
            }
        }
    }

    // Resource class
    class Resource
    {
        public string Type { get; private set; }
        public int Amount { get; private set; }

        public Resource(string type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }

    // Galaxy class
    class Galaxy
    {
        private readonly int width;
        private readonly int height;
        private readonly List<Alien>[,] alienMap;
        private readonly List<Resource>[,] resourceMap;

        public Galaxy(int width, int height)
        {
            this.width = width;
            this.height = height;
            alienMap = new List<Alien>[width, height];
            resourceMap = new List<Resource>[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    alienMap[i, j] = new List<Alien>();
                    resourceMap[i, j] = new List<Resource>();
                }
        }

        public void AddAlien(int x, int y, Alien alien)
        {
            if (IsInBounds(x, y))
                alienMap[x, y].Add(alien);
        }

        public void AddResource(int x, int y, Resource resource)
        {
            if (IsInBounds(x, y))
                resourceMap[x, y].Add(resource);
        }

        public List<Alien> GetAliensAt(int x, int y)
        {
            return IsInBounds(x, y) ? alienMap[x, y] : new List<Alien>();
        }

        public List<Resource> GetResourcesAt(int x, int y)
        {
            return IsInBounds(x, y) ? resourceMap[x, y] : new List<Resource>();
        }

        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }

    // Game class
    class Game
    {
        private readonly Galaxy galaxy;
        private readonly Spaceship spaceship;
        private readonly Random random = new Random();

        public Game()
        {
            galaxy = new Galaxy(10, 10);
            spaceship = new Spaceship(20, 100, 50, 0, 0);

            // Populate galaxy with aliens and resources
            InitializeGalaxy();
        }

        private void InitializeGalaxy()
        {
            // Aliens and resources
            galaxy.AddAlien(2, 2, new Alien("Martian", 30, 10));
            galaxy.AddAlien(3, 1, new Alien("Martian", 30, 10));
            galaxy.AddAlien(4, 5, new Alien("Zogarian", 50, 15));
            galaxy.AddAlien(0, 4, new Alien("Zogarian", 50, 15));
            galaxy.AddAlien(4, 0, new Alien("Zogarian", 50, 15));
            galaxy.AddAlien(4, 3, new Alien("Zogarian", 50, 15));
            galaxy.AddAlien(2, 3, new Alien("Space Pirate", 60, 20));
            galaxy.AddAlien(0, 1, new Alien("Space Pirate", 60, 20));
            galaxy.AddResource(1, 1, new Resource("Ancient Artifacts", 5));
            galaxy.AddResource(3, 3, new Resource("Space Minerals", 10));
            galaxy.AddResource(0, 2, new Resource("Space Minerals", 10));
            galaxy.AddResource(2, 0, new Resource("Space Minerals", 10));
            galaxy.AddResource(1, 2, new Resource("Ancient Artifacts", 5));
            galaxy.AddResource(4, 1, new Resource("Ancient Artifacts", 5));
            galaxy.AddResource(1, 4, new Resource("Ancient Artifacts", 5));

        }

        public void Run()
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                if (spaceship.getFuel() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You ran out of fuel! YOU LOSE.");
                    gameRunning = false;
                    break;
                }
                spaceship.DisplayStatus();
                Console.WriteLine("Enter a command (move <direction> (up, down, left, right), collect <resource>, or quit):");
                Console.WriteLine("You must reach Venus at 5, 5");
                string command = Console.ReadLine().ToLower();

                if (command.StartsWith("move "))
                {
                    string direction = command.Substring(5);
                    spaceship.Move(direction);
                }
                else if (command.StartsWith("collect "))
                {
                    string resourceType = command.Substring(8);
                    CollectResource(resourceType);
                }
                else if (command == "quit")
                {
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }
                if (spaceship.X == 5 && spaceship.Y == 5)
                {
                    Console.Clear();
                    Console.WriteLine("You reached Venus! YOU WIN.");
                    gameRunning = false;
                    break;
                }

                Console.Clear();

                // Handle encounters with aliens and resources
                gameRunning = HandleEncounters(gameRunning);
                HandleResources("space minerals");
                HandleResources("ancient artifacts");
            }
        }

        private void HandleResources(string resourceType)
        {
            var resources = galaxy.GetResourcesAt(spaceship.X, spaceship.Y);
            Resource resource = resources.Find(r => r.Type.ToLower() == resourceType);

            if (resource != null)
            {
                Console.WriteLine($"There is {resource.Amount} of {resource.Type}.");
            }
        }

        private void CollectResource(string resourceType)
        {
            var resources = galaxy.GetResourcesAt(spaceship.X, spaceship.Y);
            Resource resource = resources.Find(r => r.Type.ToLower() == resourceType);

            if (resource != null)
            {
                spaceship.CollectResource(resource);
                resources.Remove(resource);
            }
            else
            {
                Console.WriteLine("No such resource here.");
            }
        }

        private bool HandleEncounters(bool gameRunning)
        {
            var aliens = galaxy.GetAliensAt(spaceship.X, spaceship.Y);

            foreach (var alien in aliens)
            {
                if (alien.IsAlive())
                {
                    alien.Attack(spaceship);
                    alien.TakeDamage(100);
                    if (spaceship.IsAlive())
                    {
                        Console.WriteLine($"After a shootout, the spaceship took {alien.AttackPower} damage. The {alien.Name} spaceship was destroyed.\n");
                        gameRunning = true;
                    }
                    else
                    {
                        Console.WriteLine("After the shootout, the spaceship was destroyed. GAME OVER.\n");
                        gameRunning = false;
                    }
                }
            }
            return gameRunning;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}
