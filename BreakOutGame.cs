class BreakOutGame
{
    //state that doesnt change between tries
    static public int MaxFps = 600;
    static public int windowWidth = 1920;
    static public int windowHeight = 1080;
    static Difficulty dif;

    public static void ChooseDifficulty()
    {
        Difficulty starkeAdolf = new Difficulty
        {
            playWidth = 1300,
            playHeight = 1000,

            tileWidth = 50,
            amountOfRows = 30,
            rows = 8,

            paddleMoveSpeed = 300,
            ballMoveSpeed = 500,

            health = 1,

            BlockDistraction = true,
            BreakableBlockDistraction = true,
            BreakableBlockDistractionSlop = true,
            SoundDistractions = true
        };
        
        Difficulty hard = new Difficulty
        {
            playWidth = 1000,
            playHeight = 1050,

            tileWidth = 80,
            amountOfRows = 8,
            rows = 6,

            paddleMoveSpeed = 350,
            ballMoveSpeed = 450,

            health = 3,

            BlockDistraction = true,
            BreakableBlockDistraction = true,
            BreakableBlockDistractionSlop = true,
            SoundDistractions = true
        };

        Difficulty easy = new Difficulty
        {
            playWidth = 800,
            playHeight = 900,

            tileWidth = 100,
            amountOfRows = 4,
            rows = 4,

            paddleMoveSpeed = 550,
            ballMoveSpeed = 300,

            health = 6,

            BlockDistraction = false,
            BreakableBlockDistraction = false,  
            BreakableBlockDistractionSlop = false,
            SoundDistractions = false,
        };

   Difficulty medium = new Difficulty
        {
            playWidth = 970,
            playHeight = 1020,

            tileWidth = 100,
            amountOfRows = 5,
            rows = 5,

            paddleMoveSpeed = 450,
            ballMoveSpeed = 350,

            health = 4,

            BlockDistraction = true,
            BreakableBlockDistraction = false,  
            BreakableBlockDistractionSlop = false,
            SoundDistractions = false,
        };


        //dif = hard;
        //dif = starkeAdolf;
        dif = easy;
        //dif = medium;
    }

    int playWidth;
    int playHeight;

    int tileWidth;
    int amountOfRows;
    int rows;

    int paddleMoveSpeed;
    int ballMoveSpeed;

    int health;

    bool BlockDistraction;
    bool BreakableBlockDistraction;
    bool BreakableBlockDistractionSlop;
    bool SoundDistractions;

    int points = 0;
    public bool DeadRun = false;
    uint textSize = 45;
    GameObjectHandler handler;
    Ball boll;
    Paddle paddel;
    Text Gui;
    Block[] boundaries = new Block[4];
    List<BreakableBlock> tiles = new();
    public RenderWindow denLustigaSkärmen;

    void BallEvent()
    {
        health--;
        boll.Reset();
    }

    void ApplyDifficulty()
    {
        playWidth = dif.playWidth;
        playHeight = dif.playHeight;
        tileWidth = dif.tileWidth;
        amountOfRows = dif.amountOfRows;
        rows = dif.rows;
        paddleMoveSpeed = dif.paddleMoveSpeed;
        ballMoveSpeed = dif.ballMoveSpeed;
        health = dif.health;
        BlockDistraction = dif.BlockDistraction;
        BreakableBlockDistraction = dif.BreakableBlockDistraction;
        BreakableBlockDistractionSlop = dif.BreakableBlockDistractionSlop;
        SoundDistractions = dif.SoundDistractions;
    }

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;

        ApplyDifficulty();
        InitilizeAudioSlop();

        handler = new();
        paddel = new(windowHeight - 140, paddleMoveSpeed, handler);

        boll = new(new(windowWidth / 2, playHeight / 2), paddel, ballMoveSpeed, handler);

        //när bollen når utanför skärmen så kallas detta event
        boll.BallLeftScreen += (_, _) => { BallEvent(); };

        MakeBoundaries();

        MakeTiles(tileWidth, amountOfRows, rows);

        Gui = new Text
        {
            CharacterSize = textSize,
            Font = new Font("assets/future.ttf")
        };
    }

    void MakeTiles(int tileWidth, int amountPerRow, int rows)
    {
        //math
        int amountOfTilesPerColumn = amountPerRow;
        int GapBetweenTiles = (playWidth - amountOfTilesPerColumn * tileWidth) / (amountOfTilesPerColumn + 1);

        int tileHeight = tileWidth / 2;
        int gapBetweenRows = ((playHeight / 2) - rows * tileHeight) / (rows + 1);


        Vector2f playSpaceOrigin = new((windowWidth - playWidth) / 2, windowHeight - playHeight);

        for (int i = 0; i < rows; i++)
        {
            //generate tiles for each column
            for (int j = 0; j < amountOfTilesPerColumn; j++)
            { //
                Vector2f positon = new(playSpaceOrigin.X + (j * tileWidth) + (GapBetweenTiles * (j + 1)), playSpaceOrigin.Y + (i * tileHeight) + (gapBetweenRows * (i + 1)));
                Vector2f tileSize = new(tileWidth, tileHeight);
                string color = "";
                switch (i % 3)
                {
                    case 0:
                        color += "Pink";
                        break;
                    case 1:
                        color += "Green";
                        break;
                    case 2:
                        color += "Blue";
                        break;
                }
                MakeBreakableBlock(positon, tileSize, color);
            }
        }
    }

    void MakeBoundaries()
    {
        //math
        int mcnuttWidth = (windowWidth - playWidth) / 2;
        int mcnuttHeight = windowHeight - playHeight;

        if (BlockDistraction)
        {
            boundaries[0] = MakeBlock(new(0, 0), new(mcnuttWidth, windowHeight), "assets/mcnutt.png");
            boundaries[1] = MakeBlock(new(windowWidth - mcnuttWidth, 0), new(mcnuttWidth, windowHeight), "assets/binding.png");
            boundaries[2] = MakeBlock(new(mcnuttWidth, 0), new(windowWidth - (mcnuttWidth * 2), mcnuttHeight), "assets/math.png");
        }
        else
        {
            boundaries[0] = MakeBlock(new(0, 0), new(mcnuttWidth, windowHeight), "assets/tileBlue.png");
            boundaries[1] = MakeBlock(new(windowWidth - mcnuttWidth, 0), new(mcnuttWidth, windowHeight), "assets/tileGreen.png");
            boundaries[2] = MakeBlock(new(mcnuttWidth, 0), new(windowWidth - (mcnuttWidth * 2), mcnuttHeight), "assets/tilePink.png");
        }
        //boundaries[3] = MakeBlock(new(mcnuttWidth, windowHeight - 40), new(windowWidth - (mcnuttWidth * 2), 40));
    }

    Vector2f OriginOffset(Vector2f desiredPos, Vector2f size) => desiredPos + (size / 2);

    Block MakeBlock(Vector2f pos, Vector2f size, string sprite)
    {
        Block båt = new(size, OriginOffset(pos, size), sprite, handler);
        if (BlockDistraction) båt.roligaGrejerAttGöra += båt.ChangeSpriteOnCooldown;
        return båt;
    }

    BreakableBlock MakeBreakableBlock(Vector2f pos, Vector2f size, string color)
    {
        BreakableBlock båt = new(size, OriginOffset(pos, size), color, handler);
        tiles.Add(båt);
        båt.BlockBreaked += (_, _) =>
        {
            points++;
            //om inte den här finns så finns den fortfarande kvar i tileslistan och då resettas inte tilesen 
            tiles.Remove(båt);

            //play random sound
            PlayRandomSound();
            if (BreakableBlockDistractionSlop) båt.SpawnSlopWindow();
        };

        if (BreakableBlockDistraction) båt.roligaGrejerAttGöra += båt.ChangeSpriteOnCooldown;
        return båt;
    }

    void CheckTiles()
    {
        if (tiles.Count == 0)
        {
            MakeTiles(tileWidth, amountOfRows, rows);
        }
    }

    public void Update(float deltaTime)
    {
        handler.GibbGubb(deltaTime);
        CheckTiles();
        if (health <= 0) DeadRun = true;
        //boll.speed = (float)(ballMoveSpeed * 1.01 *  points);
    }

    public void DrawStuff()
    {
        handler.Draw(denLustigaSkärmen);

        Gui.DisplayedString = $"Score: {points}";
        Gui.Position = new Vector2f(12, 8);
        denLustigaSkärmen.Draw(Gui);

        Gui.DisplayedString = $"Health: {health}";
        Gui.Position = new Vector2f(windowWidth - 300, 8);
        denLustigaSkärmen.Draw(Gui);
    }

    //hemligt
    static public void HiddenSlop()
    {
        int wait = 150;
        // slop dialogue
        Console.WriteLine("Hej kära spelare"); Console.ReadKey();
        Console.WriteLine("Jag är spelledaren av detta spel"); Console.ReadKey();
        Console.WriteLine("Jag har gjort spel i många år nu"); Thread.Sleep(wait);
        Console.WriteLine("Jag har även vunnit SM långfinger dragkamp"); Thread.Sleep(wait);
        Console.WriteLine("Och vet du vad?"); Thread.Sleep(wait);
        Console.WriteLine("Jag har även skapat en 1:1 kopia av Darth Vader av snorkråkor och öronvax i mitt gara..."); Thread.Sleep(300);
        Console.WriteLine("juste"); Thread.Sleep(wait);
        Console.WriteLine("Det är inte jag som är huvudpersonen av denna berättelse"); Thread.Sleep(wait);
        Console.WriteLine("Det är du som är den viktiga nu!"); Thread.Sleep(wait);
        Console.WriteLine("Vad är ditt namn?"); Thread.Sleep(wait);
        Console.Write("Skriv ditt namn här:"); Console.ReadLine();
        Console.WriteLine("Äsch strunta i det där"); Console.ReadKey();
        Console.WriteLine("Nu spelar vi Adolf Kirk OUT!!!!!11"); Console.ReadKey();
    }

    public static int GetIntFromConsole()
    {
        int output;
        while (!int.TryParse(Console.ReadLine(), out output))
        {
            Console.WriteLine("input is not a integer");
        }
        return output;
    }

    public static int GetIntFromConsole(int minValue, int maxValue)
    {
        int output;
        while (1 == 1)
        {
            if (!int.TryParse(Console.ReadLine(), out output)) Console.WriteLine("input is not a integer");
            else
            {
                if (output > maxValue)
                {
                    Console.WriteLine("input is too big");
                }
                else if (output < minValue)
                {
                    Console.WriteLine("input is too small");
                }
                else return output;
            }
        }
    }

    public static string ListToString(List<Difficulty> list)
    {
        string output = "";
        for (int i = 0; i < list.Count; i++)
        {
            output += "\n   " + (i + 1) + ": " + list[i].name;
        }
        if (output == "") return "empty list";
        else return output;
    }

                                       
    Dictionary<string, Sound> sounds = new(StringComparer.OrdinalIgnoreCase); 
    //                                                   ☝️skiter i stor eller liten bokstav

    void InitilizeAudioSlop()
    {
        //får alla wav filer i assets och sparar de i en dictionary
        foreach (string filePath in Directory.EnumerateFiles("assets", "*.wav"))
        {
            //så skönt att inte behöva skriva .wav
            string name = Path.GetFileNameWithoutExtension(filePath);
            var buffer = new SoundBuffer(filePath);
            sounds[name] = new Sound(buffer);
        }
    }

    //gets the soundName value from the sounds dictionary then plays
    void PlaySound(string soundName)
    {
        //if it gets a string that doesnt exist it doesnt crash😂😂
        if (sounds.TryGetValue( soundName, out Sound sound))
        {
            sound.Play();
        }
    }

    void PlayRandomSound()
    {
        if (sounds.Count == 0)
            return;

        string[] names = sounds.Keys.ToArray();
        string randomName = names[new Random().Next(names.Length)];

        if (!SoundDistractions) randomName = "vine-boom";


        PlaySound(randomName);
    }

}