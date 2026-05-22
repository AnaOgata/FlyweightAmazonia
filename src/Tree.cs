namespace FlyweightAmazonia
{
    public class Tree
    {
        public double PosX          { get; }
        public double PosY          { get; }
        public float  Altura        { get; }  
        public float  LarguraTronco { get; }   
        public int    NumGalhos     { get; }

        public TreeType Tipo { get; }

        public Tree(double posX, double posY,
                    float altura, float larguraTronco, int numGalhos,
                    TreeType tipo)
        {
            PosX          = posX;
            PosY          = posY;
            Altura        = altura;
            LarguraTronco = larguraTronco;
            NumGalhos     = numGalhos;
            Tipo          = tipo;
        }

        public void ImprimirInfo() =>
            Tipo.ImprimirInfo(PosX, PosY, Altura, LarguraTronco, NumGalhos);
    }
}