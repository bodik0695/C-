using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartHouse
{
    public class Menu
    {
        public IFridge Fridge { get; set; }
        public IHeater Heater { get; set; }
        public IFreezer Freezer { get; set; }
        public IAirConditioning AirConditioning { get; set; }
        public ITV TV { get; set; }
        public IMediaPlayer MediaPlayer { get; set; }
        public Menu()
        { }
        public Menu(IFridge fridge, IHeater heater, IFreezer freezer, IAirConditioning airConditioning, ITV tV, IMediaPlayer mediaPlayer)
        {
            Fridge = fridge;
            Heater = heater;
            Freezer = freezer;
            AirConditioning = airConditioning;
            TV = tV;
            MediaPlayer = mediaPlayer;
        }
        public virtual void ConsoleMenu()
        {
            DeviceCreator dc = new DeviceCreator();
            IDictionary<string, IDevice> AllDevices = new Dictionary<string, IDevice>();
            AllDevices.Add("Fridge", Fridge);
            AllDevices.Add("Freezer", Freezer);
            AllDevices.Add("Heater", Heater);
            AllDevices.Add("AirConditioning", AirConditioning);
            AllDevices.Add("TV", TV);
            AllDevices.Add("MediaPlayer", MediaPlayer);
            while (true)
            {

                Console.Clear();
                foreach (var name in AllDevices)
                {
                    Console.WriteLine("Устройство: " + name.Key + ". " + name.Value);
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");
                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    return;
                }
                if (commands[0].ToLower() == "mods" & commands.Length == 1)
                {
                    HelpByMode();
                }
                if (commands[0].ToLower() == "help" & commands.Length == 1)
                {
                    Help();
                }
                if (commands.Length != 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Неверный формат команды");
                    Console.WriteLine("Доступные команды: help");
                    Console.WriteLine("Доступные режимы: mods");
                    Console.WriteLine("Доступные названия устройств: Fridge<>, Freezer<>, Heater<>, AirConditioning<>, TV<>, MediaPlayer<>");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    continue;
                }
                if (commands[0].ToLower() == "add" && !AllDevices.ContainsKey(commands[1]))
                {
                    string regex = @"Fridge|Freezer|Heater|AirConditioning|TV|MediaPlayer\w*";
                    if (Regex.IsMatch(commands[1], regex))
                    {
                        if (commands[1].Contains("Fridge"))
                        {
                            AllDevices.Add(commands[1], dc.CreateFridge());
                        }
                        if (commands[1].Contains("Freezer"))
                        {
                            AllDevices.Add(commands[1], dc.CreateFreezer());
                        }
                        if (commands[1].Contains("Heater"))
                        {
                            AllDevices.Add(commands[1], dc.CreateHeater());
                        }
                        if (commands[1].Contains("AirConditioning"))
                        {
                            AllDevices.Add(commands[1], dc.CreateAirConditioning());
                        }
                        if (commands[1].Contains("TV"))
                        {
                            AllDevices.Add(commands[1], dc.CreateTV());
                        }
                        if (commands[1].Contains("MediaPlayer"))
                        {
                            AllDevices.Add(commands[1], dc.CreateMediaPlayer());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невозможно добавить устройство с таким именем");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                    }
                    continue;
                }
                if (commands[0].ToLower() == "add" && AllDevices.ContainsKey(commands[1]))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    continue;
                }
                if (AllDevices.ContainsKey(commands[1]))
                {
                    switch (commands[0].ToLower())
                    {
                        case "on":
                            AllDevices[commands[1]].On();
                            break;
                        case "off":
                            AllDevices[commands[1]].Off();
                            break;
                        case "del":
                            AllDevices.Remove(commands[1]);
                            break;
                        case "incr_t":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Fridge.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IFridge device = (IFridge)AllDevices[commands[1]];
                                    device.IncreaseTemperature();
                                }
                                else if (Heater.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IHeater device = (IHeater)AllDevices[commands[1]];
                                    device.IncreaseTemperature();
                                }
                                else if (AirConditioning.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IAirConditioning device = (IAirConditioning)AllDevices[commands[1]];
                                    device.IncreaseTemperature();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "decr_t":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Fridge.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IFridge device = (IFridge)AllDevices[commands[1]];
                                    device.DecreaseTemperature();
                                }
                                else if (Heater.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IHeater device = (IHeater)AllDevices[commands[1]];
                                    device.DecreaseTemperature();
                                }
                                else if (AirConditioning.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IAirConditioning device = (IAirConditioning)AllDevices[commands[1]];
                                    device.DecreaseTemperature();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "incr_s":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV device = (ITV)AllDevices[commands[1]];
                                    device.IncreaseSound();
                                }
                                else if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.IncreaseSound();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "decr_s":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV device = (ITV)AllDevices[commands[1]];
                                    device.DecreaseSound();
                                }
                                else if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.DecreaseSound();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "s_off":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV device = (ITV)AllDevices[commands[1]];
                                    device.SoundOff();
                                }
                                else if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.SoundOff();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "s_on":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV device = (ITV)AllDevices[commands[1]];
                                    device.SoundOn();
                                }
                                else if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.SoundOn();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "next_c":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV device = (ITV)AllDevices[commands[1]];
                                    device.NextChannel();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "prev_c":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV device = (ITV)AllDevices[commands[1]];
                                    device.PreviousChannel();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "sel_c":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (TV.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    ITV tv = (ITV)AllDevices[commands[1]];
                                    Console.WriteLine("Введите номер канала: ");
                                    int temp;
                                    Int32.TryParse(Console.ReadLine(), out temp);
                                    if (temp <= tv.Channel.MaxChannelNumber && temp >= tv.Channel.MaxChannelNumber)
                                    {
                                        tv.SelectChannel(temp);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "next_t":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer mp = (IMediaPlayer)AllDevices[commands[1]];
                                    mp.NextTrack();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "prev_t":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.PreviousTrack();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "sel_t":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    Console.WriteLine("Введите название аудиотрека: ");
                                    string s = Console.ReadLine();
                                    if (device.SelectTrack(s)) { }
                                    else
                                    {
                                        Console.WriteLine("Нет диска или трек не найден");
                                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "play":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.Play();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "pause":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.Pause();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "stop":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.Stop();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "extr_disc":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    device.ExtractDisc();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "ins_disc":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (MediaPlayer.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IMediaPlayer device = (IMediaPlayer)AllDevices[commands[1]];
                                    if (device.DiscPresence == false)
                                    {
                                        List<string> numbers = new List<string>();
                                        Console.WriteLine("Введите название диска");
                                        string diskName = Console.ReadLine();
                                        Console.WriteLine("Введите треки для диска, когда будет введено название последнего напишите \"end\"");
                                        while (Console.ReadLine() != "end")
                                        {
                                            numbers.Add(Console.ReadLine());
                                        }
                                        string[] trac = numbers.ToArray<string>();
                                        trac[trac.Length - 1] = null;
                                        device.InsertDisc(new Disc(diskName, trac));
                                    }
                                    else
                                    {
                                        Console.WriteLine("для начала вытащите из устройства текущий диск");
                                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                                        Console.ReadKey();
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ml_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Fridge.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IFridge device = (IFridge)AllDevices[commands[1]];
                                    device.SetManualMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_nl_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Fridge.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IFridge device = (IFridge)AllDevices[commands[1]];
                                    device.SetNormalMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_wm_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Fridge.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IFridge device = (IFridge)AllDevices[commands[1]];
                                    device.SetWarmMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_lt_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Fridge.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IFridge device = (IFridge)AllDevices[commands[1]];
                                    device.SetLowTemperatureMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ff_m":
                            if (Freezer.GetType() == AllDevices[commands[1]].GetType())
                            {
                                IFreezer device = (IFreezer)AllDevices[commands[1]];
                                if (device.PresenceFridge)
                                {
                                    IFridge device1 = (IFridge)AllDevices[device.CurrentFridge];
                                    if (device1.Power)
                                    {
                                        device.SetFastFreezeMode();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Сначала включите холодильник");
                                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Для переключения режима морозильная камера должна быть подключена к холодильнику");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                }
                            }

                            break;
                        case "set_fg_m":
                            if (Freezer.GetType() == AllDevices[commands[1]].GetType())
                            {
                                IFreezer device = (IFreezer)AllDevices[commands[1]];
                                if (device.PresenceFridge)
                                {
                                    IFridge device1 = (IFridge)AllDevices[device.CurrentFridge];
                                    if (device1.Power)
                                    {
                                        device.SetFreezingMode();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Сначала включите холодильник");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Для переключения режима морозильная камера должна быть подключена к холодильнику");
                                }
                            }
                            break;
                        case "set_st_m":
                            if (Freezer.GetType() == AllDevices[commands[1]].GetType())
                            {
                                IFreezer device = (IFreezer)AllDevices[commands[1]];
                                if (device.PresenceFridge)
                                {
                                    IFridge device1 = (IFridge)AllDevices[device.CurrentFridge];
                                    if (device1.Power)
                                    {
                                        device.SetStorageMode();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Сначала включите холодильник");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Для переключения режима морозильная камера должна быть подключена к холодильнику");
                                }
                            }
                            break;
                        case "set_ir_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Heater.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IHeater device = (IHeater)AllDevices[commands[1]];
                                    device.SetModeInRoom();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_os_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (Heater.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IHeater device = (IHeater)AllDevices[commands[1]];
                                    device.SetModeOnStreet();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_cl_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (AirConditioning.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IAirConditioning device = (IAirConditioning)AllDevices[commands[1]];
                                    device.SetModeCooling();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ht_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (AirConditioning.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IAirConditioning device = (IAirConditioning)AllDevices[commands[1]];
                                    device.SetModeHeating();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_vt_m":
                            if (AllDevices[commands[1]].Power == true)
                            {
                                if (AirConditioning.GetType() == AllDevices[commands[1]].GetType())
                                {
                                    IAirConditioning device = (IAirConditioning)AllDevices[commands[1]];
                                    device.SetModeVentilation();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала включите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "con_f":
                            Console.WriteLine("Введите название холодильника к которому хотите подключить морозильную камеру");
                            string fridgeName = Console.ReadLine();
                            IFridge newF = (IFridge)AllDevices[fridgeName];
                            if (newF.PresenceFreezer)
                            {
                                Console.WriteLine("К данному холодильнику уже подключена морозильная камера камера: " + newF.CurrentFreezerName);
                            }
                            else
                            {
                                IFreezer newFz = (IFreezer)AllDevices[commands[1]];
                                newF.ConnectFreezer(commands[1]);
                                newFz.ConnectFridge(fridgeName);
                            }

                            break;
                        case "dis_f":
                            Console.WriteLine("Введите название холодильника от которого хотите отключить морозильную камеру");
                            string fridgeName1 = Console.ReadLine();
                            IFridge newFg = (IFridge)AllDevices[fridgeName1];
                            IFreezer newFrz = (IFreezer)AllDevices[commands[1]];
                            newFg.DisableFreezer(commands[1]);
                            newFrz.DisableFrifge(fridgeName1);
                            break;
                        default:
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Нет устройства с таким именем или неправильный формат команды");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
            }
        }
        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tДобавить новое устройство: add <nameDevice>");
            Console.WriteLine("\tУдалить устройство: del <nameDevice>");
            Console.WriteLine("\tВключить устройство: on <nameDevice>");
            Console.WriteLine("\tВыключить устройство: off <nameDevice>");
            Console.WriteLine("\tПовысить температуру на 1С (Применимо только для: Fridge, Heater или AirConditioning): decr_t <nameDevice>");
            Console.WriteLine("\tУменьшить температуру на 1С (Применимо только для: Fridge, Heater или AirConditioning): incr_t <nameDevice>");
            Console.WriteLine("\tУвеличить громкость (Применимо только для: TV, MediaPlayer): incr_s <nameDevice>");
            Console.WriteLine("\tУменьшить громкость (Применимо только для: TV, MediaPlayer): decr_s <nameDevice>");
            Console.WriteLine("\tВыключить звук (Применимо только для: TV, MediaPlayer): s_on <nameDevice>");
            Console.WriteLine("\tВключить звук (Применимо только для: TV, MediaPlayer): s_off <nameDevice>");
            Console.WriteLine("\tСледующий канал (Применимо только для: TV): next_c <nameDevice>");
            Console.WriteLine("\tПредыдущий канал (Применимо только для: TV): prev_c <nameDevice>");
            Console.WriteLine("\tВыбрать канал (Применимо только для: TV): sel_c <nameDevice>");
            Console.WriteLine("\tСледующий трек (Применимо только для: MediaPlayer): next_t <nameDevice>");
            Console.WriteLine("\tПредыдущий трек (Применимо только для: MediaPlayer): prev_t <nameDevice>");
            Console.WriteLine("\tВыбрать трек (Применимо только для: MediaPlayer): sel_t <nameDevice>");
            Console.WriteLine("\tВставить диск (Применимо только для: MediaPlayer): ins_disc <nameDevice>");
            Console.WriteLine("\tВытащить диск (Применимо только для: MediaPlayer): extr_disc <nameDevice>");
            Console.WriteLine("\tПоставить на паузу (Применимо только для: MediaPlayer): pause <nameDevice>");
            Console.WriteLine("\tОстановить проигрывание трека (Применимо только для: MediaPlayer): stop <nameDevice>");
            Console.WriteLine("\tПродолжить воспроизведение трека (Применимо только для: MediaPlayer): play <nameDevice>");
            Console.WriteLine("\tПодключить морозильную камеру к холодильнику (Применимо только для: Freezer): con_f <nameDevice>");
            Console.WriteLine("\tОтключить морозильную камеру от холодильника (Применимо только для: Freezer): dis_f <nameDevice>");
            Console.WriteLine("\tВыйти из программы: exit");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
        }
        private static void HelpByMode()
        {
            Console.WriteLine();
            Console.WriteLine("Доступные режимы:");
            Console.WriteLine("\tДля холодильника:");
            Console.WriteLine("\t   пользовательский: set_ml_m <nameDevice>");
            Console.WriteLine("\t   нормальный: set_nl_m <nameDevice>");
            Console.WriteLine("\t   теплый: set_wm_m <nameDevice>");
            Console.WriteLine("\t   низких температур: set_lt_m <nameDevice>");
            Console.WriteLine("\tДля морозильной камеры:");
            Console.WriteLine("\t   быстрая заморозка: set_ff_m <nameDevice>");
            Console.WriteLine("\t   заморозка: set_fg_m <nameDevice>");
            Console.WriteLine("\t   хранение: set_st_m <nameDevice>");
            Console.WriteLine("\tДля обогревателя:");
            Console.WriteLine("\t   в помещении: set_ir_m <nameDevice>");
            Console.WriteLine("\t   на улие: set_os_m <nameDevice>");
            Console.WriteLine("\tДля кондиионера:");
            Console.WriteLine("\t   охлаждение: set_cl_m <nameDevice>");
            Console.WriteLine("\t   обогрев: set_ht_m <nameDevice>");
            Console.WriteLine("\t   вентиляция: set_vt_m <nameDevice>");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
    }
}