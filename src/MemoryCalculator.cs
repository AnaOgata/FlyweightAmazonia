using System;

namespace FlyweightAmazonia
{
    public static class MemoryCalculator
    {
        // TreeType - imutável
        private const int BytesEspecie = 32; 
        private const int BytesTextura = 8; 
        private const int BytesAlturaMedia = 4; 
        private const int BytesLarguraTroncoMedia = 4; 
        private const int BytesProjecaoMaxSombra = 4; 

        // Tree - mutável
        private const int BytesPosX = 8; 
        private const int BytesPosY = 8; 
        private const int BytesAltura = 4; 
        private const int BytesLarguraTronco = 4; 
        private const int BytesNumGalhos = 4; 
        private const int BytesRefTipo = 8; 

        public static readonly int BytesPorTreeType =
            BytesEspecie + BytesTextura + BytesAlturaMedia +
            BytesLarguraTroncoMedia + BytesProjecaoMaxSombra; // 52

        public static readonly int BytesPorTreeComFly =
            BytesPosX + BytesPosY + BytesAltura +
            BytesLarguraTronco + BytesNumGalhos + BytesRefTipo; // 36

        public static readonly int BytesPorTreeSemFly =
            BytesPorTreeComFly - BytesRefTipo +                        // sem ponteiro
            BytesEspecie + BytesTextura + BytesAlturaMedia +           // + dados imutáveis
            BytesLarguraTroncoMedia + BytesProjecaoMaxSombra;          // = 80

        public static long CustoComFlyweight(int totalArvores, int totalEspecies)
            => (long)totalArvores  * BytesPorTreeComFly
             + (long)totalEspecies * BytesPorTreeType;

        public static long CustoSemFlyweight(int totalArvores)
            => (long)totalArvores * BytesPorTreeSemFly;


        public static void ExibirRelatorio(int totalArvores, int totalEspecies)
        {
            long comFly  = CustoComFlyweight(totalArvores, totalEspecies);
            long semFly  = CustoSemFlyweight(totalArvores);
            long economia = semFly - comFly;
            double pct   = (double)economia / semFly * 100;

            Console.WriteLine();
            Console.WriteLine("RELATÓRIO DE MEMÓRIA — FLYWEIGHT");
            Console.WriteLine();

            Console.WriteLine("1. Parâmetros da simulação");
            Console.WriteLine($"- Árvores plantadas: {totalArvores:N0}");
            Console.WriteLine($"- Espécies únicas: {totalEspecies:N0}");
            Console.WriteLine();

            Console.WriteLine("2. Custo por objeto");
            Console.WriteLine($"- TreeType (imutável): {BytesPorTreeType} bytes (compartilhado por espécie)");
            Console.WriteLine($"- Tree c/ Flyweight: {BytesPorTreeComFly} bytes (só dados mutáveis)");
            Console.WriteLine($"- Tree s/ Flyweight: {BytesPorTreeSemFly} bytes (todos os dados)");
            Console.WriteLine();

            Console.WriteLine("3. Objetos criados");
            Console.WriteLine($"- Objetos mutáveis (Tree): {totalArvores:N0}");
            Console.WriteLine($"- Objetos imutáveis (TreeType): {totalEspecies:N0}");
            Console.WriteLine($"- Sem Flyweight (1 tipo/obj):  0  (dados embutidos)");
            Console.WriteLine();

            Console.WriteLine("4. Custo total de memória");
            Console.WriteLine($"- COM Flyweight: {FormatBytes(comFly)} ({comFly:N0} bytes)");
            Console.WriteLine($"- SEM Flyweight: {FormatBytes(semFly)} ({semFly:N0} bytes)");
            Console.WriteLine();

            Console.WriteLine("5. Resultado");
            Console.WriteLine($"- Economia: {FormatBytes(economia)} ({pct:F1}% menos)");
            Console.WriteLine($"- Fator de redução: {(double)semFly/comFly:F2}x menos memória com Flyweight");
            Console.WriteLine();
        }

        private static string FormatBytes(long bytes)
        {
            if (bytes >= 1_073_741_824) return $"{bytes / 1_073_741_824.0:F2} GB";
            if (bytes >= 1_048_576)     return $"{bytes / 1_048_576.0:F2} MB";
            if (bytes >= 1_024)         return $"{bytes / 1_024.0:F2} KB";
            return $"{bytes} B";
        }
    }
}
