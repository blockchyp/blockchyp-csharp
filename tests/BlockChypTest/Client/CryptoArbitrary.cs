using BlockChyp.Client;
using FsCheck;

namespace BlockChypTest.Client
{
    public sealed class NonceLength
    {
        public int Get { get; }

        public NonceLength(int len)
        {
            Get = len;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.GetType().Name, Get);
        }
    }

    public sealed class Nonce
    {
        public string Get { get; }

        public Nonce(string nonce)
        {
            Get = nonce;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.GetType().Name, Get);
        }
    }

    public class CryptoArbitrary
    {
        public static Arbitrary<NonceLength> NonceLength() =>
            Arb.Default.PositiveInt()
                .Generator
                .Where(len => len.Get >= 16)
                .Select(len => new NonceLength(len.Get))
                .ToArbitrary();

        public static Arbitrary<Nonce> Nonce() =>
            NonceLength()
                .Generator
                .Select(nonceLen => new Nonce(Crypto.GenerateNonce(nonceLen.Get)))
                .ToArbitrary();
    }
}
