using System;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class EventLearn : IProblem
    {
        public void RunProblem()
        {
            var m = new MailManager();

            new Fax(m, 1);
            new Fax(m, 2);
            new Fax(m, 3);

            try
            {
                m.SimulateNewMail("from", "to", "subject");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("end");
        }
    }

    public sealed class NewMailEventArgs : EventArgs
    {
        private readonly string m_from, m_to, m_subject;

        public NewMailEventArgs(string from, string to, string subject)
        {
            m_from = from;
            m_to = to;
            m_subject = subject;
        }

        public string From => m_from;
        public string To => m_to;
        public string Subject => m_subject;
    }

    public class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;
        //public event EventHandler Mail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            Volatile.Read(ref NewMail)?.Invoke(this, e);
        }

        public void SimulateNewMail(string from, string to, string subject)
        {
            var e = new NewMailEventArgs(from, to, subject);

            Task.Run(() => OnNewMail(e));
        }
    }

    public class Fax
    {
        private int m_id;

        public Fax(MailManager mm,int id)
        {
            m_id = id;
            mm.NewMail += FaxMsg;
        }

        public void FaxMsg(object sender, NewMailEventArgs e)
        {
            //if (m_id == 2) throw new Exception("just say something");

            Console.WriteLine($"{m_id}_{e.From}_{e.To}_{e.Subject}");
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}
