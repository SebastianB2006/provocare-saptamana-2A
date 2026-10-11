# Provocarea 02A - TemperatureSensor

Implementare defensivă și încapsulată a unei clase `TemperatureSensor` în C#

---

## Cerințe implementate

- **Identificator obligatoriu care nu se poate schimba:** Un senzor nu poate fi creat fără un ID nevid (`string.IsNullOrWhiteSpace`), iar `Id` este marcat ca `read-only` (`get;`) după instanțiere.
- **Validarea pragurilor de alarmă:** Constructorul verifică respectarea strictă a condiției `min < max`, aruncând `ArgumentException` în caz contrar.
- **Modificarea sigură a pragurilor:** Metoda `ModificaPraguri(double min, double max)` permite actualizarea pragurilor doar împreună și doar dacă noua pereche rămâne validă (`min < max`).
- **Validarea fizică a citirilor (`AdaugaValoare`):**
  - Respinge valorile `null`, `double.NaN` sau cele sub zero absolut -273.15 C, incrementând contorul `ErrorCount`.
  - Înregistrează citirile valide chiar dacă depășesc pragurile de alarmă (starea de alarmă fiind verificabilă separat prin `IsAlarm()`).
- **Încapsularea stării și a istoricului:**
  - `Value` și `ErrorCount` au `private set`, putând fi doar citite din exterior.
  - Istoricul intern `_history` este expus prin `IReadOnlyList<double>` (`History`), împiedicând alterarea colecției din afara clasei.
- **Conversie fără alterarea stării interne:**
  - Temperatura este stocată intern exclusiv în grade Celsius (`Unit = "C"`).
  - Metoda `getTemperature(string unit)` permite interogarea valorii în `"C"` sau `"F"`, fără a schimba datele salvate în obiect.
