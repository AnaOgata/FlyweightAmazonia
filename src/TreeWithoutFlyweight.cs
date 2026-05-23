// TreeWithoutFlyweight: modelo INGÊNUO sem o padrão.
// Cada instância carrega TODOS os dados (mutáveis + imutáveis).

using System;

namespace FlyweightAmazonia
{

    public class TreeWithoutFlyweight
    {
        // estado imutável — duplicado em cada instância
        public string Especie { get; set; } = "";
        public string Textura { get; set; } = "";
        public float  AlturaMedia { get; set; }
        public float  LarguraTroncoMedia { get; set; }
        public float  ProjecaoMaxSombra { get; set; }

        // estado mutável — único por árvore
        public double PosX { get; set; }
        public double PosY { get; set; }
        public float  Altura { get; set; }
        public float  LarguraTronco { get; set; }
        public int    NumGalhos { get; set; }

        public void ImprimirInfo()
        {
            Console.WriteLine(
                $"[{Especie}] pos=({PosX:F1},{PosY:F1}) " +
                $"alt={Altura:F1}m tronco={LarguraTronco:F1}cm galhos={NumGalhos} " +
                $"textura={Textura}");
        }
    }
}
