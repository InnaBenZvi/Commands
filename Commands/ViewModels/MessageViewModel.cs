using Commands.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace Commands.ViewModels
{
    public class MessageViewModel
    {
        public string MessageText { get; set; }
        public MessageCommand DisplayMessageCommand { get; private set; } 
        public MessageCommandWithParam DisplayMessageCommandWithParam { get; private set; } 

        public ObservableCollection<string> MyMessages { get; private set; }
        public RelayCommand MessageBoxCommand { get; private set; }
        public RelayCommand ConsoleLogCommand { get; private set; }

        public MessageViewModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMessage);
            DisplayMessageCommandWithParam = new MessageCommandWithParam(DisplayMessageWithParam);

            MyMessages = new ObservableCollection<String>()
            {
                "Hello World",
                "My name is Inna",
                "I love learning commands",
                "I am a message box",
                "I am a console",
            };
            MessageBoxCommand = new RelayCommand(DisplayInMessageBox, MessageBoxCanUse);
            ConsoleLogCommand = new RelayCommand(DisplayInConsole, ConsoleCanUse);
        }

        public void DisplayMessage()
        {
            MessageBox.Show(MessageText);
        }

        public void DisplayMessageWithParam(string msg)
        {
            MessageBox.Show(msg);
        }

        public void DisplayInMessageBox(object message)
        {
            MessageBox.Show((string)message);
        }

        public void DisplayInConsole(object message)
        {
            Console.WriteLine((string)message);
        }

        public bool MessageBoxCanUse(object message)
        {
            if ((string)message == "I am a console")
                return false;
            return true;
        }

        public bool ConsoleCanUse(object message)
        {
            if ((string)message == "I am a message box")
                return false;
            return true;
        }

    }
}
