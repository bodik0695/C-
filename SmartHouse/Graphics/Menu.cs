using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartHouse
{
    public static class Menu
    {
        public static void ConsoleMenu()
        {
            IDictionary<string, Device> allDevices = new Dictionary<string, Device>();
            IDictionary<string, Disc> allDisc = new Dictionary<string, Disc>();
            allDevices.Add("Fridge1", new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()));
            allDevices.Add("Freezer1", new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode()));
            allDevices.Add("Heater1", new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()));
            allDevices.Add("AirConditioning1", new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()));
            allDevices.Add("TV1", new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)));
            allDevices.Add("MediaPlayer1", new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()));
            string[] tracks = new string[] { "one", "two", "thre" };
            Disc disc = new Disc("Пробный", tracks);
            MediaPlayer m = (MediaPlayer)allDevices["MediaPlayer1"];
            m.InsertDisc(disc);
            Display d = new Display();

            while (true)
            {
                Console.Clear();
                foreach (var name in allDevices)
                {
                    Console.WriteLine("Устройство: " + name.Key + ". " + d.ShowSpecificationDevice(allDevices[name.Key]));
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
                if (commands[0].ToLower() == "add" && !allDevices.ContainsKey(commands[1]))
                {
                    string regex = @"Fridge|Freezer|Heater|AirConditioning|TV|MediaPlayer\w*";
                    if (Regex.IsMatch(commands[1], regex))
                    {
                        if (commands[1].Contains("Fridge"))
                        {
                            allDevices.Add(commands[1], new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()));
                        }
                        if (commands[1].Contains("Freezer"))
                        {
                            allDevices.Add(commands[1], new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode()));
                        }
                        if (commands[1].Contains("Heater"))
                        {
                            allDevices.Add(commands[1], new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()));
                        }
                        if (commands[1].Contains("AirConditioning"))
                        {
                            allDevices.Add(commands[1], new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()));
                        }
                        if (commands[1].Contains("TV"))
                        {
                            allDevices.Add(commands[1], new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)));
                        }
                        if (commands[1].Contains("MediaPlayer"))
                        {
                            allDevices.Add(commands[1], new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()));
                            MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                            mp.InsertDisc(disc);
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
                if (commands[0].ToLower() == "add" && allDevices.ContainsKey(commands[1]))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    continue;
                }
                if (allDevices.ContainsKey(commands[1]))
                {
                    switch (commands[0].ToLower())
                    {
                        case "on":
                            allDevices[commands[1]].On();
                            break;
                        case "off":
                            allDevices[commands[1]].Off();
                            break;
                        case "del":
                            allDevices.Remove(commands[1]);
                            break;
                        case "incr_t":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Fridge f = (Fridge)allDevices[commands[1]];
                                    f.IncreaseTemperature();
                                }
                                else if (new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Heater h = (Heater)allDevices[commands[1]];
                                    h.IncreaseTemperature();
                                }
                                else if (new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    AirConditioning a = (AirConditioning)allDevices[commands[1]];
                                    a.IncreaseTemperature();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "decr_t":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Fridge f = (Fridge)allDevices[commands[1]];
                                    f.DecreaseTemperature();
                                }
                                else if (new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Heater h = (Heater)allDevices[commands[1]];
                                    h.DecreaseTemperature();
                                }
                                else if (new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    AirConditioning a = (AirConditioning)allDevices[commands[1]];
                                    a.DecreaseTemperature();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "incr_s":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    t.IncreaseSound();
                                }
                                else if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.IncreaseSound();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "decr_s":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    t.DecreaseSound();
                                }
                                else if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.DecreaseSound();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "s_off":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    t.SoundOff();
                                }
                                else if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.SoundOff();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "s_on":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    t.SoundOn();
                                }
                                else if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.SoundOn();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "next_c":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    t.NextChannel();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "prev_c":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    t.PreviousChannel();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "sel_c":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType() == allDevices[commands[1]].GetType())
                                {
                                    TV t = (TV)allDevices[commands[1]];
                                    Console.WriteLine("Введите номер канала: ");
                                    int temp;
                                    Int32.TryParse(Console.ReadLine(), out temp);
                                    if (temp <= t.Channel.MaxChannelNumber && temp >= t.Channel.MaxChannelNumber)
                                    {
                                        t.SelectChannel(temp);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "next_t":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.NextTrack();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "prev_t":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.PreviousTrack();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "sel_t":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    Console.WriteLine("Введите название аудиотрека: ");
                                    string s = Console.ReadLine();
                                    if (mp.SelectTrack(s)) { }
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
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "play":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.Play();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "pause":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.Pause();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "stop":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.Stop();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "extr_disc":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    mp.ExtractDisc();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "ins_disc":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {

                                    MediaPlayer mp = (MediaPlayer)allDevices[commands[1]];
                                    if (mp.DiscPresence == false)
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
                                        mp.InsertDisc(allDisc[diskName]);
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
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ml_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Fridge f = (Fridge)allDevices[commands[1]];
                                    f.SetManualMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_nl_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Fridge f = (Fridge)allDevices[commands[1]];
                                    f.SetNormalMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_wm_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Fridge f = (Fridge)allDevices[commands[1]];
                                    f.SetWarmMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_lt_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Fridge f = (Fridge)allDevices[commands[1]];
                                    f.SetLowTemperatureMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ff_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Freezer f = (Freezer)allDevices[commands[1]];
                                    f.SetFastFreezeMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_fg_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Freezer f = (Freezer)allDevices[commands[1]];
                                    f.SetFreezingMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_st_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Freezer f = (Freezer)allDevices[commands[1]];
                                    f.SetStorageMode();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ir_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Heater f = (Heater)allDevices[commands[1]];
                                    f.SetModeInRoom();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_os_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    Heater f = (Heater)allDevices[commands[1]];
                                    f.SetModeOnStreet();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_cl_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    AirConditioning f = (AirConditioning)allDevices[commands[1]];
                                    f.SetModeCooling();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_ht_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    AirConditioning f = (AirConditioning)allDevices[commands[1]];
                                    f.SetModeHeating();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            break;
                        case "set_vt_m":
                            if (allDevices[commands[1]].Power == true)
                            {
                                if (new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()).GetType() == allDevices[commands[1]].GetType())
                                {
                                    AirConditioning f = (AirConditioning)allDevices[commands[1]];
                                    f.SetModeVentilation();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сначала вксючите устройство");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
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