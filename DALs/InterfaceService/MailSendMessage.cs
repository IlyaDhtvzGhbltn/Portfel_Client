using System.Net;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace Custodian.DALs.InterfaceService
{
    class MailSendMessage
    {
        string text { get; set; }
        string title { get; set; }
        string to { get; set; }
        string from { get; set; }
        string smtpAddress { get; set; }
        private string pass = "222222222";

        MailMessage mail { get; set; }

        public MailSendMessage(string text, string tema)
        {
            this.text = text;
            this.title = tema;
            this.from = "cgaaftechnical@gmail.com";
            this.to = "cgaaftechnical@gmail.com";
        }
        public MailSendMessage(string text, string tema, string to)
        {
            this.text = text;
            this.title = tema;
            this.from = "cgaaftechnical@gmail.com";
            this.to = to;
        }

        public void SendMessage()
        {
            using (mail = new MailMessage())
            {
                MailMessage message = new MailMessage(this.to, this.from);
                message.Body = this.text;;
                message.Subject = this.title;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = new NetworkCredential(this.from, pass);
                client.EnableSsl = true;
                client.Send(message);
            }
        }
        public void SendMessageClientMail()
        {
            using (mail = new MailMessage())
            {
                MailMessage message = new MailMessage(this.from, this.to);
                message.Body = this.text; ;
                message.Subject = this.title;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = new NetworkCredential(this.from, pass);
                client.EnableSsl = true;
                client.Send(message);
            }
        }
    }
    //public void SendEmailFromAccount()
    //{
    //    Outlook.Application application = new Outlook.Application();
    //    Outlook.MailItem newMail = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
    //    newMail.To = this.to;
    //    newMail.Subject = this.title;
    //    newMail.Body = this.text;
    //    Outlook.Account account = GetAccountForEmailAddress(application, smtpAddress);
    //    newMail.SendUsingAccount = account;
    //    newMail.Send();
    //}


    //public Outlook.Account GetAccountForEmailAddress(Outlook.Application application, string smtpAddress)
    //{
    //    Outlook.Accounts accounts = application.Session.Accounts;
    //    foreach (Outlook.Account account in accounts)
    //    {
    //        if (account.SmtpAddress == smtpAddress)
    //        {
    //            return account;
    //        }
    //    }
    //    throw new System.Exception(string.Format("No Account with SmtpAddress: {0} exists!", smtpAddress));
    //}
}

