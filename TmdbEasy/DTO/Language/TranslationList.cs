using System.Collections.Generic;

namespace TmdbEasy.DTO.Language
{
    public class TranslationList
    {
        public int Id { get; set; }
        public List<Translation> Translations { get; set; }
    }
}
