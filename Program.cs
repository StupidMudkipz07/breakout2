global using SFML.Graphics;
global using SFML.Audio;
global using SFML.System;
global using SFML.Window;

uint windowWidth = 1760;
uint windowHeight = 990;


RenderWindow window = new(new VideoMode(windowWidth, windowHeight), "Sloppa gibbaren");

window.SetFramerateLimit(60);

window.Closed += (sender, e) => window.Close();
//defines exit button and input debug
window.KeyPressed += (sender, e) =>
{
    //input debug
    Console.WriteLine("Key pressed " + e.Code);
    if (e.Code == Keyboard.Key.Escape)
    {
        window.Close();
    }
};

Paddle kirkigBåt = new();
Ball kirkigKött = new();

Clock clock = new Clock();
while (window.IsOpen)
{
    window.DispatchEvents();

    float deltaTime = clock.Restart().AsSeconds();

    // Console.WriteLine(deltaTime);
    window.Clear(Color.Black);
    kirkigBåt.Update(deltaTime);
    kirkigBåt.Draw(window);
    kirkigKött.Update(deltaTime);
    kirkigKött.Draw(window);

    window.Display();
}


