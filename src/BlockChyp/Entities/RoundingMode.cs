// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.

namespace BlockChyp.Entities
{
    public enum RoundingMode
    {
        /// <summary>Round fractional pennies up.</summary>
        [EnumMember(Value = "up")]
        Up,

        /// <summary>Round fractional pennies to the nearest whole penny.</summary>
        [EnumMember(Value = "nearest")]
        Nearest,

        /// <summary>Round fractional pennies down.</summary>
        [EnumMember(Value = "down")]
        Down,
    }
}
