void Main()
{
    Robo Robo = new Robo();
    while (true)
    {
        Robo.RealizarLeituras();
        Robo.PrintarLeituras("Luz");
        Robo.run(135);
    }
}

public class Robo
{
    static int anguloBase = 10;
    public int anguloMaximo = (360 / anguloBase) - 1;
    public int multiplicador = 0;
    public float sensorLuz1;
    public float sensorLuz2;
    public float sensorLuz3;
    public float sensorLuz4;
    public float sensorLuz5;
    public float sensorLuz6;
    public float direcaoAngulo;
    public String  sensorCor1;
    public String sensorCor2;
    public String sensorCor3;
    public String sensorCor4;
    public String sensorCor5;
    public String sensorCor6;


    public void EncontrarLinha()
    {
        RealizarLeituras();
        if (sensorLuz2 <= 50 && sensorLuz3 >= 50)
        {
            bc.MoveFrontal(-1000, 1000);
        }
        else if (sensorLuz4 <= 50  && sensorLuz3 >= 50)
        {
            bc.MoveFrontal(1000, -1000);
        }
        else if (sensorLuz3 >= 50)
        {
            EncontrarLinha();
        }
    }


    public float MenorDif(float valor)
    {
        if (valor > 0 && valor < 90)
        {
            if (valor < 45)
            {
                return 0;
            }
            else
            {
                return 90;
            }
        }
        else if (valor > 90 && valor < 180)
        {
            float dif1 = System.Math.Abs(valor - 90);
            float dif2 = System.Math.Abs(valor - 180);
            if (System.Math.Min(dif1, dif2) == dif1)
            {
                return 90;
            }
            else
            {
                return 180;
            }
        }
        else if (valor > 180 && valor < 270)
        {
            float dif1 = System.Math.Abs(valor - 180);
            float dif2 = System.Math.Abs(valor - 270);
            if (System.Math.Min(dif1, dif2) == dif1)
            {
                return 180;
            }
            else
            {
                return 270;
            }
        }
        else if (valor > 270 && valor <= 359)
        {
            float dif1 = System.Math.Abs(valor - 270);
            float dif2 = System.Math.Abs(valor - 359);
            if (System.Math.Min(dif1, dif2) == dif1)
            {
                return 270;
            }
            else
            {
                return 360;
            }
        }
        else
        {
            return 0;
        }
    }


    public void CorrigirCurva90()
    {
        RealizarLeituras();
        GirarAteAngulo(System.Convert.ToInt32(MenorDif(direcaoAngulo)));
    }


    public void GirarAteAngulo(int anguloCerto)
    {
        var diferenca = System.Math.Abs(anguloCerto - bc.Compass());
        if (anguloCerto > bc.Compass())
        {
            if (diferenca <= 0.5)
            {
                bc.MoveFrontalAngles(1, System.Convert.ToSingle(System.Math.Round(diferenca)));
            }
            else
            {
                bc.MoveFrontalAngles(1000, System.Convert.ToSingle(System.Math.Round(diferenca)));
            }
        }
        else if (anguloCerto < bc.Compass())
        {
            if (diferenca <= 0.5)
            {
                bc.MoveFrontalAngles(1, System.Convert.ToSingle(System.Math.Round(-diferenca)));
            }
            else
            {
                bc.MoveFrontalAngles(1000, System.Convert.ToSingle(System.Math.Round(-diferenca)));
            }
        }
    }


    public void VirarDireita()
    {   
        Virar90(400, "D");
        CorrigirCurva90();
        multiplicador = System.Convert.ToInt32(System.Math.Round(bc.Compass())) / anguloBase;
    }


    public void VirarEsquerda()
    {
        Virar90(400, "E");
        CorrigirCurva90();
        multiplicador = System.Convert.ToInt32(System.Math.Round(bc.Compass())) / anguloBase;
    }


