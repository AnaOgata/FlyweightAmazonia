using System;
using System.Collections.Generic;

namespace FlyweightAmazonia
{
    public class TreeFactory
    {
        private readonly Dictionary<string, TreeType> _cache = new();

        public TreeType ObterTipo(
            string especie,
            string textura,
            float  alturaMedia,
            float  larguraTroncoMedia,
            float  projecaoMaxSombra)
        {
            if (!_cache.ContainsKey(especie))
            {
                _cache[especie] = new TreeType(
                    especie, textura, alturaMedia,
                    larguraTroncoMedia, projecaoMaxSombra);

                Console.WriteLine($"  [Factory] Novo TreeType criado: {especie}");
            }

            return _cache[especie];
        }

        public int TotalTipos => _cache.Count;

        public IEnumerable<string> Especies => _cache.Keys;
    }
}