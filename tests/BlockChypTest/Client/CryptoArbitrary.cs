using System.Security.Cryptography;
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

    public sealed class AesKey
    {
        public byte[] Get { get; }

        public AesKey(byte[] key)
        {
            Get = key;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} {1}",
                this.GetType().Name,
                System.BitConverter.ToString(Get).Replace("-", string.Empty)
            );
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

        public static Arbitrary<AesKey> AesKey()
        {
            using (Aes aes = Aes.Create())
            {
                const int BITS_PER_BYTE = 8;
                int[] keySizes = new int[] {
                    (aes.LegalKeySizes[0].MinSize / BITS_PER_BYTE),
                    (aes.LegalKeySizes[0].MaxSize / BITS_PER_BYTE)
                };
                return (from len in Gen.Elements<int>(keySizes)
                        from ba in Gen.ArrayOf<byte>(len, Arb.Generate<byte>())
                        select new AesKey(ba)
                        ).ToArbitrary();
            }
        }
    }
}
