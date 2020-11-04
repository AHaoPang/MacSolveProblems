using System;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class EventLearn : IProblem
    {
        public void RunProblem()
        {
            #region Test1

            var m = new MailManager();

            new Fax(m, 1);
            new Fax(m, 2);
            new Fax(m, 3);

            try
            {
                m.SimulateNewMail("from", "to", "subject");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            var cl = new ConsoleLogger();

            Logger.Instance.AddMsg(100, "200");

            Console.WriteLine("end");
        }

        public delegate void MySelf<T>(T t);

        private class Logger
        {
            public static Logger Instance { get; } = new Logger();
            private Logger() { }

            public event EventHandler<LoggerEventArgs> Log;

            //public event MySelf<int> AnotherMsg;

            public void AddMsg(int priority, string msg)
                => Log?.Invoke(this, new LoggerEventArgs(priority, msg));
        }

        private class LoggerEventArgs
        {
            public LoggerEventArgs(int priority, string msg)
            {
                Priority = priority;
                Msg = msg;
            }

            public int Priority { get; }
            public string Msg { get; }
        }

        private class ConsoleLogger
        {
            public ConsoleLogger()
            {
                Logger.Instance.Log +=
                    (sender, msg) => Console.WriteLine($"From ConsoleLogger:{msg.Priority}_{msg.Msg}");

                //Logger.Instance.AnotherMsg +=
                //    i => Console.WriteLine($"int num:{i}");
            }
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

        public Fax(MailManager mm, int id)
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
