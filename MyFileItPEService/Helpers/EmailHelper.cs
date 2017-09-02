using MyFileItDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace MyFileItPEService.Helpers
{
    public class EmailHelper
    {
        public static string MyFileItEmailLink = "<a href=\"mailto:support@myfileit.com\">support@myfileit.com</a>";
        public static string ViewDocumentLink = ConfigurationSettings.ViewDocumentUrl;

        public static bool SendForgotPassword(APPUSER userObj)
        {
            var subject = "MyFileIT Forgotten Password";
            string error = "";
            return EmailHelper.SendEmailAsync(userObj.EMAILADDRESS, new List<string>(), new List<string>(), subject, CreateForgottenPasswordEmail(userObj), true, new List<string>(), ref error);
        }

        private static string CreateForgottenPasswordEmail(APPUSER userObj)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine(userObj.FIRSTNAME + " " + userObj.LASTNAME + ", you forgot your password. It is " + userObj.PASSWORD);
            return result.ToString();
        }

        public static bool SendInvitationEmail(string emailAddress, string message)
        {
            var subject = "MyFileIT Invitation to Share Documents";
            if (message.Length == 0)
            {
                message = GetInviteToShareEmailMessage();
            }
            string error = "";
            return EmailHelper.SendEmailAsync(emailAddress, new List<string>(), new List<string>(), subject, message, true, new List<string>(), ref error);
        }

        public static string GetInviteToShareEmailMessage()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            result.AppendLine("I would like you to join MyFile-IT and create an account. There is no cost for joining MyFile-IT. If you want to share your important documents there is a small cost annual user charge. Go to your App store and search for 'Myfileit'.");
            //result.AppendLine("I would like you to join MyFile-It and create an user account so I can share my documents.");
            //result.AppendLine("There is no cost to joining MyFile-It, unless you decide to share your own documents. At that point there will be a small cost per user per year. Click on this link to get started.");
            //result.AppendLine("It only takes a minute or so.");
            return result.ToString();
        }

        public static bool SendDocumentAssociatedEmail(List<string> emails, SHAREDOCUMENT newShare)
        {
            var subject = "MyFileIT member " + newShare.APPUSER.FIRSTNAME + " " + newShare.APPUSER.LASTNAME + " has associated a document to " + newShare.TEAMEVENT.NAME;

            var message = GetDocumentAssociatedEmailMessage(newShare);

            string error = "";
            return EmailHelper.SendEmailAsync(emails.First(), emails, new List<string>(), subject, message, true, new List<string>(), ref error);
        }

        public static string GetDocumentAssociatedEmailMessage(SHAREDOCUMENT newShare)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            result.AppendLine("<h2>New Document Associated to Event</h2>");
            result.AppendLine("<h3>" + newShare.TEAMEVENT.ORGANIZATION.NAME + "</h3>");
            result.AppendLine("<h3>" + newShare.TEAMEVENT.NAME + "</h3>");
            result.AppendLine("<p>MyFileIT member " + newShare.APPUSER.FIRSTNAME + " " + newShare.APPUSER.LASTNAME + " has associated a document to " + newShare.TEAMEVENT.NAME + "</p>");
            if (newShare.COMMENT.Length > 0)
            {
                result.AppendLine("<h3>Additional comments</p>");
                result.AppendLine("<p>" + newShare.COMMENT.ToString() + "</p>");
            }

            result.AppendLine("<p>Please log in to your MyFileIT application and verify that the document is correct.</p>");

            result.AppendLine("<p>Thank You");
            result.AppendLine("<br/>MyFileIt Team");
            result.AppendLine("<br/>" + MyFileItEmailLink + "</p>");

            return result.ToString();
        }

        public static bool SendSignUpEmail(APPUSER userObj, bool isPlayerUser, bool autoSignUp, string organizationName)
        {
            var subject = "Thank you for signing up for MyFileIT";

            var message = GetSignUpMessage(userObj, isPlayerUser, autoSignUp, organizationName);

            string error = "";
            return EmailHelper.SendEmailAsync(userObj.EMAILADDRESS, new List<string>(), new List<string>(), subject, message, true, new List<string>(), ref error);
        }

        private static string GetSignUpMessage(APPUSER userObj, bool isPlayerUser, bool autoSignUp, string organizationName)
        {
            var result = new System.Text.StringBuilder();
            //result.AppendLine("Dear " + userObj.FIRSTNAME + " " + userObj.LASTNAME);
            //result.AppendLine("<p>Thank you for joining the MyFileIt service! You can now enjoy all the benefits of sharing your documents quickly and easily.</p>");

            if (isPlayerUser)
            {
                result.AppendLine("<p>Thank you for registering.</p>");
            }
            else
            {
                if (autoSignUp)
                {
                    result.AppendLine("<p>You have been registered for MyFile-IT by " + organizationName + "</p>");
                }
                else
                {
                    result.AppendLine("<p>You have been registered for MyFileIT.</p>");
                }
                result.AppendLine("<p>Please click the link to login to your account.</p>");
                result.AppendLine("<p>Your username is: " + userObj.USERNAME + "</p>");
                result.AppendLine("<p>Your password is: " + userObj.PASSWORD + "</p>");
                result.AppendLine("<p>Go to your app store (Apple,Antroid,Windows) and search for “Myfileit” and download and install it.</p>");
                result.AppendLine("<p>My FileIT Website</p>");
                result.AppendLine("<p><a href=\"http://myfileit.com\" >www.myfileit.com</a></p>");
            }
            result.AppendLine("<p>Myfile is powerful tool that allows 24/7/365 access in case of an emergency to you or your children’s important documents. Like Medical forms, membership info, Birth certificates, and permissions forms. These documents can be easily share if necessary.</p>");

            result.AppendLine("<p>Thank You");
            result.AppendLine("<br/>MyFileIt Team");
            result.AppendLine("<br/>" + MyFileItEmailLink + "</p>");

            return result.ToString();
        }

        public static bool SendCoachSignUpEmail(ORGANIZATION organization, COACH coach)
        {
            var subject = "Thank you for signing up for MyFileIT";

            var message = GetCoachSignUpEmail(organization, coach);

            string error = "";
            return EmailHelper.SendEmailAsync(coach.EMAILADDRESS, new List<string>(), new List<string>(), subject, message, true, new List<string>(), ref error);
        }

        private static string GetCoachSignUpEmail(ORGANIZATION organization, COACH coach)
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("<p>Dear " + coach.FIRSTNAME + " " + coach.LASTNAME + ",</p>");
            result.AppendLine("<p>" + organization.NAME + " has signed up to be in MyFileIT network and allow coaches/staff and parents to use the MyFileIT mobile app which allows the user the ability to take pictures of important documents like physical form, code conduct, birth certificates, permission slips and other required documents to participate in organization’s activities and securely upload them and share them with you. There is no cost to you to participate as a coach or staff member. </p>");
            result.AppendLine("<p>Click here to register and create a coach / staff profile.</p> ");
            result.AppendLine("<p>Http://b,fdsfdjkfdjkljsfdlkfdjlfdjdflgjldgjldsgjlsdjgsdfl;</p>");
            result.AppendLine("<p>If you do not register no user will be able to share their documents with you.  In addition using MyFileIT makes it much easier and more efficient in handling paperwork  as well as giving you 24/7/365 access to your students important documents and being able to share the documents with any emergency staff with MyFileIT network and outside. Please send up now.</p>");

            result.AppendLine("<p>Thanks</br>");
            result.AppendLine(organization.DIRECTORNAME + "</p>");


            return result.ToString();
        }

        public static bool SendChangeAccountEmail(APPUSER appUser)
        {
            var subject = "Your MyFileIT Account Has Been Updated";

            var message = GetChangeAccountEmail(appUser);

            string error = "";
            return EmailHelper.SendEmailAsync(appUser.EMAILADDRESS, new List<string>(), new List<string>(), subject, message, true, new List<string>(), ref error);
        }

        private static string GetChangeAccountEmail(APPUSER appUser)
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("<p>Dear " + appUser.FIRSTNAME + " " + appUser.LASTNAME + "</p>");
            result.AppendLine("<p>You have you have made changes to your Myfileit account. If this not true please notify us at</p>");
            result.AppendLine("<p>" + MyFileItEmailLink + "</p>");

            return result.ToString();
        }

        public static bool SendRejectDocumentEmail(APPUSER appUser, TEAMEVENT teamEvent)
        {
            var subject = "MyFileIT Incorrect Document";
            string error = "";

            return EmailHelper.SendEmailAsync(appUser.EMAILADDRESS, new List<string>(), new List<string>(), subject, CreateRejectDocumentEmail(appUser, teamEvent), true, new List<string>(), ref error);
        }

        private static string CreateRejectDocumentEmail(APPUSER appUser, TEAMEVENT teamEvent)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine("<h2>" + teamEvent.ORGANIZATION.NAME + "</h2>");
            result.AppendLine("<h3>" + teamEvent.NAME + "</h3>");
            result.AppendLine("<hr/>");
            result.AppendLine("<p>" + appUser.FIRSTNAME + " " + appUser.LASTNAME + ",</p>");
            result.AppendLine("<p>The document you associated with <strong>" + teamEvent.NAME + "</strong> for the above team event is not sufficient or is incorrect.</p>");
            result.AppendLine("<p>Please log in to your MyFileIT account and associate a different document.");
            result.AppendLine("<p>" + MyFileItEmailLink + "</p>");

            return result.ToString();
        }
        public static bool SendAssociateUserToOrganizationEmail(string emailAddress, string subject, string body, List<string> ccEmailAddresses)
        {
            string error = "";
            if (ccEmailAddresses == null)
            {
                ccEmailAddresses = new List<string>();
            }

            return EmailHelper.SendEmailAsync(emailAddress, ccEmailAddresses, new List<string>(), subject, body, true, new List<string>(), ref error);
        }


        public static bool SendAssociateUserToOrganizationEmail(APPUSER appUser, ORGANIZATION organization, string appUserTypeName)
        {
            var subject = "MyFileIT - Your user has been added to " + organization.NAME;
            string error = "";

            return EmailHelper.SendEmailAsync(appUser.EMAILADDRESS, new List<string>(), new List<string>(), subject, CreateAssociateUserToOrganizationEmail(appUser, organization, appUserTypeName), true, new List<string>(), ref error);
        }

        private static string CreateAssociateUserToOrganizationEmail(APPUSER appUser, ORGANIZATION organization, string appUserTypeName)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine("Add the assocation text here.");
            return result.ToString();
        }

        public static bool SendEmergencyShareEmail(APPUSER appUser, string emergencyEmailAddress, string emailMessage, List<FILECABINETDOCUMENT> documents, List<SHAREDOCUMENT> shares)
        {
            var subject = "MyFileIT Emergency Share";

            var message = GetEmergencyShareEmail(appUser, emergencyEmailAddress, emailMessage, documents, shares);

            string error = "";
            return EmailHelper.SendEmail(emergencyEmailAddress, new List<string>() { appUser.EMAILADDRESS }, new List<string>(), subject, message, true, new List<string>(), ref error);
        }

        private static string GetEmergencyShareEmail(APPUSER appUser, string emergencyEmailAddress, string emailMessage, List<FILECABINETDOCUMENT> documents, List<SHAREDOCUMENT> shares)
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("<p>To: " + emergencyEmailAddress + "</p>");

            result.AppendLine("<p>" + appUser.FIRSTNAME + " " + appUser.LASTNAME + "  has shared the following documents with you. Please press on following click and view and verify or go Myfileit portal and review.</p>");

            shares.ToList().ForEach(s =>
            {
                var document = documents.Single(d => d.ID == s.FILECABINETDOCUMENTID);
                result.AppendLine("<p>" + document.DOCUMENTTYPE.NAME + "</br>" + document.COMMENT + "<br/>" + "<a href=\"" + ViewDocumentLink + "?g=" + s.VIEWDOCUMENTKEY + "\">" + "Click to view" + "</a>" + "</p>");
            });

            result.AppendLine("<p>" + emailMessage + "</p>");

            result.AppendLine("<p>Please note that once you click the link and view the document, the emergency share will be removed and access will be denied.</p>");
            return result.ToString();
        }

        public static bool SendShareReminderEmail(APPUSER appUser, ORGANIZATION organization, TEAMEVENT teamEvent)
        {
            var bccList = new List<string>(){
                "josifchin75@gmail.com",
                "sbutcher@binaryresearch.com"
            };
            //appUser.EMAILADDRESS = "sbutcher@binaryresearch.com";

            var subject = "MyFileIT - Message from " + organization.NAME;
            string error = "";

            return EmailHelper.SendEmailAsync(appUser.EMAILADDRESS, new List<string>(), bccList, subject, CreateShareReminderEmail(organization, teamEvent), true, new List<string>(), ref error);
        }

        private static string CreateShareReminderEmail(ORGANIZATION organization, TEAMEVENT teamEvent)
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("<p>Friendly Reminder,</p>");
            result.AppendLine("<p>" + organization.NAME + " sent out paperwork for " + teamEvent.NAME + " by either email or will be sending them home with your child. These documents need to be filled out and sent back via " + organization.NAME + " MyFile-IT EventDoc Box as soon as possible.</p>");
            result.AppendLine("<p>You can do this by logging in to MyFile-IT APP and (SNAP) taking a picture of the filled-out documents and saving them (SAVE). Then (SHARE) share the documents with the organization’s event.  We know you’re busy but if you could take 5 minutes and share these documents with us, we would appreciate it. If you have any questions, please contact " + organization.CONTACTPERSON + "</p>");

            return result.ToString();
            /*
             Friendly Reminder,

            <Organization> sent out paperwork for <event name> by either email or will be sending them home with your child. These documents need to be filled out and sent back via <organization> MyFile-IT EventDoc Box as soon as possible.

            You can do this by logging in to MyFile-IT APP and (SNAP) taking a picture of the filled-out documents and saving them (SAVE). Then (SHARE) share the documents with the organization’s event.  We know you’re busy but if you could take 5 minutes and share these documents with us, we would appreciate it. If you have any questions, please contact <assigned person to the event> */
        }

        public static bool SendMonthlyReminderEmail(APPUSER appUser, ORGANIZATION organization, int emailSelectionNumber)
        {
            var bccList = new List<string>(){
                "josifchin75@gmail.com",
                "sbutcher@binaryresearch.com"
            };
            //appUser.EMAILADDRESS = "josifchin75@gmail.com";

            var subject = "MyFileIT PE - Message from " + organization.NAME;
            string error = "";
            string html = "";
            switch (emailSelectionNumber)
            {
                case 1:
                    html = CreateMonthlyReminderEmail1();
                    break;
                case 2:
                    html = CreateMonthlyReminderEmail2();
                    break;
            }

            return EmailHelper.SendEmailAsync(appUser.EMAILADDRESS, new List<string>(), bccList, subject, html, true, new List<string>(), ref error);
        }

        private static string CreateMonthlyReminderEmail1()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("<p>Thank you creating a MyFile-IT  account.</p>");
            result.AppendLine("<p>We noticed that you have not started to protect yourself. We hope you start soon.</p>");
            CreateReminderChecklistText(result);

            return result.ToString();
        }

        private static string CreateMonthlyReminderEmail2()
        {
            var result = new System.Text.StringBuilder();

            result.AppendLine("<p>Today we see so much in the news of what happens to people’s personal property in a disaster. It is so tragic! In 2014, there is 32.2 million victims from natural disasters. Most the time you cannot stop it, but you can be prepared to protect yourself. The problem is that most of us do not. For example; in Hurricane “Sandy” & “Katrina”, thousands of people lost many of their important documents. In most cases, FEMA and other agencies can’t do that much for you, unless you have certain documents like; insurance forms, local, state and federal tax returns, mortgage information, and financial information. Since you lost the information, you will have to go and hope you can get copies of your paperwork.  This can take a lot of time. These agents and insurance companies might be able to give some emergency help but until you provide the information, they need to see if you qualify for assistance.  But we still do very little to protect ourselves. We think that it will never happen to me. Well it does!</p>");
            result.AppendLine("<p>I have been through two nationally declared (Clinton, G Bush) floods from a small creek outside of Philadelphia in which one of the storms, we received more than 8 inches of rain in two hours. We had more than 4 feet of water in my home and in my office building. With a wife and four kids, it was a nightmare getting help and providing all the right documents. This was one of the reasons we decided to create this App.</p>");
            result.AppendLine("<p>Kristina W, Philadelphia, says “It’s a great app. I use it all the time for my personal expenses. It also gives me a feeling that I am prepared for a disaster.”</p>");
            result.AppendLine("<p>Rachael M, Ambler, “This App is easy to use and keeps all my documents safe and easy to access.”</p>");

            CreateReminderChecklistText(result);

            return result.ToString();
        }

        private static void CreateReminderChecklistText(System.Text.StringBuilder result)
        {
            result.AppendLine("<p>Here is helpful checklist of some documents you should protect in case of disaster:</p>");

            result.AppendLine("<ol>");
            result.AppendLine("<li>Take pictures of each room where you are living.</li>");
            result.AppendLine("<li>If you have personal property that is worth more than $1000, take separate picture.</li>");
            result.AppendLine("<li>Local, State, Federal Taxes for last 7 years</li>");
            result.AppendLine("<li>Insurance policy</li>");
            result.AppendLine("<li>Mortgage information including a Deed</li>");
            result.AppendLine("<li>Driver license, Car registration, car title, Passport, Certification, other licenses</li>");
            result.AppendLine("<li>Equipment Warranties</li>");
            result.AppendLine("<li>If you rent, get the Lease information.</li>");
            result.AppendLine("<li>Your Will and other legal documents.</li>");
            result.AppendLine("<li>Medical History Information, and medication.</li>");
            result.AppendLine("</ol>");

            result.AppendLine("<p>Best regards</p>");
            result.AppendLine("<p>Sandy</p>");
        }


        public static bool SendReferralSignupEmail(REFERRAL referral)
        {
            var subject = "MyFileIT PE Direct Ambassador Sign up";
            string error = "";

            return EmailHelper.SendEmailAsync(referral.EMAILADDRESS, new List<string>(), new List<string>(), subject, CreateReferralSignupEmail(referral), true, new List<string>(), ref error);
        }

        private static string CreateReferralSignupEmail(REFERRAL referral)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine(referral.FIRSTNAME + ",");
            result.AppendLine("<p>Thank You for signing up for the MyFile-IT PE Direct Ambassador Program.</p>");
            result.AppendLine("<p>Here is your Rewards Code:</p>");
            result.AppendLine("<h3>" + referral.REFERRALCODE + "</h3>");
            result.AppendLine("<p>This will allow you to give the Rewards Code to anybody, so they can receive a 10% discount for the first year on MyFile-IT PE Subscription Key. You will also earn " + string.Format("{0:C}", referral.DISCOUNTAMOUNT) + "each time someone purchased MyFile-IT PE Subscription Key and the user uses your Rewards Code.</p>");
            result.AppendLine("<p>If this was sent to you by mistake, please forward this email to sales@myfileit.com with a message 'Please Remove'.</p>");
            result.AppendLine("<p>Thank You</p>");
            result.AppendLine("<p>MyFile-IT Team</p>");
            return result.ToString();
        }

        public static bool SendReferralUsedEmail(REFERRAL referral, APPUSER appUser)
        {
            var subject = "MyFileIT PE Direct Ambassador";
            string error = "";

            return EmailHelper.SendEmailAsync(referral.EMAILADDRESS, new List<string>(), new List<string>(), subject, CreateReferralUsedEmail(referral, appUser), true, new List<string>(), ref error);
        }

        private static string CreateReferralUsedEmail(REFERRAL referral, APPUSER appUser)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine("<p>" + appUser.FIRSTNAME + " " + appUser.LASTNAME + " has just purchased MyFile-IT PE subscription. You have earned " + string.Format("{0:C}", referral.DISCOUNTAMOUNT) + ". Payment will be per terms Direct Ambassador Agreement. You must go to your Direct Ambassador Account and add your banking information.</p>");
            result.AppendLine(@"<p>Click here: <a href=""https://www.myfileit.com/DirectLogin.aspx"">https://www.myfileit.com/DirectLogin.aspx</a></p>");
            result.AppendLine("<p>GREAT JOB!</p>");
            result.AppendLine("<p></p>");
            result.AppendLine("<p>Thank You</p>");
            result.AppendLine("<p>MyFile-IT Team</p>");
            return result.ToString();
        }

        /************************************************************/

        public static bool SendEmailAsync(string emailAddress, List<string> ccEmails, List<string> bccEmails, string subject, string body, bool html, List<string> attachmentsFullPath, ref string error)
        {
            Task.Factory.StartNew(() =>
                {
                    string innerError = "";
                    return MyFileItPEService.Helpers.EmailHelper.SendEmail(
                              emailAddress,
                              ccEmails,
                              bccEmails,
                              subject,
                              body,
                              html,
                              attachmentsFullPath,
                              ref innerError
                              );
                });
            return true;
        }

        public static bool SendEmail(string emailAddress, List<string> ccEmails, List<string> bccEmails, string subject, string body, bool html, List<string> attachmentsFullPath, ref string error)
        {
            var result = false;
            //  SmtpClient objSMTPClient;
            //MailMessage objCustomerEmail;

            try
            {
                var objCustomerEmail = new MailMessage();
                //Works also
                var objSMTPClient = new SmtpClient(ConfigurationSettings.MailServer, ConfigurationSettings.MailPort);

                objSMTPClient.Credentials = new NetworkCredential(ConfigurationSettings.MailUser, ConfigurationSettings.MailPass);
                objCustomerEmail.From = new MailAddress(ConfigurationSettings.MailUser);
                objCustomerEmail.ReplyTo = new MailAddress(ConfigurationSettings.MailUser);
                objCustomerEmail.To.Add(new MailAddress(emailAddress));
                if (ccEmails.Any())
                {
                    ccEmails.ToList().ForEach(c => { objCustomerEmail.CC.Add(new MailAddress(c)); });
                }
                if (bccEmails.Any())
                {
                    bccEmails.ToList().ForEach(b => { objCustomerEmail.Bcc.Add(new MailAddress(b)); });
                }

                objCustomerEmail.Headers.Set("Return-Path", ConfigurationSettings.MailUser);
                objCustomerEmail.IsBodyHtml = html;
                objCustomerEmail.Subject = subject;
                objCustomerEmail.Body = body;

                if (attachmentsFullPath.Any())
                {
                    attachmentsFullPath.ToList().ForEach(a => { objCustomerEmail.Attachments.Add(new Attachment(a)); });
                }

                objSMTPClient.Send(objCustomerEmail);

                objSMTPClient = null;
                objCustomerEmail = null;

                result = true;

                //log the email in the db
                EmailHelper.Log(emailAddress, ccEmails, subject, body);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                ExceptionHelper.LogError(ex);
            }

            return result;
        }

        private static void Log(string emailAddress, List<string> ccEmails, string subject, string body)
        {
            using (var db = new MyFileItEntities())
            {
                var emailLogObject = new EMAILLOG()
                {
                    TOEMAILADDRESS = emailAddress,
                    SUBJECTLINE = subject,
                    MESSAGE = body,
                    DATECREATED = DateTime.Now
                };
                emailLogObject.SetNewID();
                db.EMAILLOGs.Add(emailLogObject);
                db.SaveChanges();

                ccEmails.ToList().ForEach(e =>
                {
                    var ccEmailLogObject = new EMAILLOG()
                    {
                        TOEMAILADDRESS = e,
                        SUBJECTLINE = subject,
                        MESSAGE = body,
                        DATECREATED = DateTime.Now
                    };
                    ccEmailLogObject.SetNewID();
                    db.EMAILLOGs.Add(ccEmailLogObject);
                    db.SaveChanges();
                });
            }
        }




    }
}