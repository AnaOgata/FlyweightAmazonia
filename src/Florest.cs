namespace FlyweightAmazonia
{
    public class Forest
    {
        private readonly List<Tree>  _trees   = new();
        private readonly TreeFactory _factory = new();

        private static readonly Dictionary<string, (string tex, float alt, float larg, float proj)> _especieDados = new()
        {
            ["Castanheira"]    = ("casca-rugosa",   30f, 150f, 80f),
            ["Seringueira"]    = ("casca-lisa",      20f,  60f, 40f),
            ["Açaizeiro"]      = ("casca-fibrosa",   15f,  20f, 25f),
            ["Mogno"]          = ("casca-escamosa",  35f, 200f, 90f),
            ["Andiroba"]       = ("casca-grossa",    25f, 100f, 60f),
            ["Cedro"]          = ("casca-sulcada",   28f, 130f, 70f),
            ["Ipê-amarelo"]    = ("casca-cinza",     22f,  80f, 50f),
            ["Buriti"]         = ("casca-anelar",    18f,  40f, 35f),
            ["Guaraná"]        = ("casca-avermelhada",8f,  10f, 15f),
            ["Jatobá"]         = ("casca-parda",     30f, 160f, 75f),
        };

        public void PlantarArvore(
            double posX, double posY,
            string especie,
            float  altura, float larguraTronco, int numGalhos)
        {
            var (tex, alt, larg, proj) = _especieDados.TryGetValue(especie, out var d)
                ? d : ("casca-generica", 20f, 80f, 45f);

            var tipo  = _factory.ObterTipo(especie, tex, alt, larg, proj);
            var arvore = new Tree(posX, posY, altura, larguraTronco, numGalhos, tipo);
            _trees.Add(arvore);
        }

        public int TotalArvores  => _trees.Count;
        public int TotalEspecies => _factory.TotalTipos;

        public void RenderizarTodas()
        {
            foreach (var a in _trees)
                a.Renderizar();
        }

        public int GetTotalArvores()  => _trees.Count;
        public int GetTotalEspecies() => _factory.TotalTipos;
    }
}