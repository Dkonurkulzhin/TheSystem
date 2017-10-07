namespace Overlord
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ActiveUserListLabel = new System.Windows.Forms.Label();
            this.ReservedPCLabel = new System.Windows.Forms.Label();
            this.ReservedPCImg = new System.Windows.Forms.PictureBox();
            this.EnabledPCLabel = new System.Windows.Forms.Label();
            this.EnabledPCImg = new System.Windows.Forms.PictureBox();
            this.FreePCLabel = new System.Windows.Forms.Label();
            this.freePCImg = new System.Windows.Forms.PictureBox();
            this.ViewTypeLabel = new System.Windows.Forms.Label();
            this.ViewBar = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cashbox = new System.Windows.Forms.ToolStripMenuItem();
            this.снятиеКассыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиКассыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компьютерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновлениеКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеПродуктовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрольЗапасовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администрированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.войтиПодАдминомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИхПодАдминаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнительноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиTelegramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиКонсолейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.MachineContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.ProductButton = new System.Windows.Forms.Button();
            this.ConsoleControlButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddCashButton = new System.Windows.Forms.Button();
            this.NewUserButton = new System.Windows.Forms.Button();
            this.проверитьОбновленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReservedPCImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnabledPCImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freePCImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(123, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 564);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ActiveUserListLabel);
            this.tabPage1.Controls.Add(this.ReservedPCLabel);
            this.tabPage1.Controls.Add(this.ReservedPCImg);
            this.tabPage1.Controls.Add(this.EnabledPCLabel);
            this.tabPage1.Controls.Add(this.EnabledPCImg);
            this.tabPage1.Controls.Add(this.FreePCLabel);
            this.tabPage1.Controls.Add(this.freePCImg);
            this.tabPage1.Controls.Add(this.ViewTypeLabel);
            this.tabPage1.Controls.Add(this.ViewBar);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Таблица";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ActiveUserListLabel
            // 
            this.ActiveUserListLabel.Location = new System.Drawing.Point(573, 7);
            this.ActiveUserListLabel.Name = "ActiveUserListLabel";
            this.ActiveUserListLabel.Size = new System.Drawing.Size(120, 155);
            this.ActiveUserListLabel.TabIndex = 10;
            this.ActiveUserListLabel.Text = "Текущие пользователи:";
            // 
            // ReservedPCLabel
            // 
            this.ReservedPCLabel.AutoSize = true;
            this.ReservedPCLabel.Location = new System.Drawing.Point(588, 470);
            this.ReservedPCLabel.Name = "ReservedPCLabel";
            this.ReservedPCLabel.Size = new System.Drawing.Size(62, 13);
            this.ReservedPCLabel.TabIndex = 9;
            this.ReservedPCLabel.Text = "В резерве:";
            // 
            // ReservedPCImg
            // 
            this.ReservedPCImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ReservedPCImg.Location = new System.Drawing.Point(572, 468);
            this.ReservedPCImg.Name = "ReservedPCImg";
            this.ReservedPCImg.Size = new System.Drawing.Size(16, 16);
            this.ReservedPCImg.TabIndex = 8;
            this.ReservedPCImg.TabStop = false;
            // 
            // EnabledPCLabel
            // 
            this.EnabledPCLabel.AutoSize = true;
            this.EnabledPCLabel.Location = new System.Drawing.Point(588, 446);
            this.EnabledPCLabel.Name = "EnabledPCLabel";
            this.EnabledPCLabel.Size = new System.Drawing.Size(70, 13);
            this.EnabledPCLabel.TabIndex = 7;
            this.EnabledPCLabel.Text = "Исправных: ";
            this.EnabledPCLabel.Click += new System.EventHandler(this.EnabledPCLabel_Click);
            // 
            // EnabledPCImg
            // 
            this.EnabledPCImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EnabledPCImg.Location = new System.Drawing.Point(572, 444);
            this.EnabledPCImg.Name = "EnabledPCImg";
            this.EnabledPCImg.Size = new System.Drawing.Size(16, 16);
            this.EnabledPCImg.TabIndex = 6;
            this.EnabledPCImg.TabStop = false;
            this.EnabledPCImg.Click += new System.EventHandler(this.EnabledPCImg_Click);
            // 
            // FreePCLabel
            // 
            this.FreePCLabel.AutoSize = true;
            this.FreePCLabel.Location = new System.Drawing.Point(588, 422);
            this.FreePCLabel.Name = "FreePCLabel";
            this.FreePCLabel.Size = new System.Drawing.Size(66, 13);
            this.FreePCLabel.TabIndex = 5;
            this.FreePCLabel.Text = "Свободных:";
            // 
            // freePCImg
            // 
            this.freePCImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.freePCImg.Location = new System.Drawing.Point(572, 420);
            this.freePCImg.Name = "freePCImg";
            this.freePCImg.Size = new System.Drawing.Size(16, 16);
            this.freePCImg.TabIndex = 4;
            this.freePCImg.TabStop = false;
            // 
            // ViewTypeLabel
            // 
            this.ViewTypeLabel.AutoSize = true;
            this.ViewTypeLabel.Location = new System.Drawing.Point(202, 512);
            this.ViewTypeLabel.Name = "ViewTypeLabel";
            this.ViewTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.ViewTypeLabel.TabIndex = 3;
            this.ViewTypeLabel.Text = "Таблица";
            this.ViewTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewBar
            // 
            this.ViewBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ViewBar.LargeChange = 3;
            this.ViewBar.Location = new System.Drawing.Point(104, 508);
            this.ViewBar.Maximum = 3;
            this.ViewBar.Name = "ViewBar";
            this.ViewBar.Size = new System.Drawing.Size(103, 45);
            this.ViewBar.TabIndex = 2;
            this.ViewBar.Scroll += new System.EventHandler(this.ViewBar_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(7, 512);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Группировка";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.label,
            this.status,
            this.user,
            this.time,
            this.balance});
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(7, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(559, 506);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // id
            // 
            this.id.Text = "номер";
            // 
            // label
            // 
            this.label.Text = "компьютер";
            // 
            // status
            // 
            this.status.Text = "состояние";
            // 
            // user
            // 
            this.user.Text = "пользователь";
            // 
            // time
            // 
            this.time.Text = "время";
            // 
            // balance
            // 
            this.balance.Text = "баланс";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(699, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расположение";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cashbox,
            this.компьютерыToolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.продуктыToolStripMenuItem,
            this.администрированиеToolStripMenuItem,
            this.дополнительноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(826, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cashbox
            // 
            this.cashbox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.снятиеКассыToolStripMenuItem,
            this.настройкиКассыToolStripMenuItem});
            this.cashbox.Name = "cashbox";
            this.cashbox.Size = new System.Drawing.Size(50, 20);
            this.cashbox.Text = "Касса";
            this.cashbox.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // снятиеКассыToolStripMenuItem
            // 
            this.снятиеКассыToolStripMenuItem.Name = "снятиеКассыToolStripMenuItem";
            this.снятиеКассыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.снятиеКассыToolStripMenuItem.Text = "Контроль кассы";
            this.снятиеКассыToolStripMenuItem.Click += new System.EventHandler(this.снятиеКассыToolStripMenuItem_Click);
            // 
            // настройкиКассыToolStripMenuItem
            // 
            this.настройкиКассыToolStripMenuItem.Image = global::Overlord.Properties.Resources._lock;
            this.настройкиКассыToolStripMenuItem.Name = "настройкиКассыToolStripMenuItem";
            this.настройкиКассыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.настройкиКассыToolStripMenuItem.Text = "Настройки кассы";
            this.настройкиКассыToolStripMenuItem.Click += new System.EventHandler(this.настройкиКассыToolStripMenuItem_Click);
            // 
            // компьютерыToolStripMenuItem
            // 
            this.компьютерыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.статистикаToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.обновлениеКлиентовToolStripMenuItem});
            this.компьютерыToolStripMenuItem.Name = "компьютерыToolStripMenuItem";
            this.компьютерыToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.компьютерыToolStripMenuItem.Text = "Компьютеры";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Image = global::Overlord.Properties.Resources._lock;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.информацияToolStripMenuItem.Text = "Диагностика";
            // 
            // обновлениеКлиентовToolStripMenuItem
            // 
            this.обновлениеКлиентовToolStripMenuItem.Name = "обновлениеКлиентовToolStripMenuItem";
            this.обновлениеКлиентовToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.обновлениеКлиентовToolStripMenuItem.Text = "Обновление клиентов";
            this.обновлениеКлиентовToolStripMenuItem.Click += new System.EventHandler(this.обновлениеКлиентовToolStripMenuItem_Click);
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            // 
            // продуктыToolStripMenuItem
            // 
            this.продуктыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлениеПродуктовToolStripMenuItem,
            this.контрольЗапасовToolStripMenuItem});
            this.продуктыToolStripMenuItem.Name = "продуктыToolStripMenuItem";
            this.продуктыToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.продуктыToolStripMenuItem.Text = "Продукты";
            // 
            // добавлениеПродуктовToolStripMenuItem
            // 
            this.добавлениеПродуктовToolStripMenuItem.Image = global::Overlord.Properties.Resources._lock;
            this.добавлениеПродуктовToolStripMenuItem.Name = "добавлениеПродуктовToolStripMenuItem";
            this.добавлениеПродуктовToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.добавлениеПродуктовToolStripMenuItem.Text = "Добавление продуктов";
            this.добавлениеПродуктовToolStripMenuItem.Click += new System.EventHandler(this.добавлениеПродуктовToolStripMenuItem_Click);
            // 
            // контрольЗапасовToolStripMenuItem
            // 
            this.контрольЗапасовToolStripMenuItem.Name = "контрольЗапасовToolStripMenuItem";
            this.контрольЗапасовToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.контрольЗапасовToolStripMenuItem.Text = "Контроль Запасов";
            this.контрольЗапасовToolStripMenuItem.Click += new System.EventHandler(this.контрольЗапасовToolStripMenuItem_Click);
            // 
            // администрированиеToolStripMenuItem
            // 
            this.администрированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.войтиПодАдминомToolStripMenuItem,
            this.выйтиИхПодАдминаToolStripMenuItem});
            this.администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            this.администрированиеToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.администрированиеToolStripMenuItem.Text = "Администрирование";
            // 
            // войтиПодАдминомToolStripMenuItem
            // 
            this.войтиПодАдминомToolStripMenuItem.Name = "войтиПодАдминомToolStripMenuItem";
            this.войтиПодАдминомToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.войтиПодАдминомToolStripMenuItem.Text = "Войти под админом";
            this.войтиПодАдминомToolStripMenuItem.Click += new System.EventHandler(this.войтиПодАдминомToolStripMenuItem_Click);
            // 
            // выйтиИхПодАдминаToolStripMenuItem
            // 
            this.выйтиИхПодАдминаToolStripMenuItem.Name = "выйтиИхПодАдминаToolStripMenuItem";
            this.выйтиИхПодАдминаToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.выйтиИхПодАдминаToolStripMenuItem.Text = "Выйти из под админа";
            this.выйтиИхПодАдминаToolStripMenuItem.Click += new System.EventHandler(this.выйтиИхПодАдминаToolStripMenuItem_Click);
            // 
            // дополнительноToolStripMenuItem
            // 
            this.дополнительноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиTelegramToolStripMenuItem,
            this.настройкиКонсолейToolStripMenuItem,
            this.проверитьОбновленияToolStripMenuItem});
            this.дополнительноToolStripMenuItem.Name = "дополнительноToolStripMenuItem";
            this.дополнительноToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.дополнительноToolStripMenuItem.Text = "Дополнительно";
            // 
            // настройкиTelegramToolStripMenuItem
            // 
            this.настройкиTelegramToolStripMenuItem.Image = global::Overlord.Properties.Resources._lock;
            this.настройкиTelegramToolStripMenuItem.Name = "настройкиTelegramToolStripMenuItem";
            this.настройкиTelegramToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.настройкиTelegramToolStripMenuItem.Text = "Настройки Telegram";
            this.настройкиTelegramToolStripMenuItem.Click += new System.EventHandler(this.настройкиTelegramToolStripMenuItem_Click);
            // 
            // настройкиКонсолейToolStripMenuItem
            // 
            this.настройкиКонсолейToolStripMenuItem.Image = global::Overlord.Properties.Resources._lock;
            this.настройкиКонсолейToolStripMenuItem.Name = "настройкиКонсолейToolStripMenuItem";
            this.настройкиКонсолейToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.настройкиКонсолейToolStripMenuItem.Text = "Настройки консолей";
            this.настройкиКонсолейToolStripMenuItem.Click += new System.EventHandler(this.настройкиКонсолейToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(826, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel2.Text = "В кассе:";
            // 
            // StatusRefreshTimer
            // 
            this.StatusRefreshTimer.Interval = 10000;
            // 
            // MachineContexMenu
            // 
            this.MachineContexMenu.Name = "MachineContexMenu";
            this.MachineContexMenu.Size = new System.Drawing.Size(61, 4);
            this.MachineContexMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MachineContexMenu_Opening);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.ProductButton);
            this.panel1.Controls.Add(this.ConsoleControlButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(6, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 609);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Смены";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Касса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ползователи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Консоли";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Магазин";
            // 
            // button3
            // 
            this.button3.Image = global::Overlord.Properties.Resources.Users;
            this.button3.Location = new System.Drawing.Point(7, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 76);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ProductButton
            // 
            this.ProductButton.Image = global::Overlord.Properties.Resources.storeicon1;
            this.ProductButton.Location = new System.Drawing.Point(7, 8);
            this.ProductButton.Name = "ProductButton";
            this.ProductButton.Size = new System.Drawing.Size(94, 76);
            this.ProductButton.TabIndex = 1;
            this.ProductButton.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ProductButton.UseVisualStyleBackColor = true;
            this.ProductButton.Click += new System.EventHandler(this.ProductButton_Click);
            // 
            // ConsoleControlButton
            // 
            this.ConsoleControlButton.Image = global::Overlord.Properties.Resources.gamepad_icon_27;
            this.ConsoleControlButton.Location = new System.Drawing.Point(7, 110);
            this.ConsoleControlButton.Name = "ConsoleControlButton";
            this.ConsoleControlButton.Size = new System.Drawing.Size(94, 76);
            this.ConsoleControlButton.TabIndex = 6;
            this.ConsoleControlButton.UseVisualStyleBackColor = true;
            this.ConsoleControlButton.Click += new System.EventHandler(this.ConsoleControlButton_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Overlord.Properties.Resources.b72c832df92479ccc7bcb42c9faeb5af;
            this.button2.Location = new System.Drawing.Point(7, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 76);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Overlord.Properties.Resources.Ecommerce_Cash_Register_icon1;
            this.button1.Location = new System.Drawing.Point(7, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 76);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.AddCashButton);
            this.panel2.Controls.Add(this.NewUserButton);
            this.panel2.Location = new System.Drawing.Point(123, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 52);
            this.panel2.TabIndex = 10;
            // 
            // AddCashButton
            // 
            this.AddCashButton.Image = ((System.Drawing.Image)(resources.GetObject("AddCashButton.Image")));
            this.AddCashButton.Location = new System.Drawing.Point(60, 3);
            this.AddCashButton.Name = "AddCashButton";
            this.AddCashButton.Size = new System.Drawing.Size(44, 44);
            this.AddCashButton.TabIndex = 1;
            this.AddCashButton.UseVisualStyleBackColor = true;
            this.AddCashButton.Click += new System.EventHandler(this.AddCashButton_Click);
            // 
            // NewUserButton
            // 
            this.NewUserButton.Image = global::Overlord.Properties.Resources.adduser;
            this.NewUserButton.Location = new System.Drawing.Point(8, 3);
            this.NewUserButton.Name = "NewUserButton";
            this.NewUserButton.Size = new System.Drawing.Size(44, 44);
            this.NewUserButton.TabIndex = 0;
            this.NewUserButton.UseVisualStyleBackColor = true;
            this.NewUserButton.Click += new System.EventHandler(this.NewUserButton_Click);
            // 
            // проверитьОбновленияToolStripMenuItem
            // 
            this.проверитьОбновленияToolStripMenuItem.Name = "проверитьОбновленияToolStripMenuItem";
            this.проверитьОбновленияToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.проверитьОбновленияToolStripMenuItem.Text = "Проверить обновления";
            this.проверитьОбновленияToolStripMenuItem.Click += new System.EventHandler(this.проверитьОбновленияToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(826, 668);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReservedPCImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnabledPCImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freePCImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ProductButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cashbox;
        private System.Windows.Forms.ToolStripMenuItem снятиеКассыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиКассыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продуктыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеПродуктовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дополнительноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиTelegramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контрольЗапасовToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer StatusRefreshTimer;
        private System.Windows.Forms.Button ConsoleControlButton;
        private System.Windows.Forms.ToolStripMenuItem настройкиКонсолейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администрированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem войтиПодАдминомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиИхПодАдминаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компьютерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader label;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader user;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader balance;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TrackBar ViewBar;
        private System.Windows.Forms.Label ViewTypeLabel;
        private System.Windows.Forms.ContextMenuStrip MachineContexMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox freePCImg;
        private System.Windows.Forms.Label FreePCLabel;
        private System.Windows.Forms.Label ReservedPCLabel;
        private System.Windows.Forms.PictureBox ReservedPCImg;
        private System.Windows.Forms.Label EnabledPCLabel;
        private System.Windows.Forms.PictureBox EnabledPCImg;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновлениеКлиентовToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddCashButton;
        private System.Windows.Forms.Button NewUserButton;
        private System.Windows.Forms.Label ActiveUserListLabel;
        private System.Windows.Forms.ToolStripMenuItem проверитьОбновленияToolStripMenuItem;
    }
}

