using Provocare02A;

// Fiecare "ATAC" de mai jos aduce senzorul într-o stare invalidă.
// După refactorizare, fiecare atac trebuie fie să NU mai compileze,
// fie să arunce o excepție clară la execuție.

TemperatureSensor s = new TemperatureSensor();
s.Id = "T-101";
s.Min = 10;
s.Max = 80;

s.Value = 25; s.History.Add(25);
s.Value = 30; s.History.Add(30);

// ATAC 1: praguri inversate
s.Min = 100;
s.Max = -20;

// ATAC 2: valoare imposibilă fizic (sub zero absolut)
s.Value = -500;

// ATAC 3: se schimbă unitatea, dar valorile rămân în °C
s.Unit = "F";

// ATAC 4: istoricul poate fi șters sau falsificat din exterior
s.History.Clear();
s.History.Add(9999);

// ATAC 5: erorile sunt ascunse
s.ErrorCount = 0;

// ATAC 6: senzorul își poate pierde identitatea
s.Id = "";

// ATAC 7: citirea este memorată, dar nu apare în istoric
s.Value = 50;

Console.WriteLine($"Senzor '{s.Id}': {s.Value} {s.Unit}, alarmă = {s.IsAlarm()}");
Console.WriteLine($"Istoric: {string.Join(", ", s.History)}, erori: {s.ErrorCount}");
