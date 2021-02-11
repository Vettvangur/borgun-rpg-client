using System;
using System.Collections.Generic;
using System.Text;

namespace BorgunRpgClient
{
    public static class Helpers
    {
        /// <summary>
        /// Useful to create OrderId for use in Borgun's systems
        /// </summary>
        /// <param name="recordNumber"></param>
        /// <returns></returns>
        public static string CreateRrnFromLong(long recordNumber)
        {
            var rrnStr = recordNumber.ToString();

            var trimmedStr = rrnStr.Substring(Math.Max(rrnStr.Length, 12) - 12);

            return trimmedStr.PadLeft(12, '0');
        }

        public static string FormatActionCode(string actionCode)
        {
            switch (actionCode)
            {
                case "000": return "Accepted";
                // 100-199	Show reason for transaction dismissal by issuer, card pick-up not required.
                case "100": return "Do not honor (Not accepted)";
                case "101": return "Expired card";
                case "102": return "Suspected card forgery (fraud)";
                case "103": return "Merchant call acquirer";
                case "104": return "Restricted card";
                case "106": return "Allowed PIN retries exceeded";
                case "109": return "Merchant not identified";
                case "110": return "Invalid amount";
                case "111": return "Invalid card number";
                case "112": return "PIN required";
                case "116": return "Not sufficient funds";
                case "117": return "Invalid PIN";
                case "118": return "Unknown card";
                case "119": return "Transaction not allowed to cardholder";
                case "120": return "Transaction not allowed to terminal";
                case "121": return "Exceeds limits to withdrawal";
                case "125": return "Card not valid";
                case "126": return "False PIN block";
                case "129": return "Suspected fraud";
                case "130": return "Invalid Track2";
                case "131": return "Invalid Expiration Date";
                case "161": return "DCC transaction not allowed to cardholder";
                case "162": return "DCC cardholder currency not supported";
                case "163": return "DCC exceeds time limit for withdrawal";
                case "164": return "DCC transaction not allowed to terminal";
                case "165": return "DCC not allowed to merchant";
                case "166": return "DCC unknown error";
                //200 - 299 Show reason for transaction dismissal by issuer, card pick-up required.
                case "200": return "No not honor";
                case "201": return "Card not valid";
                case "202": return "Suspected card forgery ";
                case "203": return "Merchant contact acquirer";
                case "204": return "Limited card";
                case "205": return "Merchant contact police";
                case "206": return "Allowed PIN";
                case "207": return "Special occasion";
                case "208": return "Lost card";
                case "209": return "Stolen card";
                case "210": return "Suspected fraud";
                case "902": return "False transaction";
                case "904": return "Form error";
                case "907": return "Issuer not responding";
                case "908": return "Message can not be routed";
                case "909": return "System error";
                case "910": return "Issuer did not respond";
                case "911": return "Issuer timed out";
                case "912": return "Issuer not reachable";
                case "913": return "Double transaction transmission";
                case "914": return "Original transaction can not be traced";
                case "916": return "Merchant not found";
                case "950": return "No financial record found for detail data";
                case "951": return "Batch already closed";
                case "952": return "Invalid batch number";
                case "953": return "Host timeout";
                case "954": return "Batch not closed";
                case "955": return "Merchant not active";
                case "956": return "Transaction number not unique";
                default: return "Unknown error";
            }
        }
    }
}
