namespace Provocare02A;

// Codul de pornire. Totul este public: oricine poate strica starea senzorului.
public class TemperatureSensor
{
  public string Id {get;}
  public double Value{get; private set;}              // ultima citire
  public double Min{get; private set;}                // pragul minim de alarmă
  public double Max{get; private set;}                // pragul maxim de alarmă
  private string Unit = "C";         // "C" sau "F"
  private readonly List<double> _history = new List<double>();
  public IReadOnlyList<double> History
  {
    get
    {
      return _history.AsReadOnly();
    }
  }
  public int ErrorCount{get;private set;}            // câte citiri invalide au sosit

  public bool IsAlarm()
  {
    return Value < Min || Value > Max;
  }
  public TemperatureSensor(string Id, double Min, Double Max)
  {
    if (string.IsNullOrWhiteSpace(Id))
    {
      throw new ArgumentException("Id-ul nu poate fi null");
    }
    this.Id=Id;

    if(Min>=Max)
    {
      throw new ArgumentException("Minimul nu poate sa fie mai mare decat maximul");
    }
    this.Min=Min;
    this.Max=Max;
  }
  public void AdaugaValoare(double? valoare)
  {
    if(valoare==null)
    {
      ErrorCount+=1;
      return;
    }
    double val = (double)valoare;
    if(double.IsNaN(val) || val<-273.15)
    {
      ErrorCount+=1;
      return;
    }
    this.Value=val;
    _history.Add(val);
  }
  public void ModificaPraguri(double Min, Double Max)
  {
    if(Min>=Max)
    {
      throw new ArgumentException("Minimul nu poate sa fie mai mare decat maximul");
    }
    this.Min=Min;
    this.Max=Max;
  }
  public double getTemperature(string unit = "C")
  {
    if(unit == "F" || unit=="f")
    {
      return Value * 1.8 + 32.0;
    }
    if(unit =="C" || unit=="c")
    {
      return Value;
    }
    throw new ArgumentException("Unitate invalida");
  }

}
