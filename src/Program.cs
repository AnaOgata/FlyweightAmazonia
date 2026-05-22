namespace FlyweightAmazonia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const int TOTAL_ARVORES = 10_000;
            const int TOTAL_ESPECIES = 50;

            var especiesBase = new[]
            {
                "Castanheira", "Seringueira", "Açaizeiro", "Mogno", "Andiroba",
                "Cedro", "Ipê-amarelo", "Buriti", "Guaraná", "Jatobá"
            };

            //para completar as 50 espécies (requisito do exc)
            var especies = especiesBase.ToList();
            for (int i = especies.Count + 1; i <= TOTAL_ESPECIES; i++)
                especies.Add($"Especie-{i:D2}");

            var rng = new Random(42);

            Console.WriteLine($"Plantando {TOTAL_ARVORES:N0} árvores de {TOTAL_ESPECIES} espécies...");
            Console.WriteLine();

            var floresta = new Forest();

            for (int i = 0; i < TOTAL_ARVORES; i++)
            {
                string esp = especies[rng.Next(especies.Count)];
                double x = rng.NextDouble() * 1000;
                double y = rng.NextDouble() * 1000;
                float altura = 5f + (float)(rng.NextDouble() * 30);
                float largura = 10f + (float)(rng.NextDouble() * 180);
                int galhos = rng.Next(20, 500);

                floresta.PlantarArvore(x, y, esp, altura, largura, galhos);
            }

            Console.WriteLine();
            Console.WriteLine($"Árvores plantadas: {floresta.TotalArvores:N0}");
            Console.WriteLine($"Espécies criadas: {floresta.TotalEspecies}");

            Console.WriteLine();
            Console.WriteLine("Amostra (5 primeiras árvores)");

            var florestaDemo = new Forest();
            string[] demo = { "Castanheira", "Mogno", "Açaizeiro", "Ipê-amarelo", "Seringueira" };
            float[] alts  = { 28f, 32f, 14f, 21f, 19f };
            for (int i = 0; i < 5; i++)
                florestaDemo.PlantarArvore(i * 10, i * 5, demo[i], alts[i], 80f + i * 20, 100 + i * 30);

            MemoryCalculator.ExibirRelatorio(
                totalArvores:  floresta.TotalArvores,
                totalEspecies: floresta.TotalEspecies);

            //simulação com escala da Amazônia real
            Console.WriteLine();
            Console.WriteLine("Escala real da Amazônia (aproximadamente 390 bilhões / 16.000 espécies)");
            long totalArvAmazon = 390_000_000_000L;
            long comFlyAmazon  = (long)(totalArvAmazon * MemoryCalculator.BytesPorTreeComFly)
                            + 16_000L * MemoryCalculator.BytesPorTreeType;
            long semFlyAmazon  = totalArvAmazon * MemoryCalculator.BytesPorTreeSemFly;
            Console.WriteLine($"COM Flyweight: {comFlyAmazon  / 1_073_741_824.0:F2} GB");
            Console.WriteLine($"SEM Flyweight: {semFlyAmazon  / 1_073_741_824.0:F2} GB");
            Console.WriteLine($"Economia: {(semFlyAmazon - comFlyAmazon) / 1_073_741_824.0:F2} GB");
        }
    }
}

