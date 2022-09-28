// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.

namespace BlockChyp.Entities
{
    public enum CardType
    {
        /// <summary>A standard credit card.</summary>
        Credit,

        /// <summary>A debit card.</summary>
        Debit,

        /// <summary>An EBT card.</summary>
        EBT,

        /// <summary>A blockchain-based gift card.</summary>
        BlockchainGiftCard,

        /// <summary>An FSA/HSA card.</summary>
        Healthcare,
    }
}
