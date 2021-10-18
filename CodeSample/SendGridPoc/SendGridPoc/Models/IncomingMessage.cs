namespace SendGridPoc.Models
{
    public class IncomingMessage
    {
        /// <summary>
        /// The Domain Keys Identified Email code for the email
        /// </summary>
        public string Dkim { get; set; }

        /// <summary>
        /// The email address that the email was sent to
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The HTML body of the email
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// The email address the email was sent from
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The Text body of the email
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The Ip address of the sender of the email
        /// </summary>
        public string SenderIp { get; set; }

        /// <summary>
        /// A JSON string containing the SMTP envelope. This will have 2 variables: to, which is an array of recipients, and from, which is the return path for the message.
        /// </summary>
        public string Envelope { get; set; }

        /// <summary>
        /// Number of attachments included in email
        /// </summary>
        public int Attachments { get; set; }

        /// <summary>
        /// The subject of the email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// A JSON string containing the character sets of the fields extracted from the message.
        /// </summary>
        public string Charsets { get; set; }

        /// <summary>
        /// The results of the Sender Policy Framework verification of the message sender and receiving IP address.
        /// </summary>
        public string Spf { get; set; }
    }
}
