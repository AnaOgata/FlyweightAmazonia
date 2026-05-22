namespace FlyweightAmazonia
{
    public class TreeType
    {
        public string Especie            { get; }
        public string Textura            { get; }   
        public float  AlturaMedia        { get; }   
        public float  LarguraTroncoMedia { get; }   
        public float  ProjecaoMaxSombra  { get; }   

        public TreeType(
            string especie,
            string textura,
            float  alturaMedia,
            float  larguraTroncoMedia,
            float  projecaoMaxSombra)
        {
            Especie             = especie;
            Textura             = textura;
            AlturaMedia         = alturaMedia;
            LarguraTroncoMedia  = larguraTroncoMedia;
            ProjecaoMaxSombra   = projecaoMaxSombra;
        }

        public void Renderizar(double x, double y, float alturaReal, float larguraReal, int galhos)
        {
            Console.WriteLine(
                $"[{Especie}] pos=({x:F1},{y:F1}) " +
                $"alt={alturaReal:F1}m tronco={larguraReal:F1}cm galhos={galhos} " +
                $"textura={Textura}");
        }

        public override string ToString() =>
            $"TreeType({Especie}, tex={Textura}, altMed={AlturaMedia}m)";
    }
}