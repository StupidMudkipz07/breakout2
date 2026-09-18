global using SFML.Graphics;
global using SFML.Audio;
global using SFML.System;
global using SFML.Window;

//sloppar kommandot ta inte bort!!!!!
//LD_LIBRARY_PATH="$HOME/Documents/programming/breakout2/bin/Debug/net10.0/runtimes/debian-x64/native:$LD_LIBRARY_PATH" dotnet run
//viktigt för linux

//hemligt 🤫🤫1
BreakOutGame.HiddenSlop();
//Detta är enklare att testa utan

BreakOutGame.ChooseDifficulty();

RenderWindow window = new(new VideoMode((uint)BreakOutGame.windowWidth, (uint)BreakOutGame.windowHeight), "AdolfKirk out");
BreakOutGame gibb = new(window);


window.SetFramerateLimit((uint)BreakOutGame.MaxFps);

window.Closed += (sender, e) => window.Close();
//defines exit button and input debug
window.KeyPressed += (sender, e) =>
{
    //input debug
    Console.WriteLine("Key pressed " + e.Code);
};

Clock clock = new Clock();
while (window.IsOpen)
{
    window.DispatchEvents();
    window.Clear(Color.Black);

    float deltaTime = clock.Restart().AsSeconds();
    gibb.Update(deltaTime);
    gibb.DrawStuff();

    window.Display();
    if (gibb.DeadRun)
    {
        gibb = new(window);
    }

}

window.Dispose();