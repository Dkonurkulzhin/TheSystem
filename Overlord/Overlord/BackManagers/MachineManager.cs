using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Overlord
{
    public static class MachineManager
    {
        public enum MachineStatus { Ready = 0, Busy = 1, Offline = 2, Disabled = 3, Reserved = 4, Unavailable = 5 };

        public static Machine[] Machines = new Machine[GlobalVars.Settings.PC_amount];
        private static System.Timers.Timer[] StatUpdateTimers = new System.Timers.Timer[GlobalVars.Settings.PC_amount];
        private static System.Timers.Timer MachineSaveTimer = new System.Timers.Timer(20000); //сохраняем состояние машин раз в 20 секунд
        private static Dictionary<MachineManager.MachineStatus, string> statusLabels = new Dictionary<MachineManager.MachineStatus, string>() {
            {MachineManager.MachineStatus.Ready, "свободен" },
            {MachineManager.MachineStatus.Busy, "занят"},
            {MachineManager.MachineStatus.Reserved,  "забронирован"},
            {MachineManager.MachineStatus.Disabled,  "отключен"},
            {MachineManager.MachineStatus.Unavailable,  "неисправен"},
            {MachineManager.MachineStatus.Offline,  "вне сети" }
        };

        public static Dictionary<string, int> GroupMultiplier;

        public static Dictionary<MachineStatus, string> StatusLabels
        {
            get
            {
                return statusLabels;
            }

            set
            {
                statusLabels = value;
            }
        }

        public static void Initialize()
        {
            LoadMachines();
            for (int i = 0; i < GlobalVars.Settings.PC_amount; i++)
            {
                UpdateStatTimer(i);
            }
            MachineSaveTimer.AutoReset = true;
            MachineSaveTimer.Elapsed += SaveMachinesOnTimer;  
            MachineSaveTimer.Start();
        }

        public static void SaveMachinesOnTimer(object sender, ElapsedEventArgs e)
        {
            SaveMachines();
        }

        public static bool LogInUser(int machineID, User user)
        {

            if (user.balance <= 0)
                return false;
            ClientCommunicationManager.SendUserObject(user, Machines[machineID].IP);
            return true;
        }

        public static void RefreshSession(int machineID, User user, int addBalance = 0)
        {
            user.balance += addBalance;
            ClientCommunicationManager.SendUserObject(user, Machines[machineID].IP);
        }

        public static void LogInGuest(int machineID, int balance)
        {
            User guest = new User("Guest");
            guest.balance = balance;
            ClientCommunicationManager.SendUserObject(guest, Machines[machineID].IP);
        }


        public static void WakeUpMachines(List<int> machineIDs)
        {
            foreach (int machineID in machineIDs)
            {
                string machineMAC = Machines[machineID].MAC_ADDRESS;
                if (machineMAC != null && machineMAC != "")
                    ClientCommunicationManager.SendWakeUpPacket(machineMAC);
            }
        }

        public static void LoadMachines() {
            
            for (int i = 0; i < GlobalVars.Settings.PC_amount; i++)
            {
                Machines[i] = XMLManager.DeserializeMachine(i);
                if (Machines[i] == null)
                    Machines[i] = ShowErrorMachine(); 
            }
           
        }

        public static void SaveMachines()
        {
            for (int i = 0; i < GlobalVars.Settings.PC_amount; i++)
            {
                XMLManager.SerializeMachines(Machines[i]);
            }
        }

        public static void InitMachines()
        {
            for (int i = 0; i < GlobalVars.Settings.PC_amount; i++)
            {
                Machines[i] = new Machine();
                Machines[i].index = i;
                Machines[i].status = MachineManager.MachineStatus.Disabled;
                Machines[i].label = "PC" + (i + 1).ToString();
            }

            SaveMachines();
        }

        public static void AddMachine(int prevIndex, int newIndex)
        {
            Machines = new Machine[GlobalVars.Settings.PC_amount];
            if (newIndex > prevIndex)
            {
                for (int i = prevIndex; i < newIndex; i++)
                {
                    Machine machineToAdd = XMLManager.DeserializeMachine(i);
                    if (machineToAdd == null)
                    {
                        machineToAdd = new Machine();
                        machineToAdd.index = i;
                        machineToAdd.status = MachineStatus.Disabled;
                        if (machineToAdd.label == null)
                            machineToAdd.label = "PC" + (i + 1).ToString();
                        SaveMachine(machineToAdd);
                    }
                }
                LoadMachines();
            }
            else if (newIndex == prevIndex)
                return;
            else
            {
                LoadMachines();
            }
            
        }

        public static void SaveMachine(Machine machine)
        {
            XMLManager.SerializeMachines(machine);
        }

        private static Machine ShowErrorMachine()
        {
            Machine machine = new Machine();
            machine.label = "not found";
            return machine;
        }

        public static void AddBalance()
        {

        }

        public static void EndSession(object sender, EventArgs e, List<int> ids)
        {
            if (ids.Count >= 3)
            {
                string pcs = "";
                foreach (int id in ids)
                {
                    pcs += id.ToString() + ", ";
                }
                if (!Program.MainForm.ShowYesNoDialog("Завершить сессию на компьютерах: " + pcs.Substring(0, pcs.Length - 2) + "?"))
                    return;
            }
            foreach(int id in ids)
            { 
                ClientCommunicationManager.SendForceLogOutCommand(Machines[id]);
            }
        }

        public static void ReserveMachines(object sender, EventArgs e, List<int> ids)
        {
            foreach (Machine machine in Machines)
            {
                if (ids.Contains(machine.index))
                {
                    if (machine.status == MachineStatus.Busy || machine.status == MachineStatus.Unavailable)
                    {
                        Program.MainForm.ShowError("Невозможно зарезервировать занятый или неисправный компьютер");

                    }
                    else
                    {
                        machine.status = MachineStatus.Reserved;
                        SaveMachine(machine);
                    }
                }

            }
            Program.MainForm.UpdatePCList();
        }

        public static void UnReserveMachines(object sender, EventArgs e, List<int> ids)
        {
            foreach (Machine machine in Machines)
            {
                if (ids.Contains(machine.index) && machine.status == MachineStatus.Reserved)
                {
                    machine.status = MachineStatus.Ready;
                    SaveMachine(machine);
                }

            }
            Program.MainForm.UpdatePCList();
        }

        public static void SwitchUnavailable(object sender, EventArgs e, int id)
        {
            foreach (Machine machine in Machines)
            {
                if (machine.index == id)
                {
                    if (machine.status != MachineStatus.Unavailable)
                    {
                        machine.status = MachineStatus.Unavailable;
                        SaveMachine(machine);
                

                    }
                    else
                    {
                        machine.status = MachineStatus.Ready;
                        SaveMachine(machine);
                     
                       
                    } 

                }

            }
            Program.MainForm.UpdatePCList();
        }
        public static void AddTimeMultiple(object Sender, EventArgs E, List<int> machineIDs)
        {
            //string selectedMachines = "";
            //foreach (int i in machineIDs)
            //    selectedMachines += (i+1).ToString() +", ";
            //if (machineIDs.Count >= 3)
            //    if (Program.MainForm.ShowYesNoDialog("Добавить время на выбранные компьютеры: "
            //        + selectedMachines.Substring(0, selectedMachines.Length - 1) + "?"))
            //        Console.WriteLine();


            //    switch (Program.MainForm.ShowDialog("Добавить время на выбранные компьютеры: "                    //MessageBox.Show("Добавить время на выбранные компьютеры: "
            //                + selectedMachines.Substring(0, selectedMachines.Length - 1)
            //                + "?", "Confirmation", MessageBoxButtons.YesNo))
            //    {
            //        case DialogResult.Yes:
            //            addTimeItem.Click += new EventHandler((Sender, E) => MachineManager.AddTimeMultiple(sender, e, indexes));
            //            break;
            //        case DialogResult.No:
            //            break;
            //    }
        }

       

        public static void GotEchoPacket(MachineStatMessage message, string ip)
        {
            //int index, string ip, bool isOccupied, string username, long balance, long minutesLeft, long clientVersion, string MachineMAC
            int index = message.Index;

            if (index <= Machines.Length)
            {
                //if (Machines[index - 1].status == MachineStatus.Disabled)
                    ClientCommunicationManager.SendConfiguration(Machines[index - 1]);
                Machines[index - 1].status = message.IsOccupied ? MachineStatus.Busy : MachineStatus.Ready;
                Machines[index - 1].IP = ip;
                Machines[index - 1].CleintVersion = message.ClientVersion;
                if (message.Username == null || message.Username == "")
                {
                    return;
                }
                User userToUpdate;

                Machines[index - 1].username = message.Username;
                Machines[index - 1].balance = message.Balance;
                Machines[index - 1].time = message.MinutesLeft;
                if (message.Username != "Guest")
                {
                    userToUpdate = UserManager.GetUserByName(message.Username);
                    userToUpdate.balance = message.Balance;
                    //userToUpdate.exp = 
                    Machines[index - 1].user = userToUpdate;
                    UserManager.AddActiveUser(userToUpdate);
                    UserManager.SaveUser(userToUpdate);
                }
                else
                {
                    Machines[index - 1].user = new User("Guest");
                    Machines[index - 1].user.balance = message.Balance;
                }
                UpdateStatTimer(index-1);

            }

        }

        public static void OnStatTimerElapsed(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer timer = sender as System.Timers.Timer;
            int index = Array.IndexOf(StatUpdateTimers, timer);
            if (index <= Machines.Length && index >= 0)
            {
                Machines[index].status = MachineStatus.Disabled;
                Machines[index].IP = "";
                Machines[index].username = "";
                Machines[index].balance = 0;
                Machines[index].time = 0;
                Machines[index].user = null;
            }
            UserManager.VerifyActiveUserList(GetAllUsersOnMachine());
            timer.Dispose();
        }

        public static List<User> GetAllUsersOnMachine()
        {
            List<User> usersOnMachines = new List<User>();
            foreach (Machine machine in Machines)
            {
                if (machine.user != null)
                    usersOnMachines.Add(machine.user);
            }
            return usersOnMachines;
        }

        public static void UpdateStatTimer(int index)
        {
            StatUpdateTimers[index] = new System.Timers.Timer(12000);
            StatUpdateTimers[index].Elapsed += OnStatTimerElapsed;
            StatUpdateTimers[index].Start();
        }

        public static void OnMachineLogOut(int machineIndex)
        {

        }

    }
}
