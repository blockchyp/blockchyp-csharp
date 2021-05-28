namespace BlockChyp.Entities
{
    public enum CvmType
    {
        /// <summary>Customer signature.</summary>
        Signature,

        /// <summary>PIN verified by the terminal.</summary>
        OfflinePin,

        /// <summary>PIN verified by the card issuer.</summary>
        OnlinePin,

        /// <summary>Consumer device verification.</summary>
        CdCvm,

        /// <summary>Customer verification was not required.</summary>
        NoCvm,
    }
}
