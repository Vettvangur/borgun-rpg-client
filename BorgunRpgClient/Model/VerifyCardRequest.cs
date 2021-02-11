namespace BorgunRpgClient.Model
{
    public class VerifyCardRequest
    {
        /// <summary>
        /// Amount of verify card request.
        /// Library handles adding 00 to amount where Borgun requires
        /// </summary>
        public int CheckAmount { get; set; }

        /// <summary>
        /// Currency of verify card request.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Used if provided.
        /// </summary>
        public string CVC { get; set; }
    }
}
