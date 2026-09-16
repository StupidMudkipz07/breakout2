global using SFML.Graphics;
global using SFML.Audio;
global using SFML.System;
global using SFML.Window;

//sloppar kommandot ta inte bort!!!!!
//LD_LIBRARY_PATH="$HOME/Documents/programming/breakout2/bin/Debug/net10.0/runtimes/debian-x64/native:$LD_LIBRARY_PATH" dotnet run
//viktigt för linux

RenderWindow window = new(new VideoMode(BreakOutGame.windowWidth, BreakOutGame.windowHeight), "Sloppa gibbaren");

window.SetFramerateLimit(600);

window.Closed += (sender, e) => window.Close();
//defines exit button and input debug
window.KeyPressed += (sender, e) =>
{
    //input debug
    Console.WriteLine("Key pressed " + e.Code);
};

BreakOutGame gibb = new(window);


Clock clock = new Clock();
while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear(Color.Black);

    float deltaTime = clock.Restart().AsSeconds();
    gibb.Update(deltaTime);
    gibb.DrawStuff();

    //detta kanske inte funkar
    if(gibb.health <= 0)
    {
        gibb = new(window);
    }
    window.Display();
}