   public void run(int forca)
    {
        if(sensorCor2 == "VERDE")
        {
            MoverPorTempo(0.2, -200);
            EncontrarLinha();
            MoverPorTempo(0.2, 200);
            bc.MoveFrontalAngles(1000, 7);
            RealizarLeituras();
            if(sensorCor2 == "VERDE")
            {
                bc.MoveFrontalAngles(1000, -7);
                VirarDireita();
            }
            else
            {
                bc.MoveFrontalAngles(1000, -14);
                RealizarLeituras();
                if (sensorCor2 == "VERDE")
                {
                    bc.MoveFrontalAngles(1000, 14);
                    VirarDireita();
                }
                else
                {
                }
            }
           
        }
        else if(sensorCor4 == "VERDE")
        {
            MoverPorTempo(0.2, -200);
            EncontrarLinha();
            MoverPorTempo(0.2, 200);
            bc.MoveFrontalAngles(1000, -7);
            RealizarLeituras();
            if (sensorCor4 == "VERDE")
            {
                bc.MoveFrontalAngles(1000, 7);
                VirarEsquerda();
            }
            else
            {
                bc.MoveFrontalAngles(1000, 14);
                RealizarLeituras();
                if (sensorCor4 == "VERDE")
                {
                    bc.MoveFrontalAngles(1000, -14);
                    VirarEsquerda();
                }
                else
                {
                }
            }
        }
        else
        {
            SeguirLinhaLuz(forca);
        }
    }


    public void SeguirLinhaLuz(int forca)
    {
        if ((sensorLuz1 >= 50 && sensorLuz5 >= 50) || (sensorLuz1 <= 50 && sensorLuz5 <= 50))
        {
           if(direcaoAngulo <= (anguloBase*multiplicador) - 1 || direcaoAngulo >= (anguloBase*multiplicador) + 1)
            {
            AjustarAngulos(forca);
            }
            else
            {
            bc.MoveFrontal(forca, forca);
            }
        }
        else if (sensorLuz1 <= 50 && sensorLuz5 >= 50)
        {
            if (multiplicador >= anguloMaximo)
            {
                multiplicador = 0;
                AjustarAngulosRev(forca);
            }
            else
            {
                multiplicador++;
                AjustarAngulos(forca);
            }
        }
        else if (sensorLuz1 >= 50 && sensorLuz5 <= 50)
        {
            if (multiplicador <=0 )
            {
                multiplicador = anguloMaximo;
                AjustarAngulosRev(forca);
            }
            else
            {
                multiplicador--;
                AjustarAngulos(forca);
            }
        }
        else
        {
            bc.MoveFrontal(forca, forca);
        }            
    }


    public void AjustarAngulos(int forca)
    {
        forca = forca * 20;
        while(direcaoAngulo >= (anguloBase * multiplicador) + 1 || direcaoAngulo <= (anguloBase * multiplicador) - 1)
        {
            this.RealizarLeituras();
            this.PrintarLeituras("Luz");
            if (direcaoAngulo < (anguloBase * multiplicador) || direcaoAngulo > 359)
            {
                bc.MoveFrontal(-forca, forca);
            } 
            else if (direcaoAngulo > (anguloBase * multiplicador))
            {
                bc.MoveFrontal(forca, -forca);
            }
        }
    }


     public void AjustarAngulosRev(int forca)
    {
        forca = forca * 20;
        this.RealizarLeituras();
            bc.PrintConsole(0, $"Sensor angulo: {direcaoAngulo}, multiplicador: {multiplicador}");
            if(direcaoAngulo > (anguloBase*multiplicador))
            {
                bc.MoveFrontalAngles(forca, 15);
            } 
            else if(direcaoAngulo < (anguloBase * multiplicador))
            {
                bc.MoveFrontalAngles(forca, -15);
            }
    }


    public void Virar90(int forca, string lado)
    {
        // Função para usar nas curvas de 90 com ou sem a fita verde
        MoverPorTempo(0.49, forca);

        if (lado == "E")
        {
            bc.MoveFrontalAngles(forca, -80);
        }
        else if (lado == "D")
        {
            bc.MoveFrontalAngles(forca, 80);
        }
        MoverPorTempo(0.20, -forca);
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

        this.direcaoAngulo = bc.Compass();
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
            bc.PrintConsole(0, $"Sensor angulo: {this.direcaoAngulo}, multiplicador: {this.multiplicador}, Angulo Ideal {this.multiplicador * anguloBase}");
            bc.PrintConsole(1, $"Sensor 1: {this.sensorLuz1.ToString("00.00")}, Sensor 2: {this.sensorLuz2.ToString("00.00")}, Sensor 3: {this.sensorLuz3.ToString("00.00")}");
            bc.PrintConsole(2, $"Sensor 4: {this.sensorLuz4.ToString("00.00")}, Sensor 5: {this.sensorLuz5.ToString("00.00")}, Sensor 6: {this.sensorLuz6.ToString("00.00")}");
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