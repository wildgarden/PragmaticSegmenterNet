namespace PragmaticSegmenterNet.Tests.Unit
{
    using Xunit;

    public class SegmenterTests
    {
        [Fact]
        public void HandlesNull()
        {
            var result = Segmenter.Segment(null);

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesEmptyString()
        {
            var result = Segmenter.Segment(string.Empty);

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesNewLine()
        {
            var result = Segmenter.Segment("\n");

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesWhitespace()
        {
            var result = Segmenter.Segment("        ");

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesSimplestCase()
        {
            var result = Segmenter.Segment("Hello world. Hello.");

            Assert.Equal(new []
            {
                "Hello world.",
                "Hello."
            }, result);
        }
    }
}
