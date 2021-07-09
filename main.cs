void Main()
{
    Robo Robo = new Robo();
    while (true)
    {
        Robo.RealizarLeituras();
        Robo.PrintarLeituras();
        bc.MoveFrontal(100, 100);
    }
    

}

public class Robo
{
    float SensorLuz1;
    float SensorLuz2;
    float SensorLuz3;
    float SensorLuz4;
    float SensorLuz5;
    float SensorLuz6;

    String SensorCor1;
    String SensorCor2;
    String SensorCor3;
    String SensorCor4;
    String SensorCor5;
    String SensorCor6;

    public void RealizarLeituras()
    {
        this.SensorLuz1 = bc.Lightness(0);
        this.SensorLuz2 = bc.Lightness(1);
        this.SensorLuz3 = bc.Lightness(2);
        this.SensorLuz4 = bc.Lightness(3);
        this.SensorLuz5 = bc.Lightness(4);
        this.SensorLuz6 = bc.Lightness(5);

        this.SensorCor1 = bc.ReturnColor(0);
        this.SensorCor2 = bc.ReturnColor(1);
        this.SensorCor3 = bc.ReturnColor(2);
        this.SensorCor4 = bc.ReturnColor(3);
        this.SensorCor5 = bc.ReturnColor(4);
        this.SensorCor6 = bc.ReturnColor(5);
    }

    public void PrintarLeituras(string tipo=null)
    {
        if (tipo == "Cor")
        {
            bc.PrintConsole(0, $"Sensor 1: {this.SensorCor1}, Sensor 2: {this.SensorCor2}");
            bc.PrintConsole(1, $"Sensor 3: {this.SensorCor3}, Sensor 4: {this.SensorCor4}");
            bc.PrintConsole(2, $"Sensor 5: {this.SensorCor5}, Sensor 6: {this.SensorCor6}");
        }
        else if (tipo == "Luz")
        {
            bc.PrintConsole(0, $"Sensor 1: {this.SensorLuz1.ToString("00.00")}, Sensor 2: {this.SensorLuz2.ToString("00.00")}");
            bc.PrintConsole(1, $"Sensor 3: {this.SensorLuz3.ToString("00.00")}, Sensor 4: {this.SensorLuz4.ToString("00.00")}");
            bc.PrintConsole(2, $"Sensor 5: {this.SensorLuz5.ToString("00.00")}, Sensor 6: {this.SensorLuz6.ToString("00.00")}");
        }
        else if (tipo == null)
        {
            bc.PrintConsole(0, $"Sensor 1: {this.SensorLuz1.ToString("00.00")}, Sensor 2: {this.SensorLuz2.ToString("00.00")}"
            + " -- " + $"Sensor 1: {this.SensorCor1}, Sensor 2: {this.SensorCor2}");
            bc.PrintConsole(1, $"Sensor 3: {this.SensorLuz3.ToString("00.00")}, Sensor 4: {this.SensorLuz4.ToString("00.00")}"
            + " -- " + $"Sensor 3: {this.SensorCor3}, Sensor 4: {this.SensorCor4}");
            bc.PrintConsole(2, $"Sensor 5: {this.SensorLuz5.ToString("00.00")}, Sensor 6: {this.SensorLuz6.ToString("00.00")}"
            + " -- " + $"Sensor 5: {this.SensorCor5}, Sensor 6: {this.SensorCor6}");
        }

    }
}
