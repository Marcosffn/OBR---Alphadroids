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
    float sensorLuz1;
    float sensorLuz2;
    float sensorLuz3;
    float sensorLuz4;
    float sensorLuz5;
    float sensorLuz6;

    String sensorCor1;
    String sensorCor2;
    String sensorCor3;
    String sensorCor4;
    String sensorCor5;
    String sensorCor6;

    public void RealizarLeituras()
    {
        this.sensorLuz1 = bc.Lightness(0);
        this.sensorLuz2 = bc.Lightness(1);
        this.sensorLuz3 = bc.Lightness(2);
        this.sensorLuz4 = bc.Lightness(3);
        this.sensorLuz5 = bc.Lightness(4);
        this.sensorLuz6 = bc.Lightness(5);

        this.sensorCor1 = bc.ReturnColor(0);
        this.sensorCor2 = bc.ReturnColor(1);
        this.sensorCor3 = bc.ReturnColor(2);
        this.sensorCor4 = bc.ReturnColor(3);
        this.sensorCor5 = bc.ReturnColor(4);
        this.sensorCor6 = bc.ReturnColor(5);
    }

    public void PrintarLeituras(string tipo=null)
    {
        if (tipo == "Cor")
        {
            bc.PrintConsole(0, $"sensor 1: {this.sensorCor1}, sensor 2: {this.sensorCor2}");
            bc.PrintConsole(1, $"sensor 3: {this.sensorCor3}, sensor 4: {this.sensorCor4}");
            bc.PrintConsole(2, $"sensor 5: {this.sensorCor5}, sensor 6: {this.sensorCor6}");
        }
        else if (tipo == "Luz")
        {
            bc.PrintConsole(0, $"sensor 1: {this.sensorLuz1.ToString("00.00")}, sensor 2: {this.sensorLuz2.ToString("00.00")}");
            bc.PrintConsole(1, $"sensor 3: {this.sensorLuz3.ToString("00.00")}, sensor 4: {this.sensorLuz4.ToString("00.00")}");
            bc.PrintConsole(2, $"sensor 5: {this.sensorLuz5.ToString("00.00")}, sensor 6: {this.sensorLuz6.ToString("00.00")}");
        }
        else if (tipo == null)
        {
            bc.PrintConsole(0, $"sensor 1: {this.sensorLuz1.ToString("00.00")}, sensor 2: {this.sensorLuz2.ToString("00.00")}"
            + " -- " + $"sensor 1: {this.sensorCor1}, sensor 2: {this.sensorCor2}");
            bc.PrintConsole(1, $"sensor 3: {this.sensorLuz3.ToString("00.00")}, sensor 4: {this.sensorLuz4.ToString("00.00")}"
            + " -- " + $"sensor 3: {this.sensorCor3}, sensor 4: {this.sensorCor4}");
            bc.PrintConsole(2, $"sensor 5: {this.sensorLuz5.ToString("00.00")}, sensor 6: {this.sensorLuz6.ToString("00.00")}"
            + " -- " + $"sensor 5: {this.sensorCor5}, sensor 6: {this.sensorCor6}");
        }

    }
}
