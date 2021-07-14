void Main()
{
    Robo Robo = new Robo();
    while (true)
    {
        Robo.RealizarLeituras();
        Robo.PrintarLeituras();
        if(Robo.sensorCor2 == "VERDE")
        {
            Robo.Virar90(400, "D");
        }
        else if(Robo.sensorCor4 == "VERDE")
        {
            Robo.Virar90(400, "E");
        }else
        {
            Robo.SeguirLinhaLuz(125);
        }
    }
}

public class Robo
{
    public float sensorLuz1;
    public float sensorLuz2;
    public float sensorLuz3;
    public float sensorLuz4;
    public float sensorLuz5;
    public float sensorLuz6;

    public String  sensorCor1;
    public String sensorCor2;
    public String sensorCor3;
    public String sensorCor4;
    public String sensorCor5;
    public String sensorCor6;

    public void SeguirLinhaLuz(int forca)
    {
        if (sensorLuz1 >= 50 && sensorLuz5 >= 50)
        {
            bc.MoveFrontal(forca, forca);
        }
        else if (sensorLuz1 <= 50 && sensorLuz5 >= 50)
        {
            bc.MoveFrontal(-forca*10, forca*10);
        }
        else if (sensorLuz1 >= 50 && sensorLuz5 <= 50)
        {
            bc.MoveFrontal(forca*10, -forca*10);
        }
        else
        {
            bc.MoveFrontal(forca, forca);
        }
            
    }

    public void Virar90(int forca, string lado)
    {
        // Função para usar nas curvas de 90 com ou sem a fita verde
        MoverPorTempo(0.67, forca);

        if (lado == "E")
        {
            bc.MoveFrontalAngles(forca, -90);
        }
        else if (lado == "D")
        {
            bc.MoveFrontalAngles(forca, 90);
        }

    }
    public void MoverPorTempo(double tempo, int forca)
    {
        // Função para mover pelo tempo e força especificados
        bc.MoveFrontal(forca, forca);
        double ms = 1000;
        var t = ms * tempo;
        bc.Wait(System.Convert.ToInt32(t));
    }

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
            bc.PrintConsole(0, $"Sensor 1: {this.sensorCor1}, Sensor 2: {this.sensorCor2}");
            bc.PrintConsole(1, $"Sensor 3: {this.sensorCor3}, Sensor 4: {this.sensorCor4}");
            bc.PrintConsole(2, $"Sensor 5: {this.sensorCor5}, Sensor 6: {this.sensorCor6}");
        }
        else if (tipo == "Luz")
        {
            bc.PrintConsole(0, $"Sensor 1: {this.sensorLuz1.ToString("00.00")}, Sensor 2: {this.sensorLuz2.ToString("00.00")}");
            bc.PrintConsole(1, $"Sensor 3: {this.sensorLuz3.ToString("00.00")}, Sensor 4: {this.sensorLuz4.ToString("00.00")}");
            bc.PrintConsole(2, $"Sensor 5: {this.sensorLuz5.ToString("00.00")}, Sensor 6: {this.sensorLuz6.ToString("00.00")}");
        }
        else if (tipo == null)
        {
            bc.PrintConsole(0, $"Sensor 1: {this.sensorLuz1.ToString("00.00")}, Sensor 2: {this.sensorLuz2.ToString("00.00")}"
            + " -- " + $"Sensor 1: {this.sensorCor1}, Sensor 2: {this.sensorCor2}");
            bc.PrintConsole(1, $"Sensor 3: {this.sensorLuz3.ToString("00.00")}, Sensor 4: {this.sensorLuz4.ToString("00.00")}"
            + " -- " + $"Sensor 3: {this.sensorCor3}, Sensor 4: {this.sensorCor4}");
            bc.PrintConsole(2, $"Sensor 5: {this.sensorLuz5.ToString("00.00")}, Sensor 6: {this.sensorLuz6.ToString("00.00")}"
            + " -- " + $"Sensor 5: {this.sensorCor5}, Sensor 6: {this.sensorCor6}");
        }
    }
}