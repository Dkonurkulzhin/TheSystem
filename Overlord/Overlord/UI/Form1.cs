using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overlord
{
    public partial class Form1 : Form
    {
        //SQL server
        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        // доступность сервера.  
        public StockControlForm stockControlForm;
        public TelegramSettingsForm telegramSettingsForm;
        public StoreForm storeForm;
        public ProductManagmentForm productManagementForm;
        public CashBoxControlForm cashboxControlForm;
        public CashBoxSettingsForm cashboxSettingsForm;
        public AuthorityCheckForm authorityCheckForm;
        public MachineConfigForm pcConfigForm;
        public AddTimeDialog addTimeDialog;
        public ConsoleSettingsForm consoleSettingsForm;
        public UserSearchForm userSearchForm;
        public UpdateSettingsForm updateSettingsForm;
        public UserConfigForm userConfigForm;
        public AddUserCashForm addUserCashForm;
        private int ViewType = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int LoadMachines()
        {

            return 0;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (storeForm != null)
                storeForm.Close();
            storeForm = new StoreForm();
            storeForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StatusRefreshTimer.Tick += StatusRefreshTimer_Tick;
            StatusRefreshTimer.Start();

            if (!GlobalVars.debug)
                ConfigureAdminRights(GlobalVars.Authority);

            UpdatePCList();
            MachineManager.SaveMachines();
            InitUIElements();


        }

        private void InitUIElements()
        {

            freePCImg.Image = GlobalVars.FreePCimg;
            ReservedPCImg.Image = GlobalVars.ReservedPCimg;
            EnabledPCImg.Image = GlobalVars.OKPCimg;

        }

        public void UpdatePCList(int viewtype = 0)
        {
            listView1.Items.Clear();

            listView1.LargeImageList = GlobalVars.newMachineStatImageList(64);
            listView1.StateImageList = GlobalVars.newMachineStatImageList(16);
            listView1.SmallImageList = GlobalVars.newMachineStatImageList(16);

            switch (viewtype)
            {
                case 0:
                    listView1.View = View.Details;
                    ViewTypeLabel.Text = "Таблица";
                    break;
                case 1:
                    listView1.View = View.SmallIcon;
                    ViewTypeLabel.Text = "Малые значки";
                    break;
                case 2:
                    listView1.View = View.Tile;
                    ViewTypeLabel.Text = "Плитки";
                    break;
                case 3:
                    listView1.View = View.LargeIcon;
                    ViewTypeLabel.Text = "Большие значки";
                    break;
                default:
                    break;

            }
            ViewBar.Value = viewtype;
            ViewType = viewtype;
            listView1.Sorting = SortOrder.None;
            listView1.FullRowSelect = true;

            foreach (string group in GlobalVars.Settings.MacineGroups)
            {
                ListViewGroup machineGroup = new ListViewGroup();
                machineGroup.Header = group;
                machineGroup.Name = group;
                listView1.Groups.Add(machineGroup);
            }
            listView1.ShowGroups = true;

            int freePCs = 0; int enabledPCs = 0; int reservedPcs = 0;
            foreach (Machine machine in MachineManager.Machines)
            {
                ListViewItem machineItem = new ListViewItem((viewtype != 0) ? machine.label : (machine.index + 1).ToString(), 0);
                if (machine != null)
                {
                    // machine.status = MachineManager.MachineStatus.Ready;
                    if (viewtype != 2)
                        machineItem.SubItems.Add(machine.label);
                    ListViewItem.ListViewSubItem stat = new ListViewItem.ListViewSubItem();
                    stat.BackColor = Color.Green;
                    stat.Text = MachineManager.StatusLabels[machine.status];
                    //stat.Text = ;
                    machineItem.SubItems.Add(stat); // MachineManager.StatusLabels[machine.status]);

                    machineItem.SubItems.Add(machine.username);

                    string machineViewTime = ((machine.status == MachineManager.MachineStatus.Busy) ?
                        machine.time.ToString() : "").ToString();
                    machineItem.SubItems.Add((viewtype == 2) ? "время: " + machineViewTime : machineViewTime);

                    string machineViewBalance = ((machine.status == MachineManager.MachineStatus.Busy) ?
                        machine.balance.ToString() : "").ToString();
                    machineItem.SubItems.Add((viewtype == 2) ? "баланс: " + machineViewBalance : machineViewBalance);

                    if (machine.status == MachineManager.MachineStatus.Ready || machine.status == MachineManager.MachineStatus.Disabled)
                        freePCs++;
                    if (machine.status != MachineManager.MachineStatus.Unavailable)
                        enabledPCs++;
                    if (machine.status == MachineManager.MachineStatus.Reserved)
                        reservedPcs++;

                }
                else
                {
                    foreach (var r in listView1.Columns)
                        machineItem.SubItems.Add("error");
                }
                foreach (ListViewGroup group in listView1.Groups)
                {
                    if (machine.group == group.Header)
                        machineItem.Group = group;

                }
                machineItem.ImageKey = machine.status.ToString();
                listView1.Items.Add(machineItem);
                FreePCLabel.Text = "Свободных: " + freePCs.ToString();
                EnabledPCLabel.Text = "Исправных: " + enabledPCs.ToString() + "/" + GlobalVars.Settings.PC_amount.ToString();
                ReservedPCLabel.Text = "В резерве: " + reservedPcs.ToString();
                // listView1.Columns.Add();
                //  dataGridView1.Rows.Add(machine.index.ToString());
            }
            GC.Collect();
        }

        private void StatusRefreshTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "В касссе: " + FinancialManager.GetCashString();
            UpdatePCList(ViewType);
            //throw new NotImplementedException();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void добавлениеПродуктовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productManagementForm != null)
                productManagementForm.Close();
            productManagementForm = new ProductManagmentForm();
            productManagementForm.Show();
        }

        private void настройкиTelegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (telegramSettingsForm != null)
                telegramSettingsForm.Close();
            telegramSettingsForm = new TelegramSettingsForm();
            telegramSettingsForm.Show();
        }

        private void контрольЗапасовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stockControlForm != null)
                stockControlForm.Close();
            stockControlForm = new StockControlForm();
            stockControlForm.Show();
        }

        private void снятиеКассыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cashboxControlForm != null)
                cashboxControlForm.Close();
            cashboxControlForm = new CashBoxControlForm();
            cashboxControlForm.Show();
        }

        private void настройкиКассыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cashboxSettingsForm != null)
                cashboxSettingsForm.Close();
            cashboxSettingsForm = new CashBoxSettingsForm();
            cashboxSettingsForm.Show();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pcConfigForm != null)
                pcConfigForm.Close();
            pcConfigForm = new MachineConfigForm();
            pcConfigForm.Show();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Закрыть программу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void ConfigureAdminRights(bool authority)
        {
            GlobalVars.Authority = authority;

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem subItem in GetItems(item))
                    {


                        foreach (string name in GlobalVars.Settings.AuthorityMenuItems)
                        {
                            if (subItem.Text == name)
                            {
                                subItem.Enabled = authority;

                                Console.WriteLine(subItem.Text + " " + authority.ToString());
                            }
                        }

                    }
                }
            }
        }

        private IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
        {
            foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
            {
                if (dropDownItem.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem subItem in GetItems(dropDownItem))
                        yield return subItem;
                }
                yield return dropDownItem;
            }
        }

        private void выйтиИхПодАдминаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigureAdminRights(false);
        }

        private void войтиПодАдминомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalVars.Authority)
            {
                MessageBox.Show("Права уже активированы");
            }
            else
            {
                if (authorityCheckForm != null)
                    authorityCheckForm.Close();
                authorityCheckForm = new AuthorityCheckForm();
                authorityCheckForm.Show();
            }
        }

        private void ConsoleControlButton_Click(object sender, EventArgs e)
        {
            if (!Program.consoleForm.Visible)
                Program.consoleForm.Show();
            else
                Program.consoleForm.Hide();
        }

        private void настройкиКонсолейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consoleSettingsForm != null)
                consoleSettingsForm.Close();
            consoleSettingsForm = new ConsoleSettingsForm();
            consoleSettingsForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.ShowGroups = checkBox1.Checked;
        }

        private void ViewBar_Scroll(object sender, EventArgs e)
        {
            UpdatePCList(ViewBar.Value);
        }

        private void MachineContexMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (sender == null)
                    return;
                if (listView1.SelectedItems != null)
                {
                    MachineContexMenu.Items.Clear();
                    List<int> indexes = new List<int>();

                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        indexes.Add(item.Index);
                    }
                    ToolStripItem placeUserItem = MachineContexMenu.Items.Add("Добавить пользователя");
                    placeUserItem.Click += new EventHandler((Sender, E) => SearchUser(sender, e, listView1.SelectedItems[0].Index));

                    ToolStripItem addTimeItem = MachineContexMenu.Items.Add("Добавть время");
                    addTimeItem.Click += new EventHandler((Sender, E) => ShowMachineAddDialog(sender, e, indexes, true));
                    addTimeItem.Enabled = false;

                    ToolStripItem addGuestSession = MachineContexMenu.Items.Add("Гостевая сессия");
                    addGuestSession.Click += new EventHandler((Sender, E) => (new AddUserCashForm(new User("Guest")) ).Show());

                    ToolStripItem addCashItem = MachineContexMenu.Items.Add("Добавть средства");
                    addCashItem.Click += new EventHandler((Sender, E) => ShowMachineAddDialog(sender, e, indexes, false));

                    ToolStripItem EndSession = MachineContexMenu.Items.Add("Завершить сессию");
                    EndSession.Click += new EventHandler((Sender, E) => MachineManager.EndSession(sender, e, indexes));

                    ToolStripItem ReserveMachine;
                    bool selectionIsReserved = false;
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        if (MachineManager.Machines[item.Index].status == MachineManager.MachineStatus.Reserved)
                            selectionIsReserved = true;

                    }
                    if (!selectionIsReserved)
                    {
                        ReserveMachine = MachineContexMenu.Items.Add("Забронировать");
                        ReserveMachine.Click += new EventHandler((Sender, E) => MachineManager.ReserveMachines(sender, e, indexes));
                    }
                    else
                    {
                        ReserveMachine = MachineContexMenu.Items.Add("Снять бронь");
                        ReserveMachine.Click += new EventHandler((Sender, E) => MachineManager.UnReserveMachines(sender, e, indexes));
                    }

                    ToolStripItem SwitchMachineCondition;
                    if (listView1.SelectedItems.Count <= 1)
                    {
                        SwitchMachineCondition = MachineContexMenu.Items.Add("Активировать/деактивировать");
                        Console.Write(listView1.SelectedItems[0].Index.ToString());
                        SwitchMachineCondition.Click += new EventHandler((Sender, E) => MachineManager.SwitchUnavailable(sender, e, listView1.SelectedItems[0].Index));
                    }

                    MachineContexMenu.Show(listView1, new Point(e.X, e.Y));
                }

            }

        }

        public void SearchUser(object sender, EventArgs e, int machineIndex)
        {
            if (listView1.SelectedItems != null)
            {
                userSearchForm = new UserSearchForm(machineIndex);
                userSearchForm.TopMost = true;
                userSearchForm.Show();
            }
        }

        public void ShowMachineAddDialog(object sender, EventArgs e, List<int> indexes, bool setTime = true)
        {
            List<Machine> machines = new List<Machine>();
            foreach (Machine machine in MachineManager.Machines)
            {
                if (indexes.Contains(machine.index))
                    machines.Add(machine);

            }

            foreach (Machine machine in machines)
            {
                if (machine.group != machines.First().group)
                {
                    MessageBox.Show("Можно выбирать компьютеры только одной группы!");
                    return;
                }
            }
            if (addTimeDialog != null)
                addTimeDialog.Close();
            addTimeDialog = new AddTimeDialog(machines, setTime);
            addTimeDialog.TopMost = true;
            addTimeDialog.Show();

        }



        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listView1.SelectedItems != null)
            {
                List<int> selectedindex = new List<int>();
                selectedindex.Add(listView1.SelectedItems[0].Index);
                ShowMachineAddDialog(sender, e, selectedindex, true);
            }
        }


        public bool ShowYesNoDialog(string text, string header = "Вы уверены?")
        {
            switch (MessageBox.Show(text, header, MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return false;
            }
        }

        public void ShowError(string text, string header = "Ошибка")
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cashboxControlForm != null)
                cashboxControlForm.Close();
            cashboxControlForm = new CashBoxControlForm();
            cashboxControlForm.Show();
        }

        private void EnabledPCImg_Click(object sender, EventArgs e)
        {

        }

        private void EnabledPCLabel_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (cashboxControlForm != null)
                cashboxControlForm.Close();
            cashboxControlForm = new CashBoxControlForm();
            cashboxControlForm.Show();
        }

        private void обновлениеКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (updateSettingsForm != null)
                updateSettingsForm.Close();
            updateSettingsForm = new UpdateSettingsForm();
            updateSettingsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userConfigForm != null)
                userConfigForm.Close();
            userConfigForm = new UserConfigForm();
            userConfigForm.Show();

        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.Show();
        }

        private void AddCashButton_Click(object sender, EventArgs e)
        {
            if (addUserCashForm != null)
                addUserCashForm.Close();
            addUserCashForm = new AddUserCashForm();
            addUserCashForm.Show();
        }
    }

     
}
