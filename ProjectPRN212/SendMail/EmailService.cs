using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using ProjectPRN212.CartModels;
using ProjectPRN212.Models;

namespace ProjectPRN212.SendMail
{
    public static class EmailService
    {


        public static void SendEmailPassNew(string toEmail, string subject, string body, string randomPassword)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("ProjectPRN212", "tungpshe176293@fpt.edu.vn"));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = body + " Your new password is: " + randomPassword };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("tungpshe176293@fpt.edu.vn", "wwga ejmr thqa ielb");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
        public static void SendEmailWithOrderDetails(string toEmail, Models.Order order, List<CartItems> cartItems)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("ProjectPRN212", "tungpshe176293@fpt.edu.vn"));

                // Ensure toEmail is not null or empty
                if (string.IsNullOrEmpty(toEmail))
                {
                    throw new ArgumentException("Recipient email address cannot be null or empty.");
                }

                emailMessage.To.Add(new MailboxAddress("", toEmail));
                emailMessage.Subject = "Your Order Details";

                var builder = new BodyBuilder();
                builder.TextBody = $"Chào bạn : {toEmail},\n\n";
                builder.TextBody += $"Cảm ơn bạn đã đặt hàng ! \n";
                builder.TextBody += $"Order ngày : {order.OrderDate}\n";
                builder.TextBody += $"Tổng đơn hàng : {order.TotalCost}\n\n";


                builder.TextBody += "Order Details:\n";

                foreach (var item in cartItems)
                {
                    builder.TextBody += $"Product: {item.ProductName}\n";
                    builder.TextBody += $"Quantity: {item.Quantity}\n";
                    builder.TextBody += $"Price per unit: {item.SalePrice}\n";
                    builder.TextBody += $"Total Price: {item.Quantity * item.SalePrice}\n\n";
                }

                emailMessage.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("tungpshe176293@fpt.edu.vn", "wwga ejmr thqa ielb");

                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }
            catch (SmtpCommandException smtpEx)
            {
                // Log the SMTP exception details
                Console.WriteLine($"SMTP Error Code: {smtpEx.ErrorCode}");
                Console.WriteLine($"SMTP Response: {smtpEx.Message}");
                Console.WriteLine($"Inner Exception: {smtpEx.InnerException?.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }


    }
}
