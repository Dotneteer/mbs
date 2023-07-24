using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Codebreaker.Client.Models {
    public class UpdateGameRequest : IParsable {
        /// <summary>The end property</summary>
        public bool? End { get; set; }
        /// <summary>The gameId property</summary>
        public Guid? GameId { get; set; }
        /// <summary>The gameType property</summary>
        public Codebreaker.Client.Models.GameType? GameType { get; set; }
        /// <summary>The guessPegs property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? GuessPegs { get; set; }
#nullable restore
#else
        public List<string> GuessPegs { get; set; }
#endif
        /// <summary>The moveNumber property</summary>
        public int? MoveNumber { get; set; }
        /// <summary>The playerName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PlayerName { get; set; }
#nullable restore
#else
        public string PlayerName { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static UpdateGameRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpdateGameRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"end", n => { End = n.GetBoolValue(); } },
                {"gameId", n => { GameId = n.GetGuidValue(); } },
                {"gameType", n => { GameType = n.GetEnumValue<GameType>(); } },
                {"guessPegs", n => { GuessPegs = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"moveNumber", n => { MoveNumber = n.GetIntValue(); } },
                {"playerName", n => { PlayerName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("end", End);
            writer.WriteGuidValue("gameId", GameId);
            writer.WriteEnumValue<GameType>("gameType", GameType);
            writer.WriteCollectionOfPrimitiveValues<string>("guessPegs", GuessPegs);
            writer.WriteIntValue("moveNumber", MoveNumber);
            writer.WriteStringValue("playerName", PlayerName);
        }
    }
}
