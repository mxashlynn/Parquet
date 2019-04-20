using Newtonsoft.Json;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Models the status of a stack of sandbox-mode parquets.
    /// </summary>
    public class ParquetStatus
    {
        /// <summary>The parquets whose statuses this instance is tracking.</summary>
        [JsonProperty(PropertyName = "in_thisStack")]
        private readonly ParquetStack _thisStack;

        /// <summary>The block's current toughness.</summary>
        [JsonIgnore]
        private int _toughness;

        /// <summary>
        /// The block's current toughness, from <see cref="Block.LowestPossibleToughness"/>
        /// to <see cref="Block.MaxToughness"/>.
        /// </summary>
        [JsonProperty(PropertyName = "in_toughness")]
        public int Toughness
        {
            get => _toughness;
            set => _toughness = value.Normalize(Block.LowestPossibleToughness, _thisStack.Block?.MaxToughness ?? Block.DefaultMaxToughness);
        }

        /// <summary>If the floor has been dug out.</summary>
        [JsonProperty(PropertyName = "in_isTrench")]
        public bool IsTrench { get; set; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStatus"/> class.
        /// </summary>
        /// <param name="in_thisStack">The parquets whose status this instance is tracking.</param>
        /// <param name="in_isTrench">Whether or not the <see cref="Floor"/> associated with this status has been dug out.</param>
        /// <param name="in_toughness">The toughness of the <see cref="Block"/> associated with this status.</param>
        [JsonConstructor]
        public ParquetStatus(ParquetStack in_thisStack, bool in_isTrench = false, int? in_toughness = null)
        {
            _thisStack = in_thisStack;
            IsTrench = in_isTrench;
            Toughness = in_toughness ?? in_thisStack.Block?.MaxToughness ?? Block.DefaultMaxToughness;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ParquetStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return $"{Toughness} toughness, {(IsTrench ? "dug out" : "filled in")}";
        }
        #endregion
    }
}
