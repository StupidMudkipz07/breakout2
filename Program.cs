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
};


GameObjectHandler slopparGibbet = new(window);
Paddle paddlaren = new(slopparGibbet);
Ball boll = new(slopparGibbet);

Clock clock = new Clock();
while (window.IsOpen)
{
    window.DispatchEvents();

    float deltaTime = clock.Restart().AsSeconds();

    window.Clear(Color.Black);
    slopparGibbet.GibbGubb(deltaTime);

    window.Display();
}


