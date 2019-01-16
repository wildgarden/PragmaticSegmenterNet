using System;

namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;

    public static class Segmenter
    {
        public static IReadOnlyList<string> Segment(string text, Operation operation, Language language = Language.English, DocumentType documentType = DocumentType.Any)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new string[0];
            }

            if (text.Length == 1)
            {
                return new [] { text };
            }

            var matchingLanguage = LanguageProvider.Get(language);

            if ((operation & Operation.Clean) == Operation.Clean)
            {
                text = Cleaner.Clean(text, matchingLanguage, documentType);
            }

            var result = Processor.Process(text, matchingLanguage);

            return result;
        }
    }

    [Flags]
    public enum Operation
    {
        None = 0,
        Segment = 1,
        Clean = 0x1 << 1,
        SegmentAndClean = Segment | Clean
    }
